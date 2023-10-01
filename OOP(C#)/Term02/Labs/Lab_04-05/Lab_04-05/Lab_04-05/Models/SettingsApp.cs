using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_04_05.Models
{
    public class SettingsApp
    {
        public string Language;
        public string Theme;

        public SettingsApp(string Language, string Theme) 
        {
            this.Language = Language;
            this.Theme = Theme;
        }

        public void UpdateSettings()
        {
            var uriTheme = new Uri("./Resources/" + Theme + ".xaml", UriKind.Relative);
            var uriLanguage = new Uri("./Language/" + Language + ".xaml", UriKind.Relative);
            var uriStan = new Uri("./Resources/Standart.xaml", UriKind.Relative);
            ResourceDictionary resourceDictTheme = Application.LoadComponent(uriTheme) as ResourceDictionary;
            ResourceDictionary resourceDictLang = Application.LoadComponent(uriLanguage) as ResourceDictionary;
            ResourceDictionary resourceDictStan = Application.LoadComponent(uriStan) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictLang);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictStan);
        }
    }
}
