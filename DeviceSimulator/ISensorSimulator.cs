using System.Threading.Tasks;

namespace DeviceSimulator
{
    public interface ISensorSimulator
    {
        public object GetValue();
        public Task Tick();
    }
}