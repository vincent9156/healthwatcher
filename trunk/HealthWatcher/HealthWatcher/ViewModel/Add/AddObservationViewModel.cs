using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace HealthWatcher.ViewModel.Add
{
    class AddObservationViewModel : BaseViewModel
    {
        #region attr
        private DateTime _date;
        private string _comment;
        private List<string> _prescription;
        private List<Image> _pictures;
        private int _weight;
        private int _bloodPressure;

        private Model.Patient _patient;
        private string _currentPrescription;
        private string _selectPrescription;
        private Image _selectPicture;
        private PatientsViewModel _pvm;
        private bool _closeSignal;
        #endregion

        #region commandes
        private ICommand _addPrescriptionCommand;
        private ICommand _removePrescriptionCommand;
        private ICommand _addPictureCommand;
        private ICommand _removePictureCommand;
        private ICommand _addCommand;
        #endregion

        #region get/set
        /// <summary>
        /// poids du patient
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /// <summary>
        /// pression artérielle du patient
        /// </summary>
        public int BloodPressure
        {
            get { return _bloodPressure; }
            set { _bloodPressure = value; }
        }

        /// <summary>
        /// images associées à l'observations
        /// </summary>
        public List<Image> Pictures
        {
            get { return _pictures; }
            set
            {
                if (_pictures != value)
                {
                    _pictures = value;
                    OnPropertyChanged("Pictures");
                }
            }
        }

        /// <summary>
        /// liste des prescriptions pour l'observation
        /// </summary>
        public List<string> Prescription
        {
            get { return _prescription; }
            set
            {
                if (_prescription != value)
                {
                    _prescription = value;
                    OnPropertyChanged("Prescription");
                }
            }
        }

        /// <summary>
        /// commentaire
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        /// <summary>
        /// date de l'observation
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

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
        public string CurrentPrescription
        {
            get { return _currentPrescription; }
            set
            {
                if (_currentPrescription != value)
                {
                    _currentPrescription = value;
                    OnPropertyChanged("CurrentPrescription");
                }
            }
        }
        public string SelectPrescription
        {
            get { return _selectPrescription; }
            set { _selectPrescription = value; }
        }
        public Image SelectPicture
        {
            get { return _selectPicture; }
            set
            {
                if (_selectPicture != value)
                {
                    _selectPicture = value;
                    OnPropertyChanged("SelectPicture");
                }
            }
        }

        public ICommand AddPrescriptionCommand
        {
            get { return _addPrescriptionCommand; }
            set { _addPrescriptionCommand = value; }
        }
        public ICommand RemovePrescriptionCommand
        {
            get { return _removePrescriptionCommand; }
            set { _removePrescriptionCommand = value; }
        }
        public ICommand AddPictureCommand
        {
            get { return _addPictureCommand; }
            set { _addPictureCommand = value; }
        }
        public ICommand RemovePictureCommand
        {
            get { return _removePictureCommand; }
            set { _removePictureCommand = value; }
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
        public AddObservationViewModel(Model.Patient patient, PatientsViewModel pvm)
        {
            Date = DateTime.Now;
            Comment = "";
            Prescription = new List<string>();
            Pictures = new List<Image>();


            Patient = patient;
            Pvm = pvm;

            _addPrescriptionCommand = new RelayCommand(param => AddPrescriptionAccess(), param => true);
            _removePrescriptionCommand = new RelayCommand(param => RemovePrescriptionAccess(), param => true);
            _addPictureCommand = new RelayCommand(param => AddPictureAccess(), param => true);
            _removePictureCommand = new RelayCommand(param => RemovePictureAccess(), param => true);
            _addCommand = new RelayCommand(param => AddAccess(), param => true);
        }
        #endregion

        #region meth
        private void AddPrescriptionAccess()
        {
            List<string> temp = new List<string>();
            foreach (string presc in Prescription)
            {
                temp.Add(presc);
            }
            temp.Add(CurrentPrescription);
            CurrentPrescription = "";
            Prescription = temp;
        }

        private void RemovePrescriptionAccess()
        {
            List<string> temp = new List<string>();
            foreach (string presc in Prescription)
            {
                temp.Add(presc);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (SelectPrescription == temp[i])
                    temp.Remove(SelectPrescription);
            }
            Prescription = temp;
        }

        private void AddPictureAccess()
        {
            OpenFileDialog fDialog = new OpenFileDialog();

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(fDialog.FileName));
                List<Image> temp = new List<Image>();
                foreach (Image pic in Pictures)
                {
                    temp.Add(pic);
                }
                temp.Add(img);
                Pictures = temp;
                SelectPicture = img;
            }
        }

        private void RemovePictureAccess()
        {
            List<Image> temp = new List<Image>();
            foreach (Image pic in Pictures)
            {
                temp.Add(pic);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (SelectPicture == temp[i])
                    temp.Remove(SelectPicture);
            }
            Pictures = temp;
        }

        private void AddAccess()
        {
            DataAccess.AccessObservation accessObsv = new DataAccess.AccessObservation();
            accessObsv.AddObservation(Patient.Id, new Model.Observation(Date, Comment, Prescription, Pictures, BloodPressure, Weight));
            DataAccess.AccessPatient accessPatient = new DataAccess.AccessPatient();
            Pvm.Patients = accessPatient.GetListPatient();
            CloseSignal = true;
        }
        #endregion
    }
}
