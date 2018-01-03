using System;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public class NormalAlertSubscriber : AlertSubscriber
	{
		public override ThresholdStatus SubscribeKey => ThresholdStatus.Normal;

		public NormalAlertSubscriber(IModel channel, EventHandler<BasicDeliverEventArgs> command, string exchange) 
			: base(channel, command, exchange)
		{
		}
	}
}
