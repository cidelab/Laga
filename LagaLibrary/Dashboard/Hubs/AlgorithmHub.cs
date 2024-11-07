
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Dashboard.Hubs
{
    public class AlgorithmHub : Hub
    {
        public async Task BroadcastUpdate(string data)
        {
            await Clients.All.SendAsync("ReceiveUpdate", data);
        }
    }
}
