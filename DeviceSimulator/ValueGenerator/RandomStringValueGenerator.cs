using System;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomStringValueGenerator : ISensorValueGenerator
    {
        private readonly Random _random;
        private readonly int _minCharacterNumber;
        private readonly int _maxCharacterNumber;

        public RandomStringValueGenerator(int minCharacterNumber, int maxCharacterNumber)
        {
            _random = new Random();
            _minCharacterNumber = minCharacterNumber;
            _maxCharacterNumber = maxCharacterNumber;
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

        public string GetValue()
        {
            int characterNumber = (int)(((_maxCharacterNumber - _minCharacterNumber) * _random.NextDouble()) + _minCharacterNumber);
            byte[] buffer = new byte[characterNumber];
            _random.NextBytes(buffer);
            return System.Text.Encoding.ASCII.GetString(buffer);
        }
    }
}
