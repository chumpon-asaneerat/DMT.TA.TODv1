#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using DMT.Models;
//using DMT.Models.ExtensionMethods;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The controller for manage common data on TSB, Plaza and Lane.
    /// </summary>
    public class MasterController : ApiController
    {
        #region MCurrency

        #region GetCurrencies

        /// <summary>
        /// Gets all Currencies (master).
        /// </summary>
        /// <returns>Returns list of all currencies (master).</returns>
        [HttpPost]
        [ActionName(RouteConsts.Master.GetCurrencies.Name)]
        public NDbResult<List<MCurrency>> GetCurrencies()
        {
            var results = MCurrency.GetCurrencies();
            return results;
        }

        #endregion

        #endregion

        #region MCoupon

        #region GetCoupons

        /// <summary>
        /// Gets all Coupons (master).
        /// </summary>
        /// <returns>Returns list of all coupons (master).</returns>
        [HttpPost]
        [ActionName(RouteConsts.Master.GetCoupons.Name)]
        public NDbResult<List<MCoupon>> GetCoupons()
        {
            var results = MCoupon.GetCoupons();
            return results;
        }

        #endregion

        #endregion
    }
}
