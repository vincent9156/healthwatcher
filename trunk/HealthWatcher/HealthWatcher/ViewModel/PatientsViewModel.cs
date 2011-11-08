using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthWatcher.ViewModel
{
    class PatientsViewModel : BaseViewModel
    {
        #region attr
        private List<Model.Patient> _patients;
        private Model.Patient _selectPatient;
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
        #endregion

        #region ctor
        public PatientsViewModel()
        {

        }
        #endregion
    }
}
