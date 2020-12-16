#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using RestSharp;
using NLib.ServiceProcess;

using DMT.Models;
using System.Runtime.InteropServices;
using System.Security.Permissions;

#endregion

namespace DMT.Services
{
    public static partial class RestAPI
    {
        public static partial class Plaza { }
        public static partial class SCW { }
        public static partial class TAxTOD { }
        public static partial class TAApp { }
        public static partial class TODApp { }
    }

    static partial class RestAPI
    {
        static partial class Plaza 
        {
            public static void Omega() { }
        }
    }

    public class XXX
    {
        public void Test()
        {
            RestAPI.Plaza.Omega();
        }
    }
}
