#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

// SQLite
using SQLite;
//using SQLiteNetExtensions.Attributes;
//using SQLiteNetExtensions.Extensions;

using NLib;
using NLib.IO;

using DMT.Models;
using DMT.Views;

#endregion

namespace DMT.Services
{
	#region LobalDbServer

	/// <summary>
	/// Local Database Server.
	/// </summary>
	public class LocalDbServer
	{
		#region Singelton

		private static LocalDbServer _instance = null;
		/// <summary>
		/// Singelton Access.
		/// </summary>
		public static LocalDbServer Instance
		{
			get
			{
				if (null == _instance)
				{
					lock (typeof(LocalDbServer))
					{
						_instance = new LocalDbServer();
					}
				}
				return _instance;
			}
		}

		#endregion

		#region Internal Variables

		private int HistoryVersion = 1;

		#endregion

		#region Constructor and Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		private LocalDbServer() : base()
		{
			this.FileName = "TODxTA.db";
		}
		/// <summary>
		/// Destructor.
		/// </summary>
		~LocalDbServer()
		{

		}

		#endregion

		#region Private Methods

		#region InitTables

		private void InitTables()
		{
			if (null == Db) return;

			Db.CreateTable<Config>();
			Db.CreateTable<ViewHistory>();
			Db.CreateTable<UniqueCode>();
		}

		#endregion

		#region InitView(s)

		class ViewInfo
		{
			public string Name { get; set; }
		}

		private void InitView(string viewName, string resourcePrefix = "")
		{
			if (null == Db) return;

			var hist = ViewHistory.GetWithChildren(viewName, false).Value();

			string checkViewCmd = "SELECT Name FROM sqlite_master WHERE Type = 'view' AND Name = ?";
			var rets = Db.Query<ViewInfo>(checkViewCmd, viewName);
			bool exists = (null != rets && rets.Count > 0);

			//bool exists = (null != info) ? info.Count > 0 : false;

			if (!exists || null == hist || hist.VersionId != HistoryVersion)
			{
				string script = string.Empty;
				MethodBase med = MethodBase.GetCurrentMethod();
				try
				{
					string dropCmd = string.Empty;
					dropCmd += "DROP VIEW IF EXISTS " + viewName;
					Db.BeginTransaction();
					try { Db.Execute(dropCmd); }
					catch (Exception dropEx)
					{
						//Console.WriteLine(dropEx);
						med.Err(dropEx);
						med.Err("Drop Failed:" + Environment.NewLine + viewName);
						Db.Rollback();
					}
					finally { Db.Commit(); }

					// Recheck
					/*
					rets = Db.Query<ViewInfo>(checkViewCmd, viewName);
					exists = (null != rets && rets.Count > 0);
					if (exists)
					{
						Console.WriteLine("Drop View Failed.");
					}
					*/

					string resourceName = viewName + ".sql";
					// Note: 
					// -----------------------------------------------------------
					// Embeded resource used . instead / to access sub contents.
					// -----------------------------------------------------------
					string embededResourceName;
					if (!string.IsNullOrWhiteSpace(resourcePrefix))
					{
						// Has prefix
						if (!resourcePrefix.Trim().EndsWith("."))
						{
							// Not end with . so append . and concat full name.
							embededResourceName = @"DMT.Views.Scripts." + resourcePrefix + "." + resourceName;
						}
						else
						{
							// Already end with . so concat to full name.
							embededResourceName = @"DMT.Views.Scripts." + resourcePrefix + resourceName;
						}
					}
					else
					{
						// No prefix.
						embededResourceName = @"DMT.Views.Scripts." + resourceName;
					}

					script = SqliteScriptManager.GetScript(embededResourceName);

					if (!string.IsNullOrEmpty(script))
					{
						var ret = Db.Execute(script);

						Console.WriteLine("Returns: {0}", ret);

						if (null == hist) hist = new ViewHistory();
						hist.ViewName = viewName;
						hist.VersionId = HistoryVersion;
						ViewHistory.Save(hist);
					}
					else
					{
						Console.WriteLine("{0} Has Empty Scripts.", viewName);
					}
				}
				catch (Exception ex)
				{
					//Console.WriteLine(ex);
					med.Err(ex);
					med.Err("Script:" + Environment.NewLine + script);
					Console.WriteLine(script);
				}
			}
		}

