#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
    #region Parameter class

    /// <summary>The TAServerCouponTransaction class.</summary>
    public class TAServerCouponTransaction
    {
        /// <summary>Gets or sets CouponPK.</summary>
        [PropertyMapName("CouponPK")]
        public int? CouponPK { get; set; }

        /// <summary>Gets or sets TransactionId.</summary>
        ////[PropertyMapName("TransactionId")]
        //public int? TransactionId { get; set; }

        /// <summary>Gets or sets TransactionDate.</summary>
        [PropertyMapName("TransactionDate")]
        public DateTime? TransactionDate { get; set; }

        /// <summary>Gets or sets TSBId.</summary>
        [PropertyMapName("TSBId")]
        public string TSBId { get; set; }

        /// <summary>Gets or sets CouponType.</summary>
        [PropertyMapName("CouponType")]
        public int? CouponType { get; set; }

        /// <summary>Gets or sets SerialNo.</summary>
        [PropertyMapName("SerialNo")]
        public string SerialNo { get; set; }

        /// <summary>Gets or sets Price.</summary>
        [PropertyMapName("Price")]
        public decimal? Price { get; set; }

        /// <summary>Gets or sets CouponStatus.</summary>
        [PropertyMapName("CouponStatus")]
        public int? CouponStatus { get; set; }

        /// <summary>Gets or sets LaneId.</summary>
        [PropertyMapName("LaneId")]
        public string LaneId { get; set; }

        /// <summary>Gets or sets UserId.</summary>
        [PropertyMapName("UserId")]
        public string UserId { get; set; }

        /// <summary>Gets or sets UserReceiveDate.</summary>
        [PropertyMapName("UserReceiveDate")]
        public DateTime? UserReceiveDate { get; set; }

        /// <summary>Gets or sets SoldDate.</summary>
        [PropertyMapName("SoldDate")]
        public DateTime? SoldDate { get; set; }

        /// <summary>Gets or sets SoldBy.</summary>
        [PropertyMapName("SoldBy")]
        public string SoldBy { get; set; }

        /// <summary>Gets or sets FinishFlag.</summary>
        [PropertyMapName("FinishFlag")]
        public int? FinishFlag { get; set; }

        /// <summary>Gets or sets SapChooseFlag.</summary>
        [PropertyMapName("SapChooseFlag")]
        public int? SapChooseFlag { get; set; }

        /// <summary>Gets or sets SapChooseDate.</summary>
        [PropertyMapName("SapChooseDate")]
        public DateTime? SapChooseDate { get; set; }
    }

    #endregion
}
