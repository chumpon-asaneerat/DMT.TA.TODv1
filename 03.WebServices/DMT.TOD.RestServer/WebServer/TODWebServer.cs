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

#endregion

namespace DMT.Services
{
    /// <summary>
    /// Web Server StartUp class.
    /// </summary>
    public class StartUp
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Setup Authentication for listener.
            HttpListener listener =
                    (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes =
                AuthenticationSchemes.Basic |
                //AuthenticationSchemes.IntegratedWindowsAuthentication |
                AuthenticationSchemes.Anonymous;

            // used Authentication middleware.
            appBuilder.Use(typeof(AuthenticationMiddleware));

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            // Enable Attribute routing.
            config.MapHttpAttributeRoutes();

            // Enable Cors and Authorize middleware.
            config.EnableCors();
            config.Filters.Add(new AuthorizeAttribute()); // Set Filter for Authorize Attribute.

            // Controllers with Actions
            // To handle routes like `/api/controller/action`
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Formatters.Clear();
            config.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            // Replace IBodyModelValidator to Custom Model Validator to prevent
            // Insufficient Stack problem.
            config.Services.Replace(typeof(IBodyModelValidator), new CustomBodyModelValidator());

            // Enable Swashbuckle (swagger) 
            // for more information see: https://github.com/domaindrivendev/Swashbuckle.WebApi
            // to see api document goto: http://your-root-url/swagger
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi(x => x.DisableValidator());

            appBuilder.UseWebApi(config);
        }
    }

    internal class CustomBodyModelValidator : DefaultBodyModelValidator
    {
        public override bool ShouldValidateType(Type type)
        {
            // Ignore validation on all DMTModelBase subclasses.
            bool isDMTModel = !type.IsSubclassOf(typeof(Models.DMTModelBase));
            return isDMTModel && base.ShouldValidateType(type);
        }
    }

    internal class AuthenticationMiddleware : OwinMiddleware
    {
        public AuthenticationMiddleware(OwinMiddleware next) :
            base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.OnSendingHeaders(state =>
            {
                var resp = (OwinResponse)state;
                if (resp.StatusCode == 401)
                {
                    resp.Headers.Add("WWW-Authenticate", new string[] { "Basic" });
                }
            }, response);

            var header = request.Headers.Get("Authorization");
            if (!String.IsNullOrWhiteSpace(header))
            {
                var authHeader = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(header);

                if ("Basic".Equals(authHeader.Scheme, StringComparison.OrdinalIgnoreCase))
                {
                    string parameter = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter));
                    var parts = parameter.Split(':');

                    string userName = parts[0];
                    string password = parts[1];

                    if (userName == "DMTUSER" && password == "DMTPASS2")
                    {
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, userName)
                        };
                        var identity = new ClaimsIdentity(claims, "Basic");
                        request.User = new ClaimsPrincipal(identity);
                    }
                    else
                    {
                        //Console.WriteLine("Invalid User");
                        request.User = null;
                    }
                }
                else
                {
                    //Console.WriteLine("No Basic Auth");
                    request.User = null;
                }
            }

            await Next.Invoke(context);
        }
    }

    /// <summary>
    /// TOD WebServer Web Server (Self Host).
    /// </summary>
    public class TODWebServer
    {
        #region Internal Variables

        private string baseAddress = string.Format(@"{0}://{1}:{2}",
            ConfigManager.Instance.Plaza.TODApp.Http.Protocol,
            "+",
            ConfigManager.Instance.Plaza.TODApp.Http.PortNumber);

        private IDisposable server = null;

        #endregion

        #region Private Methods

        private void InitOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.TODApp.Http.PortNumber.ToString();
            string appName = "DMT TOD App Service(REST)";
            var nash = new CommandLine();
            nash.Run("http add urlacl url=http://+:" + portNum + "/ user=Everyone");
            nash.Run("advfirewall firewall add rule dir=in action=allow protocol=TCP localport=" + portNum + " name=\"" + appName + "\" enable=yes profile=Any");
        }

        private void ReleaseOwinFirewall()
        {
            string portNum = ConfigManager.Instance.Plaza.TODApp.Http.PortNumber.ToString();
            string appName = "DMT TOD App Service(REST)";
            var nash = new CommandLine();
            nash.Run("http delete urlacl url=http://+:" + portNum + "/");
            nash.Run("advfirewall firewall delete rule name=\"" + appName + "\"");
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            // Start database server.
            LocalDbServer.Instance.Start();

            if (null == server)
            {
                InitOwinFirewall();
                server = WebApp.Start<StartUp>(url: baseAddress);
            }
        }

        public void Shutdown()
        {
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
            ReleaseOwinFirewall();

            // Shutdown database server.
            LocalDbServer.Instance.Shutdown();
        }

        #endregion
    }
}
