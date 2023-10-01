using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace GoldTime.ViewModels.Settings
{
    public class ChangeUserNameViewModel : ViewModelBase
    {
        #region fields

        private string name;
        private string nameError;

        #endregion

        #region propertys
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }
        #endregion

        #region commands

        #region save 

        private DelegateCommand? save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new DelegateCommand(SaveUser);
                }
                return save;
            }
        }

        private void SaveUser()
        {
            bool check_01 = true;
            bool check_02 = true;

            if (Name == "" || Name == null)
            {
                NameError = Application.Current.FindResource("EnterNameError").ToString();
                check_01 = false;
            }

            List<User> users = ControllerApplication.DataBase.UsersRepository.GetAll().ToList();

            foreach (var user in users)
            {
                if (user.Name == Name)
                {
                    NameError = Application.Current.FindResource("UserBlock").ToString();
                    check_02 = false;
                }
            }

            if(check_01 && check_02)
            {
                ControllerApplication.user.Name = Name;
                ControllerApplication.DataBase.UsersRepository.Update(ControllerApplication.user);

                ControllerApplication.User = ControllerApplication.DataBase.UsersRepository.Get(ControllerApplication.user.Id);
                ControllerApplication.ClearFieldsUsersInfo();

                Name = "";
                NameError = "";
                ControllerApplication.SetSettingsPage("MainSettings");
            }
        }

        #endregion

        #endregion
    }
}
