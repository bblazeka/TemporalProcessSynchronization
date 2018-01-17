using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Base;
using Base.Extensions;
using Base.Interfaces;

namespace GeigerCounterSystem
{
	public class CounterSystem : Observable<MeasureValue>
	{
		private readonly int SendDelay;	// send every 5 seconds

		private readonly Stopwatch _watch;
		private readonly ISender _sender;
		private readonly MeasurementManager _measurementManager;

		private bool _isRunning;

		public CounterSystem(MeasurementManager manager, ISender sender, int delay = 3000)
		{
			_watch = Stopwatch.StartNew();
			_isRunning = false;

		    SendDelay = delay;

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

		public void StartMeasuring()
		{
		    Task.Factory.StartNew(() =>
		    {
		        _isRunning = true;

		        while (_isRunning)
		        {
		            Thread.Sleep(SendDelay);

		            var data = ThresholdCalculator.Calculate(_emulateMeasurement());
		            data.TimeStamp = _watch.ElapsedTicks;
                    var bytes = data.ToByteArray();
		            _sender.Send(bytes);
		            Console.WriteLine($"Sent data: [{data}]\n");
		            Notify(data);
                }

		        Console.WriteLine("Stopping measuring and sending...");
            });
		}

		public void StopMeasuring()
		{
			_isRunning = false;
		}
	}
}
