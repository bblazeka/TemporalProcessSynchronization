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
		private readonly int SendDelay;

		private readonly Stopwatch _watch;
		private readonly ISender _sender;
		private readonly IMeasurementManager _measurementManager;

		private bool _isRunning;

		public CounterSystem(IMeasurementManager manager, ISender sender, int delay = 5000)
		{
			_watch = Stopwatch.StartNew();
			_isRunning = false;

		    SendDelay = delay;

            _sender = sender;
			_measurementManager = manager;
		}
		private double _emulateMeasurement()
		{
		    return _measurementManager.GetMeasure();
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
		            Notify(data);
                }
            });
		}

		public void StopMeasuring()
		{
			_isRunning = false;
		}
	}
}
