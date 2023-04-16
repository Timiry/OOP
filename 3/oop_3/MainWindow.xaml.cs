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

namespace oop_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int tests = 0;

        private void btn_Shutdown_Click(object sender, RoutedEventArgs e)
        {
            tests++;
            textBlock1.Text += $"\n test {tests} \n" ;
            Switch sw = new Switch();
            sw.DisconnectPowerGenerator(textBlock1);
            sw.VerifyPrimaryCoolantSystem(textBlock1);
            sw.VerifyBackupCoolantSystem(textBlock1);
            sw.GetCoreTemperature(textBlock1);
            sw.InsertRodCluster(textBlock1);
            sw.GetRadiationLevel(textBlock1);
            sw.SignalShutdownComplete(textBlock1);
        }
    }
}
