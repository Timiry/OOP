using DeviceControl;
using MeasuringDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace oop_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox_DeviceType.Items.Add("Mass");
            ComboBox_DeviceType.Items.Add("Length");
            ComboBox_Units.Items.Add("Metric");
            ComboBox_Units.Items.Add("Imperial");
        }

        public DeviceType devType;
        public Units units;
        public IEventEnabledMeasuringDevice device = null;
        public event EventHandler NewMeasurementTaken;

        private void ComboBox_DeviceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_DeviceType.SelectedItem.ToString() == "Mass")
            {
                devType = DeviceType.Mass;
            }
            if (ComboBox_DeviceType.SelectedItem.ToString() == "Length")
            {
                devType = DeviceType.Length;
            }
        }

        private void ComboBox_Units_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_Units.SelectedItem.ToString() == "Metric")
            {
                units = Units.Metric;
            }
            if (ComboBox_Units.SelectedItem.ToString() == "Imperial")
            {
                units = Units.Imperial;
            }
        }

        private void Btn_CreateInstance_Click(object sender, RoutedEventArgs e)
        {
            if(devType == DeviceType.Mass)
            {
                device = new MeasureMassDevice(units);
            }
            if (devType == DeviceType.Length)
            {
                device = new MeasureLengthDevice(units);
            }

            Btn_StartCollecting.IsEnabled = true;
            Btn_StopCollecting.IsEnabled = true;
            Btn_Dispose.IsEnabled = true;
        }

        private void Btn_StartCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StartCollecting();
            NewMeasurementTaken = new EventHandler(device_NewMeasurementTaken);
            device.NewMeasurementTaken += NewMeasurementTaken;
            device.HeartBeat += (o, args) => Label_heartBeatTimeStamp.Content = $"HeartBeat Timestamp: {args.TimeStamp}";
        }

        private void device_NewMeasurementTaken(object? sender, EventArgs e)
        {
            if(device != null)
            {
                Tb_mostRecentMeasure.Text = device.MostRecentMeasure.ToString();
                Tb_metricValue.Text = device.MetricValue().ToString();
                Tb_imperialValue.Text = device.ImperialValue().ToString();
                ListBox_rawDataValues.ItemsSource = null;
                ListBox_rawDataValues.ItemsSource = device.GetRawData();
            }
        }

        private void Btn_StopCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StopCollecting();
            device.NewMeasurementTaken -= NewMeasurementTaken;
        }


        private void Btn_Dispose_Click(object sender, RoutedEventArgs e)
        {
            device.Dispose();
        }
    }
}
