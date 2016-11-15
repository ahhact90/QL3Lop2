using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    public sealed class Session
    {
        public enum Roles { Admininistrator = 1, Manager, User, Gest };

        private bool _login;

        public string Id { set; get; }
        public string Acc { set; get; }
        public string Pass { set; get; }
        public string Name { set; get; }
        public Roles Role { set; get; }
        public DateTime? Current { set; get; }

        public bool Login
        {
            set
            {
                if (value == false)
                {
                    Id = null;
                    Acc = null;
                    Pass = null;
                    Name = "USER LOGIN";
                    Role = Roles.Gest;
                }
                _login = value;
            }
            get
            {
                return _login;
            }
        }

        public Session()
        {
            Login = false;
        }
    }
}
