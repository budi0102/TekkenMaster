using Prism.Commands;
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
    public class MenuViewModel : ViewModelBase
    {
        #region Static Members
        public static ObservableCollection<MenuItemViewModel> StaticMenus { get; private set; }
        #endregion

        #region Public Properties
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region private Fields
        private const string CurrentPageTokenKey = "CurrentPageToken";
        private Dictionary<PageTokens, bool> _canNavigateLookup;
        private PageTokens _currentPageToken;
        private INavigationService _navigationService;
        private ISessionStateService _sessionStateService;
        #endregion

        #region Constructor
        public MenuViewModel(IEventAggregator eventAggregator, INavigationService navigationService, IResourceLoader resourceLoader, ISessionStateService sessionStateService)
        {
            eventAggregator.GetEvent<NavigationStateChangedEvent>().Subscribe(OnNavigationStateChanged);
            _navigationService = navigationService;
            _sessionStateService = sessionStateService;

            if (StaticMenus == null)
            {
                StaticMenus = new ObservableCollection<MenuItemViewModel>
                {
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("MainPageMenuItemDisplayName"), FontIcon = "\ue15f", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Main), () => CanNavigateToPage(PageTokens.Main)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("ProfilePageMenuItemDisplayName"), FontIcon = "\u2781", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Profile), () => CanNavigateToPage(PageTokens.Profile)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("BasicMoveListPageMenuItemDisplayName"), FontIcon = "\u2782", Command = new DelegateCommand(() => NavigateToPage(PageTokens.BasicMoveList), () => CanNavigateToPage(PageTokens.BasicMoveList)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("ThrowMoveListPageMenuItemDisplayName"), FontIcon = "\u2783", Command = new DelegateCommand(() => NavigateToPage(PageTokens.ThrowMoveList), () => CanNavigateToPage(PageTokens.ThrowMoveList)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("SpecialMoveListPageMenuItemDisplayName"), FontIcon = "\u2784", Command = new DelegateCommand(() => NavigateToPage(PageTokens.SpecialMoveList), () => CanNavigateToPage(PageTokens.SpecialMoveList)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("PunishmentPageMenuItemDisplayName"), FontIcon = "\u2785", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Punishment), () => CanNavigateToPage(PageTokens.Punishment)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("OffensiveStrategyMenuItemDisplayName"), FontIcon = "\u2786", Command = new DelegateCommand(() => NavigateToPage(PageTokens.OffensiveStrategy), () => CanNavigateToPage(PageTokens.OffensiveStrategy)) },
                    new MenuItemViewModel { DisplayName = resourceLoader.GetString("DefensiveStrategyMenuItemDisplayName"), FontIcon = "\u2787", Command = new DelegateCommand(() => NavigateToPage(PageTokens.DefensiveStrategy), () => CanNavigateToPage(PageTokens.DefensiveStrategy)) },
                };
            }
            Menus = StaticMenus;

            _canNavigateLookup = new Dictionary<PageTokens, bool>();

            foreach (PageTokens pageToken in Enum.GetValues(typeof(PageTokens)))
            {
                _canNavigateLookup.Add(pageToken, true);
            }

            if (_sessionStateService.SessionState.ContainsKey(CurrentPageTokenKey))
            {
                // Resuming, so update the menu to reflect the current page correctly
                PageTokens currentPageToken;
                if (Enum.TryParse(_sessionStateService.SessionState[CurrentPageTokenKey].ToString(), out currentPageToken))
                {
                    UpdateCanNavigateLookup(currentPageToken);
                    RaiseCanExecuteChanged();
                }
            }
        }
        #endregion

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
        #endregion
    }
}