﻿#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

using DMT.Models;
//using DMT.Models.ExtensionMethods;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The controller for manage common data on Revenue Entry.
    /// </summary>
    [Authorize]
    public class RevenueController : ApiController
    {
        #region UserShiftRevenue

        #region CreateRevenueShift
        /*
        /// <summary>
        /// Create Revenue Shift.
        /// </summary>
        /// <param name="value">The search parameter instance.</param>
        /// <returns>Returns instance of UserShiftRevenue (NDbResult).</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.CreatePlazaRevenue.Name)]
        public NDbResult<UserShiftRevenue> CreateRevenueShift([FromBody] Search.Revenues.PlazaShift value)
        {
            NDbResult<UserShiftRevenue> result;
            if (null == value)
            {
                result = new NDbResult<UserShiftRevenue>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShiftRevenue.CreatePlazaRevenue(value.Shift, value.PlazaGroup);
            }
            return result;
        }
        */
        #endregion

        #region SaveRevenueShift
        /*
        /// <summary>
        /// Save Revenue Shift.
        /// </summary>
        /// <param name="value">The save parameter instance.</param>
        /// <returns>Returns instance of UserShiftRevenue (NDbResult).</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.SavePlazaRevenue.Name)]
        public NDbResult<UserShiftRevenue> SaveRevenueShift([FromBody] Search.Revenues.SaveRevenueShift value)
        {
            NDbResult<UserShiftRevenue> result;
            if (null == value)
            {
                result = new NDbResult<UserShiftRevenue>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShiftRevenue.SavePlazaRevenue(
                    value.RevenueShift, value.RevenueDate, value.RevenueId);
            }
            return result;
        }
        */
        #endregion

        #region GetRevenueShift
        /*
        /// <summary>
        /// Get Revenue Shift.
        /// </summary>
        /// <param name="value">The search parameter instance.</param>
        /// <returns>Returns instance of UserShiftRevenue (NDbResult).</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.GetPlazaRevenue.Name)]
        public NDbResult<UserShiftRevenue> GetRevenueShift([FromBody] Search.Revenues.PlazaShift value)
        {
            NDbResult<UserShiftRevenue> result;
            if (null == value)
            {
                result = new NDbResult<UserShiftRevenue>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShiftRevenue.GetPlazaRevenue(value.Shift, value.PlazaGroup);
            }
            return result;
        }
        */
        #endregion

        #endregion

        #region Revenue Entry

        #region SaveRevenue

        /// <summary>
        /// Save Revenue.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns save instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.SaveRevenue.Name)]
        public NDbResult<RevenueEntry> SaveRevenue([FromBody] RevenueEntry value)
        {
            NDbResult<RevenueEntry> result;
            if (null == value)
            {
                result = new NDbResult<RevenueEntry>();
                result.ParameterIsNull();
            }
            else
            {
                if (value.PKId == Guid.Empty)
                {
                    value.PKId = Guid.NewGuid();
                }
                result = RevenueEntry.Save(value);
            }
            return result;
        }

        #endregion

        #region GetRevenues
        /*
        /// <summary>
        /// Get Revenues.
        /// </summary>
        /// <param name="value">The DateTime to search.</param>
        /// <returns>Returns list of Revenue Entries.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.GetRevenues.Name)]
        public NDbResult<List<RevenueEntry>> GetRevenues([FromBody] DateTime value)
        {
            NDbResult<List<RevenueEntry>> result;

            if (value == DateTime.MinValue)
            {
                result = new NDbResult<List<RevenueEntry>>();
                result.ParameterIsNull();
            }
            else
            {
                result = RevenueEntry.FindByRevnueDate(value);
            }

            return result;
        }
        */
        #endregion

        #region GetUnsendRevenues
        /*
        /// <summary>
        /// Get Unsend Revenues.
        /// </summary>
        /// <returns>Returns list of Revenue Entries.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Revenue.GetUnsendRevenues.Name)]
        public NDbResult<List<RevenueEntry>> GetUnsendRevenues()
        {
            NDbResult<List<RevenueEntry>> result;
            result = RevenueEntry.FindUnsendRevenueEnties();
            return result;
        }
        */
        #endregion

        #endregion
    }
}
