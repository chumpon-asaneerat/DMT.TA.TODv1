using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Item data;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            data = new Item();
            this.DataContext = data;
        }
    }

    public class Item
    {
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public int Total
        {
            get { return this.Data1 + this.Data2; }
            set { }
        }
    }
}
