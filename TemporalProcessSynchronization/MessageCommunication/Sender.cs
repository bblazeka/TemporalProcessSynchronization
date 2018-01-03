using System;
using Base;
using RabbitMQ.Client;

namespace MessageCommunication
{
	public class Sender : ISender, IDisposable
	{
		private readonly IModel _channel;
		private readonly IConnection _connection;

		public Sender()
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_init(_channel);
		}

		private void _init(IModel channel)
		{
			channel.ExchangeDeclare(exchange: "radiation_exchange", type: "fanout");
		}

		public void Send(byte[] value)
		{
			_channel.BasicPublish(exchange: "radiation_exchange", routingKey: "", basicProperties: null, body: value);
		}

		public void Dispose()
		{
			_channel?.Dispose();
			_connection?.Dispose();
		}
	}
}
