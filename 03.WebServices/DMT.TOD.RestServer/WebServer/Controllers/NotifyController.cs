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
    /// The controller for Notify event to application.
    /// </summary>
    public class NotifyController : ApiController
    {
        #region ActiveTSBChanged

        /// <summary>
        /// Call when set active TSB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Notify.ActiveTSBChanged.Name)]
        public NDbResult ActiveTSBChanged()
        {
            NDbResult result = new NDbResult();
            result = new NDbResult();
            result.Success();
            return result;
        }

        #endregion

        #region TSBShiftChanged

        /// <summary>
        /// Call when TSB Shift Changed. 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.Notify.TSBShiftChanged.Name)]
        public NDbResult TSBShiftChanged()
        {
            NDbResult result = new NDbResult();
            result = new NDbResult();
            result.Success();
            return result;
        }

        #endregion
    }
}
