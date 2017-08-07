using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenMaster.UWP.ViewModels
{
    public class SpecialMoveListViewModel : ViewModelBase
    {
        public ObservableCollection<MoveListItemViewModel> SpecialMoveList { get; set; }

        public SpecialMoveListViewModel()
        {
            SpecialMoveList = new ObservableCollection<MoveListItemViewModel>()
            {
                new MoveListItemViewModel(){ Name="OneTwo"},
                new MoveListItemViewModel(){ Name="OneTwoThree"},
            };
        }
    }
}
