#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Shift class.
    /// </summary>
    public partial class Shift
    {
        /// <summary>The Shift Controller class.</summary>
        [Authorize]
        public partial class ShiftController : ApiController { }

        /// <summary>The TSB Controller class.</summary>
        [Authorize]
        public partial class TSBController : ApiController { }

        /// <summary>The User Controller class.</summary>
        [Authorize]
        public partial class UserController : ApiController { }
    }

    // hack for exports nested class to controller(s)
    /// <summary>
    /// The Shift's Shift Manage Controller class.
    /// </summary>
    public class ShiftManageController : Shift.ShiftController { }
    /// <summary>
    /// The TSB Shift's Manage Controller class.
    /// </summary>
    public class TSBShiftManageController : Shift.TSBController { }
    /// <summary>
    /// The User Shift's Manage Controller class.
    /// </summary>
    public class UserShiftManageController : Shift.UserController { }
}
