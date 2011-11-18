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
        private String _loginFail;
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

        public String LoginFail
        {
            get { return _loginFail; }
            set { _loginFail = value; }
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
            LoginFail = "Hidden";

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
                    ViewModel.PatientsViewModel pmv = new ViewModel.PatientsViewModel();
                    ViewModel.UsersViewModel umv = new ViewModel.UsersViewModel();
                    Model.Register reg = Model.Register.getInstance();
                    reg.CurrentUser = currentUser;
                    reg.Pvm = pmv;
                    reg.Uvm = umv;

                    patientsWindow.Left = 0;
                    patientsWindow.Top = 0;
                    usersWindow.Left = 600;
                    usersWindow.Top = 0;

                    patientsWindow.DataContext = pmv;
                    usersWindow.DataContext = umv;
                    patientsWindow.Show();
                    usersWindow.Show();
                    CloseSignal = true;
                }
                else
                {
                }
            }
            else
            {
                LoginFail = "Visible";
            }
        }
        #endregion
    }
}
