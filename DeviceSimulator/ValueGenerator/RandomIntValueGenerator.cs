using System;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomIntValueGenerator : ISensorValueGenerator
    {
        private readonly Random _random;
        private readonly int _minValue;
        private readonly int _maxValue;

        public RandomIntValueGenerator(int minValue, int maxValue)
        {
            _random = new Random();
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public object GetValue(DateTime time)
        {
            return GetValue();
        }

        public object GetValue(TimeSpan time)
        {
            return GetValue();
        }

        public object GetValue()
        {
                return _random.Next(_minValue, _maxValue);
        }
    }
}
