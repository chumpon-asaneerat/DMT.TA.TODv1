#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
    /// <summary>The SCWCurrency class.</summary>
    public class SCWCurrency
    {
        /// <summary>Gets or sets currencyId.</summary>
        [PropertyMapName("currencyId")]
        public int currencyId { get; set; }

        /// <summary>Gets or sets currencyDenomId.</summary>
        [PropertyMapName("currencyDenomId")]
        public int currencyDenomId { get; set; }

        /// <summary>Gets or sets abbreviation.</summary>
        [PropertyMapName("abbreviation")]
        public string abbreviation { get; set; }

        /// <summary>Gets or sets description.</summary>
        [PropertyMapName("description")]
        public string description { get; set; }

        /// <summary>Gets or sets denomValue.</summary>
        [PropertyMapName("denomValue")]
        public decimal denomValue { get; set; }

        /// <summary>Gets or sets denomTypeId.</summary>
        [PropertyMapName("denomTypeId")]
        public int denomTypeId { get; set; }
    }

    /// <summary>The SCWCurrencyList class.</summary>
    public class SCWCurrencyList
    {
        /// <summary>Gets or sets list.</summary>
        //[PropertyMapName("list")]
        public List<SCWCurrency> list { get; set; }

        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }
}
