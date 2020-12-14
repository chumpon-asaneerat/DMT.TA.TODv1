#region Using

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

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

            // set ItemsControl data context.
            buttonItemsControl.DataContext = this;
            // Init properties
            Header = "Header";
            Buttons = new ObservableCollection<MetroUIMenuButton>();
        }

        #endregion

        #region Dependency Properties

        #region Group Colors

        public static readonly DependencyProperty GroupForegroundProperty =
                DependencyProperty.Register("GroupForground", typeof(Brush), typeof(MetroUIGroupMenu), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));
        
        public Brush GroupForeground
        {
            get { return (Brush)GetValue(GroupForegroundProperty); }
            set { SetValue(GroupForegroundProperty, value); }
        }

        public static readonly DependencyProperty GroupBackgroundProperty =
                DependencyProperty.Register("GroupBackground", typeof(Brush), typeof(MetroUIGroupMenu), new PropertyMetadata(new SolidColorBrush(Colors.ForestGreen)));
        
        public Brush GroupBackground
        {
            get { return (Brush)GetValue(GroupBackgroundProperty); }
            set { SetValue(GroupBackgroundProperty, value); }
        }

        #endregion

        #region Buttons

        public static readonly DependencyProperty ButtonsProperty =
                DependencyProperty.Register("Buttons", typeof(ObservableCollection<MetroUIMenuButton>), typeof(MetroUIGroupMenu), new PropertyMetadata(null));

        public ObservableCollection<MetroUIMenuButton> Buttons
        {
            get { return (ObservableCollection<MetroUIMenuButton>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        #endregion

        #region Header (Text/FontSize)

        public static readonly DependencyProperty HeaderProperty =
                DependencyProperty.Register("Header", typeof(string), typeof(MetroUIGroupMenu), new PropertyMetadata(""));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderFontSizeProperty =
                DependencyProperty.Register("HeaderFontSize", typeof(int), typeof(MetroUIGroupMenu), new PropertyMetadata(20));

        public int HeaderFontSize
        {
            get { return (int)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion

        #endregion
    }
}
