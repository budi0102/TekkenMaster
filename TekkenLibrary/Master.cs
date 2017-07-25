using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        public void Load()
        {

        }

        #endregion
    }
}
