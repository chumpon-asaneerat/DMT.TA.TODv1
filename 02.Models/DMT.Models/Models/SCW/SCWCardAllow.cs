#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
	/// <summary>The SCWCardAllow class.</summary>
	public class SCWCardAllow
	{
		/// <summary>Gets or sets cardAllowId.</summary>
		[PropertyMapName("cardAllowId")]
		public int cardAllowId { get; set; }

		/// <summary>Gets or sets abbreviation.</summary>
		[PropertyMapName("abbreviation")]
		public string abbreviation { get; set; }

		/// <summary>Gets or sets description.</summary>
		[PropertyMapName("description")]
		public string description { get; set; }
	}

	/// <summary>The SCWCardAllowList class.</summary>
	public class SCWCardAllowList
	{
		/// <summary>Gets or sets list.</summary>
		//[PropertyMapName("list")]
		public List<SCWCardAllow> list { get; set; }

		/// <summary>Gets or sets status.</summary>
		[PropertyMapName("status")]
		public SCWStatus status { get; set; }
	}
}
