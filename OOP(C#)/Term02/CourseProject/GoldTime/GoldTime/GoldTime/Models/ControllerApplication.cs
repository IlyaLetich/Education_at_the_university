using GoldTime.Models.DataBase;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.ViewModels.AdminPanel;
using GoldTime.ViewModels.Authentication;
using GoldTime.ViewModels.MainViewModel;
using GoldTime.ViewModels.Settings;
using GoldTime.ViewModels.Shop;
using GoldTime.Views.AdminPanel;
using GoldTime.Views.Authentication;
using GoldTime.Views.MainView;
using GoldTime.Views.Settings;
using GoldTime.Views.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GoldTime.Models
{
    public static class ControllerApplication
    {
        #region fields

        #region data

        public static User user;
        public static MainView mainView;
        public static MainViewModel mainViewModel;
        public static AuthenticationViewModel authenticationViewModel;
        public static AuthenticationView authenticationView;
        public static UnitOfWork DataBase = new UnitOfWork();

        #endregion

        #region views and view models

        #region main view

        private static AdminPanelView adminPanelView;
        private static AdminPanelViewModel adminPanelViewModel;

        private static NewsView newsView;
        private static NewsViewModel newsViewModel;

        private static ShopView shopView;
        private static ShopViewModel shopViewModel;

        private static BasketView basketView;
        private static BasketViewModel basketViewModel;

        private static OrdersView ordersView;
        private static OrdersViewModel ordersViewModel;

        private static SettingsView settingsView;
        private static SettingsViewModel settingsViewModel;

        private static ComparisonView comparisonView;
        private static ComparisonViewModel comparisonViewModel;

        public static NewsDescriptionView newsDescriptionView;
        public static NewsDescriptionViewModel newsDescriptionViewModel;

        public static WatchDescriptionView watchDescriptionView;
        public static WatchDescriptionViewModel watchDescriptionViewModel;

        public static FilterView filterView;
        public static FilterViewModel filterViewModel;

        #endregion

        #region admin view

        private static AddWatchView addWatchView;
        private static AddWatchViewModel addWatchViewModel;

        private static AddNewsView addNewsView;
        private static AddNewsViewModel addNewsViewModel;

        private static ListUsersView listUsersView;
        private static ListUsersViewModel listUsersViewModel;

        #endregion

        #region settings view

        private static MainSettingsView mainSettingsView;
        private static MainSettingsViewModel mainSettingsViewModel;

        private static ThemesView themesView;
        private static ThemesViewModel themesViewModel;

        private static LanguagesView languagesView;
        private static LanguagesViewModel languagesViewModel;

        private static ChangeUserNameView changeUserNameView;
        private static ChangeUserNameViewModel changeUserNameViewModel;
        
        private static ChangeUserEmailView changeUserEmailView;
        private static ChangeUserEmailViewModel changeUserEmailViewModel;
        
        private static ChangeUserPasswordView changeUserPasswordView;
        private static ChangeUserPasswordViewModel changeUserPasswordViewModel;

        #endregion

        #region authentication

        public static LoginView loginView;
        private static LoginViewModel loginViewModel;

        public static RegistrationView registrationView;
        private static RegistrationViewModel registrationViewModel;

        #endregion

        #endregion

        #endregion

        #region propertys

        public static User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                basketViewModel.Watches = user.WatchesBasket.Watches.ToList();
                comparisonViewModel.Watches = user.ComparisonWatches.Watches.ToList();
                ordersViewModel.Orders = user.OrdersUser.Orders.ToList();
                mainSettingsViewModel.UserName = user.Name;
                mainSettingsViewModel.UserEmail = user.Email;

                SetAdminPage("AddWatch");

                if(user.Status == Status.Admin)
                {
                    mainView.BasketMain.Visibility = Visibility.Collapsed;
                    mainView.OrdersMain.Visibility = Visibility.Collapsed;

                    mainView.AdminMain.Visibility = Visibility.Visible;

                    watchDescriptionView.EditWatch.Visibility = Visibility.Visible;
                    watchDescriptionView.DeleteWatch.Visibility = Visibility.Visible;

                    watchDescriptionView.ToBasket.Visibility = Visibility.Collapsed;
                    watchDescriptionView.ToComparison.Visibility = Visibility.Collapsed;

                    newsDescriptionView.EditNews.Visibility = Visibility.Visible;
                    newsDescriptionView.DeleteNews.Visibility = Visibility.Visible;

                    shopView.ComparisonPage.Visibility = Visibility.Collapsed;

                }
                if(user.Status == Status.User)
                {
                    mainView.BasketMain.Visibility = Visibility.Visible;
                    mainView.OrdersMain.Visibility = Visibility.Visible;

                    mainView.AdminMain.Visibility = Visibility.Collapsed;

                    watchDescriptionView.ToBasket.Visibility = Visibility.Visible;
                    watchDescriptionView.ToComparison.Visibility = Visibility.Visible;

                    watchDescriptionView.EditWatch.Visibility = Visibility.Collapsed;
                    watchDescriptionView.DeleteWatch.Visibility = Visibility.Collapsed;

                    newsDescriptionView.EditNews.Visibility = Visibility.Collapsed;
                    newsDescriptionView.DeleteNews.Visibility = Visibility.Collapsed;

                    shopView.ComparisonPage.Visibility = Visibility.Visible;
                }
            }
        }

        #endregion

        #region constructors

        static ControllerApplication()
        {
            #region main view

            adminPanelView = new AdminPanelView();
            adminPanelViewModel = new AdminPanelViewModel();
            adminPanelView.DataContext = adminPanelViewModel;

            newsView = new NewsView();
            newsViewModel = new NewsViewModel();
            newsView.DataContext = newsViewModel;

            shopView = new ShopView();
            shopViewModel = new ShopViewModel();
            shopView.DataContext = shopViewModel;

            basketView = new BasketView();
            basketViewModel = new BasketViewModel();
            basketView.DataContext = basketViewModel;

            ordersView = new OrdersView();
            ordersViewModel = new OrdersViewModel();
            ordersView.DataContext = ordersViewModel;

            settingsView = new SettingsView();
            settingsViewModel = new SettingsViewModel();
            settingsView.DataContext = settingsViewModel;

            comparisonView = new ComparisonView();
            comparisonViewModel = new ComparisonViewModel();
            comparisonView.DataContext = comparisonViewModel;

            watchDescriptionView = new WatchDescriptionView();
            watchDescriptionViewModel = new WatchDescriptionViewModel();
            watchDescriptionView.DataContext = watchDescriptionViewModel;

            newsDescriptionView = new NewsDescriptionView();
            newsDescriptionViewModel = new NewsDescriptionViewModel();
            newsDescriptionView.DataContext = newsDescriptionViewModel;

            #endregion

            #region admin panel view

            addNewsView = new AddNewsView();
            addNewsViewModel = new AddNewsViewModel(); 
            addNewsView.DataContext = addNewsViewModel;

            addWatchView = new AddWatchView();
            addWatchViewModel = new AddWatchViewModel();
            addWatchView.DataContext = addWatchViewModel;

            listUsersView = new ListUsersView();
            listUsersViewModel = new ListUsersViewModel();
            listUsersView.DataContext = listUsersViewModel;

            settingsView = new SettingsView();
            settingsViewModel = new SettingsViewModel();
            settingsView.DataContext = settingsViewModel;

            filterView = new FilterView();
            filterViewModel = new FilterViewModel();
            filterView.DataContext = filterView;


            SetAdminPage("ListUsers");

            #endregion

            #region settings view

            mainSettingsView = new MainSettingsView();
            mainSettingsViewModel = new MainSettingsViewModel();
            mainSettingsView.DataContext = mainSettingsViewModel;

            themesView = new ThemesView();
            themesViewModel = new ThemesViewModel();
            themesView.DataContext = themesViewModel;

            languagesView = new LanguagesView();
            languagesViewModel = new LanguagesViewModel();
            languagesView.DataContext = languagesViewModel;

            changeUserNameView = new ChangeUserNameView();
            changeUserNameViewModel = new ChangeUserNameViewModel();
            changeUserNameView.DataContext = changeUserNameViewModel;

            changeUserEmailView = new ChangeUserEmailView();
            changeUserEmailViewModel = new ChangeUserEmailViewModel();
            changeUserEmailView.DataContext = changeUserEmailViewModel;

            changeUserPasswordView = new ChangeUserPasswordView();
            changeUserPasswordViewModel = new ChangeUserPasswordViewModel();
            changeUserPasswordView.DataContext = changeUserPasswordViewModel;

            settingsViewModel.SettingsPage = mainSettingsView;

            #endregion

            #region authentication view
            
            loginView = new LoginView();
            loginViewModel = new LoginViewModel();
            loginView.DataContext = loginViewModel;

            registrationView = new RegistrationView();
            registrationViewModel = new RegistrationViewModel();
            registrationView.DataContext = registrationViewModel;

            #endregion
        }

        #endregion

        #region methods
        public static void SetMainPage(string namePage)
        {
            switch (namePage)
            {
                case "AdminPanel":
                    mainViewModel.MainPageBack = adminPanelView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "News":
                    mainViewModel.MainPageBack = newsView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "Comparison":
                    mainViewModel.MainPageBack = comparisonView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "Filter":
                    mainViewModel.MainPageFront = filterView;
                    break;
                case "CloseFilter":
                    mainViewModel.MainPageFront = null;
                    break;
                case "Shop":
                    mainViewModel.MainPageBack = shopView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "Basket":
                    mainViewModel.MainPageBack = basketView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "Orders":
                    mainViewModel.MainPageBack = ordersView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "Settings":
                    mainViewModel.MainPageFront = settingsView;
                    SetSettingsPage("MainSettings");
                    break;
                case "DescriptionWatch":
                    mainViewModel.MainPageBack = watchDescriptionView;
                    mainViewModel.MainPageFront = null;
                    break;
                case "DescriptionNews":
                    mainViewModel.MainPageBack = newsDescriptionView;
                    mainViewModel.MainPageFront = null;
                    break;
                default:
                    mainViewModel.MainPageBack = shopView;
                    mainViewModel.MainPageFront = null;
                    break;
            }
        }
        public static void SetAdminPage(string namePage)
        {
            switch (namePage)
            {
                case "AddWatch":
                    adminPanelViewModel.AdminPanelPage = addWatchView;
                    break;
                case "AddNews":
                    adminPanelViewModel.AdminPanelPage = addNewsView;
                    break;
                case "ListUsers":
                    adminPanelViewModel.AdminPanelPage = listUsersView;
                    break;
                default:
                    adminPanelViewModel.AdminPanelPage = addWatchView;
                    break;
            }
        }
        public static void SetSettingsPage(string namePage)
        {
            switch (namePage)
            {
                case "Themes":
                    settingsViewModel.SettingsPage = themesView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Visible;
                    break;
                case "Languages":
                    settingsViewModel.SettingsPage = languagesView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Visible;
                    break;
                case "ChangeUserName":
                    settingsViewModel.SettingsPage = changeUserNameView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Visible;
                    break;
                case "ChangeUserPassword":
                    settingsViewModel.SettingsPage = changeUserPasswordView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Visible;
                    break;
                case "ChangeUserEmail":
                    settingsViewModel.SettingsPage = changeUserEmailView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Visible;
                    break;
                case "MainSettings":
                    settingsViewModel.SettingsPage = mainSettingsView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Hidden;
                    break;
                case "Exit":
                    settingsViewModel.SettingsPage = mainSettingsView;
                    settingsView.MainSettingsNavigator.Visibility = Visibility.Hidden;
                    mainViewModel.MainPageBack = shopView;
                    mainViewModel.MainPageFront = null;

                    mainView.Hide();
                    authenticationView.Show();


                    break;
                case "CloseSettings":
                    mainViewModel.MainPageFront = null;
                    break;
                default:
                    break;
            }
        }
        public static void SetAuthenticationPage(string namePage)
        {
            switch (namePage)
            {
                case "Login":
                    authenticationViewModel.MainBodyAuthenticationPage = loginView;
                    break;
                case "Registration":
                    authenticationViewModel.MainBodyAuthenticationPage = registrationView;
                    break;
                default:
                    authenticationViewModel.MainBodyAuthenticationPage = registrationView;
                    break;
            }
        }

        public static void ClearFieldsUsersInfo()
        {
            changeUserNameView.UserChange.InputText = "";
            changeUserEmailView.UserChange.InputText = "";
            changeUserPasswordView.UserChange1.Password = "";
            changeUserPasswordView.UserChange2.Password = "";

            loginView.UserChange.InputText = "";
            loginView.UserChange1.Password = "";

            registrationView.UserChange1.InputText = "";
            registrationView.UserChange2.InputText = "";
            registrationView.UserChange3.Password = "";
            registrationView.UserChange4.Password = "";
        }

        public static void UpdateInformationDataBase()
        {
            newsViewModel.News = ControllerApplication.DataBase.NewsRepository.GetAll().ToList(); ;
            shopViewModel.Watches = ControllerApplication.DataBase.WatchesRepository.GetAll().ToList();
            basketViewModel.Watches = user.WatchesBasket.Watches.ToList();
            comparisonViewModel.Watches = user.ComparisonWatches.Watches.ToList();
            ordersViewModel.Orders = user.OrdersUser.Orders.ToList();
        }

        #endregion

    }
}
