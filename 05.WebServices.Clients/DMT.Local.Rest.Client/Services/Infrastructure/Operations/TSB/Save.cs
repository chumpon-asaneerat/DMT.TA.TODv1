﻿#region Usings

using System.Collections.Generic;

#endregion

namespace DMT.Services.Operations
{
    static partial class Plaza
    {
        static partial class Infrastructure
        {
            static partial class TSB
            {
                /// <summary>
                /// Save TSB.
                /// </summary>
                /// <returns>Returns Saved TSB.</returns>
                public static NRestResult<Models.TSB> Save(Models.TSB value)
                {
                    var ret = Execute<Models.TSB>(
                        RouteConsts.Infrastructure.TSB.Save.Url, value);
                    return ret;
                }
            }
        }
    }
}
