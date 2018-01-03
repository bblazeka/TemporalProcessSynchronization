using Base;

namespace GeigerCounterSystem
{
	public class ThresholdCalculator
	{
		public static MeasureValue Calculate(double value)
		{
			var status = ThresholdStatus.Critical.ToString();

			if (value < 1)
			{
				status = ThresholdStatus.Normal.ToString();
			}
			else if (value >= 1 && value < 7)
			{
				status = ThresholdStatus.Warning.ToString();
			}

			return new MeasureValue(status, value);
		}
	}
}
