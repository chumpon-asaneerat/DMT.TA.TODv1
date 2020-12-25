#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;
using Newtonsoft.Json;

#endregion

namespace DMT.Models
{
    /// <summary>The SCWSaveChiefDuty class.</summary>
    public class SCWSaveChiefDuty
    {
        /// <summary>Gets or sets networkId.</summary>
        [PropertyMapName("networkId")]
        public int? networkId { get; set; }

        /// <summary>Gets or sets plazaId.</summary>
        [PropertyMapName("plazaId")]
        public int? plazaId { get; set; }

        /// <summary>Gets or sets staffId.</summary>
        [PropertyMapName("staffId")]
        public string staffId { get; set; }

        /// <summary>Gets or sets staffTypeId.</summary>
        [PropertyMapName("staffTypeId")]
        public string staffTypeId { get; set; }

        /// <summary>Gets or sets beginDateTime.</summary>
        [PropertyMapName("beginDateTime")]
        public DateTime? beginDateTime { get; set; }
    }

    /// <summary>The SCWSaveChiefDutyResult class.</summary>
    public class SCWSaveChiefDutyResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }
}
