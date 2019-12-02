﻿using System;
using System.Collections;

namespace Pospa.Azure.IoT.DeviceSimulator.ValueGenerator
{
    public class ListValueGenerator : ISensorValueGenerator
    {
        private readonly IEnumerator _valuesEnumerator;

        public ListValueGenerator(IEnumerable values)
        {
            _valuesEnumerator = values.GetEnumerator();
        }
        public object GetValue(DateTime time)
        {
            return GetValue();
        }

        public object GetValue(TimeSpan time)
        {
            return GetValue();
        }

        private object GetValue()
        {
            object value = _valuesEnumerator.Current;
            if (!_valuesEnumerator.MoveNext())
            {
                _valuesEnumerator.Reset();
            }
            return value;
        }
    }
}
