﻿#region Using

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NLib;
using NLib.IO;
using Newtonsoft.Json;
using NLib.Controls.Design;

#endregion

namespace DMT.Services
{
    #region Plaza Config and related classes

    #region WebServiceConfig

    /// <summary>
    /// The WebServiceConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class WebServiceConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public WebServiceConfig()
        {
            this.Protocol = "http";
            this.HostName = "localhost";
            this.PortNumber = 9000;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is WebServiceConfig)) return false;
            return this.GetString() == (obj as WebServiceConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            string code = string.Format("{0}://{1}:{2}",
                this.Protocol, this.HostName, this.PortNumber);
            return code;
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets protocol.
        /// </summary>
        public string Protocol { get; set; }
        /// <summary>
        /// Gets or sets Host Name or IP Address.
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Gets or sets port number.
        /// </summary>
        public int PortNumber { get; set; }

        #endregion
    }

    #endregion

    #region LocalWebServiceConfig

    /// <summary>
    /// The LocalWebServiceConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class LocalWebServiceConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalWebServiceConfig() 
        {
            this.Http = new WebServiceConfig()
            {
                Protocol = "http",
                HostName = "localhost",
                PortNumber = 9000
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is LocalWebServiceConfig)) return false;
            return this.GetString() == (obj as LocalWebServiceConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            if (null != this.Http)
                return string.Format("{0}", this.Http.GetString());
            else return "Local http is null.";
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Http service.
        /// </summary>
        public WebServiceConfig Http { get; set; }

        #endregion
    }

    #endregion

    #region TAxTODWebServiceConfig

    /// <summary>
    /// The TAxTODWebServiceConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class TAxTODWebServiceConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public TAxTODWebServiceConfig()
        {
            this.Http = new WebServiceConfig()
            {
                Protocol = "http",
                HostName = "localhost",
                PortNumber = 3000
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is TAxTODWebServiceConfig)) return false;
            return this.GetString() == (obj as TAxTODWebServiceConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            if (null != this.Http)
                return string.Format("{0}", this.Http.GetString());
            else return "TAxTOD http is null.";
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Http service.
        /// </summary>
        public WebServiceConfig Http { get; set; }

        #endregion
    }

    #endregion

    #region SCWWebServiceConfig

    /// <summary>
    /// The SCWWebServiceConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class SCWWebServiceConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public SCWWebServiceConfig()
        {
            this.Http = new WebServiceConfig()
            {
                Protocol = "http",
                HostName = "192.168.244.252",
                PortNumber = 8110
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is SCWWebServiceConfig)) return false;
            return this.GetString() == (obj as SCWWebServiceConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            if (null != this.Http)
                return string.Format("{0}", this.Http.GetString());
            else return "DC http is null.";
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Http service.
        /// </summary>
        public WebServiceConfig Http { get; set; }

        #endregion
    }

    #endregion

    #region TAAppConfig

    /// <summary>
    /// The TAAppConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class TAAppConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public TAAppConfig()
        {
            this.Http = new WebServiceConfig()
            {
                Protocol = "http",
                HostName = "localhost",
                PortNumber = 9001
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is TAAppConfig)) return false;
            return this.GetString() == (obj as TAAppConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            if (null != this.Http)
                return string.Format("{0}", this.Http.GetString());
            else return "TA App http is null.";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Http service.
        /// </summary>
        public WebServiceConfig Http { get; set; }

        #endregion
    }

    #endregion

    #region TODAppConfig

    /// <summary>
    /// The TAAppConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class TODAppConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public TODAppConfig()
        {
            this.Http = new WebServiceConfig()
            {
                Protocol = "http",
                HostName = "localhost",
                PortNumber = 9002
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is TODAppConfig)) return false;
            return this.GetString() == (obj as TODAppConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            if (null != this.Http)
                return string.Format("{0}", this.Http.GetString());
            else return "TOD App http is null.";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Http service.
        /// </summary>
        public WebServiceConfig Http { get; set; }

        #endregion
    }

    #endregion

    #region PlazaConfig

    /// <summary>
    /// The PlazaConfig class.
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class PlazaConfig
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlazaConfig() : base()
        {
            this.Local = new LocalWebServiceConfig();
            this.TAxTOD = new TAxTODWebServiceConfig();
            this.SCW = new SCWWebServiceConfig();
            this.TAApp = new TAAppConfig();
            this.TODApp = new TODAppConfig();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// IsEquals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsEquals(object obj)
        {
            if (null == obj || !(obj is PlazaConfig)) return false;
            return this.GetString() == (obj as PlazaConfig).GetString();
        }
        /// <summary>
        /// GetString.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            string code = string.Empty;
            if (null == this.Local)
            {
                code += "Local: null" + Environment.NewLine;
            }
            else
            {
                code += string.Format("Local: {0}", 
                    this.Local.GetString()) + Environment.NewLine;
            }
            if (null == this.TAxTOD)
            {
                code += "TAxTOD: null" + Environment.NewLine;
            }
            else
            {
                code += string.Format("TAxTOD: {0}", 
                    this.TAxTOD.GetString()) + Environment.NewLine;
            }
            if (null == this.SCW)
            {
                code += "SCW: null" + Environment.NewLine;
            }
            else
            {
                code += string.Format("DC: {0}", 
                    this.SCW.GetString()) + Environment.NewLine;
            }
            return code;
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Local Service Config.
        /// </summary>
        public LocalWebServiceConfig Local { get; set; }
        /// <summary>
        /// Gets or sets TAxTOD Service Config.
        /// </summary>
        public TAxTODWebServiceConfig TAxTOD { get; set; }
        /// <summary>
        /// Gets or sets SCW Service Config.
        /// </summary>
        public SCWWebServiceConfig SCW { get; set; }
        /// <summary>
        /// Gets or sets TA App Service Config (for notify).
        /// </summary>
        public TAAppConfig TAApp { get; set; }
        /// <summary>
        /// Gets or sets TOD App Service Config (for notify).
        /// </summary>
        public TODAppConfig TODApp { get; set; }

        #endregion
    }

    #endregion

    #endregion

    #region ConfigManager

    /// <summary>
    /// The ConfigManager class.
    /// </summary>
    public class ConfigManager
    {
        #region Static Instance Access

        private static ConfigManager _instance = null;

        /// <summary>
        /// Gets DMTAppManager instance access.
        /// </summary>
        public static ConfigManager Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (typeof(ConfigManager))
                    {
                        _instance = new ConfigManager();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Internal Variables

        //private Thread _th = null;
        //private DateTime _lastUpdate = DateTime.MinValue;
        //private int _timeout = 15 * 1000; // timeout in ms.

        private string _fileName = NJson.LocalConfigFile("plaza.config.json");
        private PlazaConfig _plazaCfg = new PlazaConfig();

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private ConfigManager() : base()
        {
            IsRunning = false;
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~ConfigManager()
        {
            //Shutdown();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Load Config from file.
        /// </summary>
        public void LoadConfig()
        {
            lock (this)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    // save back to file.
                    if (!NJson.ConfigExists(_fileName))
                    {
                        if (null == _plazaCfg)
                        {
                            _plazaCfg = new PlazaConfig();
                        }
                        NJson.SaveToFile(_plazaCfg, _fileName);
                    }
                    else
                    {
                        // TODO: Check When file is exists but size is zero so config is null.
                        _plazaCfg = NJson.LoadFromFile<PlazaConfig>(_fileName);
                    }
                    // Raise event.
                    ConfigChanged.Call(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                }
            }
        }
        /// <summary>
        /// Save Config to file.
        /// </summary>
        public void SaveConfig()
        {
            lock (this)
            {
                MethodBase med = MethodBase.GetCurrentMethod();
                try
                {
                    // save back to file.
                    if (null == _plazaCfg)
                    {
                        _plazaCfg = new PlazaConfig();
                    }
                    NJson.SaveToFile(_plazaCfg, _fileName);
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets is service is running.
        /// </summary>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// Gets current plaza app information.
        /// </summary>
        public PlazaConfig Plaza 
        { 
            get { return _plazaCfg; }
            set { }
        }

        #endregion

        #region Public Events

        public event EventHandler ConfigChanged;

        #endregion
    }

    #endregion
}
