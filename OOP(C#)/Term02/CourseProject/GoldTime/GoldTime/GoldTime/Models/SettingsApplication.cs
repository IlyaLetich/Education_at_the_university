using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoldTime.Models
{
    public class SettingsApplication
    {
        #region fields
        private string theme;
        private string language;
        #endregion

        #region constructors
        
        public SettingsApplication()
        {
            this.language = "Russian";
            this.theme = "DarkBlue";
        }

        public SettingsApplication(string theme, string language)
        {
            this.theme = theme;
            this.language = language;
        }

        #endregion

        #region propertys

        #endregion

        #region methods

        public void SetLanguage(string language)
        {
            this.language = language;
            UpdateSettings();
        }
        public void SetTheme(string theme)
        {
            this.theme = theme;
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            var uriTheme = new Uri("./Resources/Themes/" + this.theme + ".xaml", UriKind.Relative);
            var uriLanguage = new Uri("./Resources/Languages/" + this.language + ".xaml", UriKind.Relative);

            Application.Current.Resources.Clear();

            ResourceDictionary resourceDictTheme = Application.LoadComponent(uriTheme) as ResourceDictionary;
            ResourceDictionary resourceDictLang = Application.LoadComponent(uriLanguage) as ResourceDictionary;

            Application.Current.Resources.MergedDictionaries.Add(resourceDictTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictLang);
        }

        #endregion

    }
}
