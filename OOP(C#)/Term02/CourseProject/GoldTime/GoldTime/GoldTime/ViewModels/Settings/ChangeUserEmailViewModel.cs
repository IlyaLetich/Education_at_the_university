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
using Validator;

namespace GoldTime.ViewModels.Settings
{
    public class ChangeUserEmailViewModel : ViewModelBase
    {
        #region fields

        private string email;
        private string emailError;

        #endregion

        #region propertys
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string EmailError
        {
            get
            {
                return emailError;
            }
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
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

            if ((Email == "" || Email == null) || !ValidatorL.Validate(Email, "Email"))
            {
                EmailError = Application.Current.FindResource("EnterEmailError").ToString();
                check_01 = false;
            }

            if(check_01)
            {
                ControllerApplication.user.Email = Email;
                ControllerApplication.DataBase.UsersRepository.Update(ControllerApplication.user);
                ControllerApplication.ClearFieldsUsersInfo();

                ControllerApplication.User = ControllerApplication.DataBase.UsersRepository.Get(ControllerApplication.user.Id);

                Email = "";
                EmailError = "";
                ControllerApplication.SetSettingsPage("MainSettings");
            }
            else
            {
                EmailError = Application.Current.FindResource("EnterEmailError").ToString();
            }
        }

        #endregion

        #endregion
    }
}
