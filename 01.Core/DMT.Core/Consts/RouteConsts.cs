using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DMT
{
    #region RouteConsts (base)

    /// <summary>
    /// The Rest api routes constants class.
    /// </summary>
    public static partial class RouteConsts
    {
        /// <summary>
        /// Gets base api url.
        /// </summary>
        public const string Url = @"api";
    }

    #endregion

    #region RouteConsts (Client)

    static partial class RouteConsts
    {
        /// <summary>The Client Controller.</summary>
        public static class Client
        {
            /// <summary>Gets controller name.</summary>
            public const string ControllerName = "Client";
            /// <summary>Gets base controller url.</summary>
            public const string Url = RouteConsts.Url + @"/" + ControllerName;

            /// <summary>The Register (TA/TOD) action.</summary>
            public static class Register
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "Register";
                /// <summary>Gets route url.</summary>
                public const string Url = Client.Url + @"/" + Name;
            }
            /// <summary>The Unregister (TA/TOD) action.</summary>
            public static class Unregister
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "Unregister";
                /// <summary>Gets route url.</summary>
                public const string Url = Client.Url + @"/" + Name;
            }
        }
    }

    #endregion

    #region RouteConsts (Notify)

    static partial class RouteConsts
    {
        /// <summary>The Notify Controller.</summary>
        public static class Notify
        {
            /// <summary>Gets controller name.</summary>
            public const string ControllerName = "Notify";
            /// <summary>Gets base controller url.</summary>
            public const string Url = RouteConsts.Url + @"/" + ControllerName;

            /// <summary>The TSBChanged action.</summary>
            public static class TSBChanged
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "TSBChanged";
                /// <summary>Gets route url.</summary>
                public const string Url = Notify.Url + @"/" + Name;
            }
            /// <summary>The ShiftChanged action.</summary>
            public static class ShiftChanged
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "ShiftChanged";
                /// <summary>Gets route url.</summary>
                public const string Url = Notify.Url + @"/" + Name;
            }
        }
    }

    #endregion
}