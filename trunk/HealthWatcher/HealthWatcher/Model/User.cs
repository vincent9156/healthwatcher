using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HealthWatcher.Model
{
    class User
    {
        #region attr
        private string _login;
        private string _pwd;
        private string _name;
        private string _firstname;
        private Image _picture;
        private string _role;
        private bool _connected;
        #endregion

        #region get/set
        /// <summary>
        /// indique si l'utilisateur est connecté
        /// </summary>
        public bool Connected
        {
            get { return _connected; }
            set { _connected = value; }
        }

        /// <summary>
        /// role de l'utilisateur
        /// </summary>
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        /// <summary>
        /// photos de l'utilisateur
        /// </summary>
        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; }
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

        /// <summary>
        /// mot de passe
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        /// <summary>
        /// login
        /// </summary>
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        #endregion
    }
}
