using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace HealthWatcher.ViewModel.Add
{
    class AddUserViewModel : BaseViewModel
    {
        #region attr
        private Model.User _user;
        private UsersViewModel _uvm;
        
        private bool _closeSignal;
        #endregion

        #region commandes
        private ICommand _addPictureCommand;
        private ICommand _addCommand;
        #endregion

        #region get/set
        public Model.User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }
        public UsersViewModel Uvm
        {
            get { return _uvm; }
            set { _uvm = value; }
        }
        public ICommand AddPictureCommand
        {
            get { return _addPictureCommand; }
            set { _addPictureCommand = value; }
        }
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
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
        public AddUserViewModel(UsersViewModel uvm)
        {
            User = new Model.User();
            User.Connected = false;
            User.Picture = new Image();
            Uvm = uvm;

            _addPictureCommand = new RelayCommand(param => AddPictureAccess(), param => true);
            _addCommand = new RelayCommand(param => AddAccess(), param => true);
        }
        #endregion

        #region meth
        private void AddPictureAccess()
        {
            OpenFileDialog fDialog = new OpenFileDialog();

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                User.Picture.Source = new BitmapImage(new Uri(fDialog.FileName));
            }
        }

        private void AddAccess()
        {
            DataAccess.AccessUser access = new DataAccess.AccessUser();
            access.AddUser(User);
            Uvm.Users = access.GetListUser();
            CloseSignal = true;
        }
        #endregion
    }
}
