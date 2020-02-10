using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1.RettetTIl
{
    public class Registry
    {
        private List<User> users;
        private List<Admin> admins;

        public Registry()
        {
            users = new List<User>();
            admins = new List<Admin>();
        }

        public void AddNewUser(User user)
        {
            users.Add(user);
        }

        public bool Login(string login, string password)
        {
            foreach(User user in users)
            {
                if (user.Login(login, password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
