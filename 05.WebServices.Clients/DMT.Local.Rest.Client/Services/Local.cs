#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The Plaza Operation class.
    /// </summary>
    public static partial class Plaza
    {
        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static IPlazaConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.Plaza) return string.Empty;
                if (null == Config.Plaza.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.Plaza.Service.Protocol,
                    Config.Plaza.Service.HostName,
                    Config.Plaza.Service.PortNumber);
            }
        }

        #endregion
    }
}
