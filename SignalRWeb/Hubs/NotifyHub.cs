using Microsoft.AspNetCore.SignalR;

namespace SignalRWeb.Hubs
{
    public class NotifyHub:Hub<ITypedHubClient>
    {
        public NotifyHub()
        {

        }
        ////you're going to invoke this method from the client app
        //public void NotifyHub(string message)
        //{
        //    //you're going to configure your client app to listen for this
        //    Clients.All.SendAsync("Send", message);
        //}
    }
}
