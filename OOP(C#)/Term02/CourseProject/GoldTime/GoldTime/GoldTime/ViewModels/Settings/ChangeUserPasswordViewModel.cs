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
using System.Windows.Input;

namespace GoldTime.ViewModels.Settings
{
    public class ChangeUserPasswordViewModel : ViewModelBase
    {
        #region fields

        private string password1;
        private string password2;

        private string passwordError1;
        private string passwordError2;

        #endregion

        #region propertys

        public string Password1
        {
            get
            {
                return password1;
            }
            set
            {
                password1 = value;
                OnPropertyChanged("Password1");
            }
        }
        public string Password2
        {
            get
            {
                return password2;
            }
            set
            {
                password2 = value;
                OnPropertyChanged("Password2");
            }
        }
        public string PasswordError1
        {
            get
            {
                return passwordError1;
            }
            set
            {
                passwordError1 = value;
                OnPropertyChanged("PasswordError1");
            }
        }
        public string PasswordError2
        {
            get
            {
                return passwordError2;
            }
            set
            {
                passwordError2 = value;
                OnPropertyChanged("PasswordError2");
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
            bool check_03 = true;

            if (Password1 == "" || Password1 == null)
            {
                PasswordError1 = Application.Current.FindResource("EnterPasswordError").ToString();
                check_01 = false;
            }
            if (Password2 == "" || Password2 == null)
            {
                PasswordError2 = Application.Current.FindResource("EnterPasswordError2").ToString();
                check_02 = false;
            }
            if (Password1 == Password2)
            {
                if(check_01 && check_02)
                {
                    ControllerApplication.user.Password = Encoder.EncoderL.HashPassword(Password1);
                    ControllerApplication.DataBase.UsersRepository.Update(ControllerApplication.user);

                    Password1 = "";
                    Password2 = "";

                    PasswordError1 = "";
                    PasswordError2 = "";
                    ControllerApplication.ClearFieldsUsersInfo();
                    ControllerApplication.SetSettingsPage("MainSettings");
                }
            }
            else
            {
                Password1 = "";
                PasswordError2 = Application.Current.FindResource("EnterPasswordErrorNoSov").ToString();
            }
        }

        #endregion

        #endregion
    }
}
