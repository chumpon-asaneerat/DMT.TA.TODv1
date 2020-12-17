#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

using DMT.Services;

#endregion

namespace DMT.UI.Controls.Elements
{
    /// <summary>
    /// Interaction logic for LocalDbConnectionStatus.xaml
    /// </summary>
    public partial class LocalDbConnectionStatus : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalDbConnectionStatus()
        {
            InitializeComponent();
        }

        #endregion

        private DispatcherTimer timer = null;

        #region Loaded/Unlaoded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (null != timer)
            {
                timer.Stop();
            }
            timer = null;
        }

        #endregion

        #region Timer Handler

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion

        private void UpdateUI() 
        {
            bool isConnected = LocalDbServer.Instance.Connected;
            txtConnectStatus.Text = isConnected ? "Connected" : "Disconnected";
            txtConnectStatus.Background = isConnected ? OkBackgroundBrush: ErrBackgroundBrush;
        }

        private static SolidColorBrush OkBackgroundBrush = new SolidColorBrush(Colors.ForestGreen);
        private static SolidColorBrush ErrBackgroundBrush = new SolidColorBrush(Colors.DarkRed);
    }
}
