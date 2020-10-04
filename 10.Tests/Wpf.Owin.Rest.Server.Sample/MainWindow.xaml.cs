#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Owin SelfHost
using Owin;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Validation;

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
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

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

            appBuilder.UseWebApi(config);
        }
    }

    public class CustomBodyModelValidator : DefaultBodyModelValidator
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


    public partial class CalculatorController : ApiController { }

    partial class CalculatorController
    {
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
}
