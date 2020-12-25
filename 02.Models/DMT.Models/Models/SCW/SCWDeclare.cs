#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
    #region Parameter related classes

    /// <summary>The SCWDeclareCash class.</summary>
    public class SCWDeclareCash
    {
        /// <summary>Gets or sets currencyId.</summary>
        [PropertyMapName("currencyId")]
        public int currencyId { get; set; }

        /// <summary>Gets or sets currencyDenomId.</summary>
        [PropertyMapName("currencyDenomId")]
        public int currencyDenomId { get; set; }

        /// <summary>Gets or sets denomValue.</summary>
        [PropertyMapName("denomValue")]
        public decimal denomValue { get; set; }

        /// <summary>Gets or sets number.</summary>
        [PropertyMapName("number")]
        public int number { get; set; }

        /// <summary>Gets or sets total.</summary>
        [PropertyMapName("total")]
        public decimal total { get; set; }
    }

    /// <summary>The SCWDeclareCoupon class.</summary>
    public class SCWDeclareCoupon
    {
        /// <summary>Gets or sets couponId.</summary>
        [PropertyMapName("couponId")]
        public int couponId { get; set; }

        /// <summary>Gets or sets couponValue.</summary>
        [PropertyMapName("couponValue")]
        public decimal couponValue { get; set; }

        /// <summary>Gets or sets number.</summary>
        [PropertyMapName("number")]
        public int number { get; set; }

        /// <summary>Gets or sets total.</summary>
        [PropertyMapName("currentotalcyId")]
        public decimal total { get; set; }
    }

    /// <summary>The SCWDeclareCouponBook class.</summary>
    public class SCWDeclareCouponBook
    {
        /// <summary>Gets or sets couponBookId.</summary>
        [PropertyMapName("couponBookId")]
        public int couponBookId { get; set; }

        /// <summary>Gets or sets couponBookValue.</summary>
        [PropertyMapName("couponBookValue")]
        public decimal couponBookValue { get; set; }

        /// <summary>Gets or sets number.</summary>
        [PropertyMapName("number")]
        public int number { get; set; }

        /// <summary>Gets or sets total.</summary>
        [PropertyMapName("total")]
        public decimal total { get; set; }
    }

    /// <summary>The SCWDeclareFreePass class.</summary>
    public class SCWDeclareFreePass
    {
        /// <summary>Gets or sets cardAllowId.</summary>
        [PropertyMapName("cardAllowId")]
        public int cardAllowId { get; set; }

        /// <summary>Gets or sets number.</summary>
        [PropertyMapName("number")]
        public int number { get; set; }
    }

    /// <summary>The SCWDeclareQRCode class.</summary>
    public class SCWDeclareQRCode
    {
        /// <summary>Gets or sets approvalCode.</summary>
        [PropertyMapName("approvalCode")]
        public string approvalCode { get; set; }

        /// <summary>Gets or sets trxDate.</summary>
        [PropertyMapName("trxDate")]
        public DateTime trxDate { get; set; }

        /// <summary>Gets or sets amount.</summary>
        [PropertyMapName("amount")]
        public decimal amount { get; set; }
    }

    /// <summary>The SCWDeclareEMV class.</summary>
    public class SCWDeclareEMV
    {
        /// <summary>Gets or sets approvalCode.</summary>
        [PropertyMapName("approvalCode")]
        public string approvalCode { get; set; }

        /// <summary>Gets or sets trxDate.</summary>
        [PropertyMapName("trxDate")]
        public DateTime trxDate { get; set; }

        /// <summary>Gets or sets amount.</summary>
        [PropertyMapName("amount")]
        public decimal amount { get; set; }
    }

    /// <summary>The SCWDeclare class.</summary>
    public class SCWDeclare
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

        /// <summary>Gets or sets bagNumber.</summary>
        [PropertyMapName("bagNumber")]
        public string bagNumber { get; set; }

        /// <summary>Gets or sets safetyBeltNumber.</summary>
        [PropertyMapName("safetyBeltNumber")]
        public string safetyBeltNumber { get; set; }

        /// <summary>Gets or sets shiftTypeId.</summary>
        [PropertyMapName("shiftTypeId")]
        public int? shiftTypeId { get; set; }

        /// <summary>Gets or sets declareDateTime.</summary>
        [PropertyMapName("declareDateTime")]
        public DateTime? declareDateTime { get; set; }

        /// <summary>Gets or sets attendanceDateTime.</summary>
        [PropertyMapName("attendanceDateTime")]
        public DateTime? attendanceDateTime { get; set; }

        /// <summary>Gets or sets departureDateTime.</summary>
        [PropertyMapName("departureDateTime")]
        public DateTime? departureDateTime { get; set; }

        /// <summary>Gets or sets operationDate.</summary>
        [PropertyMapName("operationDate")]
        public DateTime? operationDate { get; set; }

        /// <summary>Gets or sets declareById.</summary>
        [PropertyMapName("declareById")]
        public string declareById { get; set; }

        /// <summary>Gets or sets declareByName.</summary>
        [PropertyMapName("declareByName")]
        public string declareByName { get; set; }

        /// <summary>Gets or sets cashTotalAmount.</summary>
        [PropertyMapName("cashTotalAmount")]
        public decimal? cashTotalAmount { get; set; }

        /// <summary>Gets or sets couponTotalAmount.</summary>
        [PropertyMapName("couponTotalAmount")]
        public decimal? couponTotalAmount { get; set; }

        /// <summary>Gets or sets couponBookTotalAmount.</summary>
        [PropertyMapName("couponBookTotalAmount")]
        public decimal? couponBookTotalAmount { get; set; }

        /// <summary>Gets or sets cardAllowTotalAmount.</summary>
        [PropertyMapName("cardAllowTotalAmount")]
        public decimal? cardAllowTotalAmount { get; set; }

        /// <summary>Gets or sets qrcodeTotalAmount.</summary>
        [PropertyMapName("qrcodeTotalAmount")]
        public decimal? qrcodeTotalAmount { get; set; }

        /// <summary>Gets or sets emvTotalAmount.</summary>
        [PropertyMapName("emvTotalAmount")]
        public decimal? emvTotalAmount { get; set; }

        /// <summary>Gets or sets otherTotalAmount.</summary>
        [PropertyMapName("otherTotalAmount")]
        public decimal? otherTotalAmount { get; set; }

        /// <summary>Gets or sets cashRemark.</summary>
        [PropertyMapName("cashRemark")]
        public string cashRemark { get; set; }

        /// <summary>Gets or sets otherRemark.</summary>
        [PropertyMapName("otherRemark")]
        public string otherRemark { get; set; }

        /// <summary>Gets or sets chiefId.</summary>
        [PropertyMapName("chiefId")]
        public string chiefId { get; set; }

        /// <summary>Gets or sets chiefName.</summary>
        [PropertyMapName("chiefName")]
        public string chiefName { get; set; }

        /// <summary>Gets or sets jobList.</summary>
        //[PropertyMapName("jobList")]
        public List<SCWJob> jobList { get; set; }

        /// <summary>Gets or sets cashList.</summary>
        //[PropertyMapName("cashList")]
        public List<SCWDeclareCash> cashList { get; set; }

        /// <summary>Gets or sets couponList.</summary>
        //[PropertyMapName("couponList")]
        public List<SCWDeclareCoupon> couponList { get; set; }

        /// <summary>Gets or sets couponBookList.</summary>
        //[PropertyMapName("couponBookList")]
        public List<SCWDeclareCouponBook> couponBookList { get; set; }

        /// <summary>Gets or sets cardAllowList.</summary>
        //[PropertyMapName("cardAllowList")]
        public List<SCWDeclareFreePass> cardAllowList { get; set; }

        /// <summary>Gets or sets qrcodeList.</summary>
        //[PropertyMapName("qrcodeList")]
        public List<SCWDeclareQRCode> qrcodeList { get; set; }

        /// <summary>Gets or sets emvList.</summary>
        //[PropertyMapName("emvList")]
        public List<SCWDeclareEMV> emvList { get; set; }
    }

    #endregion

    #region Result class

    /// <summary>The SCWDeclareResult class.</summary>
    public class SCWDeclareResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }

    #endregion
}
