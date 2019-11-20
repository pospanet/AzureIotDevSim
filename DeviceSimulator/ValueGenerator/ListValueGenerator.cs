using System;
using System.Collections;
using System.Text;

namespace DeviceSimulator.ValueGenerator
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
            T value = _valuesEnumerator.Current;
            if (!_valuesEnumerator.MoveNext())
            {
                _valuesEnumerator.Reset();
            }
            return value;
        }
    }
}
