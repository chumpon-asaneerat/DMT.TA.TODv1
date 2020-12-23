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
            [ActionName(RouteConsts.Infrastructure.TSB.Save.Name)]
            //[AllowAnonymous]
            public NDbResult<TSB> Save([FromBody] TSB value)
            {
                NDbResult<TSB> result;
                if (null == value)
                {
                    result = new NDbResult<TSB>();
                    result.ParameterIsNull();
                }
                else
                {
                    result = TSB.SaveTSB(value);
                }
                return result;
            }
        }
    }
}
