using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TekkenLibrary.Model
{
    public class MoveList : ObservableCollection<Move>
    {
        #region Constructor
        public MoveList()
            : base()
        {
        }
        public MoveList(IEnumerable<Move> collection)
            : base(collection)
        {
        }
        #endregion
    }
}
