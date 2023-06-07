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
using System.Threading;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected DeviceController controller;
        protected DeviceType measurementType;

        private BackgroundWorker dataCollector;
        private BackgroundWorker heartBeatTimer;
        public bool Disposed { get; set; } = false;
        protected bool IsCollecting { get; set; }
        public int HeartBeatInterval { get; set; }
        public Units UnitsToUse { get; set; }
        public int[] DataCaptured { get; set; }
        public int MostRecentMeasure { get; set; }
        private StreamWriter loggingFileWriter;
        public string LoggingFileName { get; set; }

        public event HeartBeatEventHandler HeartBeat;
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
                if (IsCollecting == false) break;
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

        public void OnHeartBeat()
        {
            if(HeartBeat != null)
            {
                HeartBeat(this, new HeartBeatEventArgs());
            }
        }

        private void StartHeartBeat()
        {
            heartBeatTimer = new BackgroundWorker();
            heartBeatTimer.WorkerSupportsCancellation = true;
            heartBeatTimer.WorkerReportsProgress = true;
            heartBeatTimer.DoWork += (o, args) =>
            {
                while (true)
                {
                    Thread.Sleep(HeartBeatInterval);
                    if (Disposed == true) break;
                    heartBeatTimer.ReportProgress(0);
                }
            };
            heartBeatTimer.ProgressChanged += (o, args) => OnHeartBeat();
            heartBeatTimer.RunWorkerAsync();
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
            IsCollecting = true;
            GetMeasurements();
            StartHeartBeat();
        }

        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public void StopCollecting()
        {
            IsCollecting = false;
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
            Disposed = true;
            if (dataCollector != null)
            {
                dataCollector.Dispose();
            }
            if(heartBeatTimer != null)
            {
                heartBeatTimer.Dispose();
            }
        }
    }
}