using System;
using System.Collections.Generic;

namespace DMT.v1
{
    #region RouteConsts V1

    /// <summary>
    /// The Route (Local dataase) constants class.
    /// </summary>
    public static class RouteConsts
    {
        #region Base Url

        /// <summary>
        /// Gets base api url.
        /// </summary>
        public const string Url = @"api";

        #endregion

        #region User - OK

        /// <User>
        /// The TSB routes class.
        /// </summary>
        public static class User
        {
            #region Base route api

            /// <summary>
            /// Gets base User api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/User";

            #endregion

            #region Role - OK

            #region GetRole

            /// <summary>
            /// Get Role.
            /// </summary>
            public static class GetRole
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetRole";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region GetRoles

            /// <summary>
            /// Get Roles.
            /// </summary>
            public static class GetRoles
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetRoles";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region SaveRole

            /// <summary>
            /// Save Role.
            /// </summary>
            public static class SaveRole
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveRole";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region User - OK

            #region GetUsers

            /// <summary>
            /// Get Users.
            /// </summary>
            public static class GetUsers
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetUsers";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region GetById

            /// <summary>
            /// Get User By User Id (exact match).
            /// </summary>
            public static class GetById
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetById";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region SearchByGroupId

            /// <summary>
            /// Get User By GroupId.
            /// </summary>
            public static class SearchByGroupId
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SearchByGroupId";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region SearchById

            /// <summary>
            /// Search User By User Id (partian match).
            /// </summary>
            public static class SearchById
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SearchById";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region GetByCardId

            /// <summary>
            /// Get User By Card Id
            /// </summary>
            public static class GetByCardId
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetByCardId";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region GetByLogIn

            /// <summary>
            /// Get User By User Name and Password
            /// </summary>
            public static class GetByLogIn
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetByLogIn";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #region SaveUser

            /// <summary>
            /// Save User.
            /// </summary>
            public static class SaveUser
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveUser";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = User.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Shift - OK

        /// <summary>
        /// The Shift routes class.
        /// </summary>
        public static class Shift
        {
            #region Base route api

            /// <summary>
            /// Gets base Shift api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Shift";

            #endregion

            #region Shift - OK

            #region GetShifts

            /// <summary>
            /// Get Shifts.
            /// </summary>
            public static class GetShifts
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetShifts";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region SaveShift 

            /// <summary>
            /// Save Shift.
            /// </summary>
            public static class SaveShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region TSB Shift - OK

            #region CreateTSBShift

            /// <summary>
            /// Create TSB Shift.
            /// </summary>
            public static class CreateTSBShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "Create";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region GetCurrentTSBShift

            /// <summary>
            /// Get Current TSB Shift.
            /// </summary>
            public static class GetCurrentTSBShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrent";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region ChangeShift

            /// <summary>
            /// Change Shift.
            /// </summary>
            public static class ChangeShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "ChangeShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region User Shift - OK

            #region CreateUserShift

            /// <summary>
            /// Create User Shift.
            /// </summary>
            public static class CreateUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "CreateUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region GetCurrentUserShift

            /// <summary>
            /// Get Current User Shift.
            /// </summary>
            public static class GetCurrentUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrent";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region BeginUserShift

            /// <summary>
            /// Begin User Shift.
            /// </summary>
            public static class BeginUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "BeginUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region EndUserShift

            /// <summary>
            /// End User Shift.
            /// </summary>
            public static class EndUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "EndUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region GetUserShifts

            /// <summary>
            /// Get User Shifts
            /// </summary>
            public static class GetUserShifts
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetUserShifts";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #region GetUnCloseUserShifts

            /// <summary>
            /// Get UnClose User Shifts.
            /// </summary>
            public static class GetUnCloseUserShifts
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetUnCloseUserShifts";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Shift.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Lane (Attendance/Payment) - OK

