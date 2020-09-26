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

            #region Plaza

            #endregion

            #region Lane

            #endregion
        }

        #endregion
    }
}
