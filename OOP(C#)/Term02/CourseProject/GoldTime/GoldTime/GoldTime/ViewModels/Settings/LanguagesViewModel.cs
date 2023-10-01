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
    public class LanguagesViewModel
    {
        #region commands

        #region set language 

        private DelegateCommand<string>? setLanguage;

        public ICommand SetLanguage
        {
            get
            {
                if (setLanguage == null)
                {
                    setLanguage = new DelegateCommand<string>(SetLanguageApplication);
                }
                return setLanguage;
            }
        }

        private void SetLanguageApplication(string language)
        {
            App.settingsApplication.SetLanguage(language);
        }

        #endregion

        #endregion
    }
}
