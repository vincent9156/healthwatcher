using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HealthWatcher.ViewModel.Add
{
    class AddPatientViewModel : BaseViewModel
    {
        #region attr
        private Model.Patient _patient;
        private PatientsViewModel _pvm;
        private ICommand _addCommand;
        private bool _closeSignal;
        #endregion

        #region get/set
        public Model.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
        public PatientsViewModel Pvm
        {
            get { return _pvm; }
            set { _pvm = value; }
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
        public AddPatientViewModel(PatientsViewModel pvm)
        {
            Patient = new Model.Patient();
            Patient.Birthday = DateTime.Now;
            Pvm = pvm;
            _addCommand = new RelayCommand(param => AddAccess(), param => true);
        }
        #endregion

        #region meth
        private void AddAccess()
        {
            DataAccess.AccessPatient access = new DataAccess.AccessPatient();
            access.AddPatient(Patient);
            Pvm.Patients = access.GetListPatient();
            CloseSignal = true;
        }
        #endregion
    }
}
