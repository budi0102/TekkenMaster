using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;

namespace TekkenMaster.UWP.ViewModels
{
    public class MoveListItemViewModel : ViewModelBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Notation { get; set; }
        public string HitProperty { get; set; }
        public string Damage { get; set; }
        public string ActiveFrame { get; set; }
        public string OnBlock { get; set; }
        public string OnHit { get; set; }
        public string OnCounterHit { get; set; }
        public string Memo { get; set; }
    }
}
