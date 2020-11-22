using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Principal;
using System.Security.Claims;

namespace BasicAuthentication
{
    public static class IPrincipals
    {
        public static string UserName(this IPrincipal principal)
        {
            var princip = (ClaimsIdentity)principal.Identity;
            return princip.Name;
        }
    }
}
