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
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == ConfigManager.Instance.Plaza) return string.Empty;
                if (null == ConfigManager.Instance.Plaza.Local) return string.Empty;
                if (null == ConfigManager.Instance.Plaza.Local.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    ConfigManager.Instance.Plaza.Local.Service.Protocol,
                    ConfigManager.Instance.Plaza.Local.Service.HostName,
                    ConfigManager.Instance.Plaza.Local.Service.PortNumber);
            }
        }

        #endregion
    }
}
