using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomValueGenerator<T> : ISensorValueGenerator<T> where T : struct
    {
        private readonly Random _random;
        private readonly T _minValue;
        private readonly T _maxValue;
        private readonly int _minValueInt;
        private readonly int _maxValueInt;

        private readonly bool _isInt;
        private readonly bool _isUInt;

        public RandomValueGenerator(T minValue, T maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
            this._minValue = minValue;
            this._maxValue = maxValue;
            _random = new Random();
            Type type = typeof(T);
            _isInt = type == typeof(SByte) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(UInt64);
            _isUInt = type == typeof(Byte) || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64);
            if (_isInt || _isUInt)
            {
                _minValueInt = Convert.ToInt32(minValue);
                _maxValueInt = Convert.ToInt32(maxValue);
            }

            if (type == typeof(UInt64) || type == typeof(UInt64))
            {
                throw new NotSupportedException("64bit types are not supported, yet");
            }
        }

        public T GetValue(DateTime time)
        {
            return GetValue();
        }

        public T GetValue(TimeSpan time)
        {
            return GetValue();
        }

        public T GetValue()
        {
            if (_isInt || _isUInt)
            {
                return (T)(object)_random.Next(_minValueInt, _maxValueInt);
            }
            throw new NotSupportedException();
        }
    }
}
