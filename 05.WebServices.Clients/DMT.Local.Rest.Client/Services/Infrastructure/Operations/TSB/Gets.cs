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
            static partial class TSB
            {
                /// <summary>
                /// Gets all TSBs.
                /// </summary>
                /// <returns>Returns all TSBs.</returns>
                public static NRestResult<Models.TSB> Gets()
                {
                    var ret = Execute<Models.TSB>(RouteConsts.Infrastructure.TSB.Gets.Url);
                    return ret;
                }
            }
        }
    }
}
