namespace DMT
{
    // Url : api/credit/tsb/gets
    static partial class RouteConsts
    {
        static partial class Credit
        {
            static partial class TSB
            {
                /// <summary>The Gets TSB Credit Balance(s) action.</summary>
                public static class Gets
                {
                    /// <summary>Gets route name.</summary>
                    public const string Name = "Gets";
                    /// <summary>Gets route url.</summary>
                    public const string Url = TSB.Url + @"/" + Name;
                }
            }
        }
    }
}
