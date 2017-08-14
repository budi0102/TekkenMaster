using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TekkenLibrary.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TekkenLibrary
{
    public class DB
    {
        #region Public Properties
        public static readonly string DefaultDirectoryPath = "Tekken7";
        public static string DirectoryPath { get; set; }
        #endregion

        static DB()
        {
            DirectoryPath = DefaultDirectoryPath;
        }

        #region Methods
        public static async Task<Master> LoadAllAsync(string directoryPath)
        {
            bool isOK = await CreateDB();
            if(!isOK)
            {
                return null;
            }

            string[] filenames = Directory.GetFiles(directoryPath);
            Master result = new Master();
            result.Characters = new ObservableCollection<Character>();
            foreach (string file in filenames)
            {
                result.Characters.Add(await Task.Run(() => LoadCharacterAsync(file)));
            }
            return result;
        }
        public static async Task<Character> LoadCharacterAsync(string filePath)
        {
            Character result = null;
            using (_reader = File.OpenText(filePath))
            {
                try
                {
                    string line = await _reader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(line))
                    {
                        TryDeserializeJson(line, out result);
                    }
                }
                catch (IOException e)
                {
                }
            }
            return result;
        }
        public static async Task SaveAllAsync(string directoryPath, Master master)
        {
            bool isOK = await CreateDB();
            if (!isOK)
            {
                return;
            }

            foreach (Character character in master.Characters)
            {
                await Task.Run(() => SaveCharacter(character));
            }
        }
        public static async Task SaveCharacter(Character character)
        {
            if (character == null)
            {
                return;
            }
            string filepath = character.Name + ".json";

            using (_writer = File.CreateText(filepath))
            {
                await _writer.WriteAsync(SerializeJson(character));
            }
        }


        public static async Task<bool> CreateDB()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                catch (IOException)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Serialization
        public static string SerializeJson(Character character)
        {
            return JsonConvert.SerializeObject(character);
        }

        public static Character DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject<Character>(json);
        }
        public static bool TryDeserializeJson(string json, out Character character)
        {
            bool result = false;
            character = null;
            try
            {
                character = JsonConvert.DeserializeObject<Character>(json);
                result = true;
            }
            catch (JsonException e)
            {
                Debug.WriteLine(e.ToString());
            }
            return result;
        }
        #endregion

        private static StreamReader _reader;
        private static StreamWriter _writer;
    }
}
