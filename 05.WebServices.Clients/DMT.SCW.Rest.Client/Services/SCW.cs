#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The SCW Operation class.
    /// </summary>
    public static partial class SCW 
    {
        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static ISCWConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.SCW) return string.Empty;
                if (null == Config.SCW.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.SCW.Service.Protocol,
                    Config.SCW.Service.HostName,
                    Config.SCW.Service.PortNumber);
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
                if (null == Config.SCW) return string.Empty;
                if (null == Config.SCW.Service) return string.Empty;

                return Config.SCW.Service.UserName;
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
                if (null == Config.SCW) return string.Empty;
                if (null == Config.SCW.Service) return string.Empty;

                return Config.SCW.Service.Password;
            }
        }

        #endregion
    }
}
