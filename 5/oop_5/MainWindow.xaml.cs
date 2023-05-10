﻿using DeviceControl;
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
        public IMeasuringDevice device = null;

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
            Btn_GetMetricValue.IsEnabled = true;
            Btn_GetImperialValue.IsEnabled = true;
            Btn_GetRawData.IsEnabled = true;
        }

        private void Btn_StartCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StartCollecting();
        }

        private void Btn_StopCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StopCollecting();
        }

        private void Btn_GetMetricValue_Click(object sender, RoutedEventArgs e)
        {
            ListBox_1.Items.Add("Metric value: " + device.MetricValue());
        }

        private void Btn_GetImperialValue_Click(object sender, RoutedEventArgs e)
        {
            ListBox_1.Items.Add("Imperial value: " + device.ImperialValue());
        }

        private void Btn_GetRawData_Click(object sender, RoutedEventArgs e)
        {
            ListBox_1.Items.Add("Row data:");
            foreach(int val in device.GetRawData())
            {
                ListBox_1.Items.Add(val);
            }
        }
    }
}
