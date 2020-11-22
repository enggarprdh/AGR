using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicAuthentication;
using IdentityNET;

namespace AGR.Module.User
{
    public class UserController : ApiController
    {
        [BasicAuthentication]
        [HttpGet]
        public IHttpActionResult Values()
        {
            var result = User.UserName();
            return Ok(result);
        }
    }
}
