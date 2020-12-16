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
    /// The controller for manage Shift and TSBShift (Supervisor shift).
    /// </summary>
    [Authorize]
    public class ShiftController : ApiController
    {
        #region Shift

        #region GetShifts

        /// <summary>
        /// Gets Shifts.
        /// </summary>
        /// <returns>Returns Shift List.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Shift.GetShifts.Name)]
        public NDbResult<List<Shift>> GetShifts()
        {
            var results = Shift.GetShifts();
            return results;
        }

        #endregion

        #region SaveShift

        /// <summary>
        /// Save Shift.
        /// </summary>
        /// <param name="value">The Shift instance.</param>
        /// <returns>Returns save shift instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Shift.SaveShift.Name)]
        public NDbResult<Shift> SaveShift([FromBody] Shift value)
        {
            NDbResult<Shift> result;
            if (null == value)
            {
                result = new NDbResult<Shift>();
                result.ParameterIsNull();
            }
            else
            {
                result = Shift.Save(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region TSB Shift

        #region CreateTSBShift

        /// <summary>
        /// Creat TSB Shift.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns new TSBShift instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.CreateTSBShift.Name)]
        public NDbResult<TSBShift> CreateTSBShift([FromBody] Create.TSBShift value)
        {
            NDbResult<TSBShift> result;
            if (null == value)
            {
                result = new NDbResult<TSBShift>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBShift.Create(value.Shift, value.User);
            }
            return result;
        }

        #endregion

        #region GetCurrentTSBShift

        /// <summary>
        /// Gets Current TSB Shift.
        /// </summary>
        /// <returns>Returns Current TSB Shift.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.GetCurrentTSBShift.Name)]
        public NDbResult<TSBShift> GetCurrentTSBShift()
        {
            var result = TSBShift.GetTSBShift();
            return result;
        }

        #endregion

        #region ChangeShift

        /// <summary>
        /// Change TSB Shift.
        /// </summary>
        /// <param name="value">The TSBShift instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.ChangeShift.Name)]
        public NDbResult ChangeShift([FromBody] TSBShift value)
        {
            NDbResult result;
            if (null == value)
            {
                result = new NDbResult<Shift>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSBShift.ChangeShift(value);
                if (!result.errors.hasError)
                {
                    //TODO: Refactor
                    // Raise event.
                    //LocalDbServer.Instance.ChangeShift();
                }
            }
            return result;
        }

        #endregion

        #endregion

        #region User Shift

        #region CreateUserShift

        /// <summary>
        /// Create new User Shift.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.CreateUserShift.Name)]
        public NDbResult<UserShift> CreateUserShift([FromBody] Create.UserShift value)
        {
            NDbResult<UserShift> result;

            if (null == value)
            {
                result = new NDbResult<UserShift>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShift.Create(value.Shift, value.User);
            }
            return result;
        }

        #endregion

        #region GetCurrentUserShift

        /// <summary>
        /// Gets Current User Shift.
        /// </summary>
        /// <param name="value">The User Instance.</param>
        /// <returns>Returns Current User Shift instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.GetCurrentUserShift.Name)]
        public NDbResult<UserShift> GetCurrentUserShift([FromBody] User value)
        {
            NDbResult<UserShift> result;

            if (null == value)
            {
                result = new NDbResult<UserShift>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShift.GetUserShift(value.UserId);
            }
            return result;
        }

        #endregion

        #region BeginUserShift

        /// <summary>
        /// Begin User Shift.
        /// </summary>
        /// <param name="value">The UserShift instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.BeginUserShift.Name)]
        public NDbResult BeginUserShift([FromBody] UserShift value)
        {
            NDbResult result;

            if (null == value)
            {
                result = new NDbResult<Shift>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShift.BeginUserShift(value);
            }
            return result;
        }

        #endregion

        #region EndUserShift

        /// <summary>
        /// End User Shift.
        /// </summary>
        /// <param name="value">The UserShift instance.</param>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.EndUserShift.Name)]
        public NDbResult EndUserShift([FromBody] UserShift value)
        {
            NDbResult result;

            if (null == value)
            {
                result = new NDbResult<Shift>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShift.EndUserShift(value);
            }
            return result;
        }

        #endregion

        #region GetUserShifts

        /// <summary>
        /// Gets User Shifts.
        /// </summary>
        /// <param name="value">The User instance.</param>
        /// <returns>Returns all User shifts List.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.GetUserShifts.Name)]
        public NDbResult<List<UserShift>> GetUserShifts([FromBody] User value)
        {
            NDbResult<List<UserShift>> result;
            if (null == value)
            {
                result = new NDbResult<List<UserShift>>();
                result.ParameterIsNull();
            }
            else
            {
                result = UserShift.GetUserShifts(value.UserId);
            }
            return result;
        }

        #endregion

        #region GetUnCloseUserShifts

        /// <summary>
        /// Gets Unclose User Shifts.
        /// </summary>
        /// <returns>Returns all User shifts List.</returns>
        [HttpPost]
        [ActionName(RouteConsts.Shift.GetUnCloseUserShifts.Name)]
        public NDbResult<List<UserShift>> GetUnCloseUserShifts()
        {
            NDbResult<List<UserShift>> result;
            result = UserShift.GetUnCloseUserShifts();
            return result;
        }

        #endregion

        #endregion
    }
}
