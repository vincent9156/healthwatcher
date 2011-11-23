using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthWatcher.Model
{
    class Patient
    {
        #region attr
        private string _name;
        private string _firstname;
        private DateTime _birthday;
        private int _id;
        private List<Observation> _observations;
        #endregion

        #region get/set
        /// <summary>
        /// liste des observatiosn pour un patient
        /// </summary>
        public List<Observation> Observations
        {
            get { return _observations; }
            set { _observations = value; }
        }

        /// <summary>
        /// id du patient
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Date de naissance
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// prénom
        /// </summary>
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        /// <summary>
        /// nom
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion
    }
}
