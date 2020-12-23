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
            static partial class PlazaGroup
            {
                /// <summary>
                /// Gets all PlazaGroups.
                /// </summary>
                /// <returns>Returns all PlazaGroups.</returns>
                public static NRestResult<Models.PlazaGroup> Gets()
                {
                    var ret = Execute<Models.PlazaGroup>(RouteConsts.Infrastructure.PlazaGroup.Gets.Url);
                    return ret;
                }
            }
        }
    }
}
