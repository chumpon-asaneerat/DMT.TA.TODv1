namespace DMT
{
    // Url : api/credit/user/gets
    static partial class RouteConsts
    {
        static partial class Credit
        {
            static partial class User
            {
                /// <summary>The Gets User Credit Balance(s) action.</summary>
                public static class Gets
                {
                    /// <summary>Gets route name.</summary>
                    public const string Name = "Gets";
                    /// <summary>Gets route url.</summary>
                    public const string Url = User.Url + @"/" + Name;
                }
            }
        }
    }
}
