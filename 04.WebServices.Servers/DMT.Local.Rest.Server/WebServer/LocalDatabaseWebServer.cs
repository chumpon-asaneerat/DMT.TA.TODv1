#region Using

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
            this.ApiName = "TOD&TA Local Server API";
            this.ApiVersion = "v1";
        }

        #endregion

        internal static class MapControllers
        {
            internal static class Infrastructure 
            {
                internal static class TSB 
                {
                    internal static void MapRoutes(HttpConfiguration config)
                    {
                        string controllerName, actionName, actionUrl;

                        // Set Controller Name.
                        controllerName = RouteConsts.Infrastructure.TSB.ControllerName;

                        // Gets
                        actionName = RouteConsts.Infrastructure.TSB.Gets.Name;
                        actionUrl = RouteConsts.Infrastructure.TSB.Gets.Url;
                        Helper.MapRoute(config, controllerName, actionName, actionUrl); // Map Route.
                    }
                }
                
                internal static class PlazaGroup 
                {
                    internal static void MapRoutes(HttpConfiguration config)
                    {
                        string controllerName, actionName, actionUrl;

                        // Set Controller Name.
                        controllerName = RouteConsts.Infrastructure.PlazaGroup.ControllerName;

                        // Gets
                        actionName = RouteConsts.Infrastructure.PlazaGroup.Gets.Name;
                        actionUrl = RouteConsts.Infrastructure.PlazaGroup.Gets.Url;
                        Helper.MapRoute(config, controllerName, actionName, actionUrl); // Map Route.
                    }
                }

                internal static class Plaza 
                {
                    internal static void MapRoutes(HttpConfiguration config)
                    {
                        string controllerName, actionName, actionUrl;

                        // Set Controller Name.
                        controllerName = RouteConsts.Infrastructure.Plaza.ControllerName;

                        // Gets
                        actionName = RouteConsts.Infrastructure.Plaza.Gets.Name;
                        actionUrl = RouteConsts.Infrastructure.Plaza.Gets.Url;
                        Helper.MapRoute(config, controllerName, actionName, actionUrl); // Map Route.
                    }
                }

                internal static class Lane 
                {
                    internal static void MapRoutes(HttpConfiguration config)
                    {
                        string controllerName, actionName, actionUrl;

                        // Set Controller Name.
                        controllerName = RouteConsts.Infrastructure.Lane.ControllerName;

                        // Gets
                        actionName = RouteConsts.Infrastructure.Lane.Gets.Name;
                        actionUrl = RouteConsts.Infrastructure.Lane.Gets.Url;
                        Helper.MapRoute(config, controllerName, actionName, actionUrl); // Map Route.
                    }
                }
            }
        }

        #region Override Methods

        /// <summary>
        /// Init Map Routes.
        /// </summary>
        /// <param name="config">The HttpConfiguration instance.</param>
        protected override void InitMapRoutes(HttpConfiguration config)
        {
            // Handle route by specificed controller (Route Order is important).

            // Infrastructure (TSB/PlazaGroup/Plaza/Lane)
            MapControllers.Infrastructure.TSB.MapRoutes(config);
            MapControllers.Infrastructure.PlazaGroup.MapRoutes(config);
            MapControllers.Infrastructure.Plaza.MapRoutes(config);
            MapControllers.Infrastructure.Lane.MapRoutes(config);

            #region Default Route (do not used)

            // If comment below line the auto map default controllers will not load and cannot access.
            //InitDefaultMapRoute(config);

            #endregion
        }

        #endregion
    }

    /// <summary>
    /// Local Database Web Server (Self Host).
    /// </summary>
    public class LocalDatabaseWebServer
    {
        #region Internal Variables

        private WebServiceConfig _cfg = null;
        private IDisposable server = null;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalDatabaseWebServer() : base() { }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~LocalDatabaseWebServer()
        {
            Shutdown();
        }

        #endregion

        #region Private Methods

        private void CheckConfig()
        {
            // Gets Plaz local service config.
            _cfg = (null != PlazaServiceConfigManager.Instance.Plaza) ? 
                PlazaServiceConfigManager.Instance.Plaza.Service : null;
        }

        private string BaseAddress
        {
            get
            {
                string result = string.Empty;
                if (null != _cfg)
                {
                    result = string.Format(@"{0}://{1}:{2}", _cfg.Protocol, "+", _cfg.PortNumber);
                }
                return result;
            }
        }

        private void InitOwinFirewall()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            if (null == _cfg)
            {
                med.Err("Server Configuration is null.");
                return;
            }
            string portNum = _cfg.PortNumber.ToString();
            string appName = "DMT Plaza Local Service (REST)";
            var nash = new CommandLine();
            nash.Run("http add urlacl url=http://+:" + portNum + "/ user=Everyone");
            nash.Run("advfirewall firewall add rule dir=in action=allow protocol=TCP localport=" + portNum + " name=\"" + appName  + "\" enable=yes profile=Any");
        }

        private void ReleaseOwinFirewall()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            if (null == _cfg)
            {
                med.Err("Server Configuration is null.");
                return;
            }
            string portNum = _cfg.PortNumber.ToString();
            string appName = "DMT Plaza Local Service (REST)";
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
            CheckConfig(); // Check Config.
            if (null == _cfg)
            {
                med.Err("Server Configuration is null.");
                return;
            }

            // Start database server.
            LocalDbServer.Instance.Start();
            if (LocalDbServer.Instance.Connected)
            {
                med.Info("Plaza local database connected.");
            }
            else
            {
                med.Info("Plaza local database connect failed.");
            }

            // Start Local Web Service.
            if (null == server)
            {
                InitOwinFirewall();
                server = WebApp.Start<StartUp>(url: BaseAddress);
                med.Info("Plaza local web service started.");
            }
            else
            {
                med.Info("Plaza local web service failed.");
            }

            // Start rabbit service.
            RabbitMQService.Instance.Start();
            if (RabbitMQService.Instance.Connected)
            {
                med.Info("RabbitMQ Client service connected.");
            }
            else
            {
                med.Info("RabbitMQ Client service connect failed.");
            }
        }
        /// <summary>
        /// Shutdown service.
        /// </summary>
        public void Shutdown()
        {
            MethodBase med = MethodBase.GetCurrentMethod();

            // Shutdown Rabbit MQ Service.
            RabbitMQService.Instance.Shutdown();
            med.Info("RabbitMQ Client service disconnected.");

            // Shutdown Local Web Service.
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
            ReleaseOwinFirewall();
            med.Info("Plaza local web service shutdown.");

            // Shutdown database server.
            LocalDbServer.Instance.Shutdown();
            med.Info("Plaza local database disconnected.");
        }

        #endregion
    }
}
