using Encoder;
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

namespace GoldTime.ViewModels.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        #region fields

        private string name;
        private string password;
        private string nameError;
        private string passwordError;


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
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
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
        public string PasswordError
        {
            get
            {
                return passwordError;
            }
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }
        #endregion

        #region commands

        #region login application

        private DelegateCommand? loginApplication;

        public ICommand LoginApplication
        {
            get
            {
                if (loginApplication == null)
                {
                    loginApplication = new DelegateCommand(LoginApplicationEnter);
                }
                return loginApplication;
            }
        }

        private void LoginApplicationEnter()
        {
            bool check_01 = true;
            bool check_02 = true;
            bool check_03 = false;

            if (Name == "" || Name == null)
            {

                NameError = Application.Current.FindResource("EnterNameError").ToString();
                check_01 = false;
            }
            if(Password == "" || Password == null)
            {

                PasswordError = Application.Current.FindResource("EnterPasswordError").ToString();
                check_02 = false;
            }

            if(check_01 && check_02)
            {
                List<User> users = ControllerApplication.DataBase.UsersRepository.GetAll().ToList();
                foreach (User user in users)
                {
                    if(user.Name == name && EncoderL.VerifyPassword(Password,user.Password))
                    {
                        ControllerApplication.User = ControllerApplication.DataBase.UsersRepository.Get(user.Id);
                        PasswordError = "";
                        NameError = "";
                        check_03 = true;
                    }
                }
            }
            if(check_01 && check_02)
            {
                if(check_03)
                {
                    Name = "";
                    Password = "";
                    NameError = "";
                    PasswordError = "";
                    ControllerApplication.authenticationView.Hide();
                    App.StartMainView();
                    ControllerApplication.ClearFieldsUsersInfo();
                }
                else
                {
                    PasswordError = "";
                    NameError = Application.Current.FindResource("UserError").ToString();
                }
            }
            
        }

        #endregion

        #region set authentication page

        private DelegateCommand<string>? setAuthenticationPage;

        public ICommand SetAuthenticationPage
        {
            get
            {
                if (setAuthenticationPage == null)
                {
                    setAuthenticationPage = new DelegateCommand<string>(SetAuthenticationPageView);
                }
                return setAuthenticationPage;
            }
        }

        private void SetAuthenticationPageView(string namePage)
        {
            ControllerApplication.SetAuthenticationPage(namePage);
        }

        #endregion

        #endregion
    }
}
