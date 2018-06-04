using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRWeb.Hubs;
using SignalRWeb.Models;

namespace SignalRWeb.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("BroadcastMessage")]
        public async Task<string> Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                await _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}