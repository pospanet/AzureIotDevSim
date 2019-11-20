using System;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomDoubleValueGenerator : ISensorValueGenerator
    {
        private readonly Random _random;
        private readonly double _minValue;
        private readonly double _maxValue;

        public RandomDoubleValueGenerator(double minValue, double maxValue)
        {
            _random = new Random();
            _minValue = minValue;
            _maxValue = maxValue;
        }
        #region ISensorValueGenerator

        public object GetValue(DateTime time)
        {
            return GetValue();
        }

        public object GetValue(TimeSpan time)
        {
            return GetValue();
        }
        #endregion

        public double GetValue()
        {
            return ((_maxValue - _minValue) * _random.NextDouble()) + _minValue;
        }
    }
}
