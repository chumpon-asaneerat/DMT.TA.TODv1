﻿#region Using

using System;

#endregion

namespace DMT
{
    public static class AppConsts
    {
        // common properties
        public static string Version = "1";
        public static string Minor = "1";
        public static string Build = "1930";
        public static DateTime LastUpdate = new DateTime(2020, 11, 14, 21, 25, 00);

        public static class Application
        {
            public static class TA
            {
                public static string ApplicationName = @"DMT Toll Admin Application";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }

            public static class TOD
            {
                public static string ApplicationName = @"DMT Toll of Duty Application";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }
            /*
            public static class Account
            {
                public static string ApplicationName = @"DMT Toll Account Application";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }
            */
            public static class PlazaConfig
            {
                public static string ApplicationName = @"DMT TOD-TA Plaza Config";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }

            public static class PlazaSumulator
            {
                public static string ApplicationName = @"DMT TOD-TA Plaza Simulator";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }
            /*
            public static class DataCenter
            {
                public static string ApplicationName = @"DMT Data Center Workbench";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }
            */
        }

        public static class WindowsService
        {
            public static class Local
            {
                public static string ServiceName = "DMT Local REST API Service";
                public static string DisplayName = "DMT Local REST API Service";
                public static string Description = "DMT Local REST API Service";
                public static string ExecutableFileName = @"DMT.Local.Web.Services.exe";
                // common
                public static string Version = AppConsts.Version;
                public static string Minor = AppConsts.Minor;
                public static string Build = AppConsts.Build;
                public static DateTime LastUpdate = AppConsts.LastUpdate;
            }
        }
    }
}
