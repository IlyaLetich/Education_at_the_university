using GoldTime.Models;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GoldTime.Utilities;
using System.Windows.Controls;

namespace GoldTime.ViewModels.AdminPanel
{
    public class AdminPanelViewModel : ViewModelBase
    {
        #region fields

        private Page adminPanelPage = null;

        #endregion

        #region constructors

        #endregion

        #region properties

        public Page AdminPanelPage
        {
            get { return adminPanelPage; }
            set
            {
                if (adminPanelPage == value)
                    return;

                adminPanelPage = value;
                OnPropertyChanged("AdminPanelPage");
            }
        }

        #endregion

        #region commands

        #region set admin panel page

        private DelegateCommand<string>? setAdminPanelPage;

        public ICommand SetAdminPanelPage
        {
            get
            {
                if (setAdminPanelPage == null)
                {
                    setAdminPanelPage = new DelegateCommand<string>(SetAdminPanelPageView);
                }
                return setAdminPanelPage;
            }
        }

        private void SetAdminPanelPageView(string namePage)
        {
            ControllerApplication.SetAdminPage(namePage);
        }

        #endregion

        #endregion
    }
}
