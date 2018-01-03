using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeigerCounterSystem;
using MessageCommunication;

namespace Starter
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (var sender = new Sender("radiation_exchange", "fanout", "localhost"))
			{
				var manager = new MeasurementManager("C:/Users/Martin/Desktop/measures.txt");
				var system = new GeigerCounterSystem.System(manager, sender);
				system.StartMeasuring();
			}
		}
	}
}
