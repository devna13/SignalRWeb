using Microsoft.AspNetCore.SignalR;
using SignalRWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWeb.Hubs
{
    public class StocHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return Clients.Client(Context.ConnectionId).SendAsync("SetConnectionId", Context.ConnectionId);
        }
        public async Task<string> ConnectGroup(string stocName, string connectionID)
        {
            await Groups.AddAsync(connectionID, stocName);
            return $"{connectionID} is added {stocName}";
        }
        public Task PushNotify(Stoc stocData)
        {
            return Clients.Group(stocData.Name).SendAsync("ChangeStocValue", stocData);
        }
    }
}
