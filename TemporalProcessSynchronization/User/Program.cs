using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Base;
using MessageCommunication;
using System.Collections.Generic;

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
                var subscriptions = new List<AlertSubscriber>();

                Console.Write("----Waiting for [");
                foreach(var type in args)
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
                    subscriptions.Add(new NormalAlertSubscriber(channel, Command, "measures_subscribe"));
                }
                if (Array.IndexOf(args, "warning") > -1)
                {
                    subscriptions.Add(new WarningAlertSubscriber(channel, Command, "measures_subscribe"));
                }
                subscriptions.Add(new CriticalAlertSubscriber(channel, Command, "measures_subscribe"));

                foreach(var sub in subscriptions)
                {
                    sub.Subscribe();
                }

				while (true)
				{
                    foreach(var sub in subscriptions)
                    {
                        sub.Consume();
                    }
				}
			}
		}
    }
}
