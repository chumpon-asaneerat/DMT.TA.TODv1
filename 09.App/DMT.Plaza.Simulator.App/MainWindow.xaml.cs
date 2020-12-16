#region Using

using System;
using System.Security.Principal;
using System.Windows;

using NLib.Services;

//using DMT.Models;
using DMT.Services;

using Fluent;

#endregion

namespace DMT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load Config service.
            ConfigManager.Instance.LoadConfig();
            // TODO: Refactor
            /*
            LocalServiceOperations.Instance.ServiceMonitor.ScanConpleted += ServiceMonitor_ScanConpleted;
            LocalServiceOperations.Instance.ServiceMonitor.Start();
            */
            // Initial Page Content Manager
            PageContentManager.Instance.ContentChanged += new EventHandler(Instance_ContentChanged);
            PageContentManager.Instance.Start();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            // Release Page Content Manager
            PageContentManager.Instance.Shutdown();
            PageContentManager.Instance.ContentChanged -= new EventHandler(Instance_ContentChanged);
            // TODO: Refactor
            /*
            LocalServiceOperations.Instance.ServiceMonitor.Shutdown();
            LocalServiceOperations.Instance.ServiceMonitor.ScanConpleted -= ServiceMonitor_ScanConpleted;
            */
        }

        #endregion

        #region Page Content Manager Handlers

        void Instance_ContentChanged(object sender, EventArgs e)
        {
            this.container.Content = PageContentManager.Instance.Current;
        }

        #endregion

        private void ServiceMonitor_ScanConpleted(object sender, EventArgs e)
        {

        }

        #region Button Handlers

        private void cmdLaneActivity_Click(object sender, RoutedEventArgs e)
        {
            //PageContentManager.Instance.Current = new Simulator.Pages.LaneActivityPage();
        }

        private void cmdUserView_Click(object sender, RoutedEventArgs e)
        {
            //PageContentManager.Instance.Current = new Simulator.Pages.UserViewPage();
        }

        private void cmdSupervisorView_Click(object sender, RoutedEventArgs e)
        {
            //PageContentManager.Instance.Current = new Simulator.Pages.SupervisorTaskPage();
        }

        private void cmdTSBCouponView_Click(object sender, RoutedEventArgs e)
        {
            //PageContentManager.Instance.Current = new Simulator.Pages.TSBCouponViewPage();
        }

        private void cmdTSBLaneSoldCoupon_Click(object sender, RoutedEventArgs e)
        {
            //PageContentManager.Instance.Current = new Simulator.Pages.TSBLaneSoldCouponPage();
        }

        private void cmdTSBPlazaSoldCoupon_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