        /// <summary>
        /// The Lane (Attendance/Payment) routes class.
        /// </summary>
        public static class Lane
        {
            #region Base route api

            /// <summary>
            /// Gets base Lane api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Lane";

            #endregion

            #region Lane Attendance - OK

            #region CreateAttendance

            /// <summary>
            /// Create Attendance.
            /// </summary>
            public static class CreateAttendance
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "CreateAttendance";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region SaveAttendance

            /// <summary>
            /// Save Attendance.
            /// </summary>
            public static class SaveAttendance
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveAttendance";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region SaveAttendances

            /// <summary>
            /// Save Attendances.
            /// </summary>
            public static class SaveAttendances
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveAttendances";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAttendancesByDate

            /// <summary>
            /// Get Attendances By Date.
            /// </summary>
            public static class GetAttendancesByDate
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAttendancesByDate";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAttendancesByUserShift

            /// <summary>
            /// Get Attendances By User Shift.
            /// </summary>
            public static class GetAttendancesByUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAttendancesByUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAttendancesByRevenue

            /// <summary>
            /// Get Attendances By Revenue.
            /// </summary>
            public static class GetAttendancesByRevenue
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAttendancesByRevenue";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAllAttendancesByUserShift

            /// <summary>
            /// Get All Attendances By User Shift.
            /// </summary>
            public static class GetAllAttendancesByUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAllAttendancesByUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAttendancesByLane

            /// <summary>
            /// Get Attendances By Lane.
            /// </summary>
            public static class GetAttendancesByLane
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAttendancesByLane";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetCurrentAttendancesByLane

            /// <summary>
            /// Get Current Attendances By Lane.
            /// </summary>
            public static class GetCurrentAttendancesByLane
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrentAttendancesByLane";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAllNotHasRevenueEntry

            /// <summary>
            /// Get All Not Has RevenueEntry.
            /// </summary>
            public static class GetAllNotHasRevenueEntry
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAllNotHasRevenueEntry";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetAllNotHasRevenueEntryByUser

            /// <summary>
            /// Get All Not Has RevenueEntry By User.
            /// </summary>
            public static class GetAllNotHasRevenueEntryByUser
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetAllNotHasRevenueEntryByUser";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region Lane Payment - OK

            #region CreatePayment

            /// <summary>
            /// Create Payment.
            /// </summary>
            public static class CreatePayment
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "CreatePayment";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region SavePayment

            /// <summary>
            /// Save Payment.
            /// </summary>
            public static class SavePayment
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SavePayment";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetPaymentsByDate

            /// <summary>
            /// Get Payments By Date.
            /// </summary>
            public static class GetPaymentsByDate
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPaymentsByDate";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetPaymentsByUserShift

            /// <summary>
            /// Get Payments By User Shift.
            /// </summary>
            public static class GetPaymentsByUserShift
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPaymentsByUserShift";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetPaymentsByLane

            /// <summary>
            /// Get Payments By Lane.
            /// </summary>
            public static class GetPaymentsByLane
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPaymentsByLane";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #region GetCurrentPaymentsByLane

            /// <summary>
            /// Get Current Payments By Lane.
            /// </summary>
            public static class GetCurrentPaymentsByLane
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrentPaymentsByLane";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Lane.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Revenue - OK

        /// <summary>
        /// The Revenue routes class.
        /// </summary>
        public static class Revenue
        {
            #region Base route api

            /// <summary>
            /// Gets base Revenue api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Revenue";

            #endregion

            #region UserShiftRevenue - OK

            #region CreatePlazaRevenue

            /// <summary>
            /// Create Plaza Revenue.
            /// </summary>
            public static class CreatePlazaRevenue
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "CreatePlazaRevenue";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #region SavePlazaRevenue

            /// <summary>
            /// Save Plaza Revenue.
            /// </summary>
            public static class SavePlazaRevenue
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SavePlazaRevenue";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #region GetPlazaRevenue

