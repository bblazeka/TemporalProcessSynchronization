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

	    private string _queue;

		protected AlertConsumer(IConnection connection, EventHandler<BasicDeliverEventArgs> command)
		{
			_channel = connection.CreateModel();
			_consumer = new EventingBasicConsumer(_channel);
		    _consumer.Received += command;
		}

        public void Subscribe(string exchange)
		{
            _queue = _channel.QueueDeclare(queue: Queue, durable: true, exclusive: false).QueueName;
            _channel.QueueBind(queue: _queue, exchange: exchange, routingKey: SubscribeKey.ToString());
        }

		public void Consume()
		{
		    if (_queue == null)
		    {
		        throw new ConsumerNotSubscribedException();    
		    }

		    Task.Factory.StartNew(() =>
		    {
		        _isConsuming = true;

		        while (_isConsuming)
		        {
		            _channel.BasicConsume(queue: _queue, noAck: false, consumer: _consumer);
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
