#region Using

using System;
using System.Collections.Generic;
using NLib.Reflection;

#endregion

namespace DMT.Models
{
    #region SCWBOJ/SCWBOJResult

    #region Parameter class

    /// <summary>
    /// SCW BOJ class.
    /// </summary>
    public class SCWBOJ
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
    }

    #endregion

    #region Result class

    /// <summary>
    /// SCW BOJ Result class.
    /// </summary>
    public class SCWBOJResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }

    #endregion

    #endregion

    #region SCWEOJ/SCWEOJResult

    #region Parameter class

    /// <summary>
    /// SCW EOJ class.
    /// </summary>
    public class SCWEOJ
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
    }

    #endregion

    #region Result class

    /// <summary>
    /// SCW EOJ Result class.
    /// </summary>
    public class SCWEOJResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }

    #endregion

    #endregion

    #region SCWRemoveJobs/SCWRemoveJobsResult

    #region Parameter class

    /// <summary>
    /// The SCWRemoveJobs class.
    /// </summary>
    public class SCWRemoveJobs
    {
        public SCWRemoveJobs() : base()
        {
            jobs = new List<SCWJob>();
        }
        public List<SCWJob> jobs { get; set; }
    }

    #endregion

    #region Result class

    /// <summary>
    /// The SCWRemoveJobsResult class
    /// </summary>
    public class SCWRemoveJobsResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }

    #endregion

    #endregion

    #region SCWClearJobs/SCWClearJobsResult

    #region Parameter class

    /// <summary>
    /// The SCWClearJobs class.
    /// </summary>
    public class SCWClearJobs { }

    #endregion

    #region Result class

    /// <summary>
    /// The SCWClearJobsResult class.
    /// </summary>
    public class SCWClearJobsResult
    {
        /// <summary>Gets or sets status.</summary>
        [PropertyMapName("status")]
        public SCWStatus status { get; set; }
    }

    #endregion

    #endregion
}
