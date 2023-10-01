using GoldTime.Models;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoldTime.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        #region field

        private Page settingsPage = null;

        #endregion

        #region propertys
        public Page SettingsPage
        {
            get { return settingsPage; }
            set
            {
                if (settingsPage == value)
                    return;

                settingsPage = value;
                OnPropertyChanged("SettingsPage");
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
