using Lab_04_05.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Lab_04_05.Models;
using Lab_04_05.View;
using System.Collections.ObjectModel;

namespace Lab_04_05.ViewModels
{
    public class CreateWatchViewModel : ViewModelBase
    {
        ObservableCollection<Watch> watches;
        CreateWatch window;

        public CreateWatchViewModel(ObservableCollection<Watch> watches,CreateWatch window)
        {
            this.watches = watches;
            this.window = window;
        }

        private DelegateCommand? createWatch;

        public ICommand CreateWatch
        {
            get
            {
                if (createWatch == null)
                {
                    createWatch = new DelegateCommand(createWatchClass);
                }
                return createWatch;
            }
        }

        private void createWatchClass()
        {
            watches.Add(new Watch(window.NameModel.Text,window.NameCompany.Text,window.Description.Text, window.PathImage.Text));
            //OnPropertyChanged(nameof(watches));
        }
    }
}
