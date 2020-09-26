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

        #region TSB (Infrastructures)

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

            #region GetCurrent

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
                public const string Url = TSB.Url + @"/" + Name;
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
                public const string Name = "SaveTSB";
                /// <summary>
                /// Gets route url.
                /// </summary>
                public const string Url = TSB.Url + @"/" + Name;
            }

            #endregion
        }

        #endregion
    }
}
