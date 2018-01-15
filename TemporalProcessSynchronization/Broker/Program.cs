using System;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Base;
using Base.Extensions;
using MessageCommunication;

namespace Broker
{
    class Program
    {
        public static void Main(string[] args)
        {
   //         var factory = new ConnectionFactory { HostName = "localhost" };

   //         using (var sender = new Sender(Exchanges.AlertsPublisherExchange, ExchangeType.Direct, "localhost"))
			//using (var connection = factory.CreateConnection())
   //         using (var channel = connection.CreateModel())
   //         {
   //             channel.ExchangeDeclare(exchange: Exchanges.AlertsReceiverExchange, type: ExchangeType.Fanout);
	  //          channel.QueueDeclare(queue: "radiation_receiver", durable: true, exclusive: true);
   //             channel.QueueBind(queue: "radiation_receiver", exchange: Exchanges.AlertsReceiverExchange, routingKey: "");

   //             //channel.QueueDeclare(queue: "measures_normal", durable: true, exclusive: false);
   //             //channel.QueueDeclare(queue: "measures_warning", durable: true, exclusive: false);
   //             //channel.QueueDeclare(queue: "measures_critical", durable: true, exclusive: false);

   //             //channel.QueueBind(queue: "measures_normal", exchange: "measures_subscribe", routingKey: "Normal");
   //             //channel.QueueBind(queue: "measures_warning", exchange: "measures_subscribe", routingKey: "Warning");
   //             //channel.QueueBind(queue: "measures_critical", exchange: "measures_subscribe", routingKey: "Critical");

			//	var consumer = new EventingBasicConsumer(channel);

	  //          consumer.Received += (model, ea) =>
	  //          {
		 //           var body = ea.Body;
		 //           var data = ea.Body.ToObject<MeasureValue>();

		 //           Console.WriteLine($"Received data: [{data}]\n");

			//		sender.Send(body, data.Status);
	  //          };

	  //          while (true)
	  //          {
   //                 // Console.WriteLine("Waiting for measures...");
			//		channel.BasicConsume(queue: Exchanges.AlertsReceiverExchange, noAck: false, consumer: consumer);
			//	}
   //         }

            var broker = new AlertsBroker();
            broker.Listen();
        }
    }
}
