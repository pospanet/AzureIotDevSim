using System.Threading.Tasks;

namespace Pospa.Azure.IoT.DeviceSimulator.SensorClock
{
    public interface ISensorValueClock
    {
        public Task Tick();
    }
}