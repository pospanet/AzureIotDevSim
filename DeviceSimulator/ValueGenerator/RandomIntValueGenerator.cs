using System;

namespace Pospa.Azure.IoT.DeviceSimulator.ValueGenerator
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

        public int GetValue()
        {
                return _random.Next(_minValue, _maxValue);
        }
    }
}
