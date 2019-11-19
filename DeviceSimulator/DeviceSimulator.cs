using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace DeviceSimulator
{
    public class DeviceSimulator : IDisposable
    {
        private readonly string _deviceId;
        private readonly string _iotHub;
        private readonly string _deviceKey;

        private const string ConnectionStringPatern = "HostName={0}.azure-devices.net;DeviceId={1};SharedAccessKey={2}";

        private readonly DeviceClient _client;

        public DeviceSimulator(string deviceId, string iotHub, string deviceKey, DeviceTransportType deviceTransportType, IDictionary<string, ISensorSimulator sensors)
        {
            this._deviceId = deviceId;
            this._iotHub = iotHub;
            this._deviceKey = deviceKey;
            string connectionString = ComposeConnectionString(_deviceId, _iotHub, _deviceKey);
            TransportType transportType = GetTransportType(deviceTransportType);
            _client = DeviceClient.CreateFromConnectionString(connectionString, _deviceId, transportType);
        }

        public async Task<bool> Connect()
        {
            try
            {
                await _client.OpenAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Disconnect()
        {
            try
            {
                await _client.CloseAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string ComposeConnectionString(string deviceId, string iotHub, string deviceKey)
        {
            return string.Format(ConnectionStringPatern, iotHub, deviceId, deviceKey);
        }

        private static TransportType GetTransportType(DeviceTransportType deviceTransportType)
        {
            switch (deviceTransportType)
            {
                case DeviceTransportType.Http:
                    return TransportType.Http1;
                    break;
                case DeviceTransportType.Amqp:
                    return TransportType.Amqp;
                    break;
                case DeviceTransportType.Mqtt:
                    return TransportType.Mqtt;
                    break;
                default:
                    return TransportType.Amqp;
                    break;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }

    public enum DeviceTransportType
    {
        Http,
        Amqp,
        Mqtt
    }
}
