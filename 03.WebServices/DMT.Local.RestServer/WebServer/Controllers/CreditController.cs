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
    /// The controller for manage credit transaction TA.
    /// </summary>
    [Authorize]
    public class CreditController : ApiController
    {
        #region TSB Balance

        #region GetTSBCreditBalance

        /// <summary>
        /// Get TSB Credit Balance.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns TSBCreditBalance instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Credit.GetTSBCreditBalance.Name)]
        public NDbResult<TSBCreditBalance> GetTSBCreditBalance([FromBody] TSB value)
        {
            NDbResult<TSBCreditBalance> result;
            if (null == value)
            {
                result = new NDbResult<TSBCreditBalance>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCreditBalance.GetCurrent(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region TSB Credit Transaction

        #region GetInitialTSBCreditTransaction

        /// <summary>
        /// Get Initial TSB Credit Transaction.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns Initial TSB Credit Transaction instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Credit.GetInitialTSBCreditTransaction.Name)]
        public NDbResult<TSBCreditTransaction> GetInitialTSBCreditTransaction([FromBody] TSB value)
        {
            NDbResult<TSBCreditTransaction> result;
            if (null == value)
            {
                result = new NDbResult<TSBCreditTransaction>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCreditTransaction.GetInitialTransaction(value);
            }
            return result;
        }

        #endregion

        #region GetReplaceTSBCreditTransaction

        /// <summary>
        /// Get Replace TSB Credit Transaction.
        /// </summary>
        /// <param name="value">The DateTime to search.</param>
        /// <returns>Returns list of TSBCreditTransaction.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.GetReplaceTSBCreditTransaction.Name)]
        public NDbResult<List<TSBCreditTransaction>> GetReplaceTSBCreditTransaction([FromBody] DateTime value)
        {
            NDbResult<List<TSBCreditTransaction>> result;
            if (null == value)
            {
                result = new NDbResult<List<TSBCreditTransaction>>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCreditTransaction.GetReplaceTransactions(value);
            }
            return result;
        }

        #endregion

        #region SaveTSBCreditTransaction

        /// <summary>
        /// Save TSB Credit Transaction.
        /// </summary>
        /// <param name="value">The TSBCreditTransaction instance.</param>
        /// <returns>Returns save instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.SaveTSBCreditTransaction.Name)]
        public NDbResult<TSBCreditTransaction> SaveTSBCreditTransaction(
            [FromBody] TSBCreditTransaction value)
        {
            NDbResult<TSBCreditTransaction> result;
            if (null == value)
            {
                result = new NDbResult<TSBCreditTransaction>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBCreditTransaction.SaveTransaction(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region User Credit Balance

        #region GetActiveUserCreditBalances

        /// <summary>
        /// Get Active User Credit Balances.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns list of UserCreditBalance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.GetActiveUserCreditBalances.Name)]
        public NDbResult<List<UserCreditBalance>> GetActiveUserCreditBalances([FromBody] TSB value)
        {
            NDbResult<List<UserCreditBalance>> result;
            if (null == value)
            {
                result = new NDbResult<List<UserCreditBalance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserCreditBalance.GetActiveUserCreditBalances(value);
            }
            return result;
        }

        #endregion

        #region GetActiveUserCreditBalanceById
        /*
        /// <summary>
        /// Get Active User Credit Balance By Id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns UserCreditBalance instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.GetActiveUserCreditBalanceById.Name)]
        public NDbResult<UserCreditBalance> GetActiveUserCreditBalanceById(
            [FromBody] Search.UserCredits.GetActiveById value)
        {
            NDbResult<UserCreditBalance> result;
            if (null == value)
            {
                result = new NDbResult<UserCreditBalance>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserCreditBalance.GetActiveUserCreditBalanceById(
                    value.UserId, value.PlazaGroupId);
            }
            return result;
        }
        */
        #endregion

        #region SaveUserCreditBalance

        /// <summary>
        /// Save User Credit Balance.
        /// </summary>
        /// <param name="value">The UserCreditBalance instance.</param>
        /// <returns>Returns save instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.SaveUserCreditBalance.Name)]
        public NDbResult<UserCreditBalance> SaveUserCreditBalance(
            [FromBody] UserCreditBalance value)
        {
            NDbResult<UserCreditBalance> result;
            if (null == value)
            {
                result = new NDbResult<UserCreditBalance>();
                result.ParameterIsNull();
            }
            else
            {

                result = UserCreditBalance.SaveUserCreditBalance(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region User Credit Transaction

        #region SaveUserCreditTransaction

        /// <summary>
        /// Save User Credit Transaction.
        /// </summary>
        /// <param name="value">The UserCreditTransaction instance.</param>
        /// <returns>Returns save instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Credit.SaveUserCreditTransaction.Name)]
        public NDbResult<UserCreditTransaction> SaveUserCreditTransaction(
            [FromBody] UserCreditTransaction value)
        {
            NDbResult<UserCreditTransaction> result;
            if (null == value)
            {
                result = new NDbResult<UserCreditTransaction>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserCreditTransaction.SaveUserCreditTransaction(value);
            }
            return result;
        }

        #endregion

        #endregion
    }
}
