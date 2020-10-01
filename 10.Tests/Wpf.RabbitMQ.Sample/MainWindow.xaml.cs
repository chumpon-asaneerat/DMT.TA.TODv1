#region Using

using System;
using System.Text;
using System.Windows;

// RabbitMQ
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

#endregion

namespace Wpf.RabbitMQ.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        private RabbitMQClient client = null;

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            DisconnectRabbitMQ();
        }

        #endregion

        #region Private Methods

        private void ConnectRabbitMQ()
        {
            if (null != client) return; // already exists.
            client = new RabbitMQClient();
            if (client.Connect())
            {
                // hook events.
                client.OnMessageArrived += Client_OnMessageArrived;
                // qm.parameters.th03x991.taa01
                // qm.parameters.th03x991.tod01
                // qm.parameters.th03x991.tod02
                // qm.parameters.th03x991.lcc02 (Test OK).
                client.Listen("qm.parameters.th03x991.lcc02");
            }
        }

        private void DisconnectRabbitMQ()
        {
            if (null != client)
            {
                if (client.IsConnected)
                {
                    // unhook events.
                    client.OnMessageArrived -= Client_OnMessageArrived;
                }
                client.Disconnect();
            }
            client = null;
        }

        #endregion

        #region Button Handlers

        private void cmdConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectRabbitMQ();
        }

        private void cmdDisconnect_Click(object sender, RoutedEventArgs e)
        {
            DisconnectRabbitMQ();
        }

        #endregion

        #region RabbitMQClient Handlers

        private void Client_OnMessageArrived(object sender, QueueMessageEventArgs e)
        {
            Action action = () =>
            {
                var msg = e.Message;
                txtMessages.AppendText(msg + Environment.NewLine);
            };

            var dispatcher = txtMessages.Dispatcher;
            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action);
        }

        #endregion
    }

    public delegate void QueueMessageEventHandler(object sender, QueueMessageEventArgs e);

    public class QueueMessageEventArgs
    {
        public string Message { get; set; }
    }

    public class RabbitMQClient
    {
        private ConnectionFactory _factory = null;
        private IConnection _connection = null;
        private IModel _channel = null;
        private EventingBasicConsumer _consumer = null;

        public RabbitMQClient() : base()
        {
            // Factory (Moc)
            this.HostName = "evthai.info";
            this.UserName = "guest";
            this.Password = "dmtDmt@2020";

            CreateFactory();
        }
        ~RabbitMQClient()
        {
            CloseFactory();
        }

        #region Private Methods

        #region Factory

        private void CreateFactory()
        {
            if (null != this._factory) return;
            this._factory = new ConnectionFactory()
            {
                HostName = this.HostName,
                UserName = this.UserName,
                Password = this.Password,
                // VirtualHost Note:
                // "/" -> default
                // "cbe" -> required on production!!!!
                VirtualHost = (!string.IsNullOrWhiteSpace(this.VirtualHost)) ? this.VirtualHost : "/",
                RequestedConnectionTimeout = TimeSpan.FromSeconds(1)
            };
        }

        private void CloseFactory()
        {
            this.Disconnect(); // free channel and connection.
            if (null != this._factory)
            {
                // No close or dispose method.
            }
            this._factory = null;
        }

        #endregion

        #endregion Public Methods

        #region Connect/Disconnect

        /// <summary>
        /// Connect
        /// </summary>
        /// <returns>Returns true if successfully connectd to RabbitMQ.</returns>
        public bool Connect()
        {
            try
            {
                this._connection = (null != this._factory) ? this._factory.CreateConnection() : null;
                this._channel = (null != this._connection) ? this._connection.CreateModel() : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Disconnect(); // free channel and connection.
                return false;
            }
            return (null != this._channel);
        }
        /// <summary>
        /// Disconnect.
        /// </summary>
        public void Disconnect()
        {
            #region Consumer

            if (null != this._consumer)
            {
                // No close or dispose method.
            }
            this._consumer = null;

            #endregion

            #region Close and Dispose channel

            if (null != this._channel)
            {
                try
                {
                    this._channel.Close();
                    this._channel.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this._channel = null;

            #endregion

            #region Close and Dispose Connection

            if (null != this._connection)
            {
                try
                {
                    this._connection.Close();
                    this._connection.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this._connection = null;

            #endregion
        }

        public bool Listen(string queueName)
        {
            if (null == this._channel)
            {
                if (!this.Connect())
                {
                    return false;
                }
            }

            this._channel.BasicQos(0, 1, false);
            var messageReceiver = new MessageReceiver(this._channel);
            this._channel.BasicConsume(queueName, false, messageReceiver);
            messageReceiver.rabbitMQRecvMessage += MessageReceiverOnRabbitMqRecvMessage;

            #region Test code - not work
            /*
            // Declare a queue.
            this._channel.QueueDeclare(
                queue: queueName,
                durable: false, 
                exclusive: false, 
                autoDelete: false,
                arguments: null);
            // Create basic consumer.
            this._consumer = new EventingBasicConsumer(this._channel);
            if (null == this._consumer)
            {
                return false;
            }
            // Init Received Handler before start consume message.
            this._consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                
                if (null != OnMessageArrived) OnMessageArrived(this,
                    new QueueMessageEventArgs() { Message = message });
            };
            // Start Consume message.
            this._channel.BasicConsume(
                queue: queueName,
                autoAck: true,
                consumer: this._consumer);
            */
            #endregion

            return true;
        }

        private void MessageReceiverOnRabbitMqRecvMessage(string szMessage)
        {
            if (null != OnMessageArrived) OnMessageArrived(this,
                new QueueMessageEventArgs() { Message = szMessage });
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Host Name or IP Address.
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Gets or sets Virtual Host Name (default is '/').
        /// </summary>
        public string VirtualHost { get; set; }
        /// <summary>
        /// Gets or sets User Name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Checks is connected.
        /// </summary>
        public bool IsConnected { get { return (null != this._channel && null != this._connection); } }

        #endregion

        #region Public Events

        /// <summary>
        /// OnMessageArrived event.
        /// </summary>
        public event QueueMessageEventHandler OnMessageArrived;

        #endregion
    }

    public class MessageReceiver : DefaultBasicConsumer
    {
        public delegate void RabbitMQReceiceMessage(string szMessage);
        public event RabbitMQReceiceMessage rabbitMQRecvMessage;

        private readonly IModel _channel;
        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered,
            string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            _channel.BasicAck(deliveryTag, false);
            rabbitMQRecvMessage(Encoding.UTF8.GetString(body.ToArray()));

            base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
        }
    }
}

// This message returns from Queues

/*

{
  "parameterName": "PLAZA_CONFIGURATION",
  "timestamp": "2020-08-19T08:53:20.658",
  "version": 1,
  "plaza": [{
    "id": 1,
    "abbrevation": "DD1",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 2,
    "abbrevation": "DD2",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 3,
    "abbrevation": "ST",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 4,
    "abbrevation": "LPI",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 5,
    "abbrevation": "LPO",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 6,
    "abbrevation": "RP1",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 7,
    "abbrevation": "RP2",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 8,
    "abbrevation": "BK",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 9,
    "abbrevation": "CW1",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 10,
    "abbrevation": "CW2",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 11,
    "abbrevation": "LKI",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 12,
    "abbrevation": "LKO",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 13,
    "abbrevation": "DM1",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 14,
    "abbrevation": "DM2",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 15,
    "abbrevation": "AN1",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 16,
    "abbrevation": "AN2",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 99,
    "abbrevation": "DMT-HQ",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 991,
    "abbrevation": "QfreeLab",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }, {
    "id": 992,
    "abbrevation": "QFDMTSite",
    "excessiveJourney": 0,
    "longJourney": 0,
    "shortJourney": 0,
    "minAllowableBalance": 0,
    "lane": []
  }]
}



{
  "parameterName": "STAFF",
  "timestamp": "2020-09-22T05:41:00.296",
  "version": 1,
  "staff": [{
    "staffId": "00011",
    "staffFamilyName": "Teste",
    "staffFirstName": "Wuttichai",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00012",
    "staffFamilyName": "pasuk",
    "staffFirstName": "wutt",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 20,
    "cardSerialNo": ""
  }, {
    "staffId": "00110",
    "staffFamilyName": "pasuk",
    "staffFirstName": "wutt",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 49,
    "cardSerialNo": ""
  }, {
    "staffId": "00111",
    "staffFamilyName": "NoName",
    "staffFirstName": "killer",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00112",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00113",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00114",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00115",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00116",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00222",
    "staffFamilyName": "mikiee",
    "staffFirstName": "mike",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00293",
    "staffFamilyName": "test",
    "staffFirstName": "yahh",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00333",
    "staffFamilyName": "Punk3",
    "staffFirstName": "fff",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "004345",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00444",
    "staffFamilyName": "Test",
    "staffFirstName": "CTC",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 40,
    "cardSerialNo": ""
  }, {
    "staffId": "00555",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00666",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 40,
    "cardSerialNo": ""
  }, {
    "staffId": "00777",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "00888",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 30,
    "cardSerialNo": ""
  }, {
    "staffId": "00987",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 60,
    "cardSerialNo": ""
  }, {
    "staffId": "00999",
    "staffFamilyName": "sulong",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "01010",
    "staffFamilyName": "ddd",
    "staffFirstName": "az",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "96e79218965eb72c92a549dd5a330112",
    "group": 20,
    "cardSerialNo": ""
  }, {
    "staffId": "012345",
    "staffFamilyName": "sulong",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 51,
    "cardSerialNo": ""
  }, {
    "staffId": "01523",
    "staffFamilyName": "Test",
    "staffFirstName": "TC2",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "015234",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "01586 ",
    "staffFamilyName": "Test",
    "staffFirstName": "TC1",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 20,
    "cardSerialNo": ""
  }, {
    "staffId": "05994",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "09493",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "09596",
    "staffFamilyName": "sulongsss",
    "staffFirstName": "basree",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "09993",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "101010",
    "staffFamilyName": "Punk",
    "staffFirstName": "Aten",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "101011",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "101030",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "101031",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "202020",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "202025",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "202026",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "202027",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "202028",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "24356",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "24357",
    "staffFamilyName": "jang",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "303030",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "3030308",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "303031",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "303032",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "595959",
    "staffFamilyName": "Punk",
    "staffFirstName": "Aten",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "696969",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "88888",
    "staffFamilyName": "Punk",
    "staffFirstName": "Aten",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "909090",
    "staffFamilyName": "jang",
    "staffFirstName": "jang",
    "staffMiddleName": "",
    "title": "Mrs.",
    "password": "d92db81c5b5bbd6d68911d01a8d15e91",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "987456",
    "staffFamilyName": "killer1115",
    "staffFirstName": "killer1115",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "2173919d7674801af25d5cb5a130f9c3",
    "group": 10,
    "cardSerialNo": ""
  }, {
    "staffId": "9999",
    "staffFamilyName": "Punk",
    "staffFirstName": "Aten",
    "staffMiddleName": "",
    "title": "Mr.",
    "password": "e10adc3949ba59abbe56e057f20f883e",
    "group": 10,
    "cardSerialNo": ""
  }]
}

*/
