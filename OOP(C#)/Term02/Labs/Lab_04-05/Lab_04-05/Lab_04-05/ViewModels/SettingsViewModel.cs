using Lab_04_05.Commands;
using Lab_04_05.Models;
using Lab_04_05.View;
using Lab_04_05.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_04_05.ViewModels
{
    internal class SettingsViewModel
    {
        MainWindow window;
        SettingsApp settings = new SettingsApp("Russian","Black");

        public SettingsViewModel(MainWindow window)
        {
            this.window = window;
        }
        private DelegateCommand? closePage;

        public ICommand ClosePage
        {
            get
            {
                if (closePage == null)
                {
                    closePage = new DelegateCommand(closeSettingsPage);
                }
                return closePage;
            }
        }

        private void closeSettingsPage()
        {
            window.WindowPanel2.Content = null;
        }


        private DelegateCommand? setYellow;

        public ICommand SetYellow
        {
            get
            {
                if (setYellow == null)
                {
                    setYellow = new DelegateCommand(setYellowTheme);
                }
                return setYellow;
            }
        }

        private void setYellowTheme()
        {
            settings.Theme = "Yellow";
            settings.UpdateSettings();
        }

        private DelegateCommand? setBlack;

        public ICommand SetBlack
        {
            get
            {
                if (setBlack == null)
                {
                    setBlack = new DelegateCommand(setBlackTheme);
                }
                return setBlack;
            }
        }

        private void setBlackTheme()
        {
            settings.Theme = "Black";
            settings.UpdateSettings();
        }

        private DelegateCommand? setEnglish;

        public ICommand SetEnglish
        {
            get
            {
                if (setEnglish == null)
                {
                    setEnglish = new DelegateCommand(setEnglishTheme);
                }
                return setEnglish;
            }
        }

        private void setEnglishTheme()
        {
            settings.Language = "English";
            settings.UpdateSettings();
        }

        private DelegateCommand? setRussian;

        public ICommand SetRussian
        {
            get
            {
                if (setRussian == null)
                {
                    setRussian = new DelegateCommand(setRussianTheme);
                }
                return setRussian;
            }
        }

        private void setRussianTheme()
        {
            settings.Language = "Russian";
            settings.UpdateSettings();
        }
    }
}
