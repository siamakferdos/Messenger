using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WebMessenger.Config;

namespace WebMessenger.MessageBroker
{
    internal class BrokerProducer : IDisposable
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        private static BrokerProducer _producer;

        private BrokerProducer()
        {
            CreateChannel();   
        }

        public static BrokerProducer GetProducer()
        {
            if(_producer == null)
            {
                _producer = new BrokerProducer();
            }
            return _producer;
        }

        private void CreateChannel()
        {

            _factory = new ConnectionFactory() { HostName = BrokerConfig.HostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: BrokerConfig.Exchange, type: ExchangeType.Direct);

            _channel.QueueDeclare(queue: BrokerConfig.QueueName,
                                    durable: true,
                                    exclusive: true,
                                    autoDelete: true,
                                    arguments: null);

            _channel.QueueBind(queue: BrokerConfig.QueueName,
                              exchange: BrokerConfig.Exchange,
                              routingKey: BrokerConfig.RoutingKey);
        }

        internal void ReceiveMessage(string message)
        {
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += (ModuleHandle, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"************* SIA! You have a message. I got it as 1st consumer: {message}");
            };

            _channel.BasicConsume(BrokerConfig.QueueName, autoAck: true, consumer: _consumer);


        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Dispose();
        }
    }
}
