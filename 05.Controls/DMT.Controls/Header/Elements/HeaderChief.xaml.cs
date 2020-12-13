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
    /// Interaction logic for HeaderChief.xaml
    /// </summary>
    public partial class HeaderChief : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public HeaderChief()
        {
            InitializeComponent();
        }

        #endregion

        // TODO: Refactor HeaderChief elements LocalOperations
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;

        #region Loaded/Unloaded

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            // TODO: Refactor HeaderChief event bind
            //LocalServiceOperations.Instance.OnChangeShift += Instance_OnChangeShift;
            //LocalServiceOperations.Instance.OnActiveTSBChanged += Instance_OnActiveTSBChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // TODO: Refactor HeaderChief event unbind
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
            // TODO: Fixed HeaderUser elements to update current chief for TA/TOD
            var ret = ops.Shifts.GetCurrent();
            var shift = ret.Value();
            if (null == shift)
            {
                txtSupervisorId.Text = "รหัสหัวหน้าด่าน : ";
                txtSupervisorName.Text = "หัวหน้าด่าน : ";
            }
            else
            {
                // TODO: Refactor
                //txtSupervisorId.Text = "รหัสหัวหน้าด่าน : " + shift.UserId;
                //txtSupervisorName.Text = "หัวหน้าด่าน : " + shift.FullNameTH;
            }
            */
        }
    }
}
