#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using NLib;
using NLib.Design;
using NLib.Reflection;

using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
// required for JsonIgnore attribute.
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Reflection;

#endregion

namespace DMT.Models
{
    #region TSB

    /// <summary>
    /// The TSB Data Model class.
    /// </summary>
    [TypeConverter(typeof(PropertySorterSupportExpandableTypeConverter))]
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    //[Table("TSB")]
    public class TSB : NTable<TSB>
    {
        #region Intenral Variables

        private string _TSBId = string.Empty;
        private string _TSBNameEN = string.Empty;
        private string _TSBNameTH = string.Empty;
        private string _NetworkId = string.Empty;

        private bool _Active = false;

        // Update User
        private string _UserId = string.Empty;
        private string _FullNameEN = string.Empty;
        private string _FullNameTH = string.Empty;

        private DateTime? _UpdateDate = new DateTime?();

        private decimal _MaxCredit = decimal.Zero;
        private decimal _ST25LowLimit = decimal.Zero;
        private decimal _ST50LowLimit = decimal.Zero;
        private decimal _BHT1LowLimit = decimal.Zero;
        private decimal _BHT2LowLimit = decimal.Zero;
        private decimal _BHT5LowLimit = decimal.Zero;
        private decimal _BHT10LowLimit = decimal.Zero;
        private decimal _BHT20LowLimit = decimal.Zero;
        private decimal _BHT50LowLimit = decimal.Zero;
        private decimal _BHT100LowLimit = decimal.Zero;
        private decimal _BHT500LowLimit = decimal.Zero;
        private decimal _BHT1000LowLimit = decimal.Zero;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public TSB() : base() { }

        #endregion

        #region Public Proprties

        #region Common