            /// <summary>
            /// Get Plaza Revenue.
            /// </summary>
            public static class GetPlazaRevenue
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPlazaRevenue";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region Revenue Entry - OK

            #region SaveRevenue

            /// <summary>
            /// Save Revenue.
            /// </summary>
            public static class SaveRevenue
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveRevenue";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #region GetRevenues

            /// <summary>
            /// Get Revenues.
            /// </summary>
            public static class GetRevenues
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetRevenues";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #region GetUnsendRevenues

            /// <summary>
            /// Get Unsend Revenues.
            /// </summary>
            public static class GetUnsendRevenues
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetUnsendRevenues";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Revenue.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Credit - OK

        /// <summary>
        /// The Credit routes class.
        /// </summary>
        public static class Credit
        {
            #region Base route api

            /// <summary>
            /// Gets base Revenue api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Credit";

            #endregion

            #region TSB Credit Balance - OK

            #region GetTSBCreditBalance

            /// <summary>
            /// Get TSB Credit Balance.
            /// </summary>
            public static class GetTSBCreditBalance
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBCreditBalance";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region TSB Credit Transaction - OK

            #region GetInitialTSBCreditTransaction

            /// <summary>
            /// Get Initial TSB Credit Transaction.
            /// </summary>
            public static class GetInitialTSBCreditTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetInitialTSBCreditTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #region GetReplaceTSBCreditTransaction

            /// <summary>
            /// Get Replace TSB Credit Transaction.
            /// </summary>
            public static class GetReplaceTSBCreditTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetReplaceTSBCreditTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #region SaveTSBCreditTransaction

            /// <summary>
            /// Save TSB Credit Transaction.
            /// </summary>
            public static class SaveTSBCreditTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveTSBCreditTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region User Credit Balance - OK

            #region GetActiveUserCreditBalances

            /// <summary>
            /// Get Active User Credit Balances.
            /// </summary>
            public static class GetActiveUserCreditBalances
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetActiveUserCreditBalances";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #region GetActiveUserCreditBalanceById

            /// <summary>
            /// Get Active User Credit Balance By Id.
            /// </summary>
            public static class GetActiveUserCreditBalanceById
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetActiveUserCreditBalanceById";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #region SaveUserCreditBalance

            /// <summary>
            /// Save User Credi tBalance.
            /// </summary>
            public static class SaveUserCreditBalance
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveUserCreditBalance";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region User Credit Transaction - OK

            #region SaveUserCreditTransaction

            /// <summary>
            /// Save User Credit Transaction.
            /// </summary>
            public static class SaveUserCreditTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveUserCreditTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Credit.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Coupon - OK

        /// <summary>
        /// The Coupon routes class.
        /// </summary>
        public static class Coupon
        {
            #region Base route api

            /// <summary>
            /// Gets base Revenue api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Coupon";

            #endregion

            #region TSB Coupon Balance - OK

            #region Get TSB Coupon Balance

            /// <summary>
            /// Get TSB Coupon Balance.
            /// </summary>
            public static class GetTSBCouponBalance
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBCouponBalance";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region TSB Coupon Summary - OK

            #region GetTSBCouponSummaries

            /// <summary>
            /// Get TSB Coupon Summaries.
            /// </summary>
            public static class GetTSBCouponSummaries
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBCouponSummaries";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region TSB Coupon Transaction - OK

            #region GetTSBCouponTransactions

            /// <summary>
            /// Get TSBCoupon Transactions.
            /// </summary>
            public static class GetTSBCouponTransactions
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBCouponTransactions";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #region SaveTSBCouponTransaction

            /// <summary>
            /// Save TSB Coupon Transaction.
            /// </summary>
            public static class SaveTSBCouponTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveTSBCouponTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #region SaveTSBCouponTransactions

            /// <summary>
            /// Save TSB Coupon Transactions.
            /// </summary>
            public static class SaveTSBCouponTransactions
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveTSBCouponTransactions";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #region SyncTSBCouponTransaction

