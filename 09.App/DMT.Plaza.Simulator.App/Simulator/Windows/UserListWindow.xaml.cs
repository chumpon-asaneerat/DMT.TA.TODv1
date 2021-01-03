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

        }

        #endregion

        #region Public Methods

        public void Setup()
        {

        }

        #endregion
    }
}
