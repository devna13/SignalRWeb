using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRWebProducer.Models;
using SignalRWebProducer.RabbitMQ;

namespace SignalRWebProducer.Controllers
{
    public class StocsController : Controller
    {
        [HttpPost]
        public string Push([FromBody]Stoc stock)
        {
            //UpdateDummyList(stoc);
            RabbitMQPost rabbitMq = new RabbitMQPost(stock);
            Console.WriteLine(rabbitMq.Post());
            return "success";
        }
    }
}