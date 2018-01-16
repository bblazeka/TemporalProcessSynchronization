using System;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public class NormalAlertConsumer : AlertConsumer
	{
	    public override string Queue => Queues.NormalAlertQueue;

	    public override ThresholdStatus SubscribeKey => ThresholdStatus.Normal;

		public NormalAlertConsumer(IConnection connection, EventHandler<BasicDeliverEventArgs> command) 
			: base(connection, command)
		{
		}
	}
}
