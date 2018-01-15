using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Base;
using Base.Extensions;
using MessageCommunication;

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
				Console.WriteLine("----Waiting for warning signals-----");

				void Command(object model, BasicDeliverEventArgs ea)
				{
					var body = ea.Body;
					var data = body.ToObject<MeasureValue>();

					Console.WriteLine($"Received data: [{data}]\n");
				}

				var warningSubscribe = new WarningAlertConsumer(channel, Command, Exchanges.AlertsPublisherExchange);

				warningSubscribe.Subscribe();

				while (true)
				{
					warningSubscribe.Consume();
				}
			}
		}
    }
}
