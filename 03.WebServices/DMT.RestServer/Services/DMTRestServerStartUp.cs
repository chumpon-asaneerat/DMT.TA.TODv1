#region Using

using System;
using System.Reflection;
// Owin SelfHost
using Owin;
using Microsoft.Owin; // for OwinStartup attribute.
using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http;
using System.Web.Http.Validation;
// Owin Authentication
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
// Swagger
using Swashbuckle.Application;
using NLib;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The DMT Rest Server StartUp class (abstract).
    /// </summary>
    public abstract class DMTRestServerStartUp
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public DMTRestServerStartUp() : base()
        {
            // Authentication
            this.HasAuthentication = true;
            this.AuthenticationSchemes = AuthenticationSchemes.Basic |
                //AuthenticationSchemes.IntegratedWindowsAuthentication |
                AuthenticationSchemes.Anonymous;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Init Authentication.
        /// </summary>
        /// <param name="app">The IAppBuilder instance.</param>
        protected virtual void InitAuthentication(IAppBuilder app)
        {
            if (null == app) return;
            if (!HasAuthentication) return;
            // Setup Authentication for listener.
            HttpListener listener;
            MethodBase med = MethodBase.GetCurrentMethod();
            try
            {
                listener = app.Properties["System.Net.HttpListener"] as HttpListener;
                if (null != listener)
                {
                    listener.AuthenticationSchemes = AuthenticationSchemes;
                }
            }
            catch (Exception ex)
            {
                med.Err(ex);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Configuration.
        /// </summary>
        /// <param name="app">The IAppBuilder instance.</param>
        public virtual void Configuration(IAppBuilder app)
        {
            InitAuthentication(app);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or (protected sets) has authentication.
        /// </summary>
        public bool HasAuthentication { get; protected set; }
        /// <summary>
        /// Gets or (protected sets) Authentication Schemes.
        /// </summary>
        public AuthenticationSchemes AuthenticationSchemes { get; protected set; }

        #endregion
    }
}
