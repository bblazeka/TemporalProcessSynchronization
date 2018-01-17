using System;
using Base.Interfaces;
using RabbitMQ.Client;

namespace MessageCommunication
{
	public class Sender : ISender
	{
		private readonly IModel _channel;
		private readonly IConnection _connection;
		private readonly string _exchange;

		public Sender(string exchange, string type, string hostName)
		{
			_exchange = exchange;

			var factory = new ConnectionFactory { HostName = hostName };
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.ExchangeDeclare(exchange: _exchange, type: type);
		}

		public void Send(byte[] data)
		{
			_channel.BasicPublish(exchange: _exchange, routingKey: "", basicProperties: null, body: data);
		}

		public void Send(byte[] data, string routingKey)
		{
			_channel.BasicPublish(exchange: _exchange, routingKey: routingKey, basicProperties: null, body: data);
		}

		public void Dispose()
		{
			_channel?.Dispose();
			_connection?.Dispose();
		}
	}
}
