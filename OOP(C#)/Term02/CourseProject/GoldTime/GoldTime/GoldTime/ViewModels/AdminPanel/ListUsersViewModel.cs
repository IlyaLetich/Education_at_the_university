using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldTime.Utilities;

namespace GoldTime.ViewModels.AdminPanel
{
    public class ListUsersViewModel : ViewModelBase
    {
        #region fields

        private List<User> users;

        #endregion

        #region constructors

        public ListUsersViewModel()
        {
            this.Users = ControllerApplication.DataBase.UsersRepository.GetAll().ToList();
        }

        #endregion

        #region propertys

        public List<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        #endregion
    }
}
