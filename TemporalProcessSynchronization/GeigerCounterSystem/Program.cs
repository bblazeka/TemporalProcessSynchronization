using System;
using Base;
using MessageCommunication;
using System.Threading;

namespace GeigerCounterSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var sender = new Sender(Exchanges.AlertsReceiverExchange, "fanout", "localhost"))
			{
				var manager = new MeasurementManager("C:\\Source\\TemporalProcessSynchronization\\measures.txt");
				var system = new CounterSystem(manager, sender);
				system.StartMeasuring();
			    Console.ReadKey();
			}
        }
    }
}
