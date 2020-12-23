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
        partial class LaneController
        {
            [HttpPost]
            [ActionName(RouteConsts.Infrastructure.Lane.Save.Name)]
            //[AllowAnonymous]
            public NDbResult<Lane> Save([FromBody] Lane value)
            {
                NDbResult<Lane> result;
                if (null == value)
                {
                    result = new NDbResult<Lane>();
                    result.ParameterIsNull();
                }
                else
                {
                    result = Lane.SaveLane(value);
                }
                return result;
            }
        }
    }
}
