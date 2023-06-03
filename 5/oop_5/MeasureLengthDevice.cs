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
    public class MeasureLengthDevice : MeasureDataDevice, IMeasuringDevice
    {
        public MeasureLengthDevice(Units unitsToUse)
        {
            this.unitsToUse = unitsToUse;
            measurementType = DeviceType.Length;
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
