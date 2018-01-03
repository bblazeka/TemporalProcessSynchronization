namespace Base
{
	public interface ISender
	{
		void Send(byte[] data);

		void Send(byte[] data, string routingKey);
	}
}
