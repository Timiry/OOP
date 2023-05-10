using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControl
{
    public class DeviceController : IDisposable
    {
        public DeviceType MeasurementType;
        public static DeviceController StartDevice(DeviceType MeasurementType)
        {
            DeviceController controller = new DeviceController();
            controller.MeasurementType = MeasurementType;
            return controller;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the controlled device.
        /// </summary>
        public DeviceController StopDevice()
        {
            return null;
        }

        /// <summary>
        /// Forces the controlled device to record a measurement.
        /// </summary>
        /// <returns>The measurement taken by the device.</returns>
        public int TakeMeasurement()
        {
            Random value = new Random();
            return value.Next(0, 100);
        }
    }

    public enum DeviceType
    {
        Length, Mass
    }
}