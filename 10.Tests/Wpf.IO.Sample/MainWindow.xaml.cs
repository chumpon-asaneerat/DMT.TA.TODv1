#region Using

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

using System.IO;
using System.Reflection;

#endregion

namespace Wpf.IO.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Handlers

        private void cmdBuildDirs_Click(object sender, RoutedEventArgs e)
        {
            Assembly assem = this.GetType().Assembly;
            string appPath = System.IO.Path.GetDirectoryName(assem.Location);
            string root = System.IO.Path.Combine(appPath, "msgs");
            Folder inst = new Folder() { Name = "Messages", Root = root };

            inst.Folders.Add(new SubFolder() { Name = "Input", Path = "Input" });
            inst.Folders.Add(new SubFolder() { Name = "Procesing", Path = "Procesing" });
            inst.Folders.Add(new SubFolder() { Name = "Output", Path = "Output" });
            inst.Folders.Add(new SubFolder() { Name = "Error", Path = "Error" });

            inst.CheckFolers();
        }

        #endregion
    }
}


namespace Wpf.IO.Sample
{
    public class Folder
    {
        public Folder() : base()
        {
            this.Folders = new List<SubFolder>();
        }
        ~Folder() 
        { 
        }

        public string Name { get; set; }
        public string Root { get; set; }
        public List<SubFolder> Folders { get; set; }

        public void CheckFolers()
        {
            if (!string.IsNullOrEmpty(this.Root))
            {
                if (!Directory.Exists(this.Root))
                {
                    Directory.CreateDirectory(this.Root);
                }
                if (!Directory.Exists(this.Root))
                {
                    // Directory not found or cannot create directory.
                    return;
                }
                if (null != Folders && Folders.Count > 0)
                {
                    Folders.ForEach(folder => 
                    {
                        folder.CheckFolers(this.Root);
                    });
                }
            }
        }
    }

    public class SubFolder
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public void CheckFolers(string root)
        {
            if (string.IsNullOrEmpty(root) || string.IsNullOrEmpty(this.Path)) return;
            string fullPath = System.IO.Path.Combine(root, this.Path);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            if (!Directory.Exists(fullPath))
            {
                // Directory not found or cannot create directory.
                return;
            }
        }
    }
}