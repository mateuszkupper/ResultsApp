using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer
{
    class Connection
    {
        private static String uID = "sql8112145", 
                                password = "yhuyly8Gyn", 
                                server = "sql8.freemysqlhosting.net", 
                                dB = "sql8112145";

        public string DB
        {
            get
            {
                return dB;
            }

            set
            {
                dB = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        public string UID
        {
            get
            {
                return uID;
            }

            set
            {
                uID = value;
            }
        }
    }
}
