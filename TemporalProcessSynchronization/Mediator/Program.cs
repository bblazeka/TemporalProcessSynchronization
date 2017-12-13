using System;
using RabbitMQ.Client;
using System.Text;

namespace Mediator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");

	            while (true)
	            {
					System.Threading.Thread.Sleep(3000);
					var message = GetMessage(args);
		            var body = Encoding.UTF8.GetBytes(message);
		            channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
		            Console.WriteLine(" [x] Sent {0}", message);
				}
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "info: Hello World!");
        }
    }
}
