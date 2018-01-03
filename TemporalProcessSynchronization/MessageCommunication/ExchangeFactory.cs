using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCommunication
{
	public class ExchangeFactory
	{
		private readonly string _exchangeName;
		private readonly string _exchangeType;
		private readonly string _hostName;

		public ExchangeFactory(string exchangeName, string exchangeType, string hostName)
		{
			_exchangeName = exchangeName;
			_exchangeType = exchangeType;
		}


	}
}
