using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldTime.Utilities;

namespace GoldTime.ViewModels.Shop
{
    public class NewsViewModel : ViewModelBase
    {
        #region fields

        private List<News> news;

        #endregion

        #region constructors

        public NewsViewModel()
        {
            this.News = ControllerApplication.DataBase.NewsRepository.GetAll().ToList();
        }

        #endregion

        #region propertys

        public List<News> News
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
                OnPropertyChanged("News");
            }
        }

        #endregion
    }
}
