using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using GoldTime.Utilities.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using GoldTime.Utilities;
using System.Windows;

namespace GoldTime.ViewModels.AdminPanel
{
    public class AddNewsViewModel : ViewModelBase
    {
        #region fields

        private string nameNews = "";
        private string descriptionNews = "";
        private ImageSource imagePath;

        private string nameNewsModel = "";
        private string imagePathModel = "";

        #endregion

        #region propertys

        public string NameNews
        {
            get
            {
                return nameNews;
            }
            set
            {
                nameNews = value;
                NameNewsModel = nameNews;
                OnPropertyChanged("NameNews");
            }
        }
        public string DescriptionNews
        {
            get
            {
                return descriptionNews;
            }
            set
            {
                descriptionNews = value;
                OnPropertyChanged("DescriptionNews");
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

        public string NameNewsModel
        {
            get
            {
                return nameNewsModel;
            }
            set
            {
                nameNewsModel = value;
                OnPropertyChanged("NameNewsModel");
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

        public AddNewsViewModel()
        {
            string imagePath = "..\\..\\Resources\\Images\\DefaultImages\\DefaultNews.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            ImagePath = bitmap;
        }

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
            NameNews = "";
            DescriptionNews = "";

            string imagePath = "..\\..\\Resources\\Images\\DefaultImages\\DefaultNews.png";
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
            ImagePath = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        #endregion

        #region create news
        private DelegateCommand? createNews;

        public ICommand CreateNews
        {
            get
            {
                if (createNews == null)
                {
                    createNews = new DelegateCommand(CreateNewsApp);
                }
                return createNews;
            }
        }

        private void CreateNewsApp()
        {
            if (NameNews.Trim() != "" && NameNews != null && DescriptionNews.Trim() != "" && DescriptionNews != null && ImagePath != null)
            {
                News news = new News(NameNews, DescriptionNews, ImagePath.ToString());
                ControllerApplication.DataBase.NewsRepository.Create(news);
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
