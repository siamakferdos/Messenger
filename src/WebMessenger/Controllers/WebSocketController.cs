using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebMessenger.Sockets;

namespace WebMessenger.Controllers
{
    public class WebSocketController : Controller
    {
        private IWebSocketService _socketService;

        public WebSocketController(IWebSocketService socketService)
        {
            _socketService = socketService;
        }

        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                await _socketService.ConnectWebSocket(HttpContext, Guid.NewGuid().ToString());
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
