#region Using

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#endregion

namespace Wpf.ContentPresenter.Controls
{
    /// <summary>
    /// Interaction logic for MetroUIGroupMenu.xaml
    /// </summary>
    [ContentProperty("Buttons")]
    public partial class MetroUIGroupMenu : UserControl
    {
        #region Constructor

        public MetroUIGroupMenu()
        {
            InitializeComponent();

            buttonItemsControl.DataContext = this;
            Buttons = new ObservableCollection<MetroUIMenuButton>();
        }

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty GroupsProperty =
                DependencyProperty.Register("Buttons", typeof(ObservableCollection<MetroUIMenuButton>), typeof(MetroUIGroupMenu), new PropertyMetadata(null));

        public ObservableCollection<MetroUIMenuButton> Buttons
        {
            get { return (ObservableCollection<MetroUIMenuButton>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        #endregion
    }
}
