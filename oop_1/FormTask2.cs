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
    public partial class FormTask2 : Form
    {
        public FormTask2()
        {
            InitializeComponent();
        }

        int iter = 0;
        decimal iterGuess, iterResult, res;
        /// <summary>
        /// При нажатии кнопки "Вычислить" выводятся значения корня,
        /// найденные методом Ньютона и встроенной функцией Math.Sqrt
        /// </summary>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // находим корень с помощью Math.Sqrt 
            if (!(double.TryParse(textBoxInput.Text, out var numDouble)))
            {
                MessageBox.Show("Введите число!"); return;
            }
            if (numDouble < 0)
            {
                MessageBox.Show("Введите положительное число!"); return;
            }
            double squareRoot = Math.Sqrt(numDouble);
            labelMathSqrt.Text = "С помощью Math.Sqrt: " + squareRoot;

            // находим корень методом Ньютона
            if (!(decimal.TryParse(textBoxInput.Text, out var numDecimal)))
            {
                MessageBox.Show("Введите число!"); return;
            }

            decimal delta = Convert.ToDecimal(Math.Pow(10, -28));
            decimal guess = numDecimal / 2;
            decimal result = ((numDecimal / guess) + guess) / 2;

            while(Math.Abs(result - guess) > delta)
            {
                guess = result;
                result = ((numDecimal / guess) + guess) / 2;
            }
            labelNewton.Text = "С помощью метода Ньютона: " + result;
        }

        /// <summary>
        /// при нажатии на кнопку "Выполнить итерацию"
        /// то же самое, что и в методе Ньютона, но без цикла
        /// </summary>
        private void buttonNewtonIter_Click(object sender, EventArgs e)
        {
            if (!(decimal.TryParse(textBoxInput.Text, out var numDecimal)))
            {
                MessageBox.Show("Введите число!"); return;
            }
            if (numDecimal < 0)
            {
                MessageBox.Show("Введите положительное число!"); return;
            }

            if (iter == 0)
            {
                iterGuess = numDecimal / 2;
                iterResult = ((numDecimal / iterGuess) + iterGuess) / 2;
                var guess = iterGuess;
                var result = iterResult;
                decimal delta = Convert.ToDecimal(Math.Pow(10, -28));
                while (Math.Abs(result - guess) > delta)
                {
                    guess = result;
                    result = ((numDecimal / guess) + guess) / 2;
                }
                res = result;
            }
            else
            {
                iterGuess = iterResult;
                iterResult = ((numDecimal / iterGuess) + iterGuess) / 2;
            }
            iter++;

            labelIterNum.Text = "Итераций: " + iter;
            labelInaccuracy.Text = "Погрешность: " + (decimal)Math.Abs(res - iterResult);
            labelSqrtOnIter.Text = "Значение на текущей итерации: " + iterResult;
        }

        /// <summary>
        /// при нажатии на кнопку "Сбросить" обнуляем счетчик итераций
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            iter = 0;
            labelIterNum.Text = "Итераций: ";
            labelInaccuracy.Text = "Погрешность: ";
            labelSqrtOnIter.Text = "Значение на текущей итерации: ";
        }

        /// <summary>
        /// переход к форме третьего задания
        /// </summary>
        private void buttonToTask3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTask3 f3 = new FormTask3();
            f3.ShowDialog();
        }
    }
}
