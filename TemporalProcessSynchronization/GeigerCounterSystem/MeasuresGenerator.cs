using System;

namespace GeigerCounterSystem
{
    public class MeasuresGenerator : IMeasurementManager
    {
        private readonly Random _random;

        private const double LowerBound = 0.2f;

        private const double UpperBound = 10.0f;

        public MeasuresGenerator()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }

        public double GetMeasure()
        {
            var measure = _random.NextDouble() * (UpperBound - LowerBound) + LowerBound;
            return Math.Round(measure, 2);
        }
    }
}
