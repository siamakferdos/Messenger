using WebMessenger.MessageBroker;

namespace WebMessenger.Sockets
{
    public class WebSocketReciever
    {
        public static void HandleNewMessageReceived(string message)
        {
           Console.WriteLine(message);
            //BrokerProducer.GetProducer().ReceiveMessage(message);
        }
    }
}
