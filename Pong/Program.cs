using MassTransit;
using PingPong;
using System;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "pong", ep =>
                {
                    ep.Consumer(() => new Pingconsumer());
                });
            });

            bus.Start();

            Console.WriteLine("=== I'm pong ===");
            while (true)
            {
                Console.ReadLine();
                bus.Publish<IPongMessage>(new { Text = "pong!" });
            }
        }
    }
}
