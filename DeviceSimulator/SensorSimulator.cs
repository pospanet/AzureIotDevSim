using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DeviceSimulator
{
    public abstract class SensorSimulator
    {
        private string _description;
        private object _actualValue;
        private string _unit;
        private string _type;
        private string _id;
        private ISensorValueGenerator _valueGenerator;
        private ISensorValueClock _sensorValueClock;

        public event EventHandler<ValueUpdateResult> ValueUpdateCallback;

        public SensorSimulator(ISensorValueGenerator valueGenerator, ISensorValueClock sensorValueClock)
        {
            _valueGenerator = valueGenerator;
            _sensorValueClock = sensorValueClock;
        }

        public bool Init(object defaultValue, string type, string id, string unit = null, string description = null)
        {
            _actualValue = defaultValue;
            _description = description;
            _unit = unit;
            _type = type;
            _id = id;
            _sensorValueClock.Tick().ContinueWith(t => { ProcessValue(); });
            return true;
        }

        private void ProcessValue()
        {
            DateTime time = DateTime.Now;
            _actualValue = _valueGenerator.GetValue(time);
            ValueUpdateCallback?.Invoke(this, new ValueUpdateResult(_actualValue, time));
            _sensorValueClock.Tick().ContinueWith(t => { ProcessValue(); });
        }

        public object ActualValue { get => _actualValue; private set => _actualValue = value; }

        public string Description { get => _description; }

        public string Unit { get => _unit; }

        public string Type { get => _type; }

        public string Id { get => _id; }
    }

    public class ValueUpdateResult
    {
        internal ValueUpdateResult(object value, DateTime updateTime)
        {
            Value = value;
            ValueUpdateTime = updateTime;
        }
        public object Value { get; private set; }
        public DateTime ValueUpdateTime { get; private set; }
    }
}
