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
            /// <summary>
            /// Execute loginAudit api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWLogInAuditResult> loginAudit(SCWLogInAudit value)
            {
                var ret = Execute<SCWLogInAuditResult>(
                    RouteConsts.SCW.Security.loginAudit.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute changePassword api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWChangePasswordResult> changePassword(SCWChangePassword value)
            {
                var ret = Execute<SCWChangePasswordResult>(
                    RouteConsts.SCW.Security.changePassword.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute passwordExpiresDays api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWPasswordExpiresDaysResult> passwordExpiresDays(SCWPasswordExpiresDays value)
            {
                var ret = Execute<SCWPasswordExpiresDaysResult>(
                    RouteConsts.SCW.Security.passwordExpiresDays.Url, value);
                return ret;
            }
        }
    }
}
