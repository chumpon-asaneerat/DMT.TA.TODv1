namespace DMT
{
    // Url: api/infrastructure
    static partial class RouteConsts
    {
        /// <summary>The Infrastructure Controller.</summary>
        public static partial class Infrastructure
        {
            /// <summary>Gets controller name.</summary>
            public const string ControllerName = "Infrastructure";
            /// <summary>Gets base controller url.</summary>
            public const string Url = RouteConsts.Url + @"/" + ControllerName;

            // Url : api/infrastructure/tsb
            /// <summary>The Infrastructure's TSB class.</summary>
            public static partial class TSB 
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "TSB";
                /// <summary>Gets route url.</summary>
                public const string Url = Infrastructure.Url + @"/" + Name;
            }

            // Url : api/infrastructure/plazagroup
            /// <summary>The Infrastructure's PlazaGroup class.</summary>
            public static partial class PlazaGroup 
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "PlazaGroup";
                /// <summary>Gets route url.</summary>
                public const string Url = Infrastructure.Url + @"/" + Name;
            }

            // Url : api/infrastructure/plaza
            /// <summary>The Infrastructure's Plaza class.</summary>
            public static partial class Plaza 
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "Plaza";
                /// <summary>Gets route url.</summary>
                public const string Url = Infrastructure.Url + @"/" + Name;
            }

            // Url : api/infrastructure/lane
            /// <summary>The Infrastructure's Lane class.</summary>
            public static partial class Lane 
            {
                /// <summary>Gets route name.</summary>
                public const string Name = "Lane";
                /// <summary>Gets route url.</summary>
                public const string Url = Infrastructure.Url + @"/" + Name;
            }
        }
    }
}
