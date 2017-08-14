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
    public class CharactersPageViewModel : ViewModelBase
    {
        #region Static members
        public static ObservableCollection<CharacterViewModel> StaticCharacters { get; private set; }
        #endregion

        public ObservableCollection<CharacterViewModel> Characters
        {
            get
            {
                return _characters;
            }
            set
            {
                SetProperty(ref _characters, value);
            }
        }
        private ObservableCollection<CharacterViewModel> _characters;

        public CharactersPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService, IResourceLoader resourceLoader, ISessionStateService sessionStateService)
        {
            if (StaticCharacters == null)
            {
                List<CharacterViewModel> characters = new List<CharacterViewModel>();
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Gouki"), FullName = resourceLoader.GetString("Gouki"), ShortName = resourceLoader.GetString("Gouki") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Kazumi"), FullName = resourceLoader.GetString("KazumiHachijo"), ShortName = resourceLoader.GetString("Kazumi") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Law"), FullName = resourceLoader.GetString("MarshallLaw"), ShortName = resourceLoader.GetString("Law") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Paul"), FullName = resourceLoader.GetString("PaulPhoenix"), ShortName = resourceLoader.GetString("Paul") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Heihachi"), FullName = resourceLoader.GetString("HeihachiMishima"), ShortName = resourceLoader.GetString("Heihachi") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Kazuya"), FullName = resourceLoader.GetString("KazuyaMishima"), ShortName = resourceLoader.GetString("Kazuya") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Eliza"), FullName = resourceLoader.GetString("Eliza"), ShortName = resourceLoader.GetString("Eliza") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Kuma"), FullName = resourceLoader.GetString("Kuma"), ShortName = resourceLoader.GetString("Kuma") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Panda"), FullName = resourceLoader.GetString("Panda"), ShortName = resourceLoader.GetString("Panda") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Lili"), FullName = resourceLoader.GetString("EmilieDeRochefort"), ShortName = resourceLoader.GetString("Lili") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Nina"), FullName = resourceLoader.GetString("NinaWilliams"), ShortName = resourceLoader.GetString("Nina") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Claudio"), FullName = resourceLoader.GetString("ClaudioSerafino"), ShortName = resourceLoader.GetString("Claudio") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Katarina"), FullName = resourceLoader.GetString("KatarinaAlves"), ShortName = resourceLoader.GetString("Katarina") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("LuckyChloe"), FullName = resourceLoader.GetString("LuckyChloe"), ShortName = resourceLoader.GetString("Chloe") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Shaheen"), FullName = resourceLoader.GetString("Shaheen"), ShortName = resourceLoader.GetString("Shaheen") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Josie"), FullName = resourceLoader.GetString("JosieRizal"), ShortName = resourceLoader.GetString("Josie") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Gigas"), FullName = resourceLoader.GetString("Gigas"), ShortName = resourceLoader.GetString("Gigas") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Lars"), FullName = resourceLoader.GetString("LarsAlexandersson"), ShortName = resourceLoader.GetString("Lars") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Alisa"), FullName = resourceLoader.GetString("AlisaBosconovitch"), ShortName = resourceLoader.GetString("Alisa") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Xiaoyu"), FullName = resourceLoader.GetString("LingXiaoYu"), ShortName = resourceLoader.GetString("Xiaoyu") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Asuka"), FullName = resourceLoader.GetString("AsukaKazama"), ShortName = resourceLoader.GetString("Asuka") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Steve"), FullName = resourceLoader.GetString("SteveFox"), ShortName = resourceLoader.GetString("Steve") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Leo"), FullName = resourceLoader.GetString("LeoKliesen"), ShortName = resourceLoader.GetString("Leo") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Hwoarang"), FullName = resourceLoader.GetString("Hwoarang"), ShortName = resourceLoader.GetString("Hwoarang") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("King"), FullName = resourceLoader.GetString("King"), ShortName = resourceLoader.GetString("King") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Dragunov"), FullName = resourceLoader.GetString("SergeiDragunov"), ShortName = resourceLoader.GetString("Dragunov") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Feng"), FullName = resourceLoader.GetString("FengWei"), ShortName = resourceLoader.GetString("Feng") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Bryan"), FullName = resourceLoader.GetString("BryanFury"), ShortName = resourceLoader.GetString("Bryan") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Jin"), FullName = resourceLoader.GetString("JinKazama"), ShortName = resourceLoader.GetString("Jin") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("DevilJin"), FullName = resourceLoader.GetString("DevilJin"), ShortName = resourceLoader.GetString("DevilJin") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Yoshimitsu"), FullName = resourceLoader.GetString("Yoshimitsu"), ShortName = resourceLoader.GetString("Yoshimitsu") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Jack7"), FullName = resourceLoader.GetString("Jack7"), ShortName = resourceLoader.GetString("Jack7") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Bob"), FullName = resourceLoader.GetString("BobRichards"), ShortName = resourceLoader.GetString("Bob") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("MRaven"), FullName = resourceLoader.GetString("MasterRaven"), ShortName = resourceLoader.GetString("MRaven") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("LeeViolet"), FullName = resourceLoader.GetString("LeeChaolan"), ShortName = resourceLoader.GetString("Lee") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Miguel"), FullName = resourceLoader.GetString("MiguelCaballeroRojo"), ShortName = resourceLoader.GetString("Miguel") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("Eddy"), FullName = resourceLoader.GetString("EddyGordo"), ShortName = resourceLoader.GetString("Eddy") });
                characters.Add(new CharacterViewModel() { Name = resourceLoader.GetString("GeeseHoward"), FullName = resourceLoader.GetString("GeeseHoward"), ShortName = resourceLoader.GetString("GeeseHoward") });

                StaticCharacters = new ObservableCollection<CharacterViewModel>(characters.OrderBy(c => c.Name));
            }
            Characters = StaticCharacters;
        }

        public static ObservableCollection<CharacterViewModel> LoadCharacters(IEnumerable<TekkenLibrary.Model.Character> characters)
        {
            var result = new ObservableCollection<CharacterViewModel>();
            foreach (var character in characters)
            {
                result.Add(new CharacterViewModel()
                {
                    Name = character.Name,
                    FullName = character.FullName,
                    ShortName = character.ShortName
                });
            }

            return result;
        }
    }
}
