using Lab_04_05.Commands;
using Lab_04_05.Models;
using Lab_04_05.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Lab_04_05.View;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Data;

namespace Lab_04_05.ViewModels
{
    public class ShopProductsViewModel : ViewModelBase
    {
        private Watch selectedWatch;


        private string seatchText;
        public string SeatchText
        {
            get
            {
                return seatchText;
            }
            set
            {
                seatchText = value;
                OnPropertyChanged("SeatchText");
                Snikers_TextChanged();
            }
        }
        public Watch SelectedWatch
        {
            get
            {
                return selectedWatch;
            }
            set
            {
                selectedWatch = value;
            }
        }
        public ObservableCollection<Watch> watches { get; set; }
        public MainWindow mainWindow;
        public ShopProducts shopProducts;
        public DescriptionWatchViewModel descriptionWatch;
        public DescriptionWatch descriptionWatchView;
        

        public ShopProductsViewModel(ObservableCollection<Watch> watches, MainWindow mainWindow, DescriptionWatchViewModel descriptionWatch, DescriptionWatch descriptionWatchView, ShopProducts shop)
        {
            this.mainWindow = mainWindow;
            this.watches = watches;
            this.descriptionWatch = descriptionWatch;
            this.descriptionWatchView = descriptionWatchView;
            this.descriptionWatch.watches = watches;
            this.shopProducts = shop;
            this.listWatches = watches;
            //Binding binding = new Binding();
            //binding.ElementName = "Snikers"; // элемент-источник
            //binding.Path = new PropertyPath("Text");
            //this.shopProducts.Snikers.SetBinding(TextBox.TextProperty, binding);
            //SeatchText = shopProducts.Snikers.Text;
            
        }

        private DelegateCommand? openDescriptionWatch;

        public ICommand OpenDescriptionWatch
        {
            get
            {
                if (openDescriptionWatch == null)
                {
                    openDescriptionWatch = new DelegateCommand(openDescriptionWatchPage);
                }
                return openDescriptionWatch;
            }
        }

        public void Snikers_TextChanged()
        {
            if (seatchText == "")
            {
                this.ListWatches = watches;
                return;
            }
            IEnumerable<Watch> enumerator = watches.Where(s => s.ModelName.ToLower().Contains(seatchText.ToLower()));
            ObservableCollection<Watch> watchesList = new ObservableCollection<Watch>();
            foreach (Watch watch in enumerator)
            {
                watchesList.Add(watch);
            }
            this.ListWatches = watchesList;
        }
        private void openDescriptionWatchPage()
        {
            descriptionWatch.watch = selectedWatch;
            descriptionWatch.ModelName = selectedWatch.ModelName;
            descriptionWatch.CompanyName = selectedWatch.CompanyName;
            descriptionWatch.Description = selectedWatch.Description;
            descriptionWatch.ImagePath = selectedWatch.ImagePath;
            mainWindow.WindowPanel.Content = descriptionWatchView;        
        }
    }
}
