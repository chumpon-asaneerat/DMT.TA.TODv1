#region Using

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
    /// Interaction logic for HeaderShift.xaml
    /// </summary>
    public partial class HeaderShift : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public HeaderShift()
        {
            InitializeComponent();
        }

        #endregion

        // TODO: Refactor HeaderShift elements LocalOperations
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;

        #region Loaded/Unloaded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            // TODO: Refactor HeaderShift event bind
            //LocalServiceOperations.Instance.OnChangeShift += Instance_OnChangeShift;
            //LocalServiceOperations.Instance.OnActiveTSBChanged += Instance_OnActiveTSBChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // TODO: Refactor HeaderShift event unbind
            //LocalServiceOperations.Instance.OnActiveTSBChanged -= Instance_OnActiveTSBChanged;
            //LocalServiceOperations.Instance.OnChangeShift -= Instance_OnChangeShift;
        }

        #endregion

        #region LocalServiceOperations Handlers

        private void Instance_OnActiveTSBChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void Instance_OnChangeShift(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion

        private void UpdateUI()
        {
            /*
            // TODO: Refactor HeaderShift element Update current shift
            var ret = ops.Shifts.GetCurrent();
            var shift = ret.Value();
            if (null != shift)
            {
                // TODO: Refactor
                txtShiftDate.Text = shift.BeginDateString;
                txtShiftTime.Text = shift.BeginTimeString;
                txtShiftId.Text = shift.ShiftNameTH;
            }
            else
            {
                txtShiftDate.Text = string.Empty;
                txtShiftTime.Text = string.Empty;
                txtShiftId.Text = string.Empty;
            }
            */
        }
    }
}
