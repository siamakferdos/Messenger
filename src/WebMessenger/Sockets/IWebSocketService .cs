using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace WebMessenger.Sockets
{
    public interface IWebSocketService
    {
        public Task ConnectWebSocket(HttpContext context, string id);

        public Task SendMessage(string id, string message);
        
    }

}
