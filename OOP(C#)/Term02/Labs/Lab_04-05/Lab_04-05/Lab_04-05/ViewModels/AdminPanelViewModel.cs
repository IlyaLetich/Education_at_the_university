using Lab_04_05.Commands;
using Lab_04_05.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Lab_04_05.Views;
using Lab_04_05.Models;
using System.Collections.ObjectModel;

namespace Lab_04_05.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        CreateWatch createWatch;
        AdminPanel window;
        ObservableCollection<Watch> watches;

        public AdminPanelViewModel(AdminPanel window, ObservableCollection<Watch> watches)
        {
            this.watches= watches;
            this.createWatch = new CreateWatch();
            this.createWatch.DataContext = new CreateWatchViewModel(watches,createWatch);
            this.window = window;
        }

        private DelegateCommand? openCreateWatch;

        public ICommand OpenCreateWatch
        {
            get
            {
                if (openCreateWatch == null)
                {
                    openCreateWatch = new DelegateCommand(openCreateWatchPage);
                }
                return openCreateWatch;
            }
        }

        private void openCreateWatchPage()
        {
            if(createWatch != null)
            {
                window.AdminPanelPage.Content = createWatch;
            }
        }
    }
}
