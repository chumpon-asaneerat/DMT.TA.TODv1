#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;
using Newtonsoft.Json;

#endregion

namespace DMT.Models
{
    /// <summary>The SCWJob class.</summary>
    public class SCWJob
    {
        /// <summary>Gets or sets networkId.</summary>
        [PropertyMapName("networkId")]
        public int? networkId { get; set; }

        /// <summary>Gets or sets plazaId.</summary>
        [PropertyMapName("plazaId")]
        public int? plazaId { get; set; }

        /// <summary>Gets or sets laneId.</summary>
        [PropertyMapName("laneId")]
        public int? laneId { get; set; }

        /// <summary>Gets or sets jobNo.</summary>
        [PropertyMapName("jobNo")]
        public int? jobNo { get; set; }

        /// <summary>Gets or sets staffId.</summary>
        [PropertyMapName("staffId")]
        public string staffId { get; set; }

        /// <summary>Gets or sets bojDateTime.</summary>
        [PropertyMapName("bojDateTime")]
        public DateTime? bojDateTime { get; set; }

        /// <summary>Gets or sets eojDateTime.</summary>
        [PropertyMapName("eojDateTime")]
        public DateTime? eojDateTime { get; set; }

        //TODO: Required properties (non json serialization)
        // FullNameEN/TH
        // Selected (??? json serialize required?)
        // boj/eoj Date, Time string.
    }

    /// <summary>The SCWJobList class.</summary>
    public class SCWJobList
    {
        /// <summary>Gets or sets list.</summary>
        //[PropertyMapName("list")]
        public List<SCWJob> list { get; set; }

        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }
}
