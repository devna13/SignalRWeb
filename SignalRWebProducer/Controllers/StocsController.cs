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
        public async Task<string> Push([FromBody]Stoc stock)
        {
            for(int i = 0; i <= 10; i++)
            {
                await Task.Delay(1500).ContinueWith((a) =>
                {
                    stock = new Stoc
                    {
                        ID = i,
                        Name = "Vivek",
                        Value = i * 100
                    };
                    RabbitMQPost rabbitMq = new RabbitMQPost(stock);
                    Console.WriteLine(rabbitMq.Post());
                });
                
            }           
            return "success";
        }
    }
}