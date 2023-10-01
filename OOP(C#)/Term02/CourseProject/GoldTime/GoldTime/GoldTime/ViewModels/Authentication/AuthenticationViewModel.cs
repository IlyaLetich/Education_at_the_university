using GoldTime.Models;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using GoldTime.Utilities;

namespace GoldTime.ViewModels.Authentication
{
    public class AuthenticationViewModel : ViewModelBase
    {
        #region fields

        private Page mainBodyAuthenticationPage = null;

        #endregion

        #region propertys
        public Page MainBodyAuthenticationPage
        {
            get { return mainBodyAuthenticationPage; }
            set
            {
                if (mainBodyAuthenticationPage == value)
                    return;

                mainBodyAuthenticationPage = value;
                OnPropertyChanged("MainBodyAuthenticationPage");
            }
        }

        #endregion

        #region commands

        #region control authentication view window

        #region close authentication view
        private DelegateCommand? closeAuthenticationView;

        public ICommand CloseAuthenticationView
        {
            get
            {
                if (closeAuthenticationView == null)
                {
                    closeAuthenticationView = new DelegateCommand(CloseAuthenticationViewViewWindow);
                }
                return closeAuthenticationView;
            }
        }

        private void CloseAuthenticationViewViewWindow()
        {
            App.Current.Shutdown();
        }
        #endregion

        #endregion

        #region set authentication view page

        private DelegateCommand<string>? setAuthenticationViewPage;

        public ICommand SetAuthenticationViewPage
        {
            get
            {
                if (setAuthenticationViewPage == null)
                {
                    setAuthenticationViewPage = new DelegateCommand<string>(SetAuthenticationPageView);
                }
                return setAuthenticationViewPage;
            }
        }

        private void SetAuthenticationPageView(string namePage)
        {
            ControllerApplication.SetMainPage(namePage);
        }

        #endregion

        #region set language
        private DelegateCommand<string>? setLanguage;

        public ICommand SetLanguage
        {
            get
            {
                if (setLanguage == null)
                {
                    setLanguage = new DelegateCommand<string>(SetLanguageWindow);
                }
                return setLanguage;
            }
        }

        private void SetLanguageWindow(string language)
        {
            App.settingsApplication.SetLanguage(language);
        }
        #endregion

        #endregion
    }
}
