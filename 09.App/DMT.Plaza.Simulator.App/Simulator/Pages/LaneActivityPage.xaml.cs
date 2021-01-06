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
    using todOps = Services.Operations.SCW.TOD;
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

        #region Internal Variables

        private CultureInfo culture = new CultureInfo("th-TH");

        // Required to stored in config.
        private int jobNo 
        { 
            get 
            {
                if (!int.TryParse(txtJobNo.Text, out int val))
                    return 0;
                return val;
            } 
            set 
            {
                string str = value.ToString();
                if (txtJobNo.Text != str)
                {
                    if (!int.TryParse(str, out int val))
                        return;
                    txtJobNo.Text = val.ToString();
                }
            }
        }

        private LaneInfo currentLane = null;
        private List<LaneInfo> lanes = new List<LaneInfo>();

        #endregion

        #region Loaded/Unloaderd

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            jobNo = 1; // init jobNo.
            RefreshLanes();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Button Handler(s)

        private void cmdRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshLanes();
        }

        #endregion

        #region Lane ListView Button Handlers.

        private void cmdBOJ_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var lane = (null != button && null != button.DataContext) ? button.DataContext as LaneInfo : null;
            if (null == lane) return;

            // Create exclude users.
            var excludeUsrs = new List<string>();
            if (null != lanes)
            {
                lanes.ForEach(ln => 
                {
                    if (null != ln.User && !excludeUsrs.Contains(ln.User.UserId))
                    {
                        // append user that on lane.
                        excludeUsrs.Add(ln.User.UserId);
                    }
                });
            }
            // Select User to Begin job.
            var win = new Windows.UserListWindow();
            win.Owner = Application.Current.MainWindow;
            win.Setup(excludeUsrs.ToArray());
            if (win.ShowDialog() == false) return;
            var usr = win.User;
            if (null == usr) return; // no user exist.
            BOJ(lane, usr);
        }

        private void cmdEOJ_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var lane = (null != button && null != button.DataContext) ? button.DataContext as LaneInfo : null;
            if (null == lane) return;
            EOJ(lane);
        }

        private void cmdPayment_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var lane = (null != button && null != button.DataContext) ? button.DataContext as LaneInfo : null;
            if (null == lane) return;
            var win = new Windows.PaymentWindow();
            win.Owner = Application.Current.MainWindow;
            win.Setup(lane);
            if (win.ShowDialog() == false) return;
        }

        #endregion

        #region ListView Handlers

        private void lvLanes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentLane = lvLanes.SelectedItem as LaneInfo;
            RefreshLaneAttendances();
            RefreshLanePayments();
        }

        #endregion

        #region Private Methods

        private void BOJ(LaneInfo value, User user)
        {
            if (null == value || null == user) return;

            int networkId = PlazaAppConfigManager.Instance.DMT.networkId;

            var param = new SCWBOJ();
            param.jobNo = jobNo++;
            param.networkId = networkId;
            param.laneId = value.LaneNo;
            param.plazaId = value.SCWPlazaId;
            param.staffId = user.UserId;

            var ret = emuOps.boj(param);
            if (null != ret && null != ret.status && ret.status.code == "S200")
            {
                RefreshLanes();
            }
        }

        private void EOJ(LaneInfo value)
        {
            if (null == value) return;

            int networkId = PlazaAppConfigManager.Instance.DMT.networkId;

            var param = new SCWEOJ();
            param.jobNo = value.JobNo;
            param.networkId = networkId;
            param.laneId = value.LaneNo;
            param.plazaId = value.SCWPlazaId;
            param.staffId = value.UserId;

            var ret = emuOps.eoj(param);
            if (null != ret && null != ret.status && ret.status.code == "S200")
            {
                RefreshLanes();
            }
        }

        private void RefreshLanes()
        {
            lvLanes.ItemsSource = null;

            lanes = LaneInfo.GetLanes();

            var tsb = localOps.Infrastructure.TSB.Current().Value();
            if (null == tsb) return;
            var plazas = localOps.Infrastructure.Plaza.Search.ByTSB(tsb).Value();
            if (null == plazas || plazas.Count <= 0) return;

            // Read all scw jobs.
            int networkId = PlazaAppConfigManager.Instance.DMT.networkId;
            var allJobs = new List<SCWJob>();
            plazas.ForEach(plaza =>
            {
                var param = new SCWAllJob();
                param.networkId = networkId;
                param.plazaId = plaza.SCWPlazaId;
                var jobs = emuOps.allJobs(param);
                if (null != jobs && null != jobs.list && jobs.list.Count > 0)
                {
                    allJobs.AddRange(jobs.list.ToArray());
                }
            });

            // assign scw jobs to lanes.
            if (null != lanes)
            {
                lanes.ForEach(lane => 
                {
                    lane.Assign(allJobs);
                });
            }

            lvLanes.ItemsSource = lanes;
        }

        private void RefreshLaneAttendances()
        {
            if (null == currentLane) return;
            lvAttendances.ItemsSource = currentLane.Jobs;
        }

        private void RefreshLanePayments()
        {
            if (null == currentLane) return;

            int networkId = PlazaAppConfigManager.Instance.DMT.networkId;


            // EMV
            lvEMVs.ItemsSource = null;

            var emvParam = new SCWEMVTransactionList();
            emvParam.networkId = networkId;
            emvParam.plazaId = currentLane.SCWPlazaId;
            emvParam.staffId = currentLane.UserId;
            emvParam.startDateTime = null;
            emvParam.endDateTime = null;

            var emvItems = new List<LaneEMV>();
            var emvResults = todOps.emvTransactionList(emvParam);
            if (null != emvResults && null != emvResults.list)
            {
                emvResults.list.ForEach(item => 
                {
                    emvItems.Add(new LaneEMV(item));
                });
            }

            lvEMVs.ItemsSource = emvItems;

            // QR Code

            lvQRCodes.ItemsSource = null;

            var qrcodeParam = new SCWQRCodeTransactionList();
            qrcodeParam.networkId = networkId;
            qrcodeParam.plazaId = currentLane.SCWPlazaId;
            qrcodeParam.staffId = currentLane.UserId;
            qrcodeParam.startDateTime = null;
            qrcodeParam.endDateTime = null;

            var qrcodeItems = new List<LaneQRCode>();
            var qrcodeResults = todOps.qrcodeTransactionList(qrcodeParam);
            if (null != qrcodeResults && null != qrcodeResults.list) 
            {
                qrcodeResults.list.ForEach(item =>
                {
                    qrcodeItems.Add(new LaneQRCode(item));
                });
            }

            lvQRCodes.ItemsSource = qrcodeItems;
        }

        #endregion
    }
}