            /// <summary>
            /// Sync TSB Coupon Transaction.
            /// </summary>
            public static class SyncTSBCouponTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SyncTSBCouponTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #region SyncTSBCouponTransactions

            /// <summary>
            /// Sync TSB Coupon Transactions.
            /// </summary>
            public static class SyncTSBCouponTransactions
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SyncTSBCouponTransactions";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Coupon.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region USer Coupon Transaction - Need Imlements

            #endregion
        }

        #endregion

        #region Exchange - OK

        /// <summary>
        /// The Exchange routes class.
        /// </summary>
        public static class Exchange
        {
            #region Base route api

            /// <summary>
            /// Gets base Revenue api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Exchange";

            #endregion

            #region TSBExchangeGroup - OK

            #region GetRequestApproveTSBExchangeGroups

            /// <summary>
            /// Get Request or Approve TSB Exchange Groups.
            /// </summary>
            public static class GetRequestApproveTSBExchangeGroups
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetRequestApproveTSBExchangeGroups";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Exchange.Url + @"/" + Name;
            }

            #endregion

            #region GetTSBExchangeGroups

            /// <summary>
            /// Get TSB Exchange Groups.
            /// </summary>
            public static class GetTSBExchangeGroups
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetRequestTSBExchangeGroups";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Exchange.Url + @"/" + Name;
            }

            #endregion

            #region SaveTSBExchangeGroup

            /// <summary>
            /// Save TSB Exchange Group.
            /// </summary>
            public static class SaveTSBExchangeGroup
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "SaveTSBExchangeGroup";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Exchange.Url + @"/" + Name;
            }

            #endregion

            #region GetTSBExchangeTransactions

            /// <summary>
            /// Get TSB Exchange Transactions.
            /// </summary>
            public static class GetTSBExchangeTransactions
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBExchangeTransactions";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Exchange.Url + @"/" + Name;
            }

            #endregion

            #region GetTSBExchangeTransaction

            /// <summary>
            /// Get TSB Exchange Transaction.
            /// </summary>
            public static class GetTSBExchangeTransaction
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBExchangeTransaction";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Exchange.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion
    }

    #endregion
}

namespace DMT.v2
{
    #region RouteConsts V2

    /// <summary>
    /// The Route (Local dataase) constants class.
    /// </summary>
    public static class RouteConsts
    {
        #region Base Url

        /// <summary>
        /// Gets base api url.
        /// </summary>
        public const string Url = @"api";

        #endregion

        #region Notify - OK

        /// <summary>
        /// The Notify routes class.
        /// </summary>
        public static class Notify
        {
            #region Base route api

            /// <summary>
            /// Gets base Notify api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Notify";

            #endregion

            #region TSB

            /// <summary>
            /// Gets base Notify TSB api url.
            /// </summary>
            public static class TSB
            {
                #region Base route api

                /// <summary>
                /// Gets base Notify api url.
                /// </summary>
                public const string Url = Notify.Url + @"/Notify";

                #endregion

                #region ActiveChanged - OK

                /// <summary>
                /// Call when active TSB Changed.
                /// </summary>
                public static class ActiveChanged
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "ActiveChanged";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSB.Url + @"/" + Name;
                }

                #endregion

                #region ShiftChanged - OK

                /// <summary>
                /// Call when TSB Shift Changed.
                /// </summary>
                public static class ShiftChanged
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "ShiftChanged";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSB.Url + @"/" + Name;
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Master - OK

        /// <summary>
        /// The Master routes class.
        /// </summary>
        public static class Master
        {
            #region Base route api

            /// <summary>
            /// Gets base Master api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Master";

            #endregion

            #region GetCurrencies - OK

            /// <summary>
            /// Gets all Currencies (master).
            /// </summary>
            public static class GetCurrencies
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrencies";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Master.Url + @"/" + Name;
            }

