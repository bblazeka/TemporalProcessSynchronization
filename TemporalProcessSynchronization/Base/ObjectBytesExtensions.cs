using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Base
{
	public static class ObjectBytesExtensions
	{
		public static byte[] ToByteArray<T>(this T obj)
		{
			var binaryFormatter = new BinaryFormatter();
			using (var memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, obj);
				return memoryStream.ToArray();
			}
		}

		public static T ToObject<T>(this byte[] arrBytes)
		{
			using (var memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();

				memoryStream.Write(arrBytes, 0, arrBytes.Length);

				memoryStream.Seek(0, SeekOrigin.Begin);

				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}
	}
}
