#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
    /// <summary>The SCWStatus class.</summary>
    public class SCWStatus
    {
        /// <summary>Gets or sets code.</summary>
        [PropertyMapName("code")]
        public string code { get; set; }

        /// <summary>Gets or sets message.</summary>
        [PropertyMapName("message")]
        public string message { get; set; }
    }
}
