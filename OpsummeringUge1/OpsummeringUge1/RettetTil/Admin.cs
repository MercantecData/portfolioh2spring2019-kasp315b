using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsummeringUge1.RettetTIl
{
    public class Admin
    {
        public void ChangePassword(User user, string newPassword) // Gætter på at diagrammet mente string her i stedet for en Password type
        {
            user.SetPassword(newPassword);
        }
    }
}
