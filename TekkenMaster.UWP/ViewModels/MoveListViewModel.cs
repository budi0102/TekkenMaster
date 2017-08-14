using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenMaster.UWP.ViewModels
{
    public class MoveListViewModel : ObservableCollection<MoveListItemViewModel>
    {
        public MoveListViewModel()
            : base()
        {
        }

        public MoveListViewModel(IEnumerable<MoveListItemViewModel> collection)
            : base(collection)
        {
        }

        public MoveListViewModel(TekkenLibrary.Model.MoveList collection)
            : this(collection.Cast<TekkenLibrary.Model.Move>())
        {
        }

        public MoveListViewModel(IEnumerable<TekkenLibrary.Model.Move> collection)
            : base()
        {
            foreach(var item in collection)
            {
                Add(new MoveListItemViewModel(item));
            }
        }
    }
}
