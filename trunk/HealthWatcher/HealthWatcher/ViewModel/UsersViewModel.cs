using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthWatcher.ViewModel
{
    class UsersViewModel : BaseViewModel
    {
        #region attr
        private Model.User _currentUser;
        private List<Model.User> _users;
        private Model.User _selectUser;
        #endregion

        #region get/set
        public List<Model.User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public Model.User SelectUser
        {
            get { return _selectUser; }
            set { _selectUser = value; }
        }
        public Model.User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        #endregion

        #region ctor
        public UsersViewModel(Model.User currentUser)
        {
            DataAccess.AccessUser au = new DataAccess.AccessUser();
            Users = au.GetListUser();
            CurrentUser = currentUser;
        }
        #endregion
    }
}
