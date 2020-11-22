using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityNET
{
    public class UserManager
    {
        public UserManager(string userName,
                            string roleName)
        {
            User_Name = userName;
            Role_Name = roleName;
        }
        private string User_Name { get; }
        private string Role_Name { get; }
        
        public string UserName()
        {
            return User_Name;
        }
        public string Role()
        {
            return Role_Name;
        }
    }
    
}
