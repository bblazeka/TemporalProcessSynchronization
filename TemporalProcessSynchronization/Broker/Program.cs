using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Random rnd = new Random();
            var subscriptions = new Dictionary<string, string>();
            var counters = new Dictionary<string, int>();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");
                Receive(counters, subscriptions, channel);
	            while (true)
                {
                    if(subscriptions.Count == 0)
                    {
                        continue;
                    }
                    var randomLocation = (rnd.Next() % subscriptions.Count + 1).ToString();

                    System.Threading.Thread.Sleep(1000);
                    counters[randomLocation] = (counters[randomLocation] + 1) % 200;
					var message = counters[randomLocation]+" "+GetMessage(args);
		            var body = Encoding.UTF8.GetBytes(message);
		            channel.BasicPublish(exchange: "direct_logs", routingKey: subscriptions[randomLocation], basicProperties: null, body: body);
		            Console.WriteLine(" [x] Sent to {1}: {0}", message,randomLocation);
				}
            }
        }

        public static void Receive(Dictionary<string,int> counters, Dictionary<string,string> subs, IModel channel)
        {
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "direct_logs", routingKey: "0");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] {0}", message);
                counters.Add(message.Substring(2,1), 0);
                subs.Add(message.Substring(2, 1), ea.DeliveryTag.ToString());
            };
            channel.BasicConsume(queue: queueName, noAck: false, consumer: consumer);
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Empty message!");
        }
    }
}
