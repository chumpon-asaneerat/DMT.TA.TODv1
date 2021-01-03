#region Using

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using DMT.Models;
using DMT.Services;
using NLib.Services;
using NLib.Reflection;

#endregion

namespace DMT.Simulator.Windows
{
    using localOps = Services.Operations.Plaza; // reference to static class.

    /// <summary>
    /// Interaction logic for UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public UserListWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Variables

        private List<User> _users = null;

        #endregion

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Button Handlers

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        #endregion

        #region ListBox Handlers

        private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lstUsers.SelectedIndex;
            if (idx == -1) return;
            User = _users[idx];
        }

        private void lstUsers_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int idx = lstUsers.SelectedIndex;
            if (idx == -1) return;
            User = _users[idx];
            if (null == User) return;
            DialogResult = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Setup.
        /// </summary>
        /// <param name="users">The exclude user id list.</param>
        public void Setup(params string[] users)
        {
            lstUsers.ItemsSource = null;
            // Load Users.
            _users = localOps.Security.User.Gets().Value();

            if (null != users && users.Length > 0)
            {
                // filter out all user on lanes.
            }

            lstUsers.ItemsSource = _users;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets selected user.
        /// </summary>
        public User User { get; private set; }

        #endregion
    }
}
