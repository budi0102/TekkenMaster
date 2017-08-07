using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TekkenLibrary.Model;

namespace TekkenLibrary
{
    public class Master
    {
        #region Static
        public static Master Instance { get; private set; }

        static Master()
        {
            Instance = new Master();
        }
        #endregion

        #region Public Property
        public string Owner { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        #endregion

        #region Constructor
        public Master()
        {
        }
        #endregion

        #region Methods
        public async Task LoadAsync()
        {
            await DB.LoadAllAsync(DB.DirectoryPath);
        }
        public async Task SaveAsync()
        {
            await DB.SaveAllAsync(DB.DirectoryPath, this);
        }

        #endregion
    }
}
