using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceSimulator;
using Microsoft.Azure.Devices;

namespace Pospa.Azure.IoT.DeviceSimulator
{
    public class AssetManagementHelper
    {
        private readonly string _iotHub;
        private readonly string _connectionString;

        private RegistryManager _registryManager;

        public AssetManagementHelper(string iotHub, string connectionString)
        {
            _iotHub = iotHub;
            _connectionString = connectionString;
            _registryManager = RegistryManager.CreateFromConnectionString(_connectionString);
        }
        public async Task<DeviceSignature[]> CreateDevices(string[] Ids)
        {
            await _registryManager.OpenAsync();
            IEnumerable<Task<Device>> deviceTaskList = Ids.Select(async id => await _registryManager.AddDeviceAsync(new Device(id)));
            Task.WaitAll(deviceTaskList.ToArray());
            IEnumerable<Device> devices = deviceTaskList.Select(task => task.Result);
            await _registryManager.CloseAsync();
            return devices.Select(d => new DeviceSignature(d)).ToArray();
        }

        public async Task<DeviceSignature> GetDevice(string id)
        {
            await _registryManager.OpenAsync();
            Device device = await _registryManager.GetDeviceAsync(id);
            await _registryManager.CloseAsync();
            return new DeviceSignature(device);
        }

        public async Task DeleteDevice(string id)
        {
            await _registryManager.OpenAsync();
            await _registryManager.RemoveDeviceAsync(id);
            await _registryManager.CloseAsync();
        }
    }
}
