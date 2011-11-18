using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthWatcher.Model
{
    class Register
    {
        #region attr
        private User _currentUser;
        private ViewModel.PatientsViewModel _pvm;
        private ViewModel.UsersViewModel _uvm;
        public static Register _instance = null;
        #endregion

        #region get/set
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public ViewModel.PatientsViewModel Pvm
        {
            get { return _pvm; }
            set { _pvm = value; }
        }

        public ViewModel.UsersViewModel Uvm
        {
            get { return _uvm; }
            set { _uvm = value; }
        }
        #endregion

        #region ctor
        public Register()
        {
        }
        #endregion

        #region meth
        public static Register getInstance()
        {
            if (_instance == null)
                _instance = new Register();
            return _instance;
        }
        #endregion


    }
}
