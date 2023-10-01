using Lab_04_05.Commands;
using Lab_04_05.Models;
using Lab_04_05.View;
using Lab_04_05.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Lab_04_05.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        AdminPanel adminPanel;
        ShopProducts shopProducts;
        MainWindow window;
        DescriptionWatch descriptionWatch;
        Settings settings;

        ObservableCollection<Watch> watches = new ObservableCollection<Watch>() { new Watch("Model1", "Company", "Description", ""),
                                                                                  new Watch("Model2", "Company", "Description", ""), 
                                                                                  new Watch("Model3", "Company", "Description", ""),
                                                                                  new Watch("Model4", "Company", "Description", ""),
                                                                                  new Watch("Model5", "Company", "Description", ""),
                                                                                  new Watch("Model6", "Company", "Description", ""),
                                                                                  new Watch("Model7", "Company", "Description", "")};

        public MainViewModel(MainWindow window)
        {
            this.adminPanel = new AdminPanel();
            this.adminPanel.DataContext = new AdminPanelViewModel(this.adminPanel, watches);
            this.window = window;
            this.window.WindowPanel.Content = this.adminPanel;
            this.shopProducts = new ShopProducts();
            this.descriptionWatch = new DescriptionWatch();
            DescriptionWatchViewModel descriptionWatchViewModel = new DescriptionWatchViewModel(window, shopProducts,descriptionWatch);
            this.descriptionWatch.DataContext = descriptionWatchViewModel;
            ShopProductsViewModel productsViewModel = new ShopProductsViewModel(watches, window, descriptionWatchViewModel, this.descriptionWatch, shopProducts);
            this.shopProducts.DataContext = productsViewModel;
            this.settings = new Settings();
            this.settings.DataContext = new SettingsViewModel(window);
        }

        private DelegateCommand? openAdminPanel;

        public ICommand OpenAdminPanel
        {
            get
            {
                if (openAdminPanel == null)
                {
                    openAdminPanel = new DelegateCommand(openAdminPanelPage);
                }
                return openAdminPanel;
            }
        }

        private void openAdminPanelPage()
        {
            this.window.WindowPanel.Content = this.adminPanel;
            this.window.WindowPanel2.Content = null;
        }

        private DelegateCommand? openShop;

        public ICommand OpenShop
        {
            get
            {
                if (openShop == null)
                {
                    openShop = new DelegateCommand(openShopPage);
                }
                return openShop;
            }
        }

        private void openShopPage()
        {
            this.window.WindowPanel.Content = this.shopProducts;
            this.window.WindowPanel2.Content = null;
        }

        private DelegateCommand? openSettings;
        
        public ICommand OpenSettings
        {
            get
            {
                if (openSettings == null)
                {
                    openSettings = new DelegateCommand(openSettingsPage);
                }
                return openSettings;
            }
        }

        private void openSettingsPage()
        {
            this.window.WindowPanel2.Content = this.settings;
        }
    }
}
