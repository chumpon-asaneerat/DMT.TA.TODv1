﻿#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NLib.Reflection;

using DMT.Models;
using System.Runtime.InteropServices.WindowsRuntime;
//using DMT.Models.ExtensionMethods;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The controller for handle Lane Attendance (Attendance/Leave).
    /// </summary>
    public class LaneController : ApiController
    {
        #region Lane Attendance

        #region Create
        /*
        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.CreateAttendance.Name)]
        public NDbResult<LaneAttendance> Create([FromBody] LaneAttendanceCreate value)
        {
            NDbResult<LaneAttendance> result;
            if (null == value)
            {
                result = new NDbResult<LaneAttendance>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Create(value.Lane, value.User);
            }
            return result;
        }
        */
        #endregion

        #region SaveAttendance
        /*
        /// <summary>
        /// Save Attendance.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.SaveAttendance.Name)]
        public NDbResult<LaneAttendance> SaveAttendance([FromBody] LaneAttendance value)
        {
            NDbResult<LaneAttendance> result;
            if (null == value)
            {
                result = new NDbResult<LaneAttendance>();
                result.ParameterIsNull();
            }
            else
            {
                // TODO: Autogenerate need to change to auto running number
                //Random rand = new Random();
                //if (string.IsNullOrWhiteSpace(value.JobId))
                //{
                //    value.JobId = rand.Next(100000).ToString("D5"); // auto generate.
                //}
                result = LaneAttendance.SaveLaneAttendance(value);
            }
            return result;
        }
        */
        #endregion

        #region SaveAttendances
        /*
        /// <summary>
        /// Save Attendances.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.SaveAttendances.Name)]
        public NDbResult SaveAttendances([FromBody] List<LaneAttendance> values)
        {
            NDbResult result;
            if (null == values)
            {
                result = new NDbResult();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.SaveLaneAttendances(values);
            }
            return result;
        }
        */
        #endregion

        #region GetAttendancesByDate
        /*
        /// <summary>
        /// GetAttendancesByDate.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAttendancesByDate.Name)]
        public NDbResult<List<LaneAttendance>> GetAttendancesByDate([FromBody] Search.Lanes.Attendances.ByDate value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Search(value.Date);
            }
            return result;
        }
        */
        #endregion

        #region GetAttendancesByUserShift
        /*
        /// <summary>
        /// GetAttendancesByUserShift.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAttendancesByUserShift.Name)]
        public NDbResult<List<LaneAttendance>> GetAttendancesByUserShift([FromBody] Search.Lanes.Attendances.ByUserShift value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Search(value.Shift, value.PlazaGroup, value.RevenueDate);
            }
            return result;
        }
        */
        #endregion

        #region GetAttendancesByRevenue
        /*
        /// <summary>
        /// GetAttendancesByRevenue.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAttendancesByRevenue.Name)]
        public NDbResult<List<LaneAttendance>> GetAttendancesByRevenue([FromBody] RevenueEntry value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Search(value);
            }
            return result;
        }
        */
        #endregion

        #region GetAllAttendancesByUserShift
        /*
        /// <summary>
        /// GetAllAttendancesByUserShift.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAllAttendancesByUserShift.Name)]
        public NDbResult<List<LaneAttendance>> GetAllAttendancesByUserShift([FromBody] UserShift value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Search(value);
            }
            return result;
        }
        */
        #endregion

        #region GetAttendancesByLane
        /*
        /// <summary>
        /// GetAttendancesByLane.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAttendancesByLane.Name)]
        public NDbResult<List<LaneAttendance>> GetAttendancesByLane([FromBody] Search.Lanes.Attendances.ByLane value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.Search(value.Lane);
            }
            return result;
        }
        */
        #endregion

        #region GetCurrentAttendancesByLane
        /*
        /// <summary>
        /// GetCurrentAttendancesByLane.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetCurrentAttendancesByLane.Name)]
        public NDbResult<LaneAttendance> GetCurrentAttendancesByLane([FromBody] Search.Lanes.Current.AttendanceByLane value)
        {
            NDbResult<LaneAttendance> result;
            if (null == value)
            {
                result = new NDbResult<LaneAttendance>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.GetCurrentByLane(value.Lane);
            }
            return result;
        }
        */
        #endregion

        #region GetAllNotHasRevenueEntry
        /*
        /// <summary>
        /// GetAllNotHasRevenueEntry.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAllNotHasRevenueEntry.Name)]
        public NDbResult<List<LaneAttendance>> GetAllNotHasRevenueEntry()
        {
            NDbResult<List<LaneAttendance>> result;
            result = LaneAttendance.GetAllNotHasRevenueEntry();
            return result;
        }
        */
        #endregion

        #region GetAllNotHasRevenueEntryByUser
        /*
        /// <summary>
        /// GetAllNotHasRevenueEntryByUser.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetAllNotHasRevenueEntryByUser.Name)]
        public NDbResult<List<LaneAttendance>> GetAllNotHasRevenueEntryByUser([FromBody] User value)
        {
            NDbResult<List<LaneAttendance>> result;
            if (null == value)
            {
                result = new NDbResult<List<LaneAttendance>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LaneAttendance.GetAllNotHasRevenueEntryByUser(value);
            }
            return result;
        }
        */
        #endregion

        #endregion

        #region Lane Payment

        #region Create
        /*
        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.SavePayment.Name)]
        public NDbResult<LanePayment> Create([FromBody] LanePaymentCreate value)
        {
            NDbResult<LanePayment> result;
            if (null == value)
            {
                result = new NDbResult<LanePayment>();
                result.ParameterIsNull();
            }
            else
            {
                result = LanePayment.Create(value.Lane, value.User,
                    value.Payment, value.Date, value.Amount);
            }
            return result;
        }
        */
        #endregion

        #region SavePayment

        /// <summary>
        /// Save Payment.
        /// </summary>
        /// <param name="value">The LanePayment instance.</param>
        /// <returns>Returns save instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.SavePayment.Name)]
        public NDbResult<LanePayment> SavePayment([FromBody] LanePayment value)
        {
            NDbResult<LanePayment> result;
            if (null == value)
            {
                result = new NDbResult<LanePayment>();
                result.ParameterIsNull();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(value.ApproveCode))
                {
                    // TODO: Autogenerate need to change to auto running number
                    Random rand = new Random();
                    value.ApproveCode = rand.Next(10000000).ToString("D8"); // auto generate.
                }
                result = LanePayment.Save(value);
            }
            return result;
        }

        #endregion

        #region GetPaymentsByDate
        /*
        /// <summary>
        /// GetPaymentsByDate.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetPaymentsByDate.Name)]
        public NDbResult<List<LanePayment>> GetPaymentsByDate([FromBody] Search.Lanes.Payments.ByDate value)
        {
            NDbResult<List<LanePayment>> result;
            if (null == value)
            {
                result = new NDbResult<List<LanePayment>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LanePayment.Search(value.Date);
            }
            return result;
        }
        */
        #endregion

        #region GetPaymentsByUserShifts
        /*
        /// <summary>
        /// GetPaymentsByUserShifts.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetPaymentsByUserShift.Name)]
        public NDbResult<List<LanePayment>> GetPaymentsByUserShifts([FromBody] Search.Lanes.Payments.ByUserShift value)
        {
            NDbResult<List<LanePayment>> result;
            if (null == value)
            {
                result = new NDbResult<List<LanePayment>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LanePayment.Search(value.Shift);
            }
            return result;
        }
        */
        #endregion

        #region GetPaymentsByLane
        /*
        /// <summary>
        /// GetPaymentsByLane.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetPaymentsByLane.Name)]
        public NDbResult<List<LanePayment>> GetPaymentsByLane([FromBody] Search.Lanes.Payments.ByLane value)
        {
            NDbResult<List<LanePayment>> result;
            if (null == value)
            {
                result = new NDbResult<List<LanePayment>>();
                result.ParameterIsNull();
            }
            else
            {
                result = LanePayment.Search(value.Lane);
            }
            return result;
        }
        */
        #endregion

        #region GetCurrentPaymentsByLane
        /*
        /// <summary>
        /// GetCurrentPaymentsByLane.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Lane.GetCurrentPaymentsByLane.Name)]
        public NDbResult<LanePayment> GetCurrentPaymentsByLane([FromBody] Search.Lanes.Current.PaymentByLane value)
        {
            NDbResult<LanePayment> result;
            if (null == value)
            {
                result = new NDbResult<LanePayment>();
                result.ParameterIsNull();
            }
            else
            {
                result = LanePayment.GetCurrentByLane(value.Lane);
            }
            return result;
        }
        */
        #endregion

        #endregion
    }
}
