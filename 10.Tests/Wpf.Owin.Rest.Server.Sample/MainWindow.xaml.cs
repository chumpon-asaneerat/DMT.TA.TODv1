﻿#region Using

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
            //button1.Enabled = false;
            //button2.Enabled = true;
        }

        private void Shutdown()
        {
            if (null != server)
            {
                server.Dispose();
            }
            server = null;
            //button1.Enabled = true;
            //button2.Enabled = false;
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
}
