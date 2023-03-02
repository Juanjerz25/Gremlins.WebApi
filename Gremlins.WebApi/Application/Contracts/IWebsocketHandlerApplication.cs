using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Gremlins.WebApi.Application.Contracts
{
    public interface IWebsocketHandlerApplication
    {
        Task Handle(string id, WebSocket webSocket);
    }
}
