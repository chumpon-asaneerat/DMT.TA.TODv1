﻿#region Usings

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
                /// Save Plaza.
                /// </summary>
                /// <returns>Returns Saved Plaza.</returns>
                public static NRestResult<Models.Plaza> Save(Models.Plaza value)
                {
                    var ret = Execute<Models.Plaza, Models.Plaza>(
                        RouteConsts.Infrastructure.Plaza.Save.Url, value);
                    return ret;
                }
            }
        }
    }
}
