using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceSimulator.ValueGenerator
{
    public class RandomGpsValueGenerator : ISensorValueGenerator
    {
        #region ISensorValueGenerator
        public object GetValue(DateTime time)
        {
            throw new NotImplementedException();
        }

        public object GetValue(TimeSpan time)
        {
            throw new NotImplementedException();
        }
        #endregion

        public object GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