		private void InitViews()
		{
			if (null == Db) return;

			string prefix;

			// Users - Embeded resource used . instead / to access sub contents.
			prefix = @"Users";
			InitView("UserView", prefix);

			//TODO: Refactor
			/*
			// Infrastructures - Embeded resource used . instead / to access sub contents.
			prefix = @"Infrastructures";
			InitView("PlazaGroupView", prefix);
			InitView("PlazaView", prefix);
			InitView("LaneView", prefix);

			// Shifts - Embeded resource used . instead / to access sub contents.
			prefix = @"Shifts";
			InitView("TSBShiftView", prefix);
			InitView("UserShiftView", prefix);
			InitView("UserShiftRevenueView", prefix);

			// LaneActivities - Embeded resource used . instead / to access sub contents.
			prefix = @"LaneActivities";
			InitView("LaneAttendanceView", prefix);
			InitView("LanePaymentView", prefix);

			// Revenues - Embeded resource used . instead / to access sub contents.
			prefix = @"Revenues";
			InitView("RevenueEntryView", prefix);

			// Credits - Embeded resource used . instead / to access sub contents.
			prefix = @"Credits";
			InitView("TSBCreditSummarryView", prefix);
			InitView("TSBCreditTransactionView", prefix);
			InitView("UserCreditBorrowSummaryView", prefix);
			InitView("UserCreditReturnSummaryView", prefix);
			InitView("UserCreditSummaryView", prefix);
			InitView("UserCreditTransactionView", prefix);

			// Coupons - Embeded resource used . instead / to access sub contents.
			prefix = @"Coupons";
			InitView("TSBCouponTransactionView", prefix);

			InitView("TSBCouponStockBalanceView", prefix);
			InitView("TSBCouponLaneBalanceView", prefix);
			InitView("TSBCouponSoldByLaneBalanceView", prefix);
			InitView("TSBCouponSoldByTSBBalanceView", prefix);
			InitView("TSBCouponBalanceView", prefix);

			InitView("TSBCouponSummarryView", prefix);
			InitView("UserCoupon35SummaryView", prefix);
			InitView("UserCoupon80SummaryView", prefix);
			InitView("UserCouponSummaryView", prefix);
			InitView("UserCouponTransactionView", prefix);

			// Exchanges - Embeded resource used . instead / to access sub contents.
			prefix = @"Exchanges";
			InitView("TSBExchangeTransactionView", prefix);
			*/
		}

		#endregion

		#endregion

		#region Private Properties

		/// <summary>
		/// Gets local json folder path name.
		/// </summary>
		private static string LocalFolder
		{
			get
			{
				/*
				string localFilder = Folders.Combine(
					Folders.Assemblies.CurrentExecutingAssembly, "data");
				*/

				// Stored in C:\ProgarmData\DMT\Data\ folder
				string localFilder = ApplicationManager.Instance.Environments.Company.Data.FullName;
				if (!Folders.Exists(localFilder))
				{
					Folders.Create(localFilder);
				}
				return localFilder;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Start.
		/// </summary>
		public void Start()
		{
			MethodBase med = MethodBase.GetCurrentMethod();
			if (null == Db)
			{
				lock (typeof(LocalDbServer))
				{
					try
					{
						// ---------------------------------------------------------------
						// NOTE:
						// ---------------------------------------------------------------
						// If Exception due to version mismatch here
						// Please rebuild only this project and try again
						// VS Should Solve mismatch version properly (maybe)
						// See: https://nickcraver.com/blog/2020/02/11/binding-redirects/
						// for more information.
						// ---------------------------------------------------------------

						string path = Path.Combine(LocalFolder, FileName);
						Db = new SQLiteConnection(path,
							SQLiteOpenFlags.Create |
							SQLiteOpenFlags.SharedCache |
							SQLiteOpenFlags.ReadWrite |
							SQLiteOpenFlags.FullMutex,
							storeDateTimeAsTicks: false);
						Db.BusyTimeout = new TimeSpan(0, 0, 5); // set busy timeout.
					}
					catch (Exception ex)
					{
						med.Err(ex);
						Db = null;

						OnConectError.Call(this, EventArgs.Empty);
					}
					if (null != Db)
					{
						// Set Default connection 
						// (be careful to make sure that we only has single database
						// for all domain otherwise call static method with user connnection
						// in each domain class instead omit connection version).

						NTable.Default = Db;
						NQuery.Default = Db;

						InitTables();

						OnConnected.Call(this, EventArgs.Empty);
					}
				}
			}
		}
		/// <summary>
		/// Shutdown.
		/// </summary>
		public void Shutdown()
		{
			if (null != Db)
			{
				Db.Dispose();
			}
			Db = null;
			OnDisconnected.Call(this, EventArgs.Empty);
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets database file name.
		/// </summary>
		public string FileName { get; set; }
		/// <summary>
		/// Gets SQLite Connection.
		/// </summary>
		public SQLiteConnection Db { get; private set; }

		#endregion

		#region Public Events

		public event EventHandler OnConnected;
		public event EventHandler OnDisconnected;
		public event EventHandler OnConectError;

		#endregion
	}

	#endregion
}
