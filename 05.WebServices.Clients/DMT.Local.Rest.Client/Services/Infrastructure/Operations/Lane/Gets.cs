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
            static partial class Lane
            {
                /// <summary>
                /// Gets all Lanes.
                /// </summary>
                /// <returns>Returns all Lanes.</returns>
                public static NRestResult<Models.Lane> Gets()
                {
                    var ret = Execute<Models.Lane>(RouteConsts.Infrastructure.Lane.Gets.Url);
                    return ret;
                }
            }
        }
    }
}
