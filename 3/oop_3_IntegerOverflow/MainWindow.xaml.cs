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

namespace oop_3_IntegerOverflow
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

        private void btn_multiply_Click(object sender, RoutedEventArgs e)
        {
            int num1, num2, res;
            if (!int.TryParse(tb_num1.Text, out num1) || !int.TryParse(tb_num2.Text, out num2))
            {
                MessageBox.Show("Неправильный ввод!"); return;
            }

            try
            {
                res = checked(num1 * num2);
                label_res.Content = $"Результат: {res}";
            }
            catch(OverflowException ex)
            {
                MessageBox.Show($"Произошло переполнение! \n{ex.Message}");
            }
        }
    }
}
