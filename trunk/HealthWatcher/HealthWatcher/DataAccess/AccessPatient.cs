﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace HealthWatcher.DataAccess
{
    class AccessPatient
    {
        #region attr
        private ServRefPatient.ServicePatientClient _spc;

        public ServRefPatient.ServicePatientClient Spc
        {
            get { return _spc; }
            set { _spc = value; }
        }
        
        
        #endregion

        #region ctor
        public AccessPatient()
        {
            Spc = new ServRefPatient.ServicePatientClient();
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

        private ServRefPatient.Observation convertObs(Model.Observation obs)
        {
            ServRefPatient.Observation newObs = new ServRefPatient.Observation();

            newObs.BloodPressure = obs.BloodPressure;
            newObs.Weight = obs.Weight;
            newObs.Comment = obs.Comment;
            newObs.Date = obs.Date;
            if (obs.Pictures != null)
            {
                for (int i = 0; i < obs.Pictures.Count(); i++)
                {
                    newObs.Pictures[i] = ImagetoStream(obs.Pictures[i]);
                }
            }
            newObs.Prescription = obs.Prescription;

            return newObs;
        }

        private Image StreamToImage(byte[] buff)
        {
            try
            {
                MemoryStream ms = new MemoryStream(buff);
                Image img = Image.FromStream(ms);
                return img;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Model.Observation convertObs(ServRefPatient.Observation obs)
        {
            Model.Observation newObs = new Model.Observation();

            newObs.BloodPressure = obs.BloodPressure;
            newObs.Weight = obs.Weight;
            newObs.Comment = obs.Comment;
            newObs.Date = obs.Date;
            if (obs.Pictures != null && newObs.Pictures != null)
            {
                for (int i = 0; i < obs.Pictures.Count(); i++)
                {
                    newObs.Pictures[i] = StreamToImage(obs.Pictures[i]);
                }
            }
            newObs.Prescription = obs.Prescription;

            return newObs;
        }

        private ServRefPatient.Patient convertPat(Model.Patient pat)
        {
            ServRefPatient.Patient newPat = new ServRefPatient.Patient();

            newPat.Birthday = pat.Birthday;
            newPat.Firstname = pat.Firstname;
            newPat.Name = pat.Name;
            if (pat.Observations != null)
            {
                int i = 0;
                foreach (Model.Observation observ in pat.Observations)
                {
                    newPat.Observations[i++] = convertObs(observ);
                }
            }
            newPat.Id = pat.Id;

            return newPat;
        }

        private Model.Patient convertPat(ServRefPatient.Patient pat)
        {
            Model.Patient newPat = new Model.Patient();

            newPat.Birthday = pat.Birthday;
            newPat.Firstname = pat.Firstname;
            newPat.Name = pat.Name;
            if (pat.Observations != null)
            {
                newPat.Observations = new List<Model.Observation>();
                foreach (ServRefPatient.Observation observ in pat.Observations)
                {
                    newPat.Observations.Add(convertObs(observ));
                }
            }
            newPat.Id = pat.Id;

            return newPat;
        }
        #endregion convert

        public List<Model.Patient> GetListPatient()
        {
            List<Model.Patient> newList = new List<Model.Patient>();

            foreach (ServRefPatient.Patient patient in Spc.GetListPatient())
            {
                newList.Add(convertPat(patient));
            }
            Spc.GetListPatient();

            return newList; 
        }

        public Model.Patient GetPatient(int id)
        {
            return convertPat(Spc.GetPatient(id));
        }

        public bool AddPatient(Model.Patient pat)
        {
            return Spc.AddPatient(convertPat(pat));
        }

        public bool DeletePatient(int id)
        {
            return Spc.DeletePatient(id);
        }

        #endregion
    }
}
