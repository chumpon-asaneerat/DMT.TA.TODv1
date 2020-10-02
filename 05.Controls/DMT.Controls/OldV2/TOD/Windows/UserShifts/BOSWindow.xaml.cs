#region Using

using System;
using System.Collections.Generic;
using System.Windows;

using DMT.Models;
using DMT.Services;
using NLib.Reflection;


#endregion

namespace DMT.TOD.Windows.UserShifts
{
    /// <summary>
    /// Interaction logic for BOSWindow.xaml
    /// </summary>
    public partial class BOSWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public BOSWindow()
        {
            InitializeComponent();
        }

        #endregion

        // TODO: Neeed Web Client
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;
        private User _user = null;

        #region Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtDate.Text = DateTime.Now.ToThaiDateString();
            txtTime.Text = DateTime.Now.ToThaiTimeString();
        }

        #endregion

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            if (cbShift.SelectedIndex == -1)
            {
                cbShift.Focus();
                return;
            }
            Shift shift = cbShift.SelectedItem as Shift;
            if (null != shift)
            {
                // TODO: Neeed Web Client
                /*
                UserShift inst = ops.UserShifts.Create(shift, _user).Value();
                if (null != inst) shift.AssignTo(inst);

                var success = ops.UserShifts.BeginUserShift(inst).Ok;
                if (!success)
                {
                    DMT.Windows.MessageBoxWindow msg = new DMT.Windows.MessageBoxWindow();
                    msg.Owner = Application.Current.MainWindow;
                    msg.Setup("ไม่สามารถเปิดกะใหม่ได้ เนื่องจาก ยังมีกะที่ยังไม่ป้อนรายได้", "DMT - Tour of Duty");
                    if (msg.ShowDialog() == true)
                    {

                    }
                }
                */
            }

            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public void Setup(User user)
        {
            _user = user;
            if (null != _user)
            {
                // TODO: Neeed Web Client
                /*
                DateTime dt = DateTime.Now;
                var shifts = ops.Shifts.GetShifts().Value();
                cbShift.ItemsSource = shifts;

                var tsb = ops.TSB.GetCurrent().Value();
                if (null != tsb)
                {
                    txtPlaza.Text = tsb.TSBNameTH;
                }
                txtDate.Text = dt.ToThaiDateString();
                txtTime.Text = dt.ToThaiTimeString();

                txtID.Text = _user.UserId;
                txtName.Text = _user.FullNameTH;
                */
            }
        }
    }
}
