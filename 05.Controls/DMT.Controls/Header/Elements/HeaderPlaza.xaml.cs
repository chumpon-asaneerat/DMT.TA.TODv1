﻿#region Using

using System;
using System.Windows;
using System.Windows.Controls;

using DMT.Models;
using DMT.Services;

#endregion

namespace DMT.Controls.Header
{
    /// <summary>
    /// Interaction logic for HeaderPlaza.xaml
    /// </summary>
    public partial class HeaderPlaza : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public HeaderPlaza()
        {
            InitializeComponent();
        }

        #endregion

        // TODO: Refactor HeaderPlaza elements LocalOperations
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;

        #region Loaded/Unloaded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtPlazaId.Visibility = Visibility.Collapsed;

            UpdateUI();
            // TODO: Refactor HeaderPlaza event bind
            //LocalServiceOperations.Instance.OnActiveTSBChanged += Instance_OnActiveTSBChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // TODO: Refactor HeaderPlaza event unbind
            //LocalServiceOperations.Instance.OnActiveTSBChanged -= Instance_OnActiveTSBChanged;
        }

        #endregion

        #region LocalServiceOperations Handlers

        private void Instance_OnActiveTSBChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion

        private void UpdateUI()
        {
            /*
            // TODO: Refactor HeaderPlaza element update active TSB
            var ret = ops.TSB.GetCurrent();
            var tsb = ret.Value();
            if (null != tsb)
            {
                // TODO: Refactor
                txtPlazaId.Text = "รหัสด่าน : " + tsb.TSBId;
                txtPlazaName.Text = "ชื่อด่าน : " + tsb.TSBNameTH;
            }
            else
            {
                txtPlazaId.Text = "รหัสด่าน : ";
                txtPlazaName.Text = "ชื่อด่าน : ";
            }
            */
        }
    }
}
