using System;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public class WarningAlertConsumer : AlertConsumer
	{
	    public override string Queue => Queues.WarniningAlertQueue;

	    public override ThresholdStatus SubscribeKey => ThresholdStatus.Warning;

		public WarningAlertConsumer(IConnection connection, EventHandler<BasicDeliverEventArgs> command) 
			: base(connection, command)
		{
		}
	}
}
