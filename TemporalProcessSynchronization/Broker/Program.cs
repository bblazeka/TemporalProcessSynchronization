using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using Base;
using MessageCommunication;

namespace Broker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

			using (var sender = new Sender("measures_subscribe", "direct", "localhost"))
			using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "radiation_exchange", type: "fanout");

	            channel.QueueDeclare(queue: "radiation_receiver", durable: true, exclusive: true);

				channel.QueueBind(queue: "radiation_receiver", exchange: "radiation_exchange", routingKey: "");

				var consumer = new EventingBasicConsumer(channel);

	            consumer.Received += (model, ea) =>
	            {
		            var body = ea.Body;
		            var data = ea.Body.ToObject<MeasureValue>();

		            Console.WriteLine($"Received data: [{data}]\n");

					sender.Send(body, data.Status);
	            };

	            while (true)
	            {
					channel.BasicConsume(queue: "radiation_receiver", noAck: false, consumer: consumer);
				}
            }
        }
    }
}
