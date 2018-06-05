using Microsoft.AspNetCore.SignalR;

namespace SignalRWeb.Hubs
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public NotifyHub()
        {

        }


    }
}
