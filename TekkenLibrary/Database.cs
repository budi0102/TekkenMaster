using System;
using System.Collections.Generic;
using System.Text;

namespace TekkenLibrary
{
    public class Database
    {
        public static Database Instance { get; private set; }

        static Database()
        {
            if (Instance == null)
            {
                Instance = new Database();
            }
        }

        public enum SerializeType
        {
            Text,
            JSON,
            XML,
            SQLite
        }

        public void Serialize(SerializeType serializeType)
        {

        }
    }
}
