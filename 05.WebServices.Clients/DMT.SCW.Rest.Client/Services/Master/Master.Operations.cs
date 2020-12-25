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
            /// <summary>
            /// Execute cardAllowList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWCardAllowListResult> cardAllowList(SCWCardAllowList value)
            {
                var ret = Execute<SCWCardAllowListResult>(
                    RouteConsts.SCW.Master.cardAllowList.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute couponList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWCouponListResult> couponList(SCWCouponList value)
            {
                var ret = Execute<SCWCouponListResult>(
                    RouteConsts.SCW.Master.couponList.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute couponBookList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWCouponBookListResult> couponBookList(SCWCouponBookList value)
            {
                var ret = Execute<SCWCouponBookListResult>(
                    RouteConsts.SCW.Master.couponBookList.Url, value);
                return ret;
            }
            /// <summary>
            /// Execute currencyDenomList api.
            /// </summary>
            /// <param name="value">The api parameter.</param>
            /// <returns>Returns instance of NRestResult.</returns>
            public static NRestResult<SCWCurrencyDemonListResult> currencyDenomList(SCWCurrencyDemonList value)
            {
                var ret = Execute<SCWCurrencyDemonListResult>(
                    RouteConsts.SCW.Master.currencyDenomList.Url, value);
                return ret;
            }
        }
    }
}
