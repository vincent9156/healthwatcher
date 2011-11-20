using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HealthWatcher.ViewModel
{
    class UsersViewModel : BaseViewModel
    {
        #region attr
        private Model.User _currentUser;
        private List<Model.User> _users;
        private Model.User _selectUser;
        private bool _closeSignal;
        private string _userRight;
        #endregion

        #region commandes
        private ICommand _addUserCommand;
        private ICommand _removeUserCommand;
        #endregion

        #region get/set
        public List<Model.User> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged("Users");
                }
            }
        }
        public Model.User SelectUser
        {
            get { return _selectUser; }
            set
            {
                if (_selectUser != value)
                {
                    _selectUser = value;
                    OnPropertyChanged("SelectUser");
                }
            }
        }
        public Model.User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        public string UserRight
        {
            get { return _userRight; }
            set { _userRight = value; }
        }
        public ICommand AddUserCommand
        {
            get { return _addUserCommand; }
            set { _addUserCommand = value; }
        }
        public ICommand RemoveUserCommand
        {
            get { return _removeUserCommand; }
            set { _removeUserCommand = value; }
        }
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
        #endregion

        #region ctor
        public UsersViewModel(Model.User currentUser)
        {
            DataAccess.AccessUser au = new DataAccess.AccessUser();
            Users = au.GetListUser();
            CurrentUser = currentUser;
            if (currentUser.Role == "Infirmière")
                UserRight = "False";
            else
                UserRight = "True";
            _addUserCommand = new RelayCommand(param => AddUserAccess(), param => true);
            _removeUserCommand = new RelayCommand(param => RemoveUserAccess(), param => true);
        }
        #endregion

        #region meth
        private void AddUserAccess()
        {
            View.Add.AddUser addUserWindow = new HealthWatcher.View.Add.AddUser();
            ViewModel.Add.AddUserViewModel aumv = new ViewModel.Add.AddUserViewModel(this);
            addUserWindow.DataContext = aumv;
            addUserWindow.Show();
        }

        private void RemoveUserAccess()
        {
            DataAccess.AccessUser access = new DataAccess.AccessUser();
            access.DeleteUser(SelectUser.Login);
            Users = access.GetListUser();
            SelectUser = null;
        }
        #endregion
    }
}
