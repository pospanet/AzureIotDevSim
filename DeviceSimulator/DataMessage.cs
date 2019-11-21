using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    [JsonObject]
    public class DataMessage
    {
        public DataMessage()
        {
            SensorData = new SensorData[0];
        }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Location")]
        public string Location { get; set; }
        [JsonProperty("name")]
        public SensorData[] SensorData { get; set; }
    }

    [JsonObject]
    public class SensorData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("Unit")]
        public string Unit { get; set; }
    }
}
