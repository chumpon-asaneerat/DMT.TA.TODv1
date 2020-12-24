#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Security class.
    /// </summary>
    [Authorize]
    public partial class Shift : ApiController
    {
        /// <summary>The TSB Controller class.</summary>
        [Authorize]
        public partial class TSBController : ApiController { }

        /// <summary>The User Controller class.</summary>
        [Authorize]
        public partial class UserController : ApiController { }
    }

    // hack for exports nested class to controller(s)
    /// <summary>
    /// The Security's Role Manage Controller class.
    /// </summary>
    public class TSBShiftManageController : Shift.TSBController { }
    /// <summary>
    /// The Security's User Manage Controller class.
    /// </summary>
    public class UserShiftManageController : Shift.UserController { }
}
