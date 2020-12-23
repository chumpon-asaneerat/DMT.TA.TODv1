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
        partial class PlazaController
        {
            [HttpPost]
            [ActionName(RouteConsts.Infrastructure.Plaza.Save.Name)]
            //[AllowAnonymous]
            public NDbResult<Plaza> Save([FromBody] Plaza value)
            {
                NDbResult<Plaza> result;
                if (null == value)
                {
                    result = new NDbResult<Plaza>();
                    result.ParameterIsNull();
                }
                else
                {
                    result = Plaza.SavePlaza(value);
                }
                return result;
            }
        }
    }
}
