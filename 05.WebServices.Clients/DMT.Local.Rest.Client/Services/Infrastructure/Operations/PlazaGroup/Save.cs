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
                /// Save PlazaGroup.
                /// </summary>
                /// <returns>Returns Saved PlazaGroup.</returns>
                public static NRestResult<Models.PlazaGroup> Save(Models.PlazaGroup value)
                {
                    var ret = Execute<Models.PlazaGroup, Models.PlazaGroup>(
                        RouteConsts.Infrastructure.PlazaGroup.Save.Url, value);
                    return ret;
                }
            }
        }
    }
}
