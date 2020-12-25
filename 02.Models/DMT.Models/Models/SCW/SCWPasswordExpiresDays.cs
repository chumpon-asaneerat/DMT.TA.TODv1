#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models.SCW
{
    /// <summary>The SCWPasswordExpiresDays class.</summary>
    public class SCWPasswordExpiresDays
    {
        /// <summary>Gets or sets networkId.</summary>
        [PropertyMapName("networkId")]
        public int? networkId { get; set; }
    }

    /// <summary>The SCWPasswordExpiresDaysResult class.</summary>
    public class SCWPasswordExpiresDaysResult
    {
        /// <summary>Gets or sets expiresIn.</summary>
        [PropertyMapName("expiresIn")]
        public int? expiresIn { get; set; }

        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }
}
