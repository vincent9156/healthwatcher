using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        #endregion

        #region get/set
        public List<Model.Patient> Patients
        {
            get { return _patients; }
            set { _patients = value; }
        }
        public Model.Patient SelectPatient
        {
            get { return _selectPatient; }
            set { _selectPatient = value; }
        }
        public Model.Observation SelectObservation
        {
            get { return _selectObservation; }
            set { _selectObservation = value; }
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
        #endregion

        #region ctor
        public PatientsViewModel(Model.User currentUser, ViewModel.UsersViewModel uvm)
        {
            DataAccess.AccessPatient ap = new DataAccess.AccessPatient();
            Patients = ap.GetListPatient();
            SelectPatient = Patients[0];
            SelectObservation = Patients[0].Observations[0];
            CurrentUser = currentUser;
            Uvm = uvm;
        }
        #endregion
    }
}
