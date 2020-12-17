#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /*
    /// <summary>
    /// The Infrastructure Controller class.
    /// </summary>
    [Authorize] // Authorize Attribute can set here or set in each method(s).
    public partial class InfrastructureController : ApiController { }
    */

    /// <summary>
    /// The Infrastructure Controller class.
    /// </summary>
    public partial class Infrastructure
    {
        [Authorize]
        public partial class TSBController : ApiController { }
        [Authorize]
        public partial class PlazaGroupController : ApiController { }
        [Authorize]
        public partial class PlazaController : ApiController { }
        [Authorize]
        public partial class LaneController : ApiController { }
    }

    // exports controller(s)
    public class InfrastructureTSBController : Infrastructure.TSBController { }
    public class InfrastructurePlazaGroupController : Infrastructure.PlazaGroupController { }
    public class InfrastructurePlazaController : Infrastructure.PlazaController { }
    public class InfrastructureLaneController : Infrastructure.LaneController { }
}
