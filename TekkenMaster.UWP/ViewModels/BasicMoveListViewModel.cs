using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekkenMaster.UWP.ViewModels
{
    public class BasicMoveListViewModel : ViewModelBase
    {
        public MoveListItemViewModel MoveList { get; set; }
        public CharactersViewModel Characters { get; set; }
        public CharacterViewModel SelectedCharacter { get; set; }

        public ICommand LoadedCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; private set; }

        public BasicMoveListViewModel()
        {
            LoadedCommand = new DelegateCommand(Loaded_EventHandler);
            SelectionChangedCommand = new DelegateCommand(SelectionChanged_EventHandler);
        }

        private void Loaded_EventHandler()
        {
            Characters = new CharactersViewModel(TekkenLibrary.Master.Instance.Characters);
            SelectedCharacter = Characters[0];
        }

        private void SelectionChanged_EventHandler()
        {
        }
    }
}
