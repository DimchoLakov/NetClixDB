using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NetPhlixDB.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
