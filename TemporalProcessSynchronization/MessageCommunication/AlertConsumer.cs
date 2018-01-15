using System;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public abstract class AlertConsumer
	{
		private readonly IModel _channel;
		private readonly EventingBasicConsumer _consumer;
		private readonly string _exchange;
		private readonly string _queueName;

		public abstract ThresholdStatus SubscribeKey { get; }

		protected AlertConsumer(IModel channel, EventHandler<BasicDeliverEventArgs> command, string exchange)
		{
			_channel = channel;
			_consumer = new EventingBasicConsumer(channel);
			_consumer.Received += command;
			_exchange = exchange;
			_queueName = channel.QueueDeclare().QueueName;
		}

		public void Subscribe()
		{
			_channel.QueueBind(queue: _queueName, exchange: _exchange, routingKey: SubscribeKey.ToString());
		}

		public void Consume()
		{
			_channel.BasicConsume(queue: _queueName, noAck: false, consumer: _consumer);
		}
	}
}
