﻿#region Using

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using DMT.Models;
using DMT.Services;
using DMT.Controls;

#endregion

namespace DMT.Windows
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public SignInWindow()
        {
            InitializeComponent();

            txtUserId.SelectAll();
            txtUserId.Focus();
        }

        #endregion

        #region Internal Variables

        // TODO: Neeed Web Client
        //private LocalOperations ops = LocalServiceOperations.Instance.Plaza;
        private List<string> _roles = new List<string>();
        private User _user = null;

        #endregion

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SmartcardManager.Instance.UserChanged += Instance_UserChanged;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SmartcardManager.Instance.UserChanged -= Instance_UserChanged;
            SmartcardManager.Instance.Shutdown();
        }

        #endregion

        #region Smartcard Handler(s)

        private void Instance_UserChanged(object sender, EventArgs e)
        {
            if (null != SmartcardManager.Instance.User)
            {
                _user = SmartcardManager.Instance.User;
                CheckUser();
            }
        }

        #endregion

        #region Button Handler(s)

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.Text = string.Empty;

            string userId = txtUserId.Text.Trim();
            string pwd = txtPassword.Password.Trim();
            if (string.IsNullOrWhiteSpace(userId))
            {
                txtUserId.SelectAll();
                txtUserId.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }

            // TODO: Neeed Web Client
            /*
            var md5 = Utils.MD5.Encrypt(pwd);
            var ret = ops.Users.GetByLogIn(Search.Users.ByLogIn.Create(userId, md5));
            _user = ret.Value();
            */
            CheckUser();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            SmartcardManager.Instance.Shutdown();
            this.DialogResult = false;
        }

        #endregion

        #region TextBox Keydown

        private void txtUserId_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter || e.Key == System.Windows.Input.Key.Return)
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter || e.Key == System.Windows.Input.Key.Return)
            {
                cmdOK.Focus();
                e.Handled = true;
            }
        }

        #endregion

        #region Private Methods

        private void CheckUser()
        {
            if (null == _user || _roles.IndexOf(_user.RoleId) == -1)
            {
                txtMsg.Text = "LogIn Failed";
                txtUserId.SelectAll();
                txtUserId.Focus();
                return;
            }
            SmartcardManager.Instance.Shutdown();
            this.DialogResult = true;
        }

        #endregion

        #region Public Methods

        public void Setup(params string[] roles)
        {
            _roles.Clear();
            _roles.AddRange(roles);

            SmartcardManager.Instance.Start();
        }

        public User User { get { return _user;} }

        #endregion
    }
}
