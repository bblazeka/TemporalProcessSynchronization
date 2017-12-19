using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: "direct_logs", routingKey: args[0]);

                // send a subscribe signal
                Send(channel, "S("+args[0]+")");

                Console.WriteLine(" [*] Waiting for message.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);
                };
                channel.BasicConsume(queue: queueName, noAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public static void Send(IModel channel, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "direct_logs", routingKey: "0", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}
