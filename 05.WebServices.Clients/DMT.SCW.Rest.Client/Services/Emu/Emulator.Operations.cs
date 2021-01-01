#region Usings

using System;
using System.Collections.Generic;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    static partial class SCW
    {
        /// <summary>The Emulator Operations class.</summary>
        public static partial class Emulator
        {
            /// <summary>
            /// Execute boj api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWBOJResult.</returns>
            public static SCWBOJResult boj(SCWBOJ value)
            {
                var ret = Execute<SCWBOJResult>(
                    RouteConsts.SCW.Emulator.boj.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute eoj api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWEOJResult.</returns>
            public static SCWEOJResult eoj(SCWEOJ value)
            {
                var ret = Execute<SCWEOJResult>(
                    RouteConsts.SCW.Emulator.eoj.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute removeJobs api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWRemoveJobsResult.</returns>
            public static SCWRemoveJobsResult removeJobs(SCWRemoveJobs value)
            {
                var ret = Execute<SCWRemoveJobsResult>(
                    RouteConsts.SCW.Emulator.removeJobs.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute clearJobs api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWClearJobsResult.</returns>
            public static SCWClearJobsResult clearJobs(SCWClearJobs value)
            {
                var ret = Execute<SCWClearJobsResult>(
                    RouteConsts.SCW.Emulator.clearJobs.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute emvTransactionList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWEMVTransactionListResult.</returns>
            public static SCWEMVTransactionListResult emvTransactionList(
                SCWEMVTransactionList value)
            {
                var ret = Execute<SCWEMVTransactionListResult>(
                    RouteConsts.SCW.Emulator.emvTransactionList.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute qrcodeTransactionList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWQRCodeTransactionListResult.</returns>
            public static SCWQRCodeTransactionListResult qrcodeTransactionList(
                SCWQRCodeTransactionList value)
            {
                var ret = Execute<SCWQRCodeTransactionListResult>(
                    RouteConsts.SCW.Emulator.qrcodeTransactionList.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute declare api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of SCWDeclareResult.</returns>
            public static SCWDeclareResult declare(SCWDeclare value)
            {
                var ret = Execute<SCWDeclareResult>(
                    RouteConsts.SCW.Emulator.declare.Url, value);
                return ret;
            }
        }
    }
}
