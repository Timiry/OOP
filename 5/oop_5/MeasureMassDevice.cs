﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasuringDevice;
using DeviceControl;

namespace oop_5
{
    public class MeasureMassDevice : MeasureDataDevice, IMeasuringDevice
    {
        public MeasureMassDevice(Units unitsToUse)
        {
            this.unitsToUse = unitsToUse;
            measurementType = DeviceType.Mass;
        }

        public override decimal MetricValue()
        {
            if (unitsToUse == Units.Metric)
            {
                return MostRecentMeasure;
            }
            else
            {
                return MostRecentMeasure * 0.4536M;
            }
        }

        public override decimal ImperialValue()
        {
            if (unitsToUse == Units.Imperial)
            {
                return MostRecentMeasure;
            }
            else
            {
                return MostRecentMeasure * 2.2046M;
            }
        }
    }
}
