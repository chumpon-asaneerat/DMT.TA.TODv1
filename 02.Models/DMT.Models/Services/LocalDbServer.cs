﻿//#define USE_PROGRAM_DATA

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
			Shutdown();
		}

		#endregion

		#region Private Properties

		/// <summary>
		/// Gets local json folder path name.
		/// </summary>
		private static string LocalFolder
		{
			get
			{
#if !USE_PROGRAM_DATA
				string localFilder = Folders.Combine(
					Folders.Assemblies.CurrentExecutingAssembly, "data");
#else
				// Stored in C:\ProgarmData\DMT\Data\ folder
				string localFilder = ApplicationManager.Instance.Environments.Company.Data.FullName;
#endif
				if (!Folders.Exists(localFilder))
				{
					Folders.Create(localFilder);
				}
				return localFilder;
			}
		}

		#endregion

		#region Private Methods

		private void InitTables()
		{
			//Db.CreateTable<Config>();
			Db.CreateTable<ViewHistory>();
			//Db.CreateTable<UniqueCode>();

			Db.CreateTable<MCurrency>();
			Db.CreateTable<MCoupon>();
			Db.CreateTable<MCardAllow>();

			Db.CreateTable<TSB>();
			Db.CreateTable<PlazaGroup>();
			Db.CreateTable<Plaza>();
			Db.CreateTable<Lane>();

			Db.CreateTable<Shift>();

			Db.CreateTable<Role>();
			Db.CreateTable<User>();
			//Db.CreateTable<LogInLog>();

			//Db.CreateTable<Payment>();

			//Db.CreateTable<TSBShift>();
			//Db.CreateTable<UserShift>();
			//Db.CreateTable<UserShiftRevenue>();

			//Db.CreateTable<LaneAttendance>();
			//Db.CreateTable<LanePayment>();

			//Db.CreateTable<RevenueEntry>();

			//Db.CreateTable<TSBCreditTransaction>();

			//Db.CreateTable<TSBCouponTransaction>();

			//Db.CreateTable<UserCreditBalance>();
			//Db.CreateTable<UserCreditTransaction>();

			////Db.CreateTable<UserCouponBalance>();
			//Db.CreateTable<UserCouponTransaction>();

			//Db.CreateTable<TSBExchangeGroup>();
			//Db.CreateTable<TSBExchangeTransaction>();
		}

		private void InitDefaults()
		{
			InitMCurrency();
			InitMCoupon();
			InitMCardAllow();
			InitTSBAndPlazaAndLanes();
			InitShifts();
			InitRoleAndUsers();
			//InitPayments();
			//InitConfigs();
		}

		private void InitMCurrency()
		{
			if (null == Db) return;

			if (Db.Table<MCurrency>().Count() > 0) return; // already exists.

			MCurrency item;
			item = new MCurrency()
			{
				currencyDenomId = 1,
				abbreviation = "Satang25",
				description = "25 Satang",
				denomValue = (decimal)0.25,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 2,
				abbreviation = "Satang50",
				description = "50 Satang",
				denomValue = (decimal)0.5,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 3,
				abbreviation = "Baht1",
				description = "1 Baht",
				denomValue = 1,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 4,
				abbreviation = "Baht2",
				description = "2 Baht",
				denomValue = 2,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 5,
				abbreviation = "Baht5",
				description = "5 Baht",
				denomValue = 5,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 6,
				abbreviation = "CBaht10",
				description = "10 Baht",
				denomValue = 10,
				currencyId = 1,
				denomTypeId = 2 // coin
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 7,
				abbreviation = "NBaht10",
				description = "10 Baht",
				denomValue = 10,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 8,
				abbreviation = "NBaht20",
				description = "20 Baht",
				denomValue = 20,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 9,
				abbreviation = "NBaht50",
				description = "50 Baht",
				denomValue = 50,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 10,
				abbreviation = "NBaht100",
				description = "100 Baht",
				denomValue = 100,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 11,
				abbreviation = "NBaht500",
				description = "500 Baht",
				denomValue = 500,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
			item = new MCurrency()
			{
				currencyDenomId = 12,
				abbreviation = "NBaht1000",
				description = "1000 Baht",
				denomValue = 1000,
				currencyId = 1,
				denomTypeId = 1 // Note
			};
			if (!MCurrency.Exists(item)) MCurrency.Save(item);
		}

		private void InitMCoupon()
		{
			if (null == Db) return;

			if (Db.Table<MCoupon>().Count() > 0) return; // already exists.

			MCoupon item;
			item = new MCoupon()
			{
				couponId = 1,
				couponValue = 30,
				abbreviation = "30",
				description = "30 บาท"
			};
			if (!MCoupon.Exists(item)) MCoupon.Save(item);
			item = new MCoupon()
			{
				couponId = 2,
				couponValue = 35,
				abbreviation = "35",
				description = "35 บาท"
			};
			if (!MCoupon.Exists(item)) MCoupon.Save(item);
			item = new MCoupon()
			{
				couponId = 3,
				couponValue = 70,
				abbreviation = "70",
				description = "70 บาท"
			};
			if (!MCoupon.Exists(item)) MCoupon.Save(item);
			item = new MCoupon()
			{
				couponId = 4,
				couponValue = 80,
				abbreviation = "80",
				description = "80 บาท"
			};
			if (!MCoupon.Exists(item)) MCoupon.Save(item);
		}

		private void InitMCardAllow()
		{
			if (null == Db) return;

			if (Db.Table<MCardAllow>().Count() > 0) return; // already exists.

			MCardAllow item;
			item = new MCardAllow()
			{
				cardAllowId = 1,
				abbreviation = "Card DMT P1",
				description = "บัตร DMT (ป 1)"
			};
			if (!MCardAllow.Exists(item)) MCardAllow.Save(item);
			item = new MCardAllow()
			{
				cardAllowId = 2,
				abbreviation = "Card DMT P2",
				description = "บัตร DMT (ป 2)"
			};
			if (!MCardAllow.Exists(item)) MCardAllow.Save(item);
		}

		private void InitTSBAndPlazaAndLanes()
		{

		}

		private void InitShifts()
		{
			if (null == Db) return;

			if (Db.Table<Shift>().Count() > 0) return; // already exists.

			Shift item;
			item = new Shift()
			{
				ShiftId = 1,
				ShiftNameEN = "Morning",
				ShiftNameTH = "เช้า"
			};
			if (!Shift.Exists(item)) Shift.Save(item);
			item = new Shift()
			{
				ShiftId = 2,
				ShiftNameEN = "Afternoon",
				ShiftNameTH = "บ่าย"
			};
			if (!Shift.Exists(item)) Shift.Save(item);
			item = new Shift()
			{
				ShiftId = 3,
				ShiftNameEN = "Midnight",
				ShiftNameTH = "ดึก"
			};
			if (!Shift.Exists(item)) Shift.Save(item);
		}

		private void InitRoleAndUsers()
		{
			if (null == Db) return;

			if (Db.Table<User>().Count() > 0) return; // has user data so not insert dummy.

			Role item;
			User user;
			string prefix;
			string fName;
			string mName;
			string lName;

			#region ADMINS

			item = new Role()
			{
				RoleId = "ADMINS",
				RoleNameEN = "Administrator",
				RoleNameTH = "ผู้ดูแลระบบ",
				GroupId = 10
			};
			if (!Role.Exists(item)) Role.Save(item);

			prefix = "";
			fName = "Admin 1";
			mName = "";
			lName = "";
			user = new User()
			{
				UserId = "99901",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("123456"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			#endregion

			#region ACCOUNT

			item = new Role()
			{
				RoleId = "ACCOUNT",
				RoleNameEN = "Account",
				RoleNameTH = "บัญชี",
				GroupId = 63
			};
			if (!Role.Exists(item)) Role.Save(item);

			prefix = "";
			fName = "audit1";
			mName = "";
			lName = "";
			user = new User()
			{
				UserId = "85020",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "สมชาย";
			mName = "";
			lName = "ตุยเอียว";
			user = new User()
			{
				UserId = "65401",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			#endregion

			#region CTC

			item = new Role()
			{
				RoleId = "CTC",
				RoleNameEN = "Chief Toll Collector",
				RoleNameTH = "หัวหน้าพนักงานจัดเก็บค่าผ่านทาง",
				GroupId = 40
			};
			if (!Role.Exists(item)) Role.Save(item);

			prefix = "นาย";
			fName = "ผจญ";
			mName = "";
			lName = "สุดศิริ";
			user = new User()
			{
				UserId = "13566",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "วิรชัย";
			mName = "";
			lName = "ขำหิรัญ";
			user = new User()
			{
				UserId = "26855",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "บุญส่ง";
			mName = "";
			lName = "บุญปลื้ม";
			user = new User()
			{
				UserId = "30242",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "สมบูรณ์";
			mName = "";
			lName = "สบายดี";
			user = new User()
			{
				UserId = "76333",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			#endregion

			#region TC

			item = new Role()
			{
				RoleId = "TC",
				RoleNameEN = "Toll Collector",
				RoleNameTH = "พนักงาน",
				GroupId = 20
			};
			if (!Role.Exists(item)) Role.Save(item);

			prefix = "นาย";
			fName = "อดิศร";
			mName = "";
			lName = "ทิพยไพศาล";
			user = new User()
			{
				UserId = "00111",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "ภักดี";
			mName = "";
			lName = "อมรรุ่งโรจน์";
			user = new User()
			{
				UserId = "14211",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นางสาว";
			fName = "แก้วใส";
			mName = "";
			lName = "ฟ้ารุ่งโรจณ์";
			user = new User()
			{
				UserId = "14124",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาง";
			fName = "วิภา";
			mName = "";
			lName = "สวัสดิวัฒน์";
			user = new User()
			{
				UserId = "14055",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "สุเทพ";
			mName = "";
			lName = "เหมัน";
			user = new User()
			{
				UserId = "14321",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาย";
			fName = "ศิริลักษณ์";
			mName = "";
			lName = "วงษาหาร";
			user = new User()
			{
				UserId = "14477",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นางสาว";
			fName = "สุณิสา";
			mName = "";
			lName = "อีนูน";
			user = new User()
			{
				UserId = "14566",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "นาง";
			fName = "วาสนา";
			mName = "";
			lName = "ชาญวิเศษ";
			user = new User()
			{
				UserId = "15097",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("1234"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			prefix = "Mr.";
			fName = "killer1115";
			mName = "";
			lName = "";
			user = new User()
			{
				UserId = "15097",
				PrefixEN = prefix,
				FirstNameEN = fName,
				MiddleNameEN = mName,
				LastNameEN = lName,
				PrefixTH = prefix,
				FirstNameTH = fName,
				MiddleNameTH = mName,
				LastNameTH = lName,
				Password = Utils.MD5.Encrypt("killer1115"),
				CardId = "",
				AccountStatus = User.AccountFlags.Valid,
				IsDummy = true,
				RoleId = item.RoleId
			};
			if (!User.Exists(user)) User.Save(user);

			#endregion

			#region MT_ADMIN

			item = new Role()
			{
				RoleId = "MT_ADMIN",
				RoleNameEN = "Maintenance Administrator",
				RoleNameTH = "ทีมซ่อมบำรุง กลุ่ม Admin",
				GroupId = 10
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region MT_TECH

			item = new Role()
			{
				RoleId = "MT_TECH",
				RoleNameEN = "Maintenance Technical",
				RoleNameTH = "ทีมซ่อมบำรุง กลุ่มช่าง",
				GroupId = 51
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region CTC_MGR

			item = new Role()
			{
				RoleId = "CTC_MGR",
				RoleNameEN = "Chief Toll Manager",
				RoleNameTH = "หัวหน้าแผนก",
				GroupId = 49
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region FINANCE

			item = new Role()
			{
				RoleId = "FINANCE",
				RoleNameEN = "Finance",
				RoleNameTH = "การเงิน",
				GroupId = 64
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region SV

			item = new Role()
			{
				RoleId = "SV",
				RoleNameEN = "Supervisor",
				RoleNameTH = "พนักงานควบคุม",
				GroupId = 30
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region RAD_MGR

			item = new Role()
			{
				RoleId = "RAD_MGR",
				RoleNameEN = "Revenue Audit Division (Manager)",
				RoleNameTH = "แผนกตรวจสอบรายได้ค่าผ่านทาง (Manager)",
				GroupId = 60
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion

			#region RAD_SUP

			item = new Role()
			{
				RoleId = "RAD_SUP",
				RoleNameEN = "Revenue Audit Division (Supervisor)",
				RoleNameTH = "แผนกตรวจสอบรายได้ค่าผ่านทาง (Supervisor)",
				GroupId = 61
			};
			if (!Role.Exists(item)) Role.Save(item);

			#endregion
		}

		private void InitViews()
		{
			if (null == Db) return;

			string prefix;

			// Infrastructures - Embeded resource used . instead / to access sub contents.
			prefix = @"Infrastructures";
			InitView("PlazaGroupView", 1, prefix);
			InitView("PlazaView", 1, prefix);
			InitView("LaneView", 1, prefix);

			// Users - Embeded resource used . instead / to access sub contents.
			prefix = @"Users";
			InitView("UserView", 1, prefix);

			// Shifts - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"Shifts";
			InitView("TSBShiftView", 1, prefix);
			InitView("UserShiftView", 1, prefix);
			InitView("UserShiftRevenueView", 1, prefix);
			*/

			// LaneActivities - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"LaneActivities";
			InitView("LaneAttendanceView", 1, prefix);
			InitView("LanePaymentView", 1, prefix);
			*/

			// Revenues - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"Revenues";
			InitView("RevenueEntryView", 1, prefix);
			*/

			// Credits - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"Credits";
			InitView("TSBCreditSummarryView", 1, prefix);
			InitView("TSBCreditTransactionView", 1, prefix);
			InitView("UserCreditBorrowSummaryView", 1, prefix);
			InitView("UserCreditReturnSummaryView", 1, prefix);
			InitView("UserCreditSummaryView", 1, prefix);
			InitView("UserCreditTransactionView", 1, prefix);
			*/
			// Coupons - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"Coupons";
			InitView("TSBCouponTransactionView", 1, prefix);
			

			InitView("TSBCouponStockBalanceView", 1, prefix);
			InitView("TSBCouponLaneBalanceView", 1, prefix);
			InitView("TSBCouponSoldByLaneBalanceView", 1, prefix);
			InitView("TSBCouponSoldByTSBBalanceView", 1, prefix);
			InitView("TSBCouponBalanceView", 1, prefix);

			InitView("TSBCouponSummarryView", 1, prefix);
			InitView("UserCoupon35SummaryView", 1, prefix);
			InitView("UserCoupon80SummaryView", prefix);
			InitView("UserCouponSummaryView", 1, prefix);
			InitView("UserCouponTransactionView", 1, prefix);
			*/

			// Exchanges - Embeded resource used . instead / to access sub contents.
			/*
			prefix = @"Exchanges";
			InitView("TSBExchangeGroupView", 1, prefix);
			InitView("TSBExchangeTransactionView", 1, prefix);
			*/
		}

		class ViewInfo
		{
			public string Name { get; set; }
		}

		private void InitView(string viewName, int version, string resourcePrefix = "")
		{
			if (null == Db) return;

			var hist = ViewHistory.GetWithChildren(viewName, false).Value();

			string checkViewCmd = "SELECT Name FROM sqlite_master WHERE Type = 'view' AND Name = ?";
			var rets = Db.Query<ViewInfo>(checkViewCmd, viewName);
			bool exists = (null != rets && rets.Count > 0);

			//bool exists = (null != info) ? info.Count > 0 : false;

			if (!exists || null == hist || hist.VersionId < version)
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
						med.Err(dropEx);
						med.Err("Drop Failed:" + Environment.NewLine + viewName);
						Db.Rollback();
					}
					finally { Db.Commit(); }

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
						//Console.WriteLine("Returns: {0}", ret);

						if (null == hist) hist = new ViewHistory();
						hist.ViewName = viewName;
						hist.VersionId = version;
						ViewHistory.Save(hist);

						string msg = string.Format("Update View {0}, version {1}.", hist.ViewName, hist.VersionId);
						Console.WriteLine(msg);
						med.Info(msg);
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
					//Console.WriteLine(script);
				}
			}
		}

		#endregion

		#region Public Methods (Start/Shutdown)

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
						InitTables(); // Init Tables.
						InitDefaults(); // init default data.
						InitViews(); // init views.

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
		/// <summary>
		/// Gets is database connected.
		/// </summary>
		public bool Connected { get { return (null != this.Db); } }

		#endregion

		#region Public Events

		/// <summary>
		/// OnConnected event.
		/// </summary>
		public event EventHandler OnConnected;
		/// <summary>
		/// OnDisconnected event.
		/// </summary>
		public event EventHandler OnDisconnected;
		/// <summary>
		/// OnConectError event.
		/// </summary>
		public event EventHandler OnConectError;

		#endregion
	}

	#endregion

}
