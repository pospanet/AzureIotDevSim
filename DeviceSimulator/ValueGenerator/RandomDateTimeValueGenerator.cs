using System;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomDateTimeValueGenerator : ISensorValueGenerator
    {
        private readonly Random _random;
        private readonly DateTime _minValue;
        private readonly DateTime _maxValue;

        public RandomDateTimeValueGenerator(DateTime minValue, DateTime maxValue)
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

        public DateTime GetValue()
        {
            return _minValue.Add((_maxValue - _minValue) * _random.NextDouble());
        }
    }
}
