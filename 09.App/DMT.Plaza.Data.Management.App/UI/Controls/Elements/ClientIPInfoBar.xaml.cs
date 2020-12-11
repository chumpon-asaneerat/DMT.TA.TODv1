#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using NLib.Utils;

#endregion

namespace DMT.UI.Controls.Elements
{
    /// <summary>
    /// Interaction logic for ClientIPInfoBar.xaml
    /// </summary>
    public partial class ClientIPInfoBar : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public ClientIPInfoBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Loaded/Unloaded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var localIP = NetworkUtils.GetLocalIPAddress();
            txtIPAddress.Text = (null != localIP) ? localIP.ToString() : "0.0.0.0";
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
