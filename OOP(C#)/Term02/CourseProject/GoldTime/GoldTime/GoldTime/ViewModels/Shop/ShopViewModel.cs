using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace GoldTime.ViewModels.Shop
{
    public class ShopViewModel : ViewModelBase
    {
        #region fields

        private List<Watch> watchesRead;

        private List<Watch> watches;
        private string searchText;

        #endregion

        #region constructors

        public ShopViewModel()
        {
            this.Watches = ControllerApplication.DataBase.WatchesRepository.GetAll().ToList();
        }

        #endregion

        #region propertys

        public List<Watch> Watches
        {
            get
            {
                return watches;
            }
            set
            {
                watches = value;
                OnPropertyChanged("Watches");
            }
        }

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                if (searchText.Trim() != "" || searchText != null)
                {
                    Watches = ControllerApplication.DataBase.WatchesRepository.GetAll().ToList().Where(x => (x.NameModel.Contains(searchText.Trim()) || x.NameCompany.Contains(searchText.Trim()))).ToList();
                }
                else
                {
                    Watches = ControllerApplication.DataBase.WatchesRepository.GetAll().ToList();
                }
                OnPropertyChanged("SearchText");
            }
        }

        #endregion

        #region commands

        #region get description watch

        private DelegateCommand<int>? getDescriptionWatch;

        public ICommand GetDescriptionWatch
        {
            get
            {
                if (getDescriptionWatch == null)
                {
                    getDescriptionWatch = new DelegateCommand<int>(GetDescriptionWatchView);
                }
                return getDescriptionWatch;
            }
        }

        private void GetDescriptionWatchView(int id)
        {
            MessageBox.Show(id.ToString());
        }

        #endregion

        #region set main page

        private DelegateCommand<string>? setMainPage;

        public ICommand SetMainPage
        {
            get
            {
                if (setMainPage == null)
                {
                    setMainPage = new DelegateCommand<string>(SetMainPageView);
                }
                return setMainPage;
            }
        }

        private void SetMainPageView(string namePage)
        {
            ControllerApplication.SetMainPage(namePage);
        }

        #endregion

        #endregion
    }
}
