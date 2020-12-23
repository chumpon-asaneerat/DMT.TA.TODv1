#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    static partial class Plaza
    {
        static partial class Infrastructure
        {
            static partial class Plaza
            {
                /// <summary>
                /// Gets all Plazas.
                /// </summary>
                /// <returns>Returns all Plazas.</returns>
                public static NRestResult<Models.Plaza> Gets()
                {
                    var ret = Execute<Models.Plaza>(RouteConsts.Infrastructure.Plaza.Gets.Url);
                    return ret;
                }
            }
        }
    }
}
