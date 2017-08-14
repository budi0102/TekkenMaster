using Prism.Events;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenMaster.UWP.ViewModels
{
    /// <summary>
    /// Characters Collection View Model
    /// </summary>
    public class CharactersViewModel : ObservableCollection<CharacterViewModel>
    {
        public CharactersViewModel()
            : base()
        {
        }

        public CharactersViewModel(IEnumerable<CharacterViewModel> collection)
            : base(collection)
        {
        }

        public CharactersViewModel(IEnumerable<TekkenLibrary.Model.Character> collection)
            : base()
        {
            foreach(var item in collection)
            {
                this.Add(new CharacterViewModel(item));
            }
        }
    }
}
