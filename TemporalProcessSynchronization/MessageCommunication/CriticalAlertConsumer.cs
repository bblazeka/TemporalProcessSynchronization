using System;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public class CriticalAlertConsumer : AlertConsumer
	{
	    public override string Queue => Queues.CriticalAlertQueue;

	    public override ThresholdStatus SubscribeKey => ThresholdStatus.Critical;

		public CriticalAlertConsumer(IConnection connection, EventHandler<BasicDeliverEventArgs> command) 
			: base(connection, command)
		{
		}
	}
}
