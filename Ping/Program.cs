using MassTransit;
using PingPong;
using System;

namespace Ping
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

                sbc.ReceiveEndpoint(host, "ping", ep =>
                {
                    ep.Consumer(() => new Pongconsumer());
                });
            });

            bus.Start();

            Console.WriteLine("=== I'm ping ===");
            while (true)
            {
                Console.ReadLine();
                bus.Publish<IPingMessage>(new { Text = "ping!" });
            }
        }
    }

}
