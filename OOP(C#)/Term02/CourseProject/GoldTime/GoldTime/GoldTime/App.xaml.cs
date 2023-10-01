using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.ViewModels.Authentication;
using GoldTime.ViewModels.MainViewModel;
using GoldTime.Views.Authentication;
using GoldTime.Views.MainView;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace GoldTime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SettingsApplication settingsApplication = new SettingsApplication();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            settingsApplication.UpdateSettings();
            ControllerApplication.DataBase.Save();

            StartApplication();
        }
        public static void StartMainView()
        {
            ControllerApplication.mainView.Show();
        }

        public static void StartApplication()
        {
            MainView mainView = new MainView();
            MainViewModel mainViewModel = new MainViewModel();
            mainView.DataContext = mainViewModel;
            ControllerApplication.mainViewModel = mainViewModel;
            ControllerApplication.SetMainPage("Shop");
            ControllerApplication.mainView = mainView;

            AuthenticationView authenticationView = new AuthenticationView();
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();
            authenticationView.DataContext = authenticationViewModel;
            authenticationView.Show();
            ControllerApplication.User = ControllerApplication.DataBase.UsersRepository.Get(2);
            ControllerApplication.authenticationViewModel = authenticationViewModel;
            ControllerApplication.authenticationView = authenticationView;
            authenticationViewModel.MainBodyAuthenticationPage = ControllerApplication.loginView;
            //StartMainView();
        }
    }
}
