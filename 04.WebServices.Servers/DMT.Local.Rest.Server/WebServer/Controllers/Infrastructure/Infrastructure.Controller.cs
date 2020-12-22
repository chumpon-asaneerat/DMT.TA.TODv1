#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Infrastructure class.
    /// </summary>
    public partial class Infrastructure
    {
        /// <summary>The TSB Controller class.</summary>
        [Authorize]
        public partial class TSBController : ApiController { }

        /// <summary>The PlazaGroup Controller class.</summary>
        [Authorize]
        public partial class PlazaGroupController : ApiController { }

        /// <summary>The Plaza Controller class.</summary>
        [Authorize]
        public partial class PlazaController : ApiController { }

        /// <summary>The Lane Controller class.</summary>
        [Authorize]
        public partial class LaneController : ApiController { }
    }

    // hack for exports nested class to controller(s)
    /// <summary>
    /// The Infrastructure's TSB Controller class.
    /// </summary>
    public class InfrastructureTSBController : Infrastructure.TSBController { }
    /// <summary>
    /// The Infrastructure's PlazaGroup Controller class.
    /// </summary>
    public class InfrastructurePlazaGroupController : Infrastructure.PlazaGroupController { }
    /// <summary>
    /// The Infrastructure's Plaza Controller class.
    /// </summary>
    public class InfrastructurePlazaController : Infrastructure.PlazaController { }
    /// <summary>
    /// The Infrastructure's Lane Controller class.
    /// </summary>
    public class InfrastructureLaneController : Infrastructure.LaneController { }
}
