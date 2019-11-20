using System;
using System.Threading.Tasks;

namespace DeviceSimulator
{
    public interface ISensorValueGenerator
    {
        public object GetValue(DateTime time);
        public object GetValue(TimeSpan time);
    }
}