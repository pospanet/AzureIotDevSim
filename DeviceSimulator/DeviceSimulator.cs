using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private readonly IDictionary<string, SensorSimulator> _sensors;

        private const string IoTHubDomain = "azure-devices.net";

        private readonly DeviceClient _client;

        public DeviceSimulator(string deviceId, string iotHub, string deviceKey, DeviceTransportType deviceTransportType, IDictionary<string, SensorSimulator> sensors)
        {
            this._deviceId = deviceId;
            this._iotHub = iotHub;
            this._deviceKey = deviceKey;
            TransportType transportType = GetTransportType(deviceTransportType);
            string hostname = string.Concat(iotHub, '.', IoTHubDomain);
            IAuthenticationMethod authMethod = new DeviceAuthenticationWithRegistrySymmetricKey(_deviceId, _deviceKey);
            _client = DeviceClient.Create(hostname, authMethod, transportType);
            _sensors = sensors;
            IotHubAutoUpdate = true;
            MinimalDataUpdate = false;
        }

        public void Init()
        {
            foreach (KeyValuePair<string, SensorSimulator> sensor in _sensors)
            {
                sensor.Value.ValueUpdateCallback += UpdateSensorValue;
            }
        }

        private void UpdateSensorValue(object sensor, ValueUpdateResult result)
        {
            string sensorName = _sensors.FirstOrDefault(pair => pair.Value == sensor).Key;
            if(IotHubAutoUpdate)
            {
                SendDataToIoTHub(sensorName, result);
            }
        }

        private void SendDataToIoTHub(string sensorName, ValueUpdateResult result)
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// If true, device will automaticaly set data update to IoT hub, if connected
        /// </summary>
        public bool IotHubAutoUpdate { get; set; }

        /// <summary>
        /// If true, device wil sent just sensor value updates, else full set of all sensor data
        /// </summary>
        public bool MinimalDataUpdate { get; set; }

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
