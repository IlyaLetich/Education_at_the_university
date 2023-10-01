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
using System.Windows;
using Microsoft.VisualBasic;
using GoldTime.Utilities;

namespace GoldTime.ViewModels.Shop
{
    public class NewsDescriptionViewModel : ViewModelBase
    {
        #region fields

        private News news;
        private string nameNews;
        private string imformationsNews;
        private string imagePath;
        private DateTime dateTime;

        #endregion

        #region propertys

        public News News
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
                NameNews = news.NameNews;
                ImformationsNews = news.InformationsNews;
                this.DateTime = news.DateTime; 
                ImagePath = news.ImagePath;
                OnPropertyChanged("News");
            }
        }
        public string NameNews
        {
            get
            {
                return nameNews;
            }
            set
            {
                nameNews = value;
                OnPropertyChanged("NameNews");
            }
        }
        public string ImformationsNews
        {
            get
            {
                return imformationsNews;
            }
            set
            {
                imformationsNews = value;
                OnPropertyChanged("ImformationsNews");
            }
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
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
            ControllerApplication.SetMainPage("News");
        }

        #endregion

        #region edit news

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
            ControllerApplication.newsDescriptionView.Name.IsHitTestVisible = true;
            ControllerApplication.newsDescriptionView.Description.IsHitTestVisible = true;
            ControllerApplication.newsDescriptionView.GetImage.Visibility = Visibility.Visible;
            ControllerApplication.newsDescriptionView.ToSave.Visibility = Visibility.Visible;
        }

        #endregion

        #region delete news

        private DelegateCommand? delete;

        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new DelegateCommand(DeleteNews);
                }
                return delete;
            }
        }

        private void DeleteNews()
        {
            ControllerApplication.DataBase.NewsRepository.Delete(news.Id);
            ControllerApplication.UpdateInformationDataBase();

            ControllerApplication.SetMainPage("News");
        }

        #endregion

        #region save news

        private DelegateCommand? save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new DelegateCommand(SaveNews);
                }
                return save;
            }
        }

        private void SaveNews()
        {
            ControllerApplication.newsDescriptionView.Name.IsHitTestVisible = false;
            ControllerApplication.newsDescriptionView.Description.IsHitTestVisible = false;
            ControllerApplication.newsDescriptionView.GetImage.Visibility = Visibility.Hidden;
            ControllerApplication.newsDescriptionView.ToSave.Visibility = Visibility.Hidden;

            news.NameNews = NameNews;
            news.InformationsNews = ImformationsNews;
            news.ImagePath = ImagePath;

            ControllerApplication.DataBase.NewsRepository.Update(news);
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
