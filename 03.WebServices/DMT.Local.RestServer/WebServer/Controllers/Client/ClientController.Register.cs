#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    partial class ClientController : ApiController 
    {
        [HttpPost]
        [ActionName(RouteConsts.Client.Register.Name)]
        //[AllowAnonymous]
        public NDbResult Register([FromBody] Client value)
        {
            var ret = Client.Register(value);
            return ret;
        }
    }
}
