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

#endregion

namespace DMT.Models
{
	#region Configs(key) constants

	/// <summary>
	/// The Config key constants.
	/// </summary>
	public static class ConfigKeys
	{
		/// <summary>
		/// Common Config key constants.
		/// </summary>
		public static class Common
		{
			// for common used
			public static string network = "network";
			public static string tsb = "tsb";
			public static string terminal = "terminal";
		}
		/// <summary>
		/// SCW Config key constants.
		/// </summary>
		public static class SCW
		{
			// for SCW Server
			public static string username = "scw_username";
			public static string password = "scw_password";
		}
		/// <summary>
		/// TAxTOD Config key constants.
		/// </summary>
		public static class TAxTOD
		{
			// for TAxTOD Server
			public static string username = "taxtod_username";
			public static string password = "taxtod_password";
		}
		/// <summary>
		/// TAApp Config key constants.
		/// </summary>
		public static class TAApp
		{
			// for TA app notify callback server
			public static string username = "taapp_username";
			public static string password = "taapp_password";
		}
		/// <summary>
		/// TODApp Config key constants.
		/// </summary>
		public static class TODApp
		{
			// for TOD app notify callback server
			public static string username = "todapp_username";
			public static string password = "todapp_password";
		}
	}

	#endregion

	#region Config

	/// <summary>
	/// The Config Data Model Class.
	/// </summary>
	[TypeConverter(typeof(PropertySorterSupportExpandableTypeConverter))]
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	//[Table("Config")]
	public class Config : NTable<Config>
	{
		#region Intenral Variables

		private string _Key = string.Empty;
		private string _Value = string.Empty;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public Config() : base() { }

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets Key
		/// </summary>
		[Category("Common")]
		[Description("Gets or sets Key")]
		[PrimaryKey, MaxLength(30)]
		[PropertyMapName("Key")]
		public string Key
		{
			get
			{
				return _Key;
			}
			set
			{
				if (_Key != value)
				{
					_Key = value;
					this.RaiseChanged("Key");
				}
			}
		}
		/// <summary>
		/// Gets or sets Value
		/// </summary>
		[Category("Common")]
		[Description("Gets or sets Value")]
		[MaxLength(100)]
		[PropertyMapName("Value")]
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (_Value != value)
				{
					_Value = value;
					this.RaiseChanged("Value");
				}
			}
		}

		#endregion
	}

	#endregion
}
