using System;
using System.Threading.Tasks;

namespace DeviceSimulator
{
    public interface ISensorValueGenerator<T>
    {
        public T GetValue(DateTime time);
        public T GetValue(TimeSpan time);
    }
}