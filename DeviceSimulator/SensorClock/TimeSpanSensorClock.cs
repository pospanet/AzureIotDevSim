using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSimulator.SensorClock
{
    public class TimeSpanSensorClock : ISensorValueClock
    {
        private readonly TimeSpan _time;

        public TimeSpanSensorClock(TimeSpan time)
        {
            _time = time;
        }
        public Task Tick()
        {
            return Task.Delay(_time);
        }
    }
}
