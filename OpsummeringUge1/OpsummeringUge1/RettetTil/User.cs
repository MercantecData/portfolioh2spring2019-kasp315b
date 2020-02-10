using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1.RettetTIl
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

        public bool Login(string login, string password)
        {
            return this.login.Equals(login) & this.password.Equals(password);
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public bool IsAdmin()
        {
            return this is Admin;
        }
    }
}
