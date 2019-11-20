using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    public abstract class SensorSimulator
    {
        private string _description;
        private object _actualValue;
        private string _unit;
        private ISensorValueGenerator _valueGenerator;
        private ISensorValueClock _sensorValueClock;

        public SensorSimulator(ISensorValueGenerator valueGenerator, ISensorValueClock sensorValueClock)
        {
            _valueGenerator = valueGenerator;
            _sensorValueClock = sensorValueClock;
        }

        public bool Init(object defaultValue, string unit = null, string description = null)
        {
            _actualValue = defaultValue;
            _description = description;
            _unit = unit;
            return true;
        }

        public object ActualValue { get => _actualValue; private set => _actualValue = value; }

        public string Description { get => _description; }
      
        public string Unit { get => _unit; }
    }
}
