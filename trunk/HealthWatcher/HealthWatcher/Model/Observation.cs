using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthWatcher.Model
{
    class Observation
    {
        #region attr
        private DateTime _date;
        private string _comment;
        private string[] _prescription;
        private Byte[][] _pictures;
        private int _weight;

        private int _bloodPressure;


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
        public Byte[][] Pictures
        {
            get { return _pictures; }
            set { _pictures = value; }
        }

        /// <summary>
        /// liste des prescriptions pour l'observation
        /// </summary>
        public string[] Prescription
        {
            get { return _prescription; }
            set { _prescription = value; }
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
        #endregion
    }
}
