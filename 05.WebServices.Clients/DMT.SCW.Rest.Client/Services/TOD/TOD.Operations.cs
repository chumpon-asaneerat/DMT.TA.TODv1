#region Usings

using System;
using System.Collections.Generic;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    static partial class SCW
    {
        /// <summary>The TOD Operations class.</summary>
        public static partial class TOD
        {
            /// <summary>
            /// Execute cheifOnDuty api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWChiefOnDutyResult> cheifOnDuty(SCWChiefOnDuty value)
            {
                var ret = Execute<SCWChiefOnDutyResult>(
                    RouteConsts.SCW.TOD.cheifOnDuty.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute saveCheifDuty api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWSaveChiefDutyResult> saveCheifDuty(SCWSaveChiefDuty value)
            {
                var ret = Execute<SCWSaveChiefDutyResult>(
                    RouteConsts.SCW.TOD.saveCheifDuty.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute jobList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWJobListResult> jobList(SCWJobList value)
            {
                var ret = Execute<SCWJobListResult>(
                    RouteConsts.SCW.TOD.jobList.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute jobList2 api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWJobList2Result> jobList2(SCWJobList2 value)
            {
                var ret = Execute<SCWJobList2Result>(
                    RouteConsts.SCW.TOD.jobList2.Url, value);
                return ret;
            }

            /*
                  - TOD
                    - emvTransactionList
                    - qrcodeTransactionList
                    - declare
            */
        }
    }
}
