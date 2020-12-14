using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.ContentPresenter.Controls
{
    /// <summary>
    /// Interaction logic for MetroUIMainMenu.xaml
    /// </summary>
    [ContentProperty("Groups")]
    public partial class MetroUIMainMenu : UserControl
    {
        public MetroUIMainMenu()
        {
            InitializeComponent();

            groupItemsControl.DataContext = this;
            Groups = new ObservableCollection<MetroUIGroupMenu>();
        }

        public static readonly DependencyProperty GroupsProperty =
                DependencyProperty.Register("Groups", typeof(ObservableCollection<MetroUIGroupMenu>), typeof(MetroUIGroupMenu), new PropertyMetadata(null));

        public ObservableCollection<MetroUIGroupMenu> Groups
        {
            get { return (ObservableCollection<MetroUIGroupMenu>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
    }
}
