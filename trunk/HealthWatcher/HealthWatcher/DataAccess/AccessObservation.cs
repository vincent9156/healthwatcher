using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthWatcher.Model;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
        public Byte[] BufferFromImage(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
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
                newObs.Pictures[i] = BufferFromImage((BitmapImage) obs.Pictures[i].Source);
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
