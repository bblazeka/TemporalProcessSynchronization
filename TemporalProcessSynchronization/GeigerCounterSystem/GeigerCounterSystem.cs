using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Base;

namespace GeigerCounterSystem
{
	public class GeigerCounterSystem
	{
		private const int SendDelay = 5000;	// send every 5 seconds

		private readonly Stopwatch _watch;
		private readonly ISender _sender;
		private readonly MeasurementManager _measurementManager;

		private bool _isRunning;

		public GeigerCounterSystem(MeasurementManager manager, ISender sender)
		{
			_watch = Stopwatch.StartNew();
			_isRunning = false;

			_sender = sender;
			_measurementManager = manager;
		}

		private int _getCalculatedRow()
		{
			var secondsRunning = (int) _watch.ElapsedMilliseconds / 1000;
			return secondsRunning % 100 + 2;
		}

		private double _emulateMeasurement()
		{
			return _measurementManager.GetMeasure(_getCalculatedRow());
		}

		public void StartMeasuring() => Task.Factory.StartNew(() =>
		{
			_isRunning = true;

			while (_isRunning)
			{
				Thread.Sleep(SendDelay);

				var data = ThresholdCalculator.Calculate(_emulateMeasurement());
				var bytes = data.ToByteArray();
				_sender.Send(bytes);
			}
		});

		public void StopMeasuring()
		{
			_isRunning = false;
		}
	}
}
