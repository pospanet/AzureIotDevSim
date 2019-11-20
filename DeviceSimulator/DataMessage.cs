using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    public class DataMessage
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public SensorData[] SensorData { get; set; }
    }

    public class SensorData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}
