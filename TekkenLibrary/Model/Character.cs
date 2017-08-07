using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TekkenLibrary.Model
{
    public class Character
    {
        #region private fields
        #endregion

        #region Public Properties
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Introduction { get; set; }
        public string Description { get; set; }
        public ObservableCollection<MoveList> BasicMoveList { get; set; }
        public ObservableCollection<MoveList> SpecialMoveList { get; set; }
        public ObservableCollection<MoveList> TenHitMoveList { get; set; }
        public ObservableCollection<MoveList> ThrowMoveList { get; set; }
        public ObservableCollection<MoveList> ComboList { get; set; } 
        #endregion

        #region Constructor
        public Character()
        {
           
        }
        #endregion

        #region Methods
        #endregion
    }
}
