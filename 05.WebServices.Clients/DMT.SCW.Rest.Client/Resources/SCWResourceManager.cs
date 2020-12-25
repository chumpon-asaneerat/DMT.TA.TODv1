#region Using

using System;
using System.IO;
using System.Reflection;
using NLib;

#endregion

namespace DMT.Services
{
    public class SCWResourceManager
    {
        #region Resouce Related Methods and Properties

        private static Assembly Current { get { return typeof(SCWResourceManager).Assembly; } }

        /// <summary>
        /// Gets View SQL Script (from embedded resource).
        /// </summary>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>Returns load view sql script.</returns>
        public static string GetScript(string resourceName)
        {
            MethodBase med = MethodBase.GetCurrentMethod();
            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(resourceName))
            {
                try
                {
                    using (Stream stream = Current.GetManifestResourceStream(resourceName))
                    {
                        if (null != stream)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                if (null != reader)
                                {
                                    ret = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    med.Err(ex);
                    ret = string.Empty;
                }
            }
            return ret;
        }
        /// <summary>
        /// Gets Json Resource Path.
        /// </summary>
        public static string JsonResourcePath { get { return "DMT.Resources.Json"; } }

        private static string GetEmbeddedResourceName(string resourceName)
        {
            return JsonResourcePath + "." + resourceName + ".json";
        }

        private static string GetJson(string resourceName)
        {
            string script = string.Empty;
            MethodBase med = MethodBase.GetCurrentMethod();
            try
            {
                string embededResourceName = GetEmbeddedResourceName(resourceName);
                script = GetScript(embededResourceName);
            }
            catch (Exception ex)
            {
                med.Err(ex);
                script = string.Empty;
            }
            return script;
        }

        #endregion

        #region public properties (static)

        /// <summary>
        /// Gets loginAudit parameter json script.
        /// </summary>
        public static string loginAudit { get { return GetJson("loginAudit"); } }

        #endregion
    }
}