        /// <summary>
        /// Gets or sets TSBId.
        /// </summary>
        [Category("Common")]
        [Description("Gets or sets TSBId.")]
        [PrimaryKey, MaxLength(10)]
        [PropertyMapName("TSBId")]
        public string TSBId
        {
            get
            {
                return _TSBId;
            }
            set
            {
                if (_TSBId != value)
                {
                    _TSBId = value;
                    this.RaiseChanged("TSBId");
                }
            }
        }
        /// <summary>
        /// Gets or sets NetworkId.
        /// </summary>
        [Category("Common")]
        [Description("Gets or sets NetworkId.")]
        [MaxLength(10)]
        [PropertyMapName("NetworkId")]
        public string NetworkId
        {
            get
            {
                return _NetworkId;
            }
            set
            {
                if (_NetworkId != value)
                {
                    _NetworkId = value;
                    this.RaiseChanged("NetworkId");
                }
            }
        }
        /// <summary>
        /// Gets or sets TSBNameEN.
        /// </summary>
        [Category("Common")]
        [Description("Gets or sets TSBNameEN.")]
        [MaxLength(100)]
        [PropertyMapName("TSBNameEN")]
        public string TSBNameEN
        {
            get
            {
                return _TSBNameEN;
            }
            set
            {
                if (_TSBNameEN != value)
                {
                    _TSBNameEN = value;
                    this.RaiseChanged("TSBNameEN");
                }
            }
        }
        /// <summary>
        /// Gets or sets TSBNameTH.
        /// </summary>
        [Category("Common")]
        [Description("Gets or sets TSBNameTH.")]
        [MaxLength(100)]
        [PropertyMapName("TSBNameTH")]
        public string TSBNameTH
        {
            get
            {
                return _TSBNameTH;
            }
            set
            {
                if (_TSBNameTH != value)
                {
                    _TSBNameTH = value;
                    this.RaiseChanged("TSBNameTH");
                }
            }
        }
        /// <summary>
        /// Gets or sets is active TSB.
        /// </summary>
        [Category("Common")]
        [Description("Gets or sets is active TSB.")]
        [ReadOnly(true)]
        [PropertyMapName("Active")]
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                if (_Active != value)
                {
                    _Active = value;
                    this.RaiseChanged("Active");
                }
            }
        }

        #endregion

        #region User

        /// <summary>
        /// Gets or sets User Id
        /// </summary>
        [Category("User")]
        [Description("Gets or sets User Id.")]
        [ReadOnly(true)]
        [Indexed]
        [MaxLength(10)]
        [PropertyMapName("UserId")]
        public virtual string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    this.RaiseChanged("UserId");
                }
            }
        }
        /// <summary>
        /// Gets or sets User Full Name EN
        /// </summary>
        [Category("User")]
        [Description("Gets or sets User Full Name EN.")]
        [ReadOnly(true)]
        [MaxLength(150)]
        [PropertyMapName("FullNameEN")]
        public virtual string FullNameEN
        {
            get
            {
                return _FullNameEN;
            }
            set
            {
                if (_FullNameEN != value)
                {
                    _FullNameEN = value;
                    this.RaiseChanged("FullNameEN");
                }
            }
        }
        /// <summary>
        /// Gets or sets User Full Name TH
        /// </summary>
        [Category("User")]
        [Description("Gets or sets User Full Name TH.")]
        [ReadOnly(true)]
        [MaxLength(150)]
        [PropertyMapName("FullNameTH")]
        public virtual string FullNameTH
        {
            get
            {
                return _FullNameTH;
            }
            set
            {
                if (_FullNameTH != value)
                {
                    _FullNameTH = value;
                    this.RaiseChanged("FullNameTH");
                }
            }
        }
        /// <summary>
        /// Gets or sets Update Date.
        /// </summary>
        [Category("User")]
        [Description("Gets or sets Update Date.")]
        [ReadOnly(true)]
        [PropertyMapName("UpdateDate")]
        public virtual DateTime? UpdateDate
        {
            get
            {
                return _UpdateDate;
            }
            set
            {
                if (_UpdateDate != value)
                {
                    _UpdateDate = value;
                    this.RaiseChanged("UpdateDate");
                }
            }
        }

        #endregion

        #region Credit

        /// <summary>
        /// Gets or sets Max TSB Credit.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Max TSB Credit.")]
        [PropertyMapName("MaxCredit")]
        public decimal MaxCredit
        {
            get
            {
                return _MaxCredit;
            }
            set
            {
                if (_MaxCredit != value)
                {
                    _MaxCredit = value;
                    this.RaiseChanged("MaxCredit");
                }
            }
        }

        #region Credit

        /// <summary>
        /// Gets or sets Low Limit for ST25.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for ST25.")]
        [PropertyMapName("ST25LowLimit")]
        public decimal ST25LowLimit
        {
            get
            {
                return _ST25LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_ST25LowLimit != value)
                {
                    _ST25LowLimit = value;
                    this.RaiseChanged("ST25LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for ST50.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for ST50.")]
        [PropertyMapName("ST50LowLimit")]
        public decimal ST50LowLimit
        {
            get
            {
                return _ST50LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_ST50LowLimit != value)
                {
                    _ST50LowLimit = value;
                    this.RaiseChanged("ST50LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT1.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT1.")]
        [PropertyMapName("BHT1LowLimit")]
        public decimal BHT1LowLimit
        {
            get
            {
                return _BHT1LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT1LowLimit != value)
                {
                    _BHT1LowLimit = value;
                    this.RaiseChanged("BHT1LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT2.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT2.")]
        [PropertyMapName("BHT2LowLimit")]
        public decimal BHT2LowLimit
        {
            get
            {
                return _BHT2LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT2LowLimit != value)
                {
                    _BHT2LowLimit = value;
                    this.RaiseChanged("BHT2LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT5.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT5.")]
        [PropertyMapName("BHT5LowLimit")]
        public decimal BHT5LowLimit
        {
            get
            {
                return _BHT5LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT5LowLimit != value)
                {
                    _BHT5LowLimit = value;
                    this.RaiseChanged("BHT5LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT10.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT10.")]
        [PropertyMapName("BHT10LowLimit")]
        public decimal BHT10LowLimit
        {
            get
            {
                return _BHT10LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT10LowLimit != value)
                {
                    _BHT10LowLimit = value;
                    this.RaiseChanged("BHT10LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT20.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT20.")]
        [PropertyMapName("BHT20LowLimit")]
        public decimal BHT20LowLimit
        {
            get
            {
                return _BHT20LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT20LowLimit != value)
                {
                    _BHT20LowLimit = value;
                    this.RaiseChanged("BHT20LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT50.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT50.")]
        [PropertyMapName("BHT50LowLimit")]
        public decimal BHT50LowLimit
        {
            get
            {
                return _BHT50LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT50LowLimit != value)
                {
                    _BHT50LowLimit = value;
                    this.RaiseChanged("BHT50LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT100.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT100.")]
        [PropertyMapName("BHT100LowLimit")]
        public decimal BHT100LowLimit
        {
            get
            {
                return _BHT100LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT100LowLimit != value)
                {
                    _BHT100LowLimit = value;
                    this.RaiseChanged("BHT100LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT500.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT500.")]
        [PropertyMapName("BHT500LowLimit")]
        public decimal BHT500LowLimit
        {
            get
            {
                return _BHT500LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT500LowLimit != value)
                {
                    _BHT500LowLimit = value;
                    this.RaiseChanged("BHT500LowLimit");
                }
            }
        }
        /// <summary>
        /// Gets or sets Low Limit for BHT1000.
        /// </summary>
        [Category("Credits")]
        [Description("Gets or sets Low Limit for BHT1.")]
        [PropertyMapName("BHT1000LowLimit")]
        public decimal BHT1000LowLimit
        {
            get
            {
                return _BHT1000LowLimit;
            }
            set
            {
                if (value < decimal.Zero) return;
                if (_BHT1000LowLimit != value)
                {
                    _BHT1000LowLimit = value;
                    this.RaiseChanged("BHT1000LowLimit");
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Static Methods

        #region Get All TSBs

        /// <summary>
        /// Gets TSBs.
        /// </summary>
        /// <param name="db">The database connection.</param>
        /// <returns>Returns List of TSB.</returns>
        public static NDbResult<List<TSB>> GetTSBs(SQLiteConnection db)
        {
            var result = new NDbResult<List<TSB>>();
            if (null == db)
            {
                result.DbConenctFailed();
                return result;
            }
            lock (sync)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    string cmd = string.Empty;
                    cmd += "SELECT * FROM TSB ";
                    result.Success();
                    var data = NQuery.Query<TSB>(cmd);
                    result.Success(data);
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    result.Error(ex);
                }
                return result;
            }
        }
        /// <summary>
        /// Gets TSBs.
        /// </summary>
        /// <returns>Returns List of TSB.</returns>
        public static NDbResult<List<TSB>> GetTSBs()
        {
            lock (sync)
            {
                SQLiteConnection db = Default;
                return GetTSBs(db);
            }
        }

        #endregion

        #region Get TSB By TSBId

        /// <summary>
        /// Gets TSB By TSB Id.
        /// </summary>
        /// <param name="db">The database connection.</param>
        /// <param name="tsbId">The TSB Id.</param>
        /// <returns>Returns TSB instance.</returns>
        public static NDbResult<TSB> GetTSB(SQLiteConnection db, string tsbId)
        {
            var result = new NDbResult<TSB>();
            if (null == db)
            {
                result.DbConenctFailed();
                return result;
            }
            lock (sync)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    string cmd = string.Empty;
                    cmd += "SELECT * FROM TSB ";
                    cmd += " WHERE TSBId = ? ";
                    var data = NQuery.Query<TSB>(cmd, tsbId).FirstOrDefault();
                    result.Success(data);
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    result.Error(ex);
                }
                return result;
            }
        }
        /// <summary>
        /// Gets TSB By TSB Id.
        /// </summary>
        /// <param name="tsbId">The TSB Id.</param>
        /// <returns>Returns TSB instance.</returns>
        public static NDbResult<TSB> GetTSB(string tsbId)
        {
            lock (sync)
            {
                SQLiteConnection db = Default;
                return GetTSB(db, tsbId);
            }
        }

        #endregion

        #region Get Current (Active) TSB

        /// <summary>
        /// Gets Active TSB.
        /// </summary>
        /// <returns>Returns Active TSB instance.</returns>
        public static NDbResult<TSB> GetCurrent()
        {
            var result = new NDbResult<TSB>();
            SQLiteConnection db = Default;
            if (null == db)
            {
                result.DbConenctFailed();
                return result;
            }
            lock (sync)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    // inactive all TSBs
                    string cmd = string.Empty;
                    cmd += "SELECT * FROM TSB ";
                    cmd += " WHERE Active = 1 ";
                    var results = NQuery.Query<TSB>(cmd);
                    var data = (null != results) ? results.FirstOrDefault() : null;
                    result.Success(data);
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    result.Error(ex);
                }
                return result;
            }
        }

        #endregion

        #region Set Active TSB

        /// <summary>
        /// Set Active by TSB Id.
        /// </summary>
        /// <param name="tsbId">The TSB Id.</param>
        /// <returns>Returns Set Active status.</returns>
        public static NDbResult SetActive(string tsbId)
        {
            var result = new NDbResult();
            SQLiteConnection db = Default;
            if (null == db)
            {
                result.DbConenctFailed();
                return result;
            }
            lock (sync)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    // inactive all TSBs
                    string cmd = string.Empty;
                    cmd += "UPDATE TSB ";
                    cmd += "   SET Active = 0";
                    NQuery.Execute(cmd);
                    // Set active TSB
                    cmd = string.Empty;
                    cmd += "UPDATE TSB ";
                    cmd += "   SET Active = 1 ";
                    cmd += " WHERE TSBId = ? ";
                    NQuery.Execute(cmd, tsbId);
                    result.Success();
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    result.Error(ex);
                }
                return result;
            }
        }

        #endregion

        #region Save TSB

        /// <summary>
        /// Save TSB.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        /// <returns>Returns TSB instance.</returns>
        public static NDbResult<TSB> SaveTSB(TSB value)
        {
            var result = new NDbResult<TSB>();
            SQLiteConnection db = Default;
            if (null == db)
            {
                result.DbConenctFailed();
                return result;
            }
            lock (sync)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    if (null != value && !value.UpdateDate.HasValue)
                    {
                        value.UpdateDate = DateTime.Now;

                    }
                    result = Save(value);

                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    result.Error(ex);
                }
                return result;
            }
        }

        #endregion

        #endregion
    }

    #endregion
}
