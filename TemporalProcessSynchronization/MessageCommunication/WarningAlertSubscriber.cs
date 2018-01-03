using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageCommunication
{
	public class WarningAlertSubscriber : AlertSubscriber
	{
		public override ThresholdStatus SubscribeKey => ThresholdStatus.Warning;

		public WarningAlertSubscriber(IModel channel, EventHandler<BasicDeliverEventArgs> command, string exchange) 
			: base(channel, command, exchange)
		{
		}
	}
}
