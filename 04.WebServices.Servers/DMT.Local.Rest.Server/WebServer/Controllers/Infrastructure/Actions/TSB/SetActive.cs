#region Using

using System;
using System.Collections.Generic;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    partial class Infrastructure
    {
        partial class TSBController
        {
            [HttpPost]
            [ActionName(RouteConsts.Infrastructure.TSB.SetActive.Name)]
            //[AllowAnonymous]
            public NDbResult SetActive([FromBody] TSB value)
            {
                var ret = TSB.SetActive(value.TSBId);
                return ret;
            }
        }
    }
}
