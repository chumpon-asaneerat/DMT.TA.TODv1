#region Usings

using System;
using DMT.Models;

#endregion

namespace DMT.Services.Operations
{
    /// <summary>
    /// The Plaza Operation class.
    /// </summary>
    public static partial class Plaza
    {
        #region Static Methods

        public static NRestResult Execute(string url)
        {
            NRestResult ret;
            NRestClient client = NRestClient.CreateLocalClient(Config);
            if (null == client)
            {
                ret = new NRestResult();
                ret.RestInvalidConfig();
                return ret;
            }
            ret = client.Execute(url, new { }, Timeout, UserName, Password);
            return ret;

        }

        public static NRestResult Execute<TValue>(string url, TValue value)
            where TValue : new()
        {
            NRestResult ret;
            NRestClient client = NRestClient.CreateLocalClient(Config);
            if (null == client)
            {
                ret = new NRestResult();
                ret.RestInvalidConfig();
                return ret;
            }

            if (null != value)
            {
                ret = client.Execute(url, value, Timeout, UserName, Password);
            }
            else
            {
                ret = new NRestResult();
                ret.ParameterIsNull();
            }
            return ret;

        }

        public static NRestResult<TResult> Execute<TResult>(string url)
            where TResult : new()
        {
            NRestResult<TResult> ret;
            NRestClient client = NRestClient.CreateLocalClient(Config);
            if (null == client)
            {
                ret = new NRestResult<TResult>();
                ret.RestInvalidConfig();
                return ret;
            }

            ret = client.Execute<TResult>(url, new { }, Timeout, UserName, Password);
            return ret;

        }

        public static NRestResult<TResult> Execute<TResult, TValue>(string url, TValue value)
            where TResult: new()
        {
            NRestResult<TResult> ret;
            NRestClient client = NRestClient.CreateLocalClient(Config);
            if (null == client)
            {
                ret = new NRestResult<TResult>();
                ret.RestInvalidConfig();
                return ret;
            }

            if (null != value)
            {
                ret = client.Execute<TResult>(url, value, Timeout, UserName, Password);
            }
            else
            {
                ret = new NRestResult<TResult>();
                ret.ParameterIsNull();
            }
            return ret;

        }

        public static NRestResult<TResult, TOut> Execute<TResult, TOut, TValue>(string url, TValue value)
            where TResult : new()
            where TOut : new ()
        {
            NRestResult<TResult, TOut> ret;
            NRestClient client = NRestClient.CreateLocalClient(Config);
            if (null == client)
            {
                ret = new NRestResult<TResult, TOut>();
                ret.RestInvalidConfig();
                return ret;
            }

            if (null != value)
            {
                ret = client.Execute<TResult, TOut>(url, value, Timeout, UserName, Password);
            }
            else
            {
                ret = new NRestResult<TResult, TOut>();
                ret.ParameterIsNull();
            }
            return ret;

        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets or sets service config.
        /// </summary>
        public static IPlazaConfig Config { get; set; }
        /// <summary>
        /// Gets Base Address.
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.Plaza) return string.Empty;
                if (null == Config.Plaza.Service) return string.Empty;

                return string.Format(@"{0}://{1}:{2}/",
                    Config.Plaza.Service.Protocol,
                    Config.Plaza.Service.HostName,
                    Config.Plaza.Service.PortNumber);
            }
        }
        /// <summary>
        /// Gets default execute timeout.
        /// </summary>
        public static int Timeout { get { return 1000; } }
        /// <summary>
        /// Gets user name.
        /// </summary>
        public static string UserName
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.Plaza) return string.Empty;
                if (null == Config.Plaza.Service) return string.Empty;

                return Config.Plaza.Service.UserName;
            }
        }
        /// <summary>
        /// Gets password.
        /// </summary>
        public static string Password 
        {
            get
            {
                if (null == Config) return string.Empty;
                if (null == Config.Plaza) return string.Empty;
                if (null == Config.Plaza.Service) return string.Empty;

                return Config.Plaza.Service.Password;
            }
        }

        #endregion
    }

    static partial class Plaza
    {
        public static partial class Infrastructure
        {
            public static partial class TSB
            {
                public static NRestResult<Models.TSB> GetCurrent()
                {
                    var ret = Execute<Models.TSB>(RouteConsts.Infrastructure.TSB.Current.Url);
                    return ret;
                }
            }
        }
    }
}
