#region Usings

using System;
using System.Collections.Generic;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    static partial class SCW
    {
        /// <summary>The Security Operations class.</summary>
        public static partial class Security
        {
            public static NRestResult<SCWLogInAuditResult> loginAudit(SCWLogInAudit value)
            {
                var ret = Execute<SCWLogInAuditResult>(
                    RouteConsts.SCW.Security.loginAudit.Url, value);
                return ret;
            }

            /*
            /// <summary>
            /// Save LogIn Audit.
            /// </summary>
            /// <returns>Returns NRestResult instance.</returns>
            public static NRestResult<List<Models.Shift>> loginAudit()
            {
                var ret = Execute<List<Models.Shift>>(
                    RouteConsts.Shift.Gets.Url);
                return ret;
            }

            /// <summary>
            /// Change Password.
            /// </summary>
            /// <returns>Returns NRestResult instance.</returns>
            public static NRestResult<List<Models.Shift>> changePassword()
            {
                var ret = Execute<List<Models.Shift>>(
                    RouteConsts.Shift.Gets.Url);
                return ret;
            }

            /// <summary>
            /// Gets passwordExpiresDays.
            /// </summary>
            /// <returns>Returns NRestResult instance.</returns>
            public static NRestResult<List<Models.Shift>> passwordExpiresDays()
            {
                var ret = Execute<List<Models.Shift>>(
                    RouteConsts.Shift.Gets.Url);
                return ret;
            }
            */
        }
    }
}