            #endregion

            #region GetCoupons - OK

            /// <summary>
            /// Gets all Coupons (master).
            /// </summary>
            public static class GetCoupons
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCoupons";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Master.Url + @"/" + Name;
            }

            #endregion
        }

        #endregion

        #region TSB - OK

        /// <summary>
        /// The TSBs routes class.
        /// </summary>
        public static class TSB
        {
            #region Base route api

            /// <summary>
            /// Gets base TSB api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/TSB";

            #endregion

            #region TSBs - OK

            /// <summary>
            /// The TSB's TSBs routes class.
            /// </summary>
            public static class TSBs
            {
                #region Base route api

                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/TSBs";

                #endregion

                #region GetTSBs - OK

                /// <summary>
                /// Gets all TSBs.
                /// </summary>
                public static class GetTSBs
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Gets";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region GetCurrent - OK

                /// <summary>
                /// Gets Current TSB.
                /// </summary>
                public static class GetCurrent
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Current";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region SetActive - OK

                /// <summary>
                /// Set Active TSB.
                /// </summary>
                public static class SetActive
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SetActive";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region SaveTSB - OK

                /// <summary>
                /// Save TSB.
                /// </summary>
                public static class SaveTSB
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Save";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion
            }

            #endregion

            #region PlazaGroups - OK

            /// <summary>
            /// The TSB's PlazaGroups routes class.
            /// </summary>
            public static class PlazaGroups
            {
                #region Base route api

                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/PlazaGroups";

                #endregion

                #region SavePlazaGroup - OK

                /// <summary>
                /// Save PlazaGroup.
                /// </summary>
                public static class SavePlazaGroup
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Save";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = PlazaGroups.Url + @"/" + Name;
                }

                #endregion

                #region Search - OK

                /// <summary>
                /// The PlazaGroups's Search routes class.
                /// </summary>
                public static class Search
                {
                    #region Base route api

                    /// <summary>
                    /// Gets base TSB api url.
                    /// </summary>
                    public const string Url = PlazaGroups.Url + @"/Search";

                    #endregion

                    #region ByTSB - OK

                    /// <summary>
                    /// Search PlazaGroups by TSB.
                    /// </summary>
                    public static class ByTSB
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "TSB";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            #region Plazas - OK

            /// <summary>
            /// The TSB's Plazas routes class.
            /// </summary>
            public static class Plazas
            {
                #region Base route api

                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/Plazas";

                #endregion

                #region SavePlaza - OK

                /// <summary>
                /// Save Plaza.
                /// </summary>
                public static class SavePlaza
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SavePlaza";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = Plazas.Url + @"/" + Name;
                }

                #endregion

                #region Search - OK

                /// <summary>
                /// The PlazaGroups's Search routes class.
                /// </summary>
                public static class Search
                {
                    #region Base route api

                    /// <summary>
                    /// Gets base TSB api url.
                    /// </summary>
                    public const string Url = Plazas.Url + @"/Search";

                    #endregion

                    #region ByPlazaGroup - OK

                    /// <summary>
                    /// Search By PlazaGroup's Plazas.
                    /// </summary>
                    public static class ByPlazaGroup
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "PlazaGroup";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            #region Lanes - OK

            /// <summary>
            /// The TSB's Lanes routes class.
            /// </summary>
            public static class Lanes
            {
                #region Base route api

                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/Lanes";

                #endregion

                #region SaveLane - OK

                /// <summary>
                /// Save Lane.
                /// </summary>
                public static class SaveLane
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SaveLane";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = Lanes.Url + @"/" + Name;
                }

                #endregion

                #region Search - OK

                /// <summary>
                /// The PlazaGroups's Search routes class.
                /// </summary>
                public static class Search
                {
                    #region Base route api

                    /// <summary>
                    /// Gets base TSB api url.
                    /// </summary>
                    public const string Url = Lanes.Url + @"/Search";

