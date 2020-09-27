using System;
using System.Collections.Generic;

namespace DMT
{
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

            #region MCurrency - OK

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

            #region MCoupon - OK

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
        /// The TSB routes class.
        /// </summary>
        public static class TSB
        {
            #region Base route api

            /// <summary>
            /// Gets base TSB api url.
            /// </summary>
            public const string Url = RouteConsts.Url + @"/TSB";

            #endregion

            #region TSB - OK

            #region GetTSBs - OK

            /// <summary>
            /// Gets all TSBs.
            /// </summary>
            public static class GetTSBs
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBs";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
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
                public const string Name = "GetCurrent";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
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
                public const string Url = TSB.Url + @"/" + Name;
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
                public const string Name = "SaveTSB";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region PlazaGroup - OK

            #region GetTSBPlazaGroups - OK

            /// <summary>
            /// Gets PlazaGroups by TSB.
            /// </summary>
            public static class GetTSBPlazaGroups
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetTSBPlazaGroups";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

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
                public const string Name = "SavePlazaGroup";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region Plaza - OK

            #region GetPlazaGroupPlazas - OK

            /// <summary>
            /// Get PlazaGroup's Plazas.
            /// </summary>
            public static class GetPlazaGroupPlazas
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPlazaGroupPlazas";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

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
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion

            #endregion

            #region Lane - OK

            #region GetPlazaGroupLanes - OK

            /// <summary>
            /// Gets Plaza Group's Lanes.
            /// </summary>
            public static class GetPlazaGroupLanes
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPlazaGroupLanes";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion

            #region GetPlazaGroupLanes - OK

            /// <summary>
            /// Gets Plaza's Lanes.
            /// </summary>
            public static class GetPlazaLanes
            {
                /// <summary>
                /// Gets route name.
                /// </summary>
                public const string Name = "GetPlazaLanes";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

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
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion

            #endregion
        }

        #endregion

        #region User

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

            #region Role

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

            #region

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

            #region User

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

        #region Shift

        #endregion

        #region Lane Attendance/Payment

        #endregion

        #region Revenue

        #endregion

        #region Credit

        #endregion

        #region Coupon

        #endregion

        #region Exchange

        #endregion
    }
}
