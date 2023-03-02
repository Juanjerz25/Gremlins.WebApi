using System.Net.WebSockets;

namespace Gremlins.WebApi.DTO.Websocket
{
    public class SocketConnection
    {
        public string Action { get; set; }
        public WebSocket WebSocket { get; set; }
    }
}
