using Encoder;
using Validator;
using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GoldTime.ViewModels.Authentication
{
    public class RegistrationViewModel : ViewModelBase
    {
        #region fields

        private string name;
        private string email;
        private string password1;
        private string password2;

        private string nameError;
        private string emailError;
        private string passwordError1;
        private string passwordError2;

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

        #region register application

        private DelegateCommand? registerApplication;

        public ICommand RegisterApplication
        {
            get
            {
                if (registerApplication == null)
                {
                    registerApplication = new DelegateCommand(RegisterApplicationEnter);
                }
                return registerApplication;
            }
        }

        private void RegisterApplicationEnter()
        {

            bool check_01 = true;
            bool check_02 = true;
            bool check_03 = true;
            bool check_04 = true;
            bool check_05 = false;
            bool check_06 = true;

            if (Name == "" || Name == null)
            {
                NameError = Application.Current.FindResource("EnterNameError").ToString();
                check_01 = false;
            }
            if ((Email == "" || Email == null) || !ValidatorL.Validate(Email, "Email")) 
            {
                EmailError = Application.Current.FindResource("EnterEmailError").ToString();
                check_02 = false;
            }
            if (Password1 == "" || Password1 == null)
            {
                PasswordError1 = Application.Current.FindResource("EnterPasswordError").ToString();
                check_03 = false;
            }
            if (Password2 == "" || Password2 == null)
            {
                PasswordError2 = Application.Current.FindResource("EnterPasswordError2").ToString();
                check_04 = false;
            }
            if (check_02)
                EmailError = "";
            if (check_01)
                NameError = "";
            if (check_03 && check_04)
            {
                if(Password1 == Password2)
                {
                    check_05 = true;
                }
                else
                {
                    if (check_02)
                        EmailError = "";
                    if (check_01)
                        NameError = "";

                    Password1 = "";
                    PasswordError2 = Application.Current.FindResource("EnterPasswordErrorNoSov").ToString();
                }
            }

            List<User> users = ControllerApplication.DataBase.UsersRepository.GetAll().ToList();

            foreach(var user in users)
            {
                if(user.Name == Name)
                {
                    NameError = Application.Current.FindResource("UserBlock").ToString();
                    check_06 = false;
                }
            }

            if (check_01 && check_02 && check_03 && check_04 && check_05 && check_06)
            {
                User user = new User(Name,Email,EncoderL.HashPassword(password1));
                ControllerApplication.DataBase.UsersRepository.Create(user);
                ControllerApplication.UpdateInformationDataBase();

                List<User> usersCollection = ControllerApplication.DataBase.UsersRepository.GetAll().ToList();

                foreach (var item in usersCollection)
                {
                    if (item.Name == Name)
                    {
                        Name = "";
                        Email = "";
                        NameError = "";
                        EmailError = "";
                        Password1 = "";
                        Password2 = "";
                        PasswordError1 = "";
                        PasswordError2 = "";
                        ControllerApplication.User = item;
                        ControllerApplication.UpdateInformationDataBase();
                        ControllerApplication.authenticationView.Hide();
                        App.StartMainView();
                        ControllerApplication.ClearFieldsUsersInfo();
                    }
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
