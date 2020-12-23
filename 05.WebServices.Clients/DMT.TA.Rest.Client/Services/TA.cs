#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The TA Operation class.
    /// </summary>
    public static partial class TA 
    {
        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static ITAAppConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.TAApp) return string.Empty;
                if (null == Config.TAApp.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.TAApp.Service.Protocol,
                    Config.TAApp.Service.HostName,
                    Config.TAApp.Service.PortNumber);
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
                if (null == Config.TAApp) return string.Empty;
                if (null == Config.TAApp.Service) return string.Empty;

                return Config.TAApp.Service.UserName;
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
                if (null == Config.TAApp) return string.Empty;
                if (null == Config.TAApp.Service) return string.Empty;

                return Config.TAApp.Service.Password;
            }
        }

        #endregion
    }
}
