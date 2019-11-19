using System.Threading.Tasks;

namespace DeviceSimulator
{
    public interface ISensorValueClock
    {
        public Task Tick();
    }
}