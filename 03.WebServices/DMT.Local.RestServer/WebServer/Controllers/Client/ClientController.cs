#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Client Controller class.
    /// </summary>
    [Authorize] // Authorize Attribute can set here or set in each method(s).
    public partial class ClientController : ApiController { }
}
