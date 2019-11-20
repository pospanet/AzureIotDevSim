using System;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomByteValueGenerator : ISensorValueGenerator
    {
        private readonly Random _random;
        private readonly int _minBufferLength;
        private readonly int _maxBufferLength;

        public RandomByteValueGenerator(int minBufferLength, int maxBufferLength)
        {
            _random = new Random();
            _minBufferLength = minBufferLength;
            _maxBufferLength = maxBufferLength;
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

        public byte[] GetValue()
        {
            int characterNumber = (int)(((_maxBufferLength - _minBufferLength) * _random.NextDouble()) + _minBufferLength);
            byte[] buffer = new byte[characterNumber];
            _random.NextBytes(buffer);
            return buffer; ;
        }
    }
}
