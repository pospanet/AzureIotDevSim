using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pospa.Azure.IoT.DeviceSimulator.SensorClock
{
    public class RandomTimeSpanSensorClock : ISensorValueClock
    {
        private readonly TimeSpan _minTime;
        private readonly TimeSpan _maxTime;

        private readonly Random _random;

        public RandomTimeSpanSensorClock(TimeSpan minTime, TimeSpan maxTime)
        {
            _random = new Random();
            _minTime = minTime;
            _maxTime = maxTime;
        }
        public Task Tick()
        {
            TimeSpan timeDelay = ((_maxTime - _minTime) * _random.NextDouble()) + _minTime;
            return Task.Delay(timeDelay);
        }
    }
}
