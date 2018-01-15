namespace Base.Interfaces
{
	public interface ISender
	{
		void Send(byte[] data);

		void Send(byte[] data, string routingKey);
	}
}
