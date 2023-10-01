using GoldTime.Models;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Configuration;
using GoldTime.Utilities;

namespace GoldTime.ViewModels.Settings
{
    public class MainSettingsViewModel : ViewModelBase
    {
        #region fields

        private string userName;
        private string userEmail;

        #endregion

        #region propertys
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string UserEmail
        {
            get { return userEmail; }
            set
            {
                userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        }
        #endregion

        #region commands

        #region set settings page

        private DelegateCommand<string>? setSettingsPage;

        public ICommand SetSettingsPage
        {
            get
            {
                if (setSettingsPage == null)
                {
                    setSettingsPage = new DelegateCommand<string>(SetSettingsPageView);
                }
                return setSettingsPage;
            }
        }

        private void SetSettingsPageView(string namePage)
        {
            ControllerApplication.SetSettingsPage(namePage);
        }

        #endregion

        #endregion
    }
}
