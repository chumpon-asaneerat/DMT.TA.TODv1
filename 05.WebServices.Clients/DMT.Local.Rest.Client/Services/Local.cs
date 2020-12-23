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
        /*
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == PlazaConfigManager.Instance.Plaza) return string.Empty;
                if (null == PlazaConfigManager.Instance.Plaza.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    PlazaConfigManager.Instance.Plaza.Service.Protocol,
                    PlazaConfigManager.Instance.Plaza.Service.HostName,
                    PlazaConfigManager.Instance.Plaza.Service.PortNumber);
            }
        }
        */
        #endregion
    }
}
