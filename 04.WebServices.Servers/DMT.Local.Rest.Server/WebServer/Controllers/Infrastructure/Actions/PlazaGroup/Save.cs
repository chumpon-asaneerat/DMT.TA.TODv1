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
        partial class PlazaGroupController
        {
            [HttpPost]
            [ActionName(RouteConsts.Infrastructure.PlazaGroup.Save.Name)]
            //[AllowAnonymous]
            public NDbResult<PlazaGroup> Save([FromBody] PlazaGroup value)
            {
                NDbResult<PlazaGroup> result;
                if (null == value)
                {
                    result = new NDbResult<PlazaGroup>();
                    result.ParameterIsNull();
                }
                else
                {
                    result = PlazaGroup.SavePlazaGroup(value);
                }
                return result;
            }
        }
    }
}
