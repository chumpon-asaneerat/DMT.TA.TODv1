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
        [ActionName(RouteConsts.Client.Unregister.Name)]
        //[AllowAnonymous]
        public NDbResult Unregister([FromBody] Client value)
        {
            var ret = Client.Unregister(value);
            return ret;
        }
    }
}
