using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MeasuringDevice;
using DeviceControl;

namespace oop_5
{
    public class MeasureLengthDevice : MeasureDataDevice
    {
        public MeasureLengthDevice(Units unitsToUse, int heartBeatInterval = 1000, string logFileName = "measurements.log")
        {
            measurementType = DeviceType.Length;
            this.unitsToUse = unitsToUse;
            this.HeartBeatInterval = heartBeatInterval;
            this.LoggingFileName = logFileName;
        }

        public override decimal MetricValue()
        {
            if(unitsToUse == Units.Metric)
            {
                return MostRecentMeasure;
            }
            else
            {
                return MostRecentMeasure * 25.4M;
            }
        }

        public override decimal ImperialValue()
        {
            if(unitsToUse == Units.Imperial)
            {
                return MostRecentMeasure;
            }
            else
            {
                return MostRecentMeasure * 0.03937M;
            }
        }
    }
}
