using GoldTime.Models;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using GoldTime.Views.MainView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoldTime.ViewModels.MainViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region fields

        private Page mainPageBack = null;
        private Page mainPageFront = null;

        #endregion

        #region constructors
        public MainViewModel()
        {

        }

        #endregion

        #region properties

        #region main page view
        public Page MainPageBack
        {
            get { return mainPageBack; }
            set
            {
                if (mainPageBack == value)
                    return;

                mainPageBack = value;
                OnPropertyChanged("MainPageBack");
            }
        }
        public Page MainPageFront
        {
            get { return mainPageFront; }
            set
            {
                if (mainPageFront == value)
                    return;

                mainPageFront = value;
                OnPropertyChanged("MainPageFront");
            }
        }
        #endregion

        #endregion

        #region commands

        #region control main view

        #region close main view
        private DelegateCommand? closeMainView;

        public ICommand CloseMainView
        {
            get
            {
                if (closeMainView == null)
                {
                    closeMainView = new DelegateCommand(CloseMainViewWindow);
                }
                return closeMainView;
            }
        }

        private void CloseMainViewWindow()
        {
            App.Current.Shutdown();
        }
        #endregion

        #region open full screen main view
        private DelegateCommand? openFullScreen;

        public ICommand OpenFullScreen
        {
            get
            {
                if (openFullScreen == null)
                {
                    openFullScreen = new DelegateCommand(OpenFullScreenWindow);
                }
                return openFullScreen;
            }
        }

        private void OpenFullScreenWindow()
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }
        #endregion

        #region hide main view
        private DelegateCommand? hideMainView;

        public ICommand HideMainView
        {
            get
            {
                if (hideMainView == null)
                {
                    hideMainView = new DelegateCommand(HideMainViewWindow);
                }
                return hideMainView;
            }
        }

        private void HideMainViewWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion

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
