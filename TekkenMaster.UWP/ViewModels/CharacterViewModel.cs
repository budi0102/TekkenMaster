using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenMaster.UWP.ViewModels
{
    public class CharacterViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public string Image { get; set; }

    }
}
