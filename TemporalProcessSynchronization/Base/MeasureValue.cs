using System;
using System.Globalization;

namespace Base
{
	[Serializable]
	public class MeasureValue
	{
	    public long TimeStamp { get; set; }

		public string Status { get; }

		public double Value { get; }

	    public string GetStringValue() => Value.ToString(CultureInfo.InvariantCulture) + " uSv/h";

	    public string GetTimeStamp() => TimeStamp.ToString();

		public MeasureValue(string status, double value)
		{
			Status = status;
			Value = value;
		}

		public override string ToString()
		{
			return $"[{TimeStamp}] Status: {Status} | Measure: {Value} uSv/h";
		}
	}
}
