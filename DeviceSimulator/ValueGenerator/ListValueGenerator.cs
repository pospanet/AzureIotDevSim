using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.ValueGenerator
{
    public class ListValueGenerator<T> : ISensorValueGenerator<T>
    {
        private readonly IEnumerator<T> _valuesEnumerator;

        public ListValueGenerator(IEnumerable<T> values)
        {
            _valuesEnumerator = values.GetEnumerator();
        }
        public T GetValue(DateTime time)
        {
            return GetValue();
        }

        public T GetValue(TimeSpan time)
        {
            return GetValue();
        }

        private T GetValue()
        {
            T value = _valuesEnumerator.Current;
            if (!_valuesEnumerator.MoveNext())
            {
                _valuesEnumerator.Reset();
            }
            return value;
        }
    }
}
