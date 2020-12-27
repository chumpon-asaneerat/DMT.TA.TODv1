#region Using

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Timers;
using System.Threading.Tasks;

using NLib;
using NLib.IO;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The Rabbit MQ Service class.
    /// </summary>
    public class RabbitMQService : JsonMessageTransferService
    {
        #region Singelton

        private static RabbitMQService _instance = null;
        /// <summary>
        /// Singelton Access.
        /// </summary>
        public static RabbitMQService Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (typeof(RabbitMQService))
                    {
                        _instance = new RabbitMQService();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Internal Variables

        private RabbitMQClient rabbitClient = null;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private RabbitMQService() : base() { }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~RabbitMQService()
        {
            Shutdown();
        }

        #endregion

        #region Override Methods and Properties

        /// <summary>
        /// Gets Folder Name (sub directory name).
        /// </summary>
        protected override string FolderName { get { return "rabbit.mq.msgs"; } }
        /// <summary>
        /// Process Json (string).
        /// </summary>
        /// <param name="jsonString">The json data in string.</param>
        protected override void ProcessJson(string jsonString)
        {

        }
        /// <summary>
        /// OnStart.
        /// </summary>
        protected override void OnStart() 
        { 
        }
        /// <summary>
        /// OnShutdown.
        /// </summary>
        protected override void OnShutdown() 
        { 
        }

        #endregion
    }
}
