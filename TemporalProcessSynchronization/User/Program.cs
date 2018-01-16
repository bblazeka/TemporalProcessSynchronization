using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Base;
using Base.Extensions;
using MessageCommunication;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Receiving data...");

            void Command(object model, BasicDeliverEventArgs ea)
            {
                var body = ea.Body;
                var data = body.ToObject<MeasureValue>();

                Console.WriteLine($"Received data: [{data}]\n");
            }

            var factory = new ConnectionFactory { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //{
                var connection = factory.CreateConnection();
                Task.Factory.StartNew(() =>
                {
                    var consumer = new CriticalAlertConsumer(connection, Command);
                    consumer.Subscribe(Exchanges.AlertsPublisherExchange);
                    while (true)
                    {
                        consumer.Consume();
                    }
                });

                Task.Factory.StartNew(() => {
                    var consumer = new WarningAlertConsumer(connection, Command);
                    consumer.Subscribe(Exchanges.AlertsPublisherExchange);
                    while (true)
                    {
                        consumer.Consume();
                    }
                });
            //}
            
            //using (var normalAlertConsumer = new NormalAlertConsumer(connection, Command))
            //using (var warningAlertConsumer = new WarningAlertConsumer(connection, Command))
            //{
            //    while (true)
            //    {
            //        warningAlertConsumer.Consume();
            //    }
            //    Task.Factory.StartNew(() =>
            //    {
            //        while (true)
            //        {
            //            normalAlertConsumer.Consume();
            //        }
            //    });

            //    Task.Factory.StartNew(() =>
            //    {
            //        while (true)
            //        {
            //            warningAlertConsumer.Consume();
            //        }
            //    });

            //    Console.ReadKey();
            //}
        }
    }
}
