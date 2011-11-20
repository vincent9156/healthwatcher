using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthWatcher.Model;
using System.Drawing;
using System.IO;

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
        private Byte[] ImagetoStream(Image img)
        {
            try
            {
                MemoryStream mstImage = new MemoryStream();
                img.Save(mstImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytImage = mstImage.GetBuffer();
                return bytImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private ServRefObservation.Observation convertObs(Observation obs)
        {
            ServRefObservation.Observation newObs = new ServRefObservation.Observation();

            newObs.BloodPressure = obs.BloodPressure;
            newObs.Weight = obs.Weight;
            newObs.Comment = obs.Comment;
            newObs.Date = obs.Date;
            for (int i = 0; i < obs.Pictures.Count(); i++)
            {
                newObs.Pictures[i] = ImagetoStream(obs.Pictures[i]);
            }
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
