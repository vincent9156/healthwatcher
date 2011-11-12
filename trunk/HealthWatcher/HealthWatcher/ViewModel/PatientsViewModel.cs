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
        #endregion

        #region ctor
        public PatientsViewModel()
        {
            SelectPatient = null;
            SelectObservation = null;
            CurrentUser = null;
        }
        #endregion
    }
}
