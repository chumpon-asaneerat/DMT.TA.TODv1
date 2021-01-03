#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NLib.Reflection;
using DMT.Services;

#endregion

namespace DMT.Models
{
    using localOps = Services.Operations.Plaza; // reference to static class.
    using todOps = Services.Operations.SCW.TOD; // reference to static class.

    /// <summary>
    /// The Lane Job class.
    /// </summary>
    public class LaneJob : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private LaneJob() : base() 
        {
            this.Selected = false;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lane">The Lane model instance.</param>
        public LaneJob(Lane lane) : base()
        {
            this.Lane = lane;
        }

        #endregion

        #region Private Methods

        private void SetCurrentJob(SCWJob value)
        {
            // assign to current job
            Job = value; 
            // Raise related events.
            RaisePropertyChanged("JobNo");
            RaisePropertyChanged("Begin");
            RaisePropertyChanged("BeginDateString");
            RaisePropertyChanged("Begin");
            RaisePropertyChanged("EndTimeString");
            RaisePropertyChanged("EndDateString");
            RaisePropertyChanged("EndTimeString");

            if (null != Job)
            {
                var search = Search.User.ById.Create(Job.staffId);
                // assign to current user
                User = localOps.Security.User.Search.ById(search).Value();
                // Raise related events.
                RaisePropertyChanged("UserId");
                RaisePropertyChanged("FirstNameEN");
                RaisePropertyChanged("FirstNameTH");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Raise PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Assign(List<SCWJob> values)
        {
            if (null == values) return;
            Jobs = values;
            if (null == Lane) return; // No Lane.
            if (null == Jobs || Jobs.Count <= 0) return; // No Jobs.
            Jobs.ForEach(job => 
            {
                if (job.plazaId != SCWPlazaId || job.laneId != LaneNo) 
                    return; // mismatch plaza/lane

            });
            //SetCurrentJob();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets item selected.</summary>
        public bool Selected { get; set; }

        /// <summary>Gets Lane Model instance.</summary>
        public Lane Lane { get; private set; }

        /// <summary>Gets Current User on lane.</summary>
        public User User { get; private set; }

        /// <summary>Gets List of all SCWJob on lane.</summary>
        public List<SCWJob> Jobs { get; private set; }

        /// <summary>Gets Current SCWJob on lane.</summary>
        public SCWJob Job { get; private set; }

        #region TSB

        /// <summary>Gets TSB Id.</summary>
        public string TSBId
        {
            get { return (null != Lane) ? Lane.TSBId : string.Empty; }
            set { }
        }
        /// <summary>Gets TSB Name EN.</summary>
        public string TSBNameEN
        {
            get { return (null != Lane) ? Lane.TSBNameEN : string.Empty; }
            set { }
        }
        /// <summary>Gets TSB Name TH.</summary>
        public string TSBNameTH
        {
            get { return (null != Lane) ? Lane.TSBNameTH : string.Empty; }
            set { }
        }

        #endregion

        #region PlazaGroup

        /// <summary>Gets Plaza Group Id.</summary>
        public string PlazaGroupId
        {
            get { return (null != Lane) ? Lane.PlazaGroupId : string.Empty; }
            set { }
        }
        /// <summary>Gets Plaza Group Name EN.</summary>
        public string PlazaGroupNameEN
        {
            get { return (null != Lane) ? Lane.PlazaGroupNameEN : string.Empty; }
            set { }
        }
        /// <summary>Gets Plaza Grop Name TH.</summary>
        public string PlazaGroupNameTH
        {
            get { return (null != Lane) ? Lane.PlazaGroupNameTH : string.Empty; }
            set { }
        }

        #endregion

        #region Plaza

        /// <summary>Gets Plaza Id.</summary>
        public string PlazaId
        {
            get { return (null != Lane) ? Lane.PlazaId : string.Empty; }
            set { }
        }
        /// <summary>Gets Plaza Name EN.</summary>
        public string PlazaNameEN
        {
            get { return (null != Lane) ? Lane.PlazaNameEN : string.Empty; }
            set { }
        }
        /// <summary>Gets Plaza Name TH.</summary>
        public string PlazaNameTH
        {
            get { return (null != Lane) ? Lane.PlazaNameTH : string.Empty; }
            set { }
        }

        #endregion

        #region Lane

        /// <summary>Gets Lane Id.</summary>
        public string LaneId
        {
            get { return (null != Lane) ? Lane.LaneId : string.Empty; }
            set { }
        }
        /// <summary>Gets Lane No.</summary>
        public int LaneNo
        {
            get { return (null != Lane) ? Lane.LaneNo : 0; }
            set { }
        }
        /// <summary>Gets Lane Type.</summary>
        public string LaneType
        {
            get { return (null != Lane) ? Lane.LaneType : string.Empty; }
            set { }
        }
        /// <summary>Gets SCW Plaza Id.</summary>
        public int SCWPlazaId
        {
            get { return (null != Lane) ? Lane.SCWPlazaId : 0; }
            set { }
        }

        #endregion

        #region User

        /// <summary>Gets User Id.</summary>
        public string UserId
        {
            get { return (null != User) ? User.UserId : string.Empty; }
            set { }
        }
        /// <summary>Gets User Full Name EN.</summary>
        public string FullNameEN
        {
            get { return (null != User) ? User.FullNameEN : string.Empty; }
            set { }
        }
        /// <summary>Gets User Full Name TH.</summary>
        public string FullNameTH
        {
            get { return (null != User) ? User.FullNameTH : string.Empty; }
            set { }
        }

        #endregion

        #region SCWJob

        /// <summary>Gets Job No.</summary>
        public int JobNo
        {
            get { return (null != Job) ? Job.jobNo.Value : 0; }
            set { }
        }

        /// <summary>Gets Begin Job DateTime.</summary>
        public DateTime? Begin
        {
            get { return (null != Job) ? Job.bojDateTime : null; }
            set { }
        }
        /// <summary>Gets Begin Job Date in string.</summary>
        public string BeginDateString
        {
            get
            {
                string val = (null != Job && Job.bojDateTime.HasValue) ?
                    Job.bojDateTime.Value.ToThaiDateTimeString("dd/MM/yyyy") : string.Empty;
                return val;
            }
            set { }
        }
        /// <summary>Gets Begin Job Time in string.</summary>
        public string BeginTimeString
        {
            get 
            {
                string val = (null != Job && Job.bojDateTime.HasValue) ?
                    Job.bojDateTime.Value.ToThaiTimeString() : string.Empty;
                return val;
            }
            set { }
        }

        /// <summary>Gets End Job DateTime.</summary>
        public DateTime? End
        {
            get { return (null != Job) ? Job.eojDateTime : null; }
            set { }
        }
        /// <summary>Gets End Job Date in string.</summary>
        public string EndDateString
        {
            get
            {
                string val = (null != Job && Job.eojDateTime.HasValue) ?
                    Job.eojDateTime.Value.ToThaiDateTimeString("dd/MM/yyyy") : string.Empty;
                return val;
            }
            set { }
        }
        /// <summary>Gets End Job Time in string.</summary>
        public string EndTimeString
        {
            get
            {
                string val = (null != Job && Job.eojDateTime.HasValue) ?
                    Job.eojDateTime.Value.ToThaiTimeString() : string.Empty;
                return val;
            }
            set { }
        }

        /// <summary>Check Has Job.</summary>
        public bool HasJob { get { return null != Job; } set { } }

        #endregion

        #endregion

        #region Public Events

        /// <summary>
        /// The PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets Current TSB Lanes.
        /// </summary>
        /// <returns>Returns avaliable lanes on current TSB.</returns>
        public static List<LaneJob> GetLanes()
        {
            List<LaneJob> results = new List<LaneJob>();
            var tsb = localOps.Infrastructure.TSB.Current().Value();
            if (null != tsb)
            {
                var lanes = localOps.Infrastructure.Lane.Search.ByTSB(tsb).Value();
                if (null != lanes && lanes.Count > 0)
                {
                    lanes.ForEach(lane => 
                    {
                        var inst = new LaneJob(lane);
                        results.Add(inst);
                    });
                }
            }
            return results;
        }
        /// <summary>
        /// Gets Jobs.
        /// </summary>
        /// <param name="networkId">The network id.</param>
        /// <param name="plazaId">The plaza id (SCW).</param>
        /// <param name="staffId">The staff id.</param>
        /// <returns>Returns List of SCWJob.</returns>
        public static List<SCWJob> GetJobs(int networkId, int plazaId, string staffId)
        {
            List<SCWJob> results = null;

            var param = new SCWJobList();
            param.networkId = networkId;
            param.plazaId = plazaId;
            param.staffId = staffId;
            var ret = todOps.jobList(param);
            if (null != ret && null != ret.status && ret.status.code == "S200")
            {
                results = ret.list;
            }

            return results;
        }

        #endregion
    }
}
