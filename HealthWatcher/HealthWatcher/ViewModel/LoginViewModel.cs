﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;

namespace HealthWatcher.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region attr
        private DataAccess.AccessUser _dataAccessUser = null;
        private bool _closeSignal;
        private string _login;
        private string _password;
        private string _loginFail;
        #endregion

        #region commandes
        private ICommand _loginCommand;
        #endregion

        #region getter / setter
        /// <summary>
        /// mot de passe de la personne
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string LoginFail
        {
            get { return _loginFail; }
            set
            {
                if (_loginFail != value)
                {
                    _loginFail = value;
                    OnPropertyChanged("LoginFail");
                }
            }
        }

        /// <summary>
        /// indique si on doit fermer la fenêtre ou non
        /// </summary>
        public bool CloseSignal
        {
            get { return _closeSignal; }
            set
            {
                if (_closeSignal != value)
                {
                    _closeSignal = value;
                    OnPropertyChanged("CloseSignal");
                }
            }
        }

        /// <summary>
        /// command pour s'authentifier
        /// </summary>
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { _loginCommand = value; }
        }

        #endregion

        #region ctor
        public LoginViewModel()
        {
            // init position

            //init variables
            base.DisplayName = "Page de login";
            Login = "";
            Password = "";
            LoginFail = "";

            _dataAccessUser = new HealthWatcher.DataAccess.AccessUser();

            //commandes
            _loginCommand = new RelayCommand(param => LoginAccess(), param => true);
        }
        #endregion

        #region meth
        private void LoginAccess()
        {
            DataAccess.AccessUser au = new DataAccess.AccessUser();
            Model.User currentUser = new Model.User();
            if (Login != "" && ((currentUser = au.GetUser(Login)) != null))
            {
                if (Password != "" && (Password == currentUser.Pwd))
                {
                    View.Patients patientsWindow = new HealthWatcher.View.Patients();
                    View.Users usersWindow = new HealthWatcher.View.Users();

                    au.Connect(currentUser.Login, currentUser.Pwd);

                    ViewModel.PatientsViewModel pvm = new ViewModel.PatientsViewModel(currentUser);
                    ViewModel.UsersViewModel uvm = new ViewModel.UsersViewModel(currentUser);
                    pvm.Uvm = uvm;
                    uvm.Pvm = pvm;

                    // Ne fonctionne pas sous résolution 800*600 :(
                    patientsWindow.Left = (Screen.PrimaryScreen.Bounds.Width * 72 / 96) / 2 - 400;
                    patientsWindow.Top = (Screen.PrimaryScreen.Bounds.Height * 72 / 96) / 2 - 300;
                    usersWindow.Left = (Screen.PrimaryScreen.Bounds.Width / 2 * 72 / 96) + 200;
                    usersWindow.Top = (Screen.PrimaryScreen.Bounds.Height / 2 * 72 / 96) - 300;
                    

                    usersWindow.DataContext = uvm;
                    patientsWindow.DataContext = pvm;
                    patientsWindow.Show();
                    usersWindow.Show();

                    CloseSignal = true;
                }
            }
            else
            {
                LoginFail = "Wrong Login or Password";
            }
        }
        #endregion
    }
}
