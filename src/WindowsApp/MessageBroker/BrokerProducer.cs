using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WindowsApp.Config;

namespace WindowsApp.MessageBroker
{
    internal class BrokerProducer : IDisposable
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

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

        internal void SendMessage(string message)
        {
            var payload = new BrokerPayload(message);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));

            _channel.BasicPublish(exchange: BrokerConfig.Exchange,
                                 routingKey: BrokerConfig.RoutingKey,
                                 basicProperties: null,
                                 body: body);


        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Dispose();
        }
    }
}
