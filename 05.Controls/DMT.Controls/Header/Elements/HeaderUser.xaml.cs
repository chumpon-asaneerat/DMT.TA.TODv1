﻿#region Using

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using DMT.Models;
using DMT.Services;

#endregion

namespace DMT.Controls.Header
{
    /// <summary>
    /// Interaction logic for HeaderUser.xaml
    /// </summary>
    public partial class HeaderUser : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public HeaderUser()
        {
            InitializeComponent();
        }

        #endregion

        // TODO: Refactor HeaderUser elements LocalOperations
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;
        private DispatcherTimer timer = null;

        #region Loaded/Unloaded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (null != timer)
            {
                timer.Tick -= timer_Tick;
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
            // TODO: Fixed HeaderUser elements to update current user for TA
            /*
            if (null != TAApp.User.Current)
            {
                // TODO: Refactor
                //txtUserId.Text = "รหัสผู้ใช้งาน: " + TAApp.User.Current.UserId;
                //txtUserame.Text = "ชื่อผู้ใช้งาน: " + TAApp.User.Current.FullNameTH;
            }
            else
            {
                txtUserId.Text = "รหัสผู้ใช้งาน: ";
                txtUserame.Text = "ชื่อผู้ใช้งาน: ";
            }
            */
        }
    }
}
