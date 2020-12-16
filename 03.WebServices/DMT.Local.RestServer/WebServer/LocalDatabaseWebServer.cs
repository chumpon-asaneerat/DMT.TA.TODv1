#region Using

using System;
using System.Reflection;
// Owin SelfHost
using Microsoft.Owin.Hosting;
using System.Web.Http;

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

        #region Private Methods

        private void MapRoute(HttpConfiguration config, string controllerName, string actionName, string actionUrl)
        {
            if (null == config ||
                string.IsNullOrWhiteSpace(controllerName) ||
                string.IsNullOrWhiteSpace(actionName) ||
                string.IsNullOrWhiteSpace(actionUrl)) return;

            config.Routes.MapHttpRoute(
                name: controllerName + "." + actionName,
                routeTemplate: actionUrl,
                defaults: new { controller = controllerName, action = actionName });
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
            string controllerName, actionName, actionUrl;

            #region Client Controller

            // Set Controller Name.
            controllerName = RouteConsts.Client.ControllerName;

            // Register
            actionName = RouteConsts.Client.Register.Name;
            actionUrl = RouteConsts.Client.Register.Url;
            MapRoute(config, controllerName, actionName, actionUrl); // Map Route.

            // Unregister
            actionName = RouteConsts.Client.Unregister.Name;
            actionUrl = RouteConsts.Client.Unregister.Url;
            MapRoute(config, controllerName, actionName, actionUrl); // Map Route.

            #endregion

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

        private string baseAddress = string.Format(@"{0}://{1}:{2}",
            ConfigManager.Instance.Plaza.Local.Service.Protocol,
            "+",
            ConfigManager.Instance.Plaza.Local.Service.PortNumber);

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

        private void InitOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.Local.Service.PortNumber.ToString();
            string appName = "DMT TODxTA Local Service(REST)";
            var nash = new CommandLine();
            nash.Run("http add urlacl url=http://+:" + portNum + "/ user=Everyone");
            nash.Run("advfirewall firewall add rule dir=in action=allow protocol=TCP localport=" + portNum + " name=\"" + appName  + "\" enable=yes profile=Any");
        }

        private void ReleaseOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.Local.Service.PortNumber.ToString();
            string appName = "DMT TODxTA Local Service(REST)";
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
            //MethodBase med = MethodBase.GetCurrentMethod();
            // Start database server.
            LocalDbServer.Instance.Start();
            // Start rabbit service.
            RabbitMQService.Instance.Start();

            if (null == server)
            {
                InitOwinFirewall();
                server = WebApp.Start<StartUp>(url: baseAddress);
            }
        }
        /// <summary>
        /// Shutdown service.
        /// </summary>
        public void Shutdown()
        {
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
            ReleaseOwinFirewall();

            // Shutdown Rabbit MQ Service.
            RabbitMQService.Instance.Shutdown();
            // Shutdown database server.
            LocalDbServer.Instance.Shutdown();
        }

        #endregion
    }
}
