using System;
using System.Collections.Generic;
using Base;
using Base.Extensions;
using MessageCommunication;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace User
{
    public class UserWorker : Observable<MeasureValue>, IDisposable
    {
        public string[] Subscriptions { private get; set; } = null;

        private IConnection _connection;

        private readonly List<AlertConsumer> _consumers = new List<AlertConsumer>();

        public UserWorker(string[] subscriptions) : this()
        {
            Subscriptions = subscriptions;
        }

        public UserWorker()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        private void _removeConsumer(AlertConsumer consumer)
        {
            _consumers.Remove(consumer);
            if (_consumers.Count == 0)
            {
                Dispose();
            }
        }

        public void Stop()
        {
            foreach (var consumer in _consumers)
            {
                consumer.StopConsuming();
            }

            _consumers.RemoveAll(c => true);
        }

        public void Start()
        {
            if (Subscriptions == null)
            {
                throw new Exception("Subscriptions not set.");    
            }

            void Command(object model, BasicDeliverEventArgs ea)
            {
                var body = ea.Body;
                var data = body.ToObject<MeasureValue>();

                Notify(data);

                Console.WriteLine($"Received data: [{data}]\n");
            }

            Console.Write("----Waiting for [");
            foreach (var subscription in Subscriptions)
            {
                Console.Write(subscription.ToUpper() + " ");
            }
            Console.WriteLine("] signals-----");

            if (Array.IndexOf(Subscriptions, "normal") > -1)
            {
                var normalConsumer = new NormalAlertConsumer(_connection, Command);
                _consumers.Add(normalConsumer);
            }
            if (Array.IndexOf(Subscriptions, "warning") > -1)
            {
                var warningConsumer = new WarningAlertConsumer(_connection, Command);
                _consumers.Add(warningConsumer);   
            }
            if (Array.IndexOf(Subscriptions, "critical") > -1)
            {
                var criticalConsumer = new CriticalAlertConsumer(_connection, Command);
                _consumers.Add(criticalConsumer);
            }

            foreach (var consumer in _consumers)
            {
                consumer.Subscribe(Exchanges.AlertsPublisherExchange);
                consumer.Consume();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
