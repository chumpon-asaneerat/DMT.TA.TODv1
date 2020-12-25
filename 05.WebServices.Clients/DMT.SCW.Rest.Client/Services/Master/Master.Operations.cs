#region Usings

using System;
using System.Collections.Generic;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    static partial class SCW
    {
        /// <summary>The Master Operations class.</summary>
        public static partial class Master
        {
            public static NRestResult<SCWCardAllowListResult> cardAllowList(SCWCardAllowList value)
            {
                var ret = Execute<SCWCardAllowListResult>(
                    RouteConsts.SCW.Security.loginAudit.Url, value);
                return ret;
            }
            /*
            /// <summary>
            /// Gets all Shifts.
            /// </summary>
            /// <returns>Returns NRestResult instance.</returns>
            public static NRestResult<List<Models.Shift>> cheifOnDuty()
            {
                var ret = Execute<List<Models.Shift>>(
                    RouteConsts.Shift.Gets.Url);
                return ret;
            }
            */

            /*
                  - Master
                    - couponList
                    - couponBookList
                    - currencyDenomList
            */
        }
    }
}
