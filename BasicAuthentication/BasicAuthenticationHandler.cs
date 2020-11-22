using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using IdentityNET;


namespace BasicAuthentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {   
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Origin Code
            //base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;
                //decoding auth token
                var decodeAuthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                //spliting decodeAuthToken using :
                var arrUserNamePassword = decodeAuthToken.Split(':');
                //at 0th position array we get userName, 1st we get password
                if (IsAuthorizedUser(arrUserNamePassword[0], arrUserNamePassword[1]))
                {
                    //setting current principal
                    var identity = new GenericIdentity(arrUserNamePassword[0]);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(arrUserNamePassword[0]), null);
                    if(HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                        
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            } else
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
        }
        public static bool IsAuthorizedUser(string userName, string password)
        {
            return userName == "enggar" && password == "admin";
        }
    }
}
