using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using GoldTime.Models;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace GoldTime.ViewModels.Shop
{
    public class WatchDescriptionViewModel : ViewModelBase
    {
        #region fields

        private Watch watch;
        private string nameModel;
        private string nameCompany;
        private decimal price;
        private string description;
        private string imagePath;

        


        #endregion

        #region propertys

        public Watch Watch
        {
            get
            {
                return watch;
            }
            set
            {
                watch = value;
                NameModel = watch.NameModel;
                NameCompany = watch.NameCompany;
                Price = watch.Price;
                Description = watch.DescriptionModel;
                ImagePath = watch.ImagePath;
                OnPropertyChanged("Watch");
            }
        }
        public string NameModel
        {
            get
            {
                return nameModel;
            }
            set
            {
                nameModel = value;
                OnPropertyChanged("NameModel");
            }
        }
        public string NameCompany
        {
            get
            {
                return nameCompany;
            }
            set
            {
                nameCompany = value;
                OnPropertyChanged("NameCompany");
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        #endregion

        #region commands

        #region set main page

        private DelegateCommand? setMainPage;

        public ICommand SetMainPage
        {
            get
            {
                if (setMainPage == null)
                {
                    setMainPage = new DelegateCommand(SetMainPageView);
                }
                return setMainPage;
            }
        }

        private void SetMainPageView()
        {
            ControllerApplication.SetMainPage("Shop");
        }

        #endregion

        #region edit watch

        private DelegateCommand? edit;

        public ICommand Edit
        {
            get
            {
                if (edit == null)
                {
                    edit = new DelegateCommand(EditWatch);
                }
                return edit;
            }
        }

        private void EditWatch()
        {
            ControllerApplication.watchDescriptionView.NameModel.IsHitTestVisible = true;
            ControllerApplication.watchDescriptionView.NameCompany.IsHitTestVisible = true;
            ControllerApplication.watchDescriptionView.Description.IsHitTestVisible = true;
            ControllerApplication.watchDescriptionView.Price.IsHitTestVisible = true;
            ControllerApplication.watchDescriptionView.ToBasket.Visibility = Visibility.Hidden;
            ControllerApplication.watchDescriptionView.ToComparison.Visibility = Visibility.Hidden;
            ControllerApplication.watchDescriptionView.ToSave.Visibility = Visibility.Visible;
            ControllerApplication.watchDescriptionView.GetImage.Visibility = Visibility.Visible;
        }

        #endregion

        #region delete watch

        private DelegateCommand? delete;

        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new DelegateCommand(DeleteWatch);
                }
                return delete;
            }
        }

        private void DeleteWatch()
        {
            ControllerApplication.DataBase.WatchesRepository.Delete(watch.Id);
            ControllerApplication.UpdateInformationDataBase();

            ControllerApplication.SetMainPage("Shop");
        }

        #endregion

        #region save watch

        private DelegateCommand? save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new DelegateCommand(SaveWatch);
                }
                return save;
            }
        }

        private void SaveWatch()
        {
            ControllerApplication.watchDescriptionView.NameModel.IsHitTestVisible = false;
            ControllerApplication.watchDescriptionView.NameCompany.IsHitTestVisible = false;
            ControllerApplication.watchDescriptionView.Description.IsHitTestVisible = false;
            ControllerApplication.watchDescriptionView.Price.IsHitTestVisible = false;
            ControllerApplication.watchDescriptionView.ToBasket.Visibility = Visibility.Visible;
            ControllerApplication.watchDescriptionView.ToComparison.Visibility = Visibility.Visible;
            ControllerApplication.watchDescriptionView.ToSave.Visibility = Visibility.Hidden;
            ControllerApplication.watchDescriptionView.GetImage.Visibility = Visibility.Hidden;

            watch.NameModel = NameModel;
            watch.NameCompany = NameCompany;
            watch.Price = Price;
            watch.DescriptionModel = Description;
            watch.ImagePath = ImagePath;

            ControllerApplication.DataBase.WatchesRepository.Update(Watch);
            ControllerApplication.UpdateInformationDataBase();
        }

        #endregion

        #region to basket

        private DelegateCommand? toBasket;

        public ICommand ToBasket
        {
            get
            {
                if (toBasket == null)
                {
                    toBasket = new DelegateCommand(ToBasketWatch);
                }
                return toBasket;
            }
        }

        private void ToBasketWatch()
        {
            BasketWatches basketWatches = ControllerApplication.user.WatchesBasket;
            basketWatches.Watches.Add(watch);
            ControllerApplication.DataBase.BasketWatchesRepository.Update(basketWatches);
            ControllerApplication.UpdateInformationDataBase();
        }

        #endregion

        #region to comparison

        private DelegateCommand?toComparison;

        public ICommand ToComparison
        {
            get
            {
                if (toComparison == null)
                {
                    toComparison = new DelegateCommand(ToComparisonWatch);
                }
                return toComparison;
            }
        }

        private void ToComparisonWatch()
        {
            ComparisonWatches comparisonWatches = ControllerApplication.user.ComparisonWatches;
            comparisonWatches.Watches.Add(watch);
            ControllerApplication.DataBase.ComparisonWatchesRepository.Update(comparisonWatches);
            ControllerApplication.UpdateInformationDataBase();
        }

        #endregion

        #region get image
        private DelegateCommand? getImage;

        public ICommand GetImage
        {
            get
            {
                if (getImage == null)
                {
                    getImage = new DelegateCommand(GetImageWatch);
                }
                return getImage;
            }
        }

        private void GetImageWatch()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = new BitmapImage(new Uri(openFileDialog.FileName)).ToString();
            }
        }
        #endregion

        #endregion
    }
}
