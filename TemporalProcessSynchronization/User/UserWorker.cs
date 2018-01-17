using System;
using System.Collections.Generic;
using Base;
using Base.Extensions;
using MessageCommunication;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace User
{
    public class UserWorker : IDisposable, Base.IObserver<AlertConsumer>
    {
        private readonly string[] _subscriptions;

        private IConnection _connection;

        private readonly List<AlertConsumer> _consumers = new List<AlertConsumer>();

        public UserWorker(string[] subscriptions)
        {
            _subscriptions = subscriptions;
        }

        private void _removeConsumer(AlertConsumer consumer)
        {
            _consumers.Remove(consumer);
            if (_consumers.Count == 0)
            {
                Dispose();
            }
        }

        public void Start()
        {
            void Command(object model, BasicDeliverEventArgs ea)
            {
                var body = ea.Body;
                var data = body.ToObject<MeasureValue>();

                Console.WriteLine($"Received data: [{data}]\n");
            }

            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();

            Console.Write("----Waiting for [");
            foreach (var subscription in _subscriptions)
            {
                Console.Write(subscription.ToUpper() + " ");
            }
            Console.WriteLine("] signals-----");

            if (Array.IndexOf(_subscriptions, "normal") > -1)
            {
                _consumers.Add(new NormalAlertConsumer(_connection, Command));
            }
            if (Array.IndexOf(_subscriptions, "warning") > -1)
            {
                _consumers.Add(new WarningAlertConsumer(_connection, Command));   
            }
            if (Array.IndexOf(_subscriptions, "critical") > -1)
            {
                _consumers.Add(new CriticalAlertConsumer(_connection, Command));
            }

            foreach (var consumer in _consumers)
            {
                consumer.Subscribe(Exchanges.AlertsPublisherExchange);
                consumer.Consume();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public void Dispose(AlertConsumer value)
        {
            _removeConsumer(value);
        }
    }
}
