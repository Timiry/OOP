using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasuringDevice;
using DeviceControl;
using oop_5;
using System.ComponentModel;
using System.IO;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected DeviceController controller;
        protected DeviceType measurementType;

        private BackgroundWorker dataCollector;
        public int HeartBeatInterval { get; set; }
        public Units UnitsToUse { get; set; }
        public int[] DataCaptured { get; set; }
        public int MostRecentMeasure { get; set; }
        private StreamWriter loggingFileWriter;
        public string LoggingFileName { get; set; }

        //public event HeartBeatEventHandler HeartBeat;
        public event EventHandler NewMeasurementTaken;

        private void GetMeasurements()
        {
            dataCollector = new BackgroundWorker();
            dataCollector.WorkerSupportsCancellation = true;
            dataCollector.WorkerReportsProgress = true;
            dataCollector.DoWork += new DoWorkEventHandler(dataCollector_DoWork);
            dataCollector.ProgressChanged += new ProgressChangedEventHandler(dataCollector_ProgressChanged);
            dataCollector.RunWorkerAsync();
        }

        private void dataCollector_DoWork(object? sender, DoWorkEventArgs e)
        {
            var timer = new Random();
            dataCaptured = new int[10];
            int i = 0;
            while (dataCollector.CancellationPending is false)
            {
                System.Threading.Thread.Sleep(timer.Next(500, 1000));
                dataCaptured[i] = controller.TakeMeasurement();
                MostRecentMeasure = dataCaptured[i];
                //if (!IsCollecting) break;
                if (loggingFileWriter is not null)
                {
                    try
                    {
                        loggingFileWriter.WriteLine($"Measurement - {MostRecentMeasure}");
                    }
                    catch (Exception ex) { }
                }
                dataCollector.ReportProgress(0);
                i++;
                if (i > 9) i = 0;
            }
        }

        private void dataCollector_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            OnNewMeasurementTaken();
        }
        protected virtual void OnNewMeasurementTaken()
        {
            if (NewMeasurementTaken != null)
            {
                NewMeasurementTaken.Invoke(this, null);
            }
         
        }      

        /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value.
        /// </summary>
        /// <returns>The latest measurement from the device converted to metric units.</returns>
        public abstract decimal MetricValue();
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        public abstract decimal ImperialValue();
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        //private void GetMeasurements()
        //{
        //    dataCaptured = new int[10];
        //    System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
        //    {
        //        int x = 0;
        //        Random timer = new Random();

        //        while (controller != null)
        //        {
        //            System.Threading.Thread.Sleep(timer.Next(500, 1000));
        //            dataCaptured[x] = controller != null ?
        //                controller.TakeMeasurement() : dataCaptured[x];
        //            mostRecentMeasure = dataCaptured[x];
        //            x++;
        //            if (x == 10)
        //            {
        //                x = 0;
        //            }
        //        }
        //    });
        //}

        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public void StopCollecting()
        {
            if (dataCollector != null)
            {
                dataCollector.CancelAsync();
            }
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }

        public string GetLoggingFile()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (dataCollector != null)
            {
                dataCollector.Dispose();
            }
        }
    }
}

