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

namespace oop_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GCD_2_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(first_num.Text, out var a) & int.TryParse(second_num.Text, out var b)))
            {
                MessageBox.Show("Введите целые числа!"); return;
            }
            if (a < 0 || b < 0)
            {
                MessageBox.Show("Введите положительные числа!"); return;
            }

            label_Euclid1.Content = $"НОД по Евклиду: {GCDAlgorithms.FindGCDEuclid(a,b)}";
        }

        private void GCD_3_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(first_num.Text, out var a) & int.TryParse(second_num.Text, out var b) &
                int.TryParse(third_num.Text, out var c)))
            {
                MessageBox.Show("Введите целые числа!"); return;
            }
            if (a < 0 || b < 0 || c < 0)
            {
                MessageBox.Show("Введите положительные числа!"); return;
            }

            label_Euclid1.Content = $"НОД по Евклиду: {GCDAlgorithms.FindGCDEuclid(a, b, c)}";
        }

        private void GCD_4_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(first_num.Text, out var a) & int.TryParse(second_num.Text, out var b) &
                int.TryParse(third_num.Text, out var c) & int.TryParse(fourth_num.Text, out var d)))
            {
                MessageBox.Show("Введите целые числа!"); return;
            }
            if (a < 0 || b < 0 || c < 0 || d < 0)
            {
                MessageBox.Show("Введите положительные числа!"); return;
            }

            label_Euclid1.Content = $"НОД по Евклиду: {GCDAlgorithms.FindGCDEuclid(a, b, c, d)}";
        }

        private void GCD_5_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(first_num.Text, out var a) & int.TryParse(second_num.Text, out var b) &
                int.TryParse(third_num.Text, out var c) & int.TryParse(fourth_num.Text, out var d) & 
                int.TryParse(fifth_num.Text, out var f)))
            {
                MessageBox.Show("Введите целые числа!"); return;
            }
            if (a < 0 || b < 0 || c < 0 || d < 0 || f < 0)
            {
                MessageBox.Show("Введите положительные числа!"); return;
            }

            label_Euclid1.Content = $"НОД по Евклиду: {GCDAlgorithms.FindGCDEuclid(a, b, c, d, f)}";
        }

        private void CompareMethods_btn_Click(object sender, RoutedEventArgs e)
        {
            string[] nums_str = nums_textbox.Text.Split(' ');
            int[] nums_int;
            try
            {
                nums_int = Array.ConvertAll(nums_str, int.Parse);
            }
            catch(FormatException)
            {
                MessageBox.Show("Введите целые числа через пробел!"); return;
            }

            long timeE, timeS;

            label_Euclid2.Content = $"Евклид: {GCDAlgorithms.FindGCDEuclid(out timeE, nums_int)}";
            label_Euclid_time.Content = $"Затраченное время: {timeE}";
            label_Stein.Content = $"Штейн: {GCDAlgorithms.FindGCDStein(out timeS, nums_int)}";
            label_Stein_time.Content = $"Затраченное время: {timeS}";
        }
    }
}
