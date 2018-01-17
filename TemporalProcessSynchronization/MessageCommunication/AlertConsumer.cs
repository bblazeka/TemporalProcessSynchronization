using System;
using System.Threading.Tasks;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public abstract class AlertConsumer : Observable<AlertConsumer>, IDisposable
	{
		private readonly IModel _channel;

		private readonly EventingBasicConsumer _consumer;

        public abstract string Queue { get; }

		public abstract ThresholdStatus SubscribeKey { get; }

	    private bool _isConsuming;

		protected AlertConsumer(IConnection connection, EventHandler<BasicDeliverEventArgs> command)
		{
			_channel = connection.CreateModel();
			_consumer = new EventingBasicConsumer(_channel);
		    _consumer.Received += command;
		}

        public void Subscribe(string exchange)
		{
            _channel.QueueDeclare(queue: Queue, durable: true, exclusive: false);
            _channel.QueueBind(queue: Queue, exchange: exchange, routingKey: SubscribeKey.ToString());
        }

		public void Consume()
		{
		    Task.Factory.StartNew(() =>
		    {
		        _isConsuming = true;

		        while (_isConsuming)
		        {
		            _channel.BasicConsume(queue: Queue, noAck: false, consumer: _consumer);
                }
		    });
		}

	    public void StopConsuming()
	    {
	        _isConsuming = false;
            Dispose();
            Notify(this);
	    }

	    public void Dispose()
	    {
	        _channel?.Dispose();
	    }
	}
}
