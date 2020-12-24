#region Using

using System;
using System.Collections.Generic;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    partial class Shift
    {
        partial class TSBController
        {
            [HttpPost]
            [ActionName(RouteConsts.Shift.TSB.Change.Name)]
            //[AllowAnonymous]
            public NDbResult Change([FromBody] TSBShift value)
            {
                var ret = TSBShift.ChangeShift(value);
                //TODO: Need to notify to TA and TOD app for shift changed.
                return ret;
            }
        }
    }
}
