#region Using

using System;
using NLib;
using DMT.Models;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Runtime Manager class.
    /// </summary>
    public class RuntimeManager
    {
        #region Singelton

        private static RuntimeManager _instance = null;
        /// <summary>
        /// Singelton Access.
        /// </summary>
        public static RuntimeManager Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (typeof(RuntimeManager))
                    {
                        _instance = new RuntimeManager();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private RuntimeManager() : base()
        {
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~RuntimeManager()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Raise TSB Changed
        /// </summary>
        public void RaiseTSBChanged()
        {
            TSBChanged.Call(this, EventArgs.Empty);
        }

        public void RaiseShiftChanged()
        {
            ShiftChanged.Call(this, EventArgs.Empty);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Network Id.
        /// </summary>
        public int NetworkId { get; set; }
        /// <summary>
        /// Gets or sets Active TSB.
        /// </summary>
        public TSB TSB { get; set; }

        public string SCWUserName { get; set; }
        public string SCWPassword { get; set; }

        public string TAxTODUserName { get; set; }
        public string TAxTODPassword { get; set; }

        public string TAAppUserName { get; set; }
        public string TAAppPassword { get; set; }

        public string TODAppUserName { get; set; }
        public string TODAppPassword { get; set; }

        #endregion

        #region Public Events

        /// <summary>
        /// The TSBChanged Event Handler.
        /// </summary>
        public event EventHandler TSBChanged;
        /// <summary>
        /// The ShiftChanged Event Handler.
        /// </summary>
        public event EventHandler ShiftChanged;

        #endregion
    }
}
