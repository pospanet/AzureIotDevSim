using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator
{
    public class AssetManagementHelper
    {
        private readonly string _iotHub;
        private readonly string _sasKey;
        public AssetManagementHelper(string iotHub, string sasKey)
        {
            _iotHub = iotHub;
            _sasKey = sasKey;
        }

    }
}
