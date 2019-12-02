using Microsoft.Azure.Devices;

namespace Pospa.Azure.IoT.DeviceSimulator
{
    public class DeviceSignature
    {
        internal DeviceSignature(Device device)
        {
            Id = device.Id;
            PrimaryKey = device.Authentication.SymmetricKey.PrimaryKey;
            SecondaryKey = device.Authentication.SymmetricKey.SecondaryKey;
        }

        public string Id { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
    }
}