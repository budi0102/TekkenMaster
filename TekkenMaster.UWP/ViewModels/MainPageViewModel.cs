using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.AppModel;
using Prism.Commands;
using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using System.Windows.Input;

namespace TekkenMaster.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region private Fields
        private const string CurrentPageTokenKey = "CurrentPageToken";
        private Dictionary<PageTokens, bool> _canNavigateLookup;
        private PageTokens _currentPageToken;
        private INavigationService _navigationService;
        private ISessionStateService _sessionStateService;
        private IUnityContainer _unityContainer;
        #endregion

        public MainPageViewModel(INavigationService navigationService, ISessionStateService sessionStateService, IUnityContainer unityContainer)
        {
            _navigationService = navigationService;
            _sessionStateService = sessionStateService;
            _unityContainer = unityContainer;
            if (MenuViewModel.StaticMenus != null)
            {
                Menus = new ObservableCollection<MenuItemViewModel>(MenuViewModel.StaticMenus.Skip(1));
            }
            else
            {
                MenuViewModel menuViewModel = _unityContainer.TryResolve<MenuViewModel>();
                Menus = new ObservableCollection<MenuItemViewModel>(menuViewModel.Menus.Skip(1));
            }
            LoadedCommand = new DelegateCommand(Loaded);
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; private set; }
        public ICommand LoadedCommand { get; private set; }

        #region Methods
        private void OnNavigationStateChanged(NavigationStateChangedEventArgs args)
        {
            PageTokens currentPageToken;
            if (Enum.TryParse(args.Sender.Content.GetType().Name.Replace("Page", string.Empty), out currentPageToken))
            {
                _sessionStateService.SessionState[CurrentPageTokenKey] = currentPageToken.ToString();
                UpdateCanNavigateLookup(currentPageToken);
                RaiseCanExecuteChanged();
            }
        }

        private void NavigateToPage(PageTokens pageToken)
        {
            if (CanNavigateToPage(pageToken))
            {
                if (_navigationService.Navigate(pageToken.ToString(), null))
                {
                    UpdateCanNavigateLookup(pageToken);
                    RaiseCanExecuteChanged();
                }
            }
        }

        private bool CanNavigateToPage(PageTokens pageToken)
        {
            return _canNavigateLookup[pageToken];
        }

        private void UpdateCanNavigateLookup(PageTokens navigatedTo)
        {
            _canNavigateLookup[_currentPageToken] = true;
            _canNavigateLookup[navigatedTo] = false;
            _currentPageToken = navigatedTo;
        }

        private void RaiseCanExecuteChanged()
        {
            foreach (var menu in Menus)
            {
                (menu.Command as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        private void Loaded()
        {
            TekkenLibrary.Master.Instance.Load();
            _unityContainer.TryResolve<CharactersViewModel>().Characters = CharactersViewModel.LoadCharacters(TekkenLibrary.Master.Instance.Characters);
        }
        #endregion
    }
}
