using System;
using System.Threading.Tasks;

namespace Pospa.Azure.IoT.DeviceSimulator.ValueGenerator
{
    public interface ISensorValueGenerator
    {
        public object GetValue(DateTime time);
        public object GetValue(TimeSpan time);
    }
}