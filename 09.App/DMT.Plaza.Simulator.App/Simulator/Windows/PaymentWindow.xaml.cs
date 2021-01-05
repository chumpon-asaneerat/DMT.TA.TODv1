#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using DMT.Models;
using DMT.Services;
using NLib.Services;
using NLib.Reflection;

#endregion

namespace DMT.Simulator.Windows
{
    using emuOps = Services.Operations.SCW.Emulator; // reference to static class.

    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public PaymentWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Variables

        private Random rand = new Random();
        private LaneInfo _lane = null;

        #endregion

        #region Button Handlers

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            if (null == _lane || null == _lane.User) return;


            if (string.IsNullOrEmpty(txtApproveCode.Text))
            {

                return;
            }

            if (string.IsNullOrEmpty(txtRefCode.Text))
            {

                return;
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {

                return;
            }

            //emuOps
            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        #endregion

        #region Private Methods

        private string GenerateRandomChar(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        private void GenerateRandomCode()
        {
            string apvChr = GenerateRandomChar(2);
            string refChr = GenerateRandomChar(2);

            int apvVal = rand.Next(100000);
            int refVal = rand.Next(100000);

            txtApproveCode.Text = "APV-" + apvChr + "-" + apvVal.ToString("D5");
            txtRefCode.Text = "REF-" + refChr + "-" + refVal.ToString("D5");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Setup.
        /// </summary>
        /// <param name="value">The LaneInfo instance.</param>
        public void Setup(LaneInfo value)
        {
            _lane = value;
            if (null == _lane || null == _lane.User) cmdOk.IsEnabled = false;
            GenerateRandomCode();
        }

        #endregion
    }
}
