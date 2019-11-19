using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    public abstract class SensorSimulator<T> : ISensorSimulator
    {
        private string _description;
        private T _actualValue;
        private string _unit;
        private ISensorValueGenerator<T> _valueGenerator;
        private ISensorValueClock _sensorValueClock;

        public SensorSimulator(ISensorValueGenerator<T> valueGenerator, ISensorValueClock sensorValueClock)
        {
            _valueGenerator = valueGenerator;
            _sensorValueClock = sensorValueClock;
        }

        public bool Init(T defaultValue, string unit = null, string description = null)
        {
            _actualValue = defaultValue is null ? default(T) : defaultValue;
            _description = description;
            _unit = unit;
            return true;
        }

        public T ActualValue { get => _actualValue; private set => _actualValue = value; }

        public string Description { get => _description; }
        public string Unit { get => _unit; }
    }
}
