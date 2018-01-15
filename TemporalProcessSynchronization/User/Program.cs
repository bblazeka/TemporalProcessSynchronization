using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Base;
using Base.Extensions;
using MessageCommunication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var subscriptions = new List<AlertConsumer>();

                Console.Write("----Waiting for [");
                foreach (var type in args)
                {
                    Console.Write(type.ToUpper() + " ");
                }
                Console.WriteLine("] signals-----");

                void Command(object model, BasicDeliverEventArgs ea)
                {
                    var body = ea.Body;
                    var data = body.ToObject<MeasureValue>();

                    Console.WriteLine($"Received data: [{data}]\n");
                }

                if (Array.IndexOf(args, "normal") > -1)
                {
                    subscriptions.Add(new NormalAlertConsumer(channel, Command, Exchanges.AlertsPublisherExchange));
                }
                if (Array.IndexOf(args, "warning") > -1)
                {
                    subscriptions.Add(new WarningAlertConsumer(channel, Command, Exchanges.AlertsPublisherExchange));
                }
                subscriptions.Add(new CriticalAlertConsumer(channel, Command, Exchanges.AlertsPublisherExchange));

                foreach (var sub in subscriptions)
                {
                    sub.Subscribe();
                }

                foreach (var sub in subscriptions)
                {
                    Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            sub.Consume();
                        }
                    });
                }
            }
        }
    }
}
