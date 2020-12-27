#region Using

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Timers;
using System.Threading.Tasks;

using NLib;
using NLib.IO;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Json Message Transfer Service class.
    /// </summary>
    public abstract class JsonMessageTransferService
    {
        #region Constructor and Destructor

        public JsonMessageTransferService() : base() { }
        ~JsonMessageTransferService() 
        { 
        }

        #endregion

        #region Internal Variables

        private Timer _timer = null;
        private bool _scanning = false;

        #endregion

        #region Private Methods

        #region File Managements

        #endregion

        #region Timer Handlers

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_scanning) return;
            _scanning = true;

            MethodBase med = MethodBase.GetCurrentMethod();
            try
            {
                List<string> files = new List<string>();
                var msgFiles = Directory.GetFiles(this.MessageFolder, "*.json");
                if (null != msgFiles && msgFiles.Length > 0) files.AddRange(msgFiles);
                files.ForEach(file =>
                {
                    try
                    {
                        string json = File.ReadAllText(file);
                    }
                    catch (Exception ex2)
                    {
                        med.Err(ex2);
                    }
                });
            }
            catch (Exception ex)
            {
                med.Err(ex);
            }
            _scanning = false;
        }

        #endregion

        #endregion

        #region Protected Methods and Properties

        /// <summary>
        /// Gets Folder Name (sub directory name).
        /// </summary>
        protected abstract string FolderName { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start service.
        /// </summary>
        public void Start()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            // Init Scanning Timer
            _scanning = false;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }
        /// <summary>
        /// Shutdown service.
        /// </summary>
        public void Shutdown()
        {
            //MethodBase med = MethodBase.GetCurrentMethod();
            // Free Scanning Timer 
            try
            {
                if (null != _timer)
                {
                    _timer.Elapsed -= _timer_Elapsed;
                    _timer.Stop();
                    _timer.Dispose();
                }
            }
            catch { }
            _timer = null;
            _scanning = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets root message folder path name.
        /// </summary>
        public string MessageFolder
        {
            get
            {
                string localFilder = Folders.Combine(
                    Folders.Assemblies.CurrentExecutingAssembly, this.FolderName);
                if (!Folders.Exists(localFilder))
                {
                    Folders.Create(localFilder);
                }
                return localFilder;
            }
        }

        #endregion
    }
}
