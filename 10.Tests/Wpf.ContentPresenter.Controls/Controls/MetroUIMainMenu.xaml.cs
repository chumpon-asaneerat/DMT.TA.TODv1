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
    /// Interaction logic for MetroUIMainMenu.xaml
    /// </summary>
    [ContentProperty("Groups")]
    public partial class MetroUIMainMenu : UserControl
    {
        #region Constructor

        public MetroUIMainMenu()
        {
            InitializeComponent();

            groupItemsControl.DataContext = this;
            Groups = new ObservableCollection<MetroUIGroupMenu>();
        }

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty GroupsProperty =
                DependencyProperty.Register("Groups", typeof(ObservableCollection<MetroUIGroupMenu>), typeof(MetroUIMainMenu), new PropertyMetadata(null));

        public ObservableCollection<MetroUIGroupMenu> Groups
        {
            get { return (ObservableCollection<MetroUIGroupMenu>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        #endregion
    }
}
