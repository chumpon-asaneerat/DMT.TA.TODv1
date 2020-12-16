﻿#region Using

using System;
using System.Reflection;
using Microsoft.Owin.Hosting;
using System.Web.Http;
using NLib;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// Web Server StartUp class.
    /// </summary>
    public class StartUp : DMTRestServerStartUp
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public StartUp() : base()
        {
            this.AuthenticationValidator = (string userName, string password) =>
            {
                return (userName == "DMTUSER" && password == "DMTPASS2");
            };
            this.EnableSwagger = true;
            this.ApiName = "TOD Application API";
            this.ApiVersion = "v1";
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Init Map Routes.
        /// </summary>
        /// <param name="config">The HttpConfiguration instance.</param>
        protected override void InitMapRoutes(HttpConfiguration config)
        {
            // Handle route by specificed controller (Route Order is important).
            // Calculator2 Controller
            //config.Routes.MapHttpRoute(name: "Calc2ApiAdd", routeTemplate: "api/Calc2/Add", defaults: new { controller = "Calculator2", action = "Add" });
            //config.Routes.MapHttpRoute(name: "Calc2ApiSub", routeTemplate: "api/Calc2/Sub", defaults: new { controller = "Calculator2", action = "Sub" });
            InitDefaultMapRoute(config);
        }

        #endregion
    }

    /// <summary>
    /// TOD WebServer Web Server (Self Host).
    /// </summary>
    public class TODWebServer
    {
        #region Internal Variables

        private string baseAddress = string.Format(@"{0}://{1}:{2}",
            ConfigManager.Instance.Plaza.TODApp.Service.Protocol,
            "+",
            ConfigManager.Instance.Plaza.TODApp.Service.PortNumber);

        private IDisposable server = null;

        #endregion

        #region Private Methods

        private void InitOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.TODApp.Service.PortNumber.ToString();
            string appName = "DMT TOD App Service(REST)";
            var nash = new CommandLine();
            nash.Run("http add urlacl url=http://+:" + portNum + "/ user=Everyone");
            nash.Run("advfirewall firewall add rule dir=in action=allow protocol=TCP localport=" + portNum + " name=\"" + appName + "\" enable=yes profile=Any");
        }

        private void ReleaseOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.TODApp.Service.PortNumber.ToString();
            string appName = "DMT TOD App Service(REST)";
            var nash = new CommandLine();
            nash.Run("http delete urlacl url=http://+:" + portNum + "/");
            nash.Run("advfirewall firewall delete rule name=\"" + appName + "\"");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start service.
        /// </summary>
        public void Start()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            if (null == server)
            {
                InitOwinFirewall();
                server = WebApp.Start<StartUp>(url: baseAddress);
            }
            med.Info("TOD App local nofify service start.");
        }
        /// <summary>
        /// Shutdown service.
        /// </summary>
        public void Shutdown()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
            ReleaseOwinFirewall();
            med.Info("TOD App local nofify service shutdown.");
        }

        #endregion
    }
}
