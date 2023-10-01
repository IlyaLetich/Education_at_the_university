using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GoldTime.ViewModels.AdminPanel
{
    public class AddWatchViewModel : ViewModelBase
    {
        #region fields

        private string nameModel = "";
        private string nameCompany = "";
        private decimal price;
        private string description = "";
        private ImageSource imagePath;

        private string nameModelModel = "";
        private string nameCompanyModel = "";
        private decimal priceModel;
        private string descriptionModel = "";
        private string imagePathModel = "";

        #endregion

        public AddWatchViewModel()
        {
            string imagePath = "..\\..\\Resources\\Images\\DefaultImages\\DefaultWatch.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImagePath = bitmap;
        }

        #region propertys

        public string NameModel
        {
            get
            {
                return nameModel;
            }
            set
            {
                nameModel = value;
                NameModelModel = nameModel;
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
                NameCompanyModel = nameCompany;
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
                PriceModel = price;
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
                DescriptionModel = description;
                OnPropertyChanged("Description");
            }
        }
        public ImageSource ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                ImagePathModel = imagePath.ToString();
                OnPropertyChanged("ImagePath");
            }
        }
        public string NameModelModel
        {
            get
            {
                return nameModelModel;
            }
            set
            {
                nameModelModel = value;
                OnPropertyChanged("NameModelModel");
            }
        }
        public string NameCompanyModel
        {
            get
            {
                return nameCompanyModel;
            }
            set
            {
                nameCompanyModel = value;
                OnPropertyChanged("NameCompanyModel");
            }
        }
        public decimal PriceModel
        {
            get
            {
                return priceModel;
            }
            set
            {
                priceModel = value;
                OnPropertyChanged("PriceModel");
            }
        }
        public string DescriptionModel
        {
            get
            {
                return descriptionModel;
            }
            set
            {
                descriptionModel = value;
                OnPropertyChanged("DescriptionModel");
            }
        }
        public string ImagePathModel
        {
            get
            {
                return imagePathModel;
            }
            set
            {
                imagePathModel = value;
                OnPropertyChanged("ImagePathModel");
            }
        }
        #endregion

        #region commands

        #region clear fields

        private DelegateCommand? clearFields;

        public ICommand ClearFields
        {
            get
            {
                if (clearFields == null)
                {
                    clearFields = new DelegateCommand(ClearFieldsEnter);
                }
                return clearFields;
            }
        }

        private void ClearFieldsEnter()
        {
            NameModel = "";
            NameCompany = "";
            Price = 0;
            Description = "";

            string imagePath = "..\\..\\Resources\\Images\\DefaultImages\\DefaultWatch.png"; 
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImagePath = bitmap;
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
                    getImage = new DelegateCommand(GetImageUser);
                }
                return getImage;
            }
        }

        private void GetImageUser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        #endregion

        #region create watch
        private DelegateCommand? createWatch;

        public ICommand CreateWatch
        {
            get
            {
                if (createWatch == null)
                {
                    createWatch = new DelegateCommand(CreateWatchShop);
                }
                return createWatch;
            }
        }

        private void CreateWatchShop()
        {
            if (nameModel != null && nameModel.Trim() != "" &&
                nameCompany != null && nameCompany.Trim() != "" &&
                description != null && description.Trim() != "" &&
                imagePath != null)
            {
                Watch watch = new Watch(NameModel, NameCompany, Description, Price, imagePath.ToString());
                ControllerApplication.DataBase.WatchesRepository.Create(watch);
                ControllerApplication.UpdateInformationDataBase();
                ClearFieldsEnter();
            }
            else
            {
                MessageBox.Show(Application.Current.FindResource("FieldsEmpty").ToString());
            }

        }
        #endregion

        #endregion
    }
}