                    #endregion

                    #region ByPlazaGroup - OK

                    /// <summary>
                    /// Scarch By Plaza Group.
                    /// </summary>
                    public static class ByPlazaGroup
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "PlazaGroup";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }

            #endregion
        }

        #endregion
    }

    #endregion
}

namespace DMT
{
    #region RouteConsts - base

    /// <summary>
    /// The Route (Local dataase) constants class.
    /// </summary>
    public static partial class RouteConsts 
    {
        /// <summary>
        /// Gets base api url.
        /// </summary>
        public const string Url = @"api";

        #region Notify

        /// <summary>
        /// The Notify routes class.
        /// </summary>
        public static partial class Notify
        {
            /// <summary>
            /// Gets base Notify api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Notify";

            #region TSB

            /// <summary>
            /// The Notify's TSB route.
            /// </summary>
            public static partial class TSB 
            {
                /// <summary>
                /// Gets base Notify api url.
                /// </summary>
                public const string Url = Notify.Url + @"/Notify";
            }

            #endregion
        }

        #endregion

        #region Master

        /// <summary>
        /// The Master routes class.
        /// </summary>
        public static partial class Master
        {
            /// <summary>
            /// Gets base Master api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/Master";
        }

        #endregion

        #region TSB

        /// <summary>
        /// The TSBs routes class.
        /// </summary>
        public static partial class TSB
        {
            /// <summary>
            /// Gets base TSB api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/TSB";

            #region TSBs

            /// <summary>
            /// The TSB's TSBs routes class.
            /// </summary>
            public static partial class TSBs
            {
                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/TSBs";
                /// <summary>
                /// The TSBs's Search routes class.
                /// </summary>
                public static partial class Search
                {
                    /// <summary>
                    /// Gets base Search api url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/Search";
                }
            }

            #endregion

            #region PlazaGroups

            /// <summary>
            /// The TSB's PlazaGroups routes class.
            /// </summary>
            public static partial class PlazaGroups
            {
                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/PlazaGroups";
                /// <summary>
                /// The PlazaGroups's Search routes class.
                /// </summary>
                public static partial class Search
                {
                    /// <summary>
                    /// Gets base Search api url.
                    /// </summary>
                    public const string Url = PlazaGroups.Url + @"/Search";
                }
            }

            #endregion

            #region Plazas

            /// <summary>
            /// The TSB's Plazas routes class.
            /// </summary>
            public static partial class Plazas
            {
                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/Plazas";
                /// <summary>
                /// The Plazas's Search routes class.
                /// </summary>
                public static partial class Search
                {
                    /// <summary>
                    /// Gets base Search api url.
                    /// </summary>
                    public const string Url = Plazas.Url + @"/Search";
                }
            }

            #endregion

            #region Lanes

            /// <summary>
            /// The TSB's Lanes routes class.
            /// </summary>
            public static partial class Lanes
            {
                /// <summary>
                /// Gets base TSB api url.
                /// </summary>
                public const string Url = TSB.Url + @"/Lanes";
                /// <summary>
                /// The Lanes's Search routes class.
                /// </summary>
                public static partial class Search
                {
                    /// <summary>
                    /// Gets base Search api url.
                    /// </summary>
                    public const string Url = Lanes.Url + @"/Search";
                }
            }

            #endregion
        }

        #endregion
    }

    #endregion

    #region Notify

    static partial class RouteConsts
    {
        static partial class Notify
        {
            static partial class TSB
            {
                #region ActiveChanged - OK

                /// <summary>
                /// Call when active TSB Changed.
                /// </summary>
                public static class ActiveChanged
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "ActiveChanged";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSB.Url + @"/" + Name;
                }

                #endregion

                #region ShiftChanged - OK

                /// <summary>
                /// Call when TSB Shift Changed.
                /// </summary>
                public static class ShiftChanged
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "ShiftChanged";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSB.Url + @"/" + Name;
                }

