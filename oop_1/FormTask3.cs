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
    public partial class FormTask3 : Form
    {
        public FormTask3()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxInput.Text, out var i))
            {
                MessageBox.Show("Ввод не соответствует формату!"); return;
            }
            if (i < 0)
            {
                MessageBox.Show("Введите положительное число!"); return;
            }

            int remainder = 0;
            StringBuilder binary = new StringBuilder();

            do
            {
                remainder = i % 2;
                i /= 2;
                binary.Insert(0, remainder);
            } while (i > 0);

            labelResult.Text = "Результат: " + binary.ToString();
        }
    }
}
