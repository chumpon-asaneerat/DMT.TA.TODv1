﻿#region Using

using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

using NLib;
using NLib.Logs;

#endregion

namespace DMT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// OnStartup.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetupExceptionHandling();

            Console.WriteLine("OnStartUp");
            if (null != AppDomain.CurrentDomain)
            {
                if (null != System.Threading.Thread.CurrentContext)
                {
                    Console.WriteLine("Thread CurrentContext is not null.");
                }
            }

            #region Create Application Environment Options

            EnvironmentOptions option = new EnvironmentOptions()
            {
                /* Setup Application Information */
                AppInfo = new NAppInformation()
                {
                    /*  This property is required */
                    CompanyName = "DMT",
                    /*  This property is required */
                    ProductName = AppConsts.Application.PlazaConfig.ApplicationName,
                    /* For Application Version */
                    Version = AppConsts.Application.PlazaConfig.Version,
                    Minor = AppConsts.Application.PlazaConfig.Minor,
                    Build = AppConsts.Application.PlazaConfig.Build,
                    LastUpdate = AppConsts.Application.PlazaConfig.LastUpdate
                },
                /* Setup Storage */
                Storage = new NAppStorage()
                {
                    StorageType = NAppFolder.ProgramData
                },
                /* Setup Behaviors */
                Behaviors = new NAppBehaviors()
                {
                    /* Set to true for allow only one instance of application can execute an runtime */
                    IsSingleAppInstance = true,
                    /* Set to true for enable Debuggers this value should always be true */
                    EnableDebuggers = true
                }
            };

            #endregion

            #region Setup Option to Controller and check instance

            WpfAppContoller.Instance.Setup(option);

            if (option.Behaviors.IsSingleAppInstance &&
                WpfAppContoller.Instance.HasMoreInstance)
            {
                return;
            }

            #endregion

            #region Init Preload classes

            ApplicationManager.Instance.Preload(() =>
            {

            });

            #endregion

            // Load Config service.
            Services.PlazaAppConfigManager.Instance.LoadConfig();
            // Setup config reference to all rest client class.
            Services.Operations.Plaza.Config = Services.PlazaAppConfigManager.Instance;
            Services.Operations.SCW.Config = Services.PlazaAppConfigManager.Instance;

            Window window = null;
            window = new MainWindow();

            // Start log manager
            LogManager.Instance.Start();

            if (null != window)
            {
                WpfAppContoller.Instance.Run(window);
            }
        }
        /// <summary>
        /// OnExit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            // Shutdown log manager
            LogManager.Instance.Shutdown();

            // Wpf shutdown process required exit code.

            /* If auto close the single instance must be true */
            bool autoCloseProcess = true;
            WpfAppContoller.Instance.Shutdown(autoCloseProcess, e.ApplicationExitCode);

            base.OnExit(e);
        }

        private void SetupExceptionHandling()
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = (Exception)e.ExceptionObject;
                //LogUnhandledException(ex, "AppDomain.CurrentDomain.UnhandledException");
            };

            DispatcherUnhandledException += (s, e) =>
            {
                //LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
                e.Handled = true;
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                //LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
                e.SetObserved();
            };
        }
    }
}
