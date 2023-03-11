using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace WebMessenger.Sockets
{
    public class WebSocketService: IWebSocketService
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

        public async Task ConnectWebSocket(HttpContext context, string socketId)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = 400;
                return;
            }

            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            _sockets.TryAdd(socketId, webSocket);

            await ReceiveWebSocketMessagesAsync(webSocket, socketId);
        }

        public async Task SendMessage(string socketId, string message)
        {
            if (_sockets.TryGetValue(socketId, out var webSocket))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task ReceiveWebSocketMessagesAsync(WebSocket webSocket, string socketId)
        {
            var buffer = new byte[1024 * 4];
            var message = new StringBuilder();

            while (webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _sockets.TryRemove(socketId, out _);
                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                }

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    message.Append(Encoding.UTF8.GetString(buffer, 0, result.Count)); 
                    if (result.EndOfMessage) 
                    {
                        var receivedMessage = message.ToString(); // convert the message builder to a string
                        message.Clear(); 
                        
                        WebSocketReciever.HandleNewMessageReceived(receivedMessage);
                    }
                }
            }
        }
    }

}
