using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GeigerCounterSystem
{
	public class MeasurementManager
	{
		private readonly string _filePath;

		private List<double> _measures;

		public MeasurementManager(string filePath)
		{
			_filePath = filePath;
		}

		public double GetMeasure(int position)
		{
			if (_measures == null)
			{
				_measures = _readMeasures();
			}

			return _measures[position];
		}

		private List<double> _readMeasures()
		{
			using (var stream = new StreamReader(_filePath))
			{
				var measurements = new List<double>();

				while (!stream.EndOfStream)
				{
					var line = stream.ReadLine();
					measurements.Add(_parseValue(line));
				}

				return measurements;
			}
		}

		private static double _parseValue(string value)
		{
			try
			{
				return double.Parse(value.Trim(), CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
