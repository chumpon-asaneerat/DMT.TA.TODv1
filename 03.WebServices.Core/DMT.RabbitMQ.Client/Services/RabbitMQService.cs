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
        /// <param name="fullFileName">The json full file name.</param>
        /// <param name="jsonString">The json data in string.</param>
        protected override void ProcessJson(string fullFileName, string jsonString)
        {
            MethodBase med = MethodBase.GetCurrentMethod();

            // Extract Header.
            var msg = jsonString.FromJson<Models.RabbitMQMessage>();
            if (null != msg)
            {
                if (msg.parameterName == "STAFF")
                {
                    // Update To Local Database.
                    var mq = jsonString.FromJson<Models.RabbitMQStaffMessage>();
                    if (null != mq)
                    {
                        //TODO: Rabbit ToLocal Need to check PasswordDate?.
                        var staffs = Models.RabbitMQStaff.ToLocals(mq.staff);
                        if (null != staffs && staffs.Count > 0)
                        {
                            Task.Run(() =>
                            {
                                // TODO: Check can save when direct access to database here.
                                Models.User.SaveUsers(staffs);
                            });
                        }
                        // process success backup file.
                        MoveToBackup(fullFileName);
                    }
                    else
                    {
                        // process success error file.
                        med.Info("Cannot convert to STAFF message.");
                        MoveToError(fullFileName);
                    }
                }
                else
                {
                    // process not staff list so Not Supports file.
                    med.Info("message is not STAFF message.");
                    MoveToNotSupports(fullFileName);
                }
            }
            else
            {
                // process success error file.
                med.Info("message is null or cannot convert to json object.");
                MoveToError(fullFileName);
            }
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
