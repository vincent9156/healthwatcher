using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HealthWatcher.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region attr
        private DataAccess.AccessUser _dataAccessUser = null;
        private bool _closeSignal;
        private string _login;
        private string _password;
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
            //init variables
            base.DisplayName = "Page de login";
            Login = "";
            Password = "";

            _dataAccessUser = new HealthWatcher.DataAccess.AccessUser();

            //commandes
            _loginCommand = new RelayCommand(param => LoginAccess(), param => true);
        }
        #endregion

        #region meth
        private void LoginAccess()
        {
            View.Patients patientsWindow = new HealthWatcher.View.Patients();
            View.Users usersWindow = new HealthWatcher.View.Users();

            patientsWindow.Left = 0;
            patientsWindow.Top = 0;
            usersWindow.Left = 610;
            usersWindow.Top = 0;


            patientsWindow.Show();
            usersWindow.Show();
            CloseSignal = true;
        }
        #endregion
    }
}
