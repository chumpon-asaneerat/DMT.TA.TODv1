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
    [Authorize]
    public class NotifyController : ApiController
    {
        #region ActiveChanged

        /// <summary>
        /// Call when set active TSB.
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Notify.TSB.ActiveChanged.Name)]
        public NDbResult ActiveChanged()
        {
            NDbResult result = new NDbResult();
            result = new NDbResult();
            result.Success();
            return result;
        }

        #endregion

        #region ShiftChanged

        /// <summary>
        /// Call when TSB Shift Changed. 
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Notify.TSB.ShiftChanged.Name)]
        public NDbResult ShiftChanged()
        {
            NDbResult result = new NDbResult();
            result = new NDbResult();
            result.Success();
            return result;
        }

        #endregion
    }
}
