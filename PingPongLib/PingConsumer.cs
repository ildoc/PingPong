using MassTransit;
using System;
using System.Threading.Tasks;

namespace PingPong
{
    public class Pingconsumer : IConsumer<IPingMessage>
    {
        //private readonly IBusControl _bus;

        //public Pingconsumer(IBusControl bus)
        //{
        //    _bus = bus;
        //}

        public Task Consume(ConsumeContext<IPingMessage> context)
        {
            Console.WriteLine("[Ping] Recieved: " + context.Message.Text);

            //Thread.Sleep(1000);
            //_bus.Publish<IPongMessage>(new { Text = "pong!" });

            return Task.CompletedTask;
        }
    }

    public class Pongconsumer : IConsumer<IPongMessage>
    {
        //private readonly IBusControl _bus;

        //public Pongconsumer(IBusControl bus)
        //{
        //    _bus = bus;
        //}

        public Task Consume(ConsumeContext<IPongMessage> context)
        {
            Console.WriteLine("[Pong] Recieved: " + context.Message.Text);

            //Thread.Sleep(1000);
            //_bus.Publish<IPingMessage>(new { Text = "ping!" });

            return Task.CompletedTask;
        }
    }

    public interface IMessage
    {
        string Text { get; set; }
    }

    public interface IPingMessage : IMessage { }
    public interface IPongMessage : IMessage { }
}
