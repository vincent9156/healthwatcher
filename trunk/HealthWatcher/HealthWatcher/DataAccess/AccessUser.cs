using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HealthWatcher.DataAccess
{
    class AccessUser
    {
        #region attr
        private ServRefUser.ServiceUserClient _suc;

        public ServRefUser.ServiceUserClient Suc
        {
            get { return _suc; }
            set { _suc = value; }
        }
        #endregion

        #region ctor
        public AccessUser()
        {
            Suc = new ServRefUser.ServiceUserClient();
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

        private ServRefUser.User convertUser(Model.User user)
        {
            ServRefUser.User newUser = new ServRefUser.User();

            newUser.Login = user.Login;
            newUser.Pwd = user.Pwd;
            newUser.Name = user.Name;
            newUser.Firstname = user.Firstname;
            newUser.Picture = BufferFromImage((BitmapImage) user.Picture.Source);
            newUser.Role = user.Role;
            newUser.Connected = user.Connected;

            return newUser;
        }

        public BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        private Model.User convertUser(ServRefUser.User user)
        {
            Model.User newUser = new Model.User();

            newUser.Login = user.Login;
            newUser.Pwd = user.Pwd;
            newUser.Name = user.Name;
            newUser.Firstname = user.Firstname;
            newUser.Picture = new Image();
            if (user.Picture != null)
                newUser.Picture.Source = ImageFromBuffer(user.Picture);
            newUser.Role = user.Role;
            newUser.Connected = user.Connected;

            return newUser;
        }
        #endregion

        public List<Model.User> GetListUser()
        {
            List<Model.User> newList = new List<Model.User>();

            foreach (ServRefUser.User user in Suc.GetListUser())
            {
                newList.Add(convertUser(user));
            }
            
            return newList;
        }

        public Model.User GetUser(string login)
        {
            foreach (Model.User user in GetListUser())
            {
                if (user.Login == login)
                    return user;
            }
            return null;
        }

        public bool AddUser(Model.User user)
        {
            return Suc.AddUser(convertUser(user));
        }

        public bool DeleteUser(string login)
        {
            return Suc.DeleteUser(login);
        }

        public bool Connect(string login, string pwd)
        {
            return Suc.Connect(login, pwd);
        }

        public void Disconnect(string login)
        {
            Suc.Disconnect(login);
        }
        #endregion
    }
}
