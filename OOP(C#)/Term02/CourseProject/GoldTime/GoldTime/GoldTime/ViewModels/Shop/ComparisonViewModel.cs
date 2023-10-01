using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoldTime.ViewModels.Shop
{
    public class ComparisonViewModel : ViewModelBase
    {
        #region fields

        private List<Watch> watches;
        private Watch selectedWatch;

        #endregion

        #region constructors

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
        public Watch SelectedWatch
        {
            get
            {
                return selectedWatch;
            }
            set
            {
                selectedWatch = value;
                OnPropertyChanged("SelectedWatch");
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
            ComparisonWatches comparisonWatches = ControllerApplication.user.ComparisonWatches;
            comparisonWatches.Watches.Remove(ControllerApplication.DataBase.WatchesRepository.Get(this.selectedWatch.Id));

            ControllerApplication.DataBase.ComparisonWatchesRepository.Update(comparisonWatches);

            ControllerApplication.UpdateInformationDataBase();
        }

        #endregion

        #endregion
    }
}
