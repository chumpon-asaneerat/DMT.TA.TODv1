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
    /// The controller for manage coupon transaction TA.
    /// </summary>
    [Authorize]
    public class CouponController : ApiController
    {
        #region TSB Coupon Balance

        #region GetTSBCouponBalance

        /// <summary>
        /// Get TSB Coupon Balance.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns TSBCouponBalance instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Coupon.GetTSBCouponBalance.Name)]
        public NDbResult<TSBCouponBalance> GetTSBCouponBalance([FromBody] TSB value)
        {
            NDbResult<TSBCouponBalance> result;
            if (null == value)
            {
                result = new NDbResult<TSBCouponBalance>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponBalance.GetTSBBalance(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region TSB Coupon Summary

        #region GetTSBCouponSummaries

        /// <summary>
        /// Get TSB Coupon Summaries.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns List of TSBCouponSummary.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Coupon.GetTSBCouponSummaries.Name)]
        public NDbResult<List<TSBCouponSummary>> GetTSBCouponSummaries([FromBody] TSB value)
        {
            NDbResult<List<TSBCouponSummary>> result;
            if (null == value)
            {
                result = new NDbResult<List<TSBCouponSummary>>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponSummary.GetTSBCouponSummaries(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region TSB Coupon Transaction

        #region GetTSBCouponTransactions

        /// <summary>
        /// Get TSB Coupon Transactions.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns list of TSBCouponTransaction.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Coupon.GetTSBCouponTransactions.Name)]
        public NDbResult<List<TSBCouponTransaction>> GetTSBCouponTransactions([FromBody] TSB value)
        {
            NDbResult<List<TSBCouponTransaction>> result;
            if (null == value)
            {
                result = new NDbResult<List<TSBCouponTransaction>>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponTransaction.GetTSBCouponTransactions(value);
            }
            return result;
        }

        #endregion

        #region SaveTransaction

        /// <summary>
        /// Save Transaction.
        /// </summary>
        /// <param name="value">The TSBCouponTransaction instance.</param>
        /// <returns>Returns save instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Coupon.SaveTSBCouponTransaction.Name)]
        public NDbResult<TSBCouponTransaction> SaveTransaction(
            [FromBody] TSBCouponTransaction value)
        {
            NDbResult<TSBCouponTransaction> result;
            if (null == value)
            {
                result = new NDbResult<TSBCouponTransaction>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponTransaction.SaveTransaction(value);
            }
            return result;
        }

        #endregion

        #region SaveTransactions

        /// <summary>
        /// Save Transactions.
        /// </summary>
        /// <param name="values">The list of TSBCouponTransaction instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Coupon.SaveTSBCouponTransactions.Name)]
        public NDbResult SaveTransactions([FromBody] List<TSBCouponTransaction> values)
        {
            NDbResult result;
            if (null == values)
            {
                result = new NDbResult();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponTransaction.SaveTransactions(values);
            }
            return result;
        }

        #endregion

        #region SyncTransaction

        /// <summary>
        /// Sync Transaction.
        /// </summary>
        /// <param name="value">The TSBCouponTransaction instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Coupon.SyncTSBCouponTransaction.Name)]
        public NDbResult SyncTransaction(
            [FromBody] TSBCouponTransaction value)
        {
            NDbResult result;
            if (null == value)
            {
                result = new NDbResult();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponTransaction.SyncTransaction(value);
            }
            return result;
        }

        #endregion

        #region SyncTransactions

        /// <summary>
        /// Sync Transactions.
        /// </summary>
        /// <param name="values">The list of TSBCouponTransaction instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Coupon.SyncTSBCouponTransactions.Name)]
        public NDbResult SyncTransactions(
            [FromBody] List<TSBCouponTransaction> values)
        {
            NDbResult result;
            if (null == values)
            {
                result = new NDbResult();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCouponTransaction.SyncTransactions(values);
            }
            return result;
        }

        #endregion

        #endregion
    }
}
