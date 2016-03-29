using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer
{
    class User
    {
        private String name;
        private String userName;
        private String password;
        private int userID;
        private Boolean isAdmin;
        private String dept;

        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }

        public string UserName {
            get {
                return userName;
            }

            set {
                userName = value;
            }
        }

        public string Password {
            get {
                return password;
            }

            set {
                password = value;
            }
        }

        public int UserID {
            get {
                return userID;
            }

            set {
                userID = value;
            }
        }

        public bool IsAdmin {
            get {
                return isAdmin;
            }

            set {
                isAdmin = value;
            }
        }

        public string Dept {
            get {
                return dept;
            }

            set {
                dept = value;
            }
        }

        public void Dispose()
        {
            Dept = "";
            IsAdmin = false;
            Name = "";
            UserID = 0;
            UserName = "";
            Password = "";
        }
    }
}
