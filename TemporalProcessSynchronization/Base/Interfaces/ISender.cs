using System;

namespace Base.Interfaces
{
	public interface ISender : IDisposable
	{
		void Send(byte[] data);

		void Send(byte[] data, string routingKey);
	}
}
