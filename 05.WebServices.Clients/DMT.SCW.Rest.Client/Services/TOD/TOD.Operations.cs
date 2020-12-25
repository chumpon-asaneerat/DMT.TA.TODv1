﻿#region Usings

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

            /// <summary>
            /// Execute emvTransactionList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWEMVTransactionListResult> emvTransactionList(
                SCWEMVTransactionList value)
            {
                var ret = Execute<SCWEMVTransactionListResult>(
                    RouteConsts.SCW.TOD.emvTransactionList.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute qrcodeTransactionList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWQRCodeTransactionListResult> qrcodeTransactionList(
                SCWQRCodeTransactionList value)
            {
                var ret = Execute<SCWQRCodeTransactionListResult>(
                    RouteConsts.SCW.TOD.qrcodeTransactionList.Url, value);
                return ret;
            }

            /// <summary>
            /// Execute declare api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWDeclareResult> declare(SCWDeclare value)
            {
                var ret = Execute<SCWDeclareResult>(
                    RouteConsts.SCW.TOD.declare.Url, value);
                return ret;
            }
        }
    }
}
