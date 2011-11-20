using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Drawing;

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

        private ServRefUser.User convertUser(Model.User user)
        {
            ServRefUser.User newUser = new ServRefUser.User();

            newUser.Login = user.Login;
            newUser.Pwd = user.Pwd;
            newUser.Name = user.Name;
            newUser.Firstname = user.Firstname;
            newUser.Picture = ImagetoStream(user.Picture);
            newUser.Role = user.Role;
            newUser.Connected = user.Connected;

            return newUser;
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

        private Model.User convertUser(ServRefUser.User user)
        {
            Model.User newUser = new Model.User();

            newUser.Login = user.Login;
            newUser.Pwd = user.Pwd;
            newUser.Name = user.Name;
            newUser.Firstname = user.Firstname;
            newUser.Picture = StreamToImage(user.Picture);
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
        #endregion
    }
}
