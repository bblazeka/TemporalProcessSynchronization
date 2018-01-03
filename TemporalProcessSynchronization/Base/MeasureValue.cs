using System;

namespace Base
{
	[Serializable]
	public class MeasureValue
	{
		public string Status { get; }

		public double Value { get; }

		public MeasureValue(string status, double value)
		{
			Status = status;
			Value = value;
		}
	}
}
