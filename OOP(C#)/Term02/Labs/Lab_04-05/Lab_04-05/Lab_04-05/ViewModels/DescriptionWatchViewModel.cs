using Lab_04_05.Commands;
using Lab_04_05.Models;
using Lab_04_05.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Lab_04_05.View;
using System.Collections.ObjectModel;

namespace Lab_04_05.ViewModels
{
    public class DescriptionWatchViewModel:ViewModelBase
    {
        public Watch watch;
        public ObservableCollection<Watch> watches;

        public string ModelName
        {
            get
            {
                if (watch == null) return "lol";
                return watch.ModelName;
            }
            set
            {
                watch.ModelName = value;
                OnPropertyChanged("ModelName");
            }
        }
        public string CompanyName
        {
            get
            {
                if (watch == null) return "lol";
                return watch.CompanyName;
            }
            set
            {
                watch.CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }
        public string Description
        {
            get
            {
                if (watch == null) return "lol";
                return watch.Description;
            }
            set
            {
                watch.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ImagePath
        {
            get
            {
                if (watch == null) return "lol";
                return watch.ImagePath;
            }
            set
            {
                watch.ImagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        MainWindow mainWindow;
        ShopProducts shopProducts;
        DescriptionWatch descriptionWatch;

        public DescriptionWatchViewModel(MainWindow window, ShopProducts shopProducts, DescriptionWatch descriptionWatch)
        {
            this.mainWindow = window;
            this.shopProducts= shopProducts;
            this.descriptionWatch= descriptionWatch;
        }

        private DelegateCommand? closePage;

        public ICommand ClosePage
        {
            get
            {
                if (closePage == null)
                {
                    closePage = new DelegateCommand(closePageDescription);
                }
                return closePage;
            }
        }

        private void closePageDescription()
        {
            mainWindow.WindowPanel.Content = shopProducts;
            descriptionWatch.NameModelWatch.IsEnabled = false;
            descriptionWatch.PriceWatch.IsEnabled = false;
            descriptionWatch.NameCompanyWatch.IsEnabled = false;
            descriptionWatch.DescriptionWatch1.IsEnabled = false;
        }

        private DelegateCommand? deleteWatch;

        public ICommand DeleteWatch
        {
            get
            {
                if (deleteWatch == null)
                {
                    deleteWatch = new DelegateCommand(deleteWatchFromShop);
                }
                return deleteWatch;
            }
        }

        private void deleteWatchFromShop()
        {
            watches.Remove(watch);
            mainWindow.WindowPanel.Content = shopProducts;
        }
        private DelegateCommand? editWatch;

        public ICommand EditWatch
        {
            get
            {
                if (editWatch == null)
                {
                    editWatch = new DelegateCommand(editWatchFromList);
                }
                return editWatch;
            }
        }

        private void editWatchFromList()
        {
            descriptionWatch.NameModelWatch.IsEnabled = true;
            descriptionWatch.PriceWatch.IsEnabled = true;
            descriptionWatch.NameCompanyWatch.IsEnabled = true;
            descriptionWatch.DescriptionWatch1.IsEnabled = true;
            descriptionWatch.edWatch.Visibility= Visibility.Collapsed;
            descriptionWatch.delWatch.Visibility = Visibility.Collapsed;
            descriptionWatch.svWatch.Visibility = Visibility.Visible;
        }

        private DelegateCommand? seveWatch;

        public ICommand SaveWatch
        {
            get
            {
                if (seveWatch == null)
                {
                    seveWatch = new DelegateCommand(seveWatchFromList);
                }
                return seveWatch;
            }
        }

        private void seveWatchFromList()
        {
            descriptionWatch.NameModelWatch.IsEnabled = false;
            descriptionWatch.PriceWatch.IsEnabled = false;
            descriptionWatch.NameCompanyWatch.IsEnabled = false;
            descriptionWatch.DescriptionWatch1.IsEnabled = false;
            descriptionWatch.edWatch.Visibility = Visibility.Visible;
            descriptionWatch.delWatch.Visibility = Visibility.Visible;
            descriptionWatch.svWatch.Visibility = Visibility.Collapsed;
        }
    }
}
