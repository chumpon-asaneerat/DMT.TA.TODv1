#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The TAxTOD Operation class.
    /// </summary>
    public static partial class TAxTOD 
    {
        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static ITAxTODConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.TAxTOD) return string.Empty;
                if (null == Config.TAxTOD.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.TAxTOD.Service.Protocol,
                    Config.TAxTOD.Service.HostName,
                    Config.TAxTOD.Service.PortNumber);
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
                if (null == Config.TAxTOD) return string.Empty;
                if (null == Config.TAxTOD.Service) return string.Empty;

                return Config.TAxTOD.Service.UserName;
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
                if (null == Config.TAxTOD) return string.Empty;
                if (null == Config.TAxTOD.Service) return string.Empty;

                return Config.TAxTOD.Service.Password;
            }
        }

        #endregion
    }
}
