#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The TOD Operation class.
    /// </summary>
    public static partial class TOD 
    {
        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static ITODAppConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.TODApp) return string.Empty;
                if (null == Config.TODApp.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.TODApp.Service.Protocol,
                    Config.TODApp.Service.HostName,
                    Config.TODApp.Service.PortNumber);
            }
        }
        /// <summary>
        /// Gets default execute timeout.
        /// </summary>
        public static int Timeout { get { return 1000; } }
        /// <summary>
        /// Gets user name.
        /// </summary>
        public static string UserName
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.TODApp) return string.Empty;
                if (null == Config.TODApp.Service) return string.Empty;

                return Config.TODApp.Service.UserName;
            }
        }
        /// <summary>
        /// Gets password.
        /// </summary>
        public static string Password
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.TODApp) return string.Empty;
                if (null == Config.TODApp.Service) return string.Empty;

                return Config.TODApp.Service.Password;
            }
        }

        #endregion
    }
}
