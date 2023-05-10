using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_1
{
    public partial class FormTask1 : Form
    {
        public FormTask1()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if(double.TryParse(textBoxEnter.Text, out var num))
            {
                MessageBox.Show($"Вещественное число: {num}");
            }
            else
            {
                MessageBox.Show($"Неправильный формат вещественного числа!");
            }
        }

        // переход к форме второго задания
        private void buttonToTask2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTask2 f2 = new FormTask2();
            f2.ShowDialog();
        }
    }
}
