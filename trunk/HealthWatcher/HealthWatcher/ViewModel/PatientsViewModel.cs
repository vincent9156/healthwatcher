using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HealthWatcher.ViewModel
{
    class PatientsViewModel : BaseViewModel
    {
        #region attr
        private Model.User _currentUser;
        private ViewModel.UsersViewModel _uvm;
        private List<Model.Patient> _patients;
        private Model.Patient _selectPatient;
        private Model.Observation _selectObservation;
        private int _bloodPressure;
        private int _temperature;
        private string _userRight;
        private bool _closeSignal;
        #endregion

        #region commandes
        private ICommand _logoutCommand;
        private ICommand _addPatientCommand;
        private ICommand _removePatientCommand;
        private ICommand _addObservationCommand;
        private ICommand _removeObservationCommand;
        #endregion

        #region get/set
        public List<Model.Patient> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients != value)
                {
                    _patients = value;
                    OnPropertyChanged("Patients");
                }
            }
        }
        public Model.Patient SelectPatient
        {
            get { return _selectPatient; }
            set
            {
                if (_selectPatient != value)
                {
                    _selectPatient = value;
                    OnPropertyChanged("SelectPatient");
                }
            }
        }
        public Model.Observation SelectObservation
        {
            get { return _selectObservation; }
            set
            {
                if (_selectObservation != value)
                {
                    _selectObservation = value;
                    OnPropertyChanged("SelectObservation");
                }
            }
        }
        public int Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public int BloodPressure
        {
            get { return _bloodPressure; }
            set { _bloodPressure = value; }
        }
        public Model.User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        public ViewModel.UsersViewModel Uvm
        {
            get { return _uvm; }
            set { _uvm = value; }
        }
        public string UserRight
        {
            get { return _userRight; }
            set { _userRight = value; }
        }
        public ICommand LogoutCommand
        {
            get { return _logoutCommand; }
            set { _logoutCommand = value; }
        }
        public ICommand AddPatientCommand
        {
            get { return _addPatientCommand; }
            set { _addPatientCommand = value; }
        }
        public ICommand RemovePatientCommand
        {
            get { return _removePatientCommand; }
            set { _removePatientCommand = value; }
        }
        public ICommand AddObservationCommand
        {
            get { return _addObservationCommand; }
            set { _addObservationCommand = value; }
        }
        public ICommand RemoveObservationCommand
        {
            get { return _removeObservationCommand; }
            set { _removeObservationCommand = value; }
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
        public PatientsViewModel(Model.User currentUser, ViewModel.UsersViewModel uvm)
        {
            DataAccess.AccessPatient ap = new DataAccess.AccessPatient();
            Patients = ap.GetListPatient();
            if (Patients != null && Patients.Count > 0)
                SelectPatient = Patients[0];
            if (Patients[0].Observations != null && Patients[0].Observations.Count > 0)
                SelectObservation = Patients[0].Observations[0];
            CurrentUser = currentUser;
            Uvm = uvm;

            //ServRefLive.ServiceLiveClient slc = new ServRefLive.ServiceLiveClient(new System.ServiceModel.InstanceContext(new DataAccess.MyServiceClient()));
            //slc.Subscribe();

            if (currentUser.Role == "Infirmière")
                UserRight = "False";
            else
                UserRight = "True";

            //commandes
            _logoutCommand = new RelayCommand(param => LogoutAccess(), param => true);
            _addPatientCommand = new RelayCommand(param => AddPatientAccess(), param => true);
            _removePatientCommand = new RelayCommand(param => RemovePatientAccess(), param => true);
            _addObservationCommand = new RelayCommand(param => AddObservationAccess(), param => true);
        }
        #endregion

        #region meth
        private void LogoutAccess()
        {
            View.Login loginWindow = new HealthWatcher.View.Login();
            ViewModel.LoginViewModel lmv = new ViewModel.LoginViewModel();
            loginWindow.DataContext = lmv;
            loginWindow.Show();

            Uvm.CloseSignal = true;
            CloseSignal = true;
        }

        private void AddPatientAccess()
        {
            View.Add.AddPatient addPatientWindow = new HealthWatcher.View.Add.AddPatient();
            ViewModel.Add.AddPatientViewModel apmv = new ViewModel.Add.AddPatientViewModel(this);
            addPatientWindow.DataContext = apmv;
            addPatientWindow.Show();
        }

        private void RemovePatientAccess()
        {
            DataAccess.AccessPatient access = new DataAccess.AccessPatient();
            access.DeletePatient(SelectPatient.Id);
            Patients = access.GetListPatient();
            SelectPatient = null;
        }

        private void AddObservationAccess()
        {
            View.Add.AddObservation addObservationWindow = new HealthWatcher.View.Add.AddObservation();
            ViewModel.Add.AddObservationViewModel aomv = new ViewModel.Add.AddObservationViewModel(SelectPatient, this);
            addObservationWindow.DataContext = aomv;
            addObservationWindow.Show();
        }
        #endregion
    }
}
