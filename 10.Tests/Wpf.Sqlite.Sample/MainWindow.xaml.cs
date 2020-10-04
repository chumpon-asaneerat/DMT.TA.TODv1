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

#endregion

using SQLite;
using SQLitePCL;
using System.ComponentModel;


namespace Wpf.Sqlite.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Connect();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Disconnect();
        }

        #endregion

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
        }

        private SQLiteConnection db;
        private Random rand = new Random();
        private int MaxRecord = 1000;

        private void Connect()
        {
            string databasePath = "./data";
            if (!System.IO.Directory.Exists(databasePath)) System.IO.Directory.CreateDirectory(databasePath);
            string databaseName = databasePath + "/stock.db";
            db = new SQLiteConnection(databaseName, 
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache |
                SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.FullMutex,
                storeDateTimeAsTicks: false);
            db.CreateTable<Stock>();
        }

        private void Disconnect()
        {
            if (null != db)
            {
                db.Close();
                db.Dispose();
            }
            db = null;
        }

        public void UpdateAll()
        {
            var items = Stock.GetAll(db);
            if (null == items || items.Count <= 0) items = InitData();
            if (null == items || items.Count <= 0) return;
            int idx = 0;
            items.ForEach(item => 
            {
                item.Data = rand.Next(100);
                item.LastUpdated = DateTime.Now;
                idx++;
            });
            while (idx < MaxRecord)
            {
                items.Add(GetInst(idx));
                idx++;
            }
            DateTime dt = DateTime.Now;
            Stock.SaveAll(db, items);
            TimeSpan ts = DateTime.Now - dt;
            string msg = string.Format("operate {0:n0} record(s) in {1:n0} ms.", items.Count, ts.TotalMilliseconds);
            txtTime.Text = msg;
        }

        public List<Stock> InitData()
        {
            List<Stock> results = new List<Stock>();
            for (int i = 0; i < MaxRecord; i++)
            {
                var inst = GetInst(i);
                results.Add(inst);
            }
            return results;
        }

        public Stock GetInst(int ItemId)
        {
            var inst = new Stock();
            inst.ItemId = ItemId.ToString("D5");
            inst.Data = rand.Next(100);
            inst.LastUpdated = DateTime.Now;
            return inst;
        }
    }

    public class Stock
    {
        [AutoIncrement, PrimaryKey]
        public int PkId { get; set; }
        [MaxLength(10)]
        public string ItemId { get; set; }
        public int? Data { get; set; }
        public DateTime? LastUpdated { get; set; }

        public static void Save(SQLiteConnection db, Stock value)
        {
            if (null == db || null == value)
                return;
            var item = db.Query<Stock>("SELECT * FROM Stock WHERE ItemId = ?", value.ItemId).FirstOrDefault();
            if (null == item)
            {
                db.Insert(value);
            }
            else
            {
                item.Data = value.Data;
                item.LastUpdated = value.LastUpdated;
                db.Update(item);
            }
        }

        public static void SaveAll(SQLiteConnection db, List<Stock> values)
        {
            if (null == db || null == values)
                return;
            values.ForEach(value => 
            {
                Save(db, value);
            });
        }

        public static List<Stock> GetAll(SQLiteConnection db)
        {
            if (null == db) return new List<Stock>();
            var results = db.Query<Stock>("SELECT * FROM Stock");
            return results;
        }
    }
}
