#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Globalization;

using DMT.Models;
using DMT.Services;
using System.Collections.ObjectModel;
using NLib.Reflection;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Runtime.InteropServices;
using System.Net;

#endregion

namespace DMT.Simulator.Pages
{
    using localOps = Services.Operations.Plaza; // reference to static class.
    using emuOps = Services.Operations.SCW.Emulator; // reference to static class.

    /// <summary>
    /// Interaction logic for LaneActivityPage.xaml
    /// </summary>
    public partial class LaneActivityPage : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public LaneActivityPage()
        {
            InitializeComponent();
        }

        #endregion

        private int jobNo = 1;

        private CultureInfo culture = new CultureInfo("th-TH");

        private List<LaneJob> lanes = new List<LaneJob>();

        #region Loaded/Unloaderd

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshLanes();
            RefreshUsers();
            RefreshShifts();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Lane ListView Button Handlers.

        private void cmdBOJ_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var lane = (null != button && null != button.DataContext) ? button.DataContext as LaneJob : null;
            if (null == lane) return;
            //BOJ(sender as LaneJob);
        }

        private void cmdEOJ_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var lane = (null != button && null != button.DataContext) ? button.DataContext as LaneJob : null;
            if (null == lane) return;
            //EOJ(sender as LaneJob);
        }

        #endregion

        #region Private Methods

        private void BOJ(LaneJob value, User user)
        {
            if (null == value || null == user) return;
            var param = new SCWBOJ();
            param.jobNo = jobNo++;
            param.laneId = value.LaneNo;
            param.plazaId = value.SCWPlazaId;
            param.staffId = user.UserId;
            var ret = emuOps.boj(param);
            if (null != ret && null != ret.status && ret.status.code == "S200")
            {
                RefreshLanes();
            }
        }

        private void EOJ(LaneJob value)
        {
            if (null == value) return;
        }

        private void RefreshLanes()
        {
            lvLanes.ItemsSource = null;

            lanes = LaneJob.GetLanes();

            var tsb = localOps.Infrastructure.TSB.Current().Value();
            if (null == tsb) return;
            var plazas = localOps.Infrastructure.Plaza.Search.ByTSB(tsb).Value();
            if (null == plazas || plazas.Count <= 0) return;
            plazas.ForEach(plaza =>
            {
                var param = new SCWAllJob();
                param.networkId = PlazaAppConfigManager.Instance.DMT.networkId;
                param.plazaId = plaza.SCWPlazaId;
                var jobs = emuOps.allJobs(param);
                if (null != lanes)
                {

                }
            });

            lvLanes.ItemsSource = lanes;

            RefreshUI();
        }

        private void RefreshUI()
        {

        }

        private void RefreshShifts()
        {

        }

        private void RefreshUsers()
        {

        }

        private void RefreshLaneAttendances()
        {

        }

        private void RefreshLanePayments()
        {

        }

        #endregion

        #region ListView Handlers

        private void lvLanes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            currentLane = lvLanes.SelectedItem as LaneItem;
            
            RefreshLaneAttendances();
            RefreshLanePayments();

            RefreshUI();
            */
        }

        #endregion

        #region Button Handler(s)

        private void cmdRefreshAttendences_Click(object sender, RoutedEventArgs e)
        {
            RefreshLaneAttendances();
        }

        private void cmdRefreshPayments_Click(object sender, RoutedEventArgs e)
        {
            RefreshLanePayments();
        }

        #endregion
    }
}