                #endregion
            }
        }
    }

    #endregion

    #region Master

    static partial class RouteConsts
    {
        static partial class Master
        {
            #region GetCurrencies - OK

            /// <summary>
            /// Gets all Currencies (master).
            /// </summary>
            public static class GetCurrencies
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCurrencies";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Master.Url + @"/" + Name;
            }

            #endregion

            #region GetCoupons - OK

            /// <summary>
            /// Gets all Coupons (master).
            /// </summary>
            public static class GetCoupons
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetCoupons";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = Master.Url + @"/" + Name;
            }

            #endregion
        }
    }

    #endregion

    #region TSB - TSBs

    static partial class RouteConsts
    {
        static partial class TSB 
        {
            static partial class TSBs
            {
                #region GetTSBs

                /// <summary>
                /// Gets all TSBs.
                /// </summary>
                public static class GetTSBs
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Gets";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region GetCurrent

                /// <summary>
                /// Gets Current TSB.
                /// </summary>
                public static class GetCurrent
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Current";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region SetActive

                /// <summary>
                /// Set Active TSB.
                /// </summary>
                public static class SetActive
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SetActive";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region SaveTSB

                /// <summary>
                /// Save TSB.
                /// </summary>
                public static class SaveTSB
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Save";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = TSBs.Url + @"/" + Name;
                }

                #endregion

                #region Search(s)

                static partial class Search
                {

                }

                #endregion
            }
        }
    }

    #endregion

    #region TSB - PlazaGroups

    static partial class RouteConsts
    {
        static partial class TSB
        {
            static partial class PlazaGroups
            {
                #region SavePlazaGroup

                /// <summary>
                /// Save PlazaGroup.
                /// </summary>
                public static class SavePlazaGroup
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "Save";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = PlazaGroups.Url + @"/" + Name;
                }

                #endregion

                #region Search(s)

                static partial class Search
                {
                    #region ByTSB

                    /// <summary>
                    /// Search PlazaGroups by TSB.
                    /// </summary>
                    public static class ByTSB
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "TSB";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }
        }
    }

    #endregion

    #region TSB - Plazas

    static partial class RouteConsts
    {
        static partial class TSB 
        {
            static partial class Plazas
            {
                #region SavePlaza

                /// <summary>
                /// Save Plaza.
                /// </summary>
                public static class SavePlaza
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SavePlaza";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = Plazas.Url + @"/" + Name;
                }

                #endregion

                #region Search(s)

                static partial class Search
                {
                    #region ByPlazaGroup

                    /// <summary>
                    /// Search By PlazaGroup's Plazas.
                    /// </summary>
                    public static class ByPlazaGroup
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "PlazaGroup";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }
        }
    }

    #endregion

    #region TSB - Lanes

    static partial class RouteConsts
    {
        static partial class TSB 
        {
            static partial class Lanes
            {
                #region SaveLane

                /// <summary>
                /// Save Lane.
                /// </summary>
                public static class SaveLane
                {
                    /// <summary>
                    /// Gets route name.
                    /// </summary>
                    public const string Name = "SaveLane";
                    /// <summary>
                    /// Gets route url.
                    /// </summary>
                    public const string Url = Lanes.Url + @"/" + Name;
                }

                #endregion

                #region Search(s)

                static partial class Search
                {
                    #region ByPlazaGroup

                    /// <summary>
                    /// Scarch By Plaza Group.
                    /// </summary>
                    public static class ByPlazaGroup
                    {
                        /// <summary>
                        /// Gets route name.
                        /// </summary>
                        public const string Name = "PlazaGroup";
                        /// <summary>
                        /// Gets route url.
                        /// </summary>
                        public const string Url = Search.Url + @"/" + Name;
                    }

                    #endregion
                }

                #endregion
            }
        }
    }

    #endregion
}
