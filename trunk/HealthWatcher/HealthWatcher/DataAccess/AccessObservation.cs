using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthWatcher.Model;

namespace HealthWatcher.DataAccess
{
    class AccessObservation
    {
        #region attr
        private ServRefObservation.ServiceObservationClient _soc;

        public ServRefObservation.ServiceObservationClient Soc
        {
            get { return _soc; }
            set { _soc = value; }
        }
        
        #endregion

        #region ctor
        public AccessObservation()
        {
            Soc = new ServRefObservation.ServiceObservationClient();
        }
        #endregion

        #region meth
        #region convert
        private ServRefObservation.Observation convertObs(Observation obs)
        {
            ServRefObservation.Observation newObs = new ServRefObservation.Observation();

            newObs.BloodPressure = obs.BloodPressure;
            newObs.Weight = obs.Weight;
            newObs.Comment = obs.Comment;
            newObs.Date = obs.Date;
            newObs.Pictures = obs.Pictures;
            newObs.Prescription = obs.Prescription;

            return newObs;
        }
        #endregion

        public bool AddObservation(int idPatient, Observation obs)
        {
            return Soc.AddObservation(idPatient, convertObs(obs));
        }
        #endregion
    }
}
