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

        #region Private Methods

        #region RabbitClient Message Handler

        private void RabbitClient_OnMessageArrived(object sender, QueueMessageEventArgs e)
        {
            if (null == e) return;
            // Save message.
            string fileName = "msg." + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.ffffff",
                System.Globalization.DateTimeFormatInfo.InvariantInfo);
            WriteFile(fileName, e.Message);
        }

        #endregion

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
            MethodBase med = MethodBase.GetCurrentMethod();

            // Init Rabbit Client
            if (null == rabbitClient)
            {
                var MQConfig = (null != PlazaServiceConfigManager.Instance.RabbitMQ) ?
                    PlazaServiceConfigManager.Instance.RabbitMQ : null;
                if (null != MQConfig && MQConfig.Enabled)
                {
                    //WriteTAFile("init");
                    med.Info("Rabbit Host Info: " + MQConfig.GetString());
                    try
                    {
                        rabbitClient = new RabbitMQClient();
                        rabbitClient.HostName = MQConfig.HostName;
                        rabbitClient.PortNumber = MQConfig.PortNumber;
                        rabbitClient.VirtualHost = MQConfig.VirtualHost;
                        rabbitClient.UserName = MQConfig.UserName;
                        rabbitClient.Password = MQConfig.Password;
                        rabbitClient.OnMessageArrived += RabbitClient_OnMessageArrived;
                        if (rabbitClient.Connect() && rabbitClient.Listen(MQConfig.QueueName))
                        {
                            med.Info("Success connected to : " + MQConfig.GetString());
                            med.Info("Listen to Queue: " + MQConfig.QueueName);
                        }
                        else
                        {
                            med.Err("failed connected to : " + MQConfig.HostName);
                        }

                    }
                    catch (Exception ex)
                    {
                        med.Err(ex);
                    }
                }
            }
        }
        /// <summary>
        /// OnShutdown.
        /// </summary>
        protected override void OnShutdown() 
        {
            // Free Rabbit Client
            try
            {
                if (null != rabbitClient)
                {
                    rabbitClient.OnMessageArrived -= RabbitClient_OnMessageArrived;
                    rabbitClient.Disconnect();

                }
            }
            catch { }
            rabbitClient = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Checks is Rabbit MQ Connected.
        /// </summary>
        public bool Connected
        {
            get { return (null != rabbitClient && rabbitClient.Connected); }
        }

        #endregion
    }
}
