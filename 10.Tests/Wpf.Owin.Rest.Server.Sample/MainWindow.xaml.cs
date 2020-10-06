#region Using

using System;
using System.Windows;
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

namespace Wpf.Owin.Rest.Server.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        private IDisposable server = null;

        #region Loaded/Unloader

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Shutdown();
        }

        #endregion

        private void Start()
        {
            if (null == server)
            {
                string baseAddress = @"http://+:8000";
                //string baseAddress = @"http://localhost:8000";
                server = WebApp.Start<StartUp>(url: baseAddress);
            }
        }

        private void Shutdown()
        {
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
        }
    }

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
            /*
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );
            */

            // Handle route by specificed controller (Route Order is important).
            // Calculator2 Controller
            config.Routes.MapHttpRoute(
                name: "Calc2ApiAdd",
                routeTemplate: "api/Calc2/Add",
                defaults: new { controller = "Calculator2", action = "Add" });
            config.Routes.MapHttpRoute(
                name: "Calc2ApiSub",
                routeTemplate: "api/Calc2/Sub",
                defaults: new { controller = "Calculator2", action = "Sub" });
            // Default Setting to handle routes like `/api/controller/action`
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}");

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
            /*
            bool isDMTModel = !type.IsSubclassOf(typeof(Models.DMTModelBase));
            return isDMTModel && base.ShouldValidateType(type);
            */
            return base.ShouldValidateType(type);
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

    // url: http://localhost:8000/api/Test/getsample
    // body: { "name": "Job" }

    #region Test

    public class TestController : ApiController
    {
        [HttpPost]
        [ActionName(@"getsample")]
        public SampleResult getsample([FromBody] SampleRequest value)
        {
            SampleResult result;
            if (null == value)
            {
                result = new SampleResult();
                result.Greating = "Welcome [anonymous].";
            }
            else
            {
                result = new SampleResult();
                result.Greating = "Welcome [" + value.Name + "].";
            }
            return result;
        }
    }

    public class SampleRequest
    {
        public string Name { get; set; }
    }

    public class SampleResult
    {
        public string Greating { get; set; }
    }

    #endregion

    // url: http://localhost:8000/api/Calculator/Add
    // body: { "num1": 1, "num2": 2 }
    // url: http://localhost:8000/api/Calculator/Sub
    // body: { "num1": 1, "num2": 2 }

    #region Calculator

    public static class RouteConsts
    {
        public const string Url = "api";

        public static class Calculator
        {
            public const string Url = RouteConsts.Url + @"/Calculator";

            public static class Add
            {
                public const string Name = "Add";
                public const string Url = Calculator.Url + @"/" + Name;
            }

            public static class Sub
            {
                public const string Name = "Sub";
                public const string Url = Calculator.Url + @"/" + Name;
            }
        }
    }


    public class CalcRequest
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
    }

    public class CalcResult
    {
        public int Result { get; set; }
    }

    [Authorize] // Authorize Attribute can set here or set in each method(s).
    public partial class CalculatorController : ApiController { }

    partial class CalculatorController
    {
        [AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.Calculator.Add.Name)]
        public CalcResult add([FromBody] CalcRequest value)
        {
            if (null == value)
                return new CalcResult() { Result = 0 };
            else return new CalcResult() { Result = value.Num1 + value.Num2 };
        }
    }

    partial class CalculatorController
    {
        [HttpPost]
        [ActionName(RouteConsts.Calculator.Sub.Name)]
        public CalcResult sub([FromBody] CalcRequest value)
        {
            if (null == value)
                return new CalcResult() { Result = 0 };
            else return new CalcResult() { Result = value.Num1 - value.Num2 };
        }
    }

    #endregion

    // See MapHttpRoute in Startup class.
    // url: http://localhost:8000/api/Calc2/Add
    // body: { "num1": 1, "num2": 2 }
    // url: http://localhost:8000/api/Calc2/Sub
    // body: { "num1": 1, "num2": 2 }

    #region Calculator2

    public static class RouteConsts2
    {
        public const string Url = "api";

        public static class Calculator
        {
            // Match MapHttpRoute in Startup class.
            public const string Url = RouteConsts2.Url + @"/Calc2";

            public static class Add
            {
                public const string Name = "Add";
                public const string Url = Calculator.Url + @"/" + Name;
            }

            public static class Sub
            {
                public const string Name = "Sub";
                public const string Url = Calculator.Url + @"/" + Name;
            }
        }
    }

    [Authorize] // Authorize Attribute can set here or set in each method(s).
    public partial class Calculator2Controller : ApiController { }

    partial class Calculator2Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts2.Calculator.Add.Name)]
        public CalcResult addMe([FromBody] CalcRequest value)
        {
            if (null == value)
                return new CalcResult() { Result = 0 };
            else return new CalcResult() { Result = value.Num1 + value.Num2 };
        }
    }

    partial class Calculator2Controller
    {
        [HttpPost]
        [ActionName(RouteConsts2.Calculator.Sub.Name)]
        public CalcResult subMe([FromBody] CalcRequest value)
        {
            if (null == value)
                return new CalcResult() { Result = 0 };
            else return new CalcResult() { Result = value.Num1 - value.Num2 };
        }
    }

    #endregion
}
