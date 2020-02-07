using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1
{
    public class User
    {

        private string login;
        private string password;
        private Job job;

        public User(string login, string password, Job job)
        {
            this.login = login;
            this.password = password;
            this.job = job;
        }

        public bool IsAdmin()
        {
            return false;
        }
    }
}
