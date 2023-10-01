using GoldTime.Models;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoldTime.ViewModels.Settings
{
    public class ThemesViewModel
    {
        #region set theme

        private DelegateCommand<string>? setTheme;

        public ICommand SetTheme
        {
            get
            {
                if (setTheme == null)
                {
                    setTheme = new DelegateCommand<string>(SetSettingsPageView);
                }
                return setTheme;
            }
        }

        private void SetSettingsPageView(string name)
        {
            App.settingsApplication.SetTheme(name);
        }

        #endregion
    }
}
