using System;
using System.Threading.Tasks;
using Base;
using Base.Extensions;
using Base.Interfaces;
using MessageCommunication;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Broker
{
    public class AlertsBroker : IDisposable
    {
        public string HostName { get; set; }

        private IConnection _connection;
        private IModel _channel;
        private ISender _sender;
        private EventingBasicConsumer _consumer;

        private bool _isRunning;

        public AlertsBroker()
        {
            HostName = "localhost";

            _createConnection();
            _setupSender();
            _setupBroker();
            _setupConsumer();
        }

        public void Listen()
        {
            Task.Factory.StartNew(() =>
            {
                _isRunning = true;

                Console.WriteLine("Collecting geiger measures and publishing...");

                while (_isRunning)
                {
                    _channel.BasicConsume(Queues.GeigerReceiverQueue, false, _consumer);
                }

                Console.WriteLine("Stoping collection and publishing...");
            });
        }

        public void StopListening()
        {
            _isRunning = false;
        }

        private void _createConnection()
        {
            var connectionFactory = new ConnectionFactory {HostName = HostName};
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        private void _setupBroker()
        {
            _channel.ExchangeDeclare(exchange: Exchanges.AlertsReceiverExchange, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queue: Queues.GeigerReceiverQueue, durable: true, exclusive: true);
            _channel.QueueBind(queue: Queues.GeigerReceiverQueue, exchange: Exchanges.AlertsReceiverExchange, routingKey: "");

            _channel.QueueDeclare(queue: Queues.NormalAlertQueue, durable: true, exclusive: false);
            _channel.QueueDeclare(queue: Queues.WarniningAlertQueue, durable: true, exclusive: false);
            _channel.QueueDeclare(queue: Queues.CriticalAlertQueue, durable: true, exclusive: false);

            _channel.QueueBind(
                queue: Queues.NormalAlertQueue, 
                exchange: Exchanges.AlertsPublisherExchange, 
                routingKey: ThresholdStatus.Normal.ToString()
            );
            _channel.QueueBind(
                queue: Queues.WarniningAlertQueue, 
                exchange: Exchanges.AlertsPublisherExchange, 
                routingKey: ThresholdStatus.Warning.ToString()
            );
            _channel.QueueBind(
                queue: Queues.CriticalAlertQueue, 
                exchange: Exchanges.AlertsPublisherExchange, 
                routingKey: ThresholdStatus.Critical.ToString()
            );
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }

        private void _setupSender()
        {
            _sender = new Sender(Exchanges.AlertsPublisherExchange, ExchangeType.Direct, HostName);
        }

        private void _setupConsumer()
        {
            _consumer = new EventingBasicConsumer(_channel);

            _consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var data = ea.Body.ToObject<MeasureValue>();

                Console.WriteLine($"Received data: [{data}]\n");

                _sender.Send(body, data.Status);
            };
        }
    }
}
