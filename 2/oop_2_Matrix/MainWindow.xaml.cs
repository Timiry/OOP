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

namespace oop_2_Matrix
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

        double[,]? matrix1;
        double[,]? matrix2;
        double[,]? matrixRes;

        private void initializeGrid(Grid grid, double[,] matrix)
        {
            if (grid != null)
            {
                // Reset the grid before doing anything
                grid.Children.Clear();
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                // Get the dimensions
                int columns = matrix.GetLength(1);
                int rows = matrix.GetLength(0);
                // Add the correct number of coumns to the grid
                for (int x = 0; x < columns; x++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40, GridUnitType.Pixel), });
                }
                for (int y = 0; y < rows; y++)
                {
                    // GridUnitType.Star - The value is expressed as a weighted proportion of available space
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel), });
                }
                // Fill each cell of the grid with an editable TextBox containing the value from the matrix 
                for (int x = 0; x < rows; x++)
                {
                    for (int y = 0; y < columns; y++)
                    {
                        double cell = (double)matrix[x, y];
                        TextBox t = new TextBox();
                        t.Text = cell.ToString();
                        t.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        t.SetValue(Grid.RowProperty, x);
                        t.SetValue(Grid.ColumnProperty, y);
                        grid.Children.Add(t);
                    }
                }
            }
        }

        public static double[,] multiplyMatrices(double[,] first, double[,] second)
        {
            
            var result = new double[first.GetLength(0), second.GetLength(1)];
            if (first.GetLength(1) != second.GetLength(0)) throw new ArgumentException("Число колонок первой матрицы должно совпадать с числом строк второй матрицы!");
            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < second.GetLength(1); j++)
                {
                    for (int k = 0; k < second.GetLength(0); k++)
                    {
                        if (first[i, k] < 0) throw new ArgumentException($"Матрица 1 содержит отрицательное значение в строке {i}, столбце {k}");                       
                        if (second[k, j] < 0) throw new ArgumentException($"Матрица 2 содержит отрицательное значение в строке {k}, столбце {j}");                      
                        result[i, j] += Math.Round(first[i, k] * second[k, j], 2);
                    }
                }
            }
            return result;
        }

        private void getValuesFromGrid(Grid grid, double[,] matrix)
        {
            int columns = grid.ColumnDefinitions.Count;
            int rows = grid.RowDefinitions.Count;
            // Iterate over cells in Grid, copying to matrix array
            for (int c = 0; c < grid.Children.Count; c++)
            {
                TextBox t = (TextBox)grid.Children[c];
                int row = Grid.GetRow(t);
                int column = Grid.GetColumn(t);
                matrix[row, column] = double.Parse(t.Text);
            }
        }


        private void btn_FillRandValues_Click(object sender, RoutedEventArgs e)
        {
            if(matrix1 == null || matrix2 == null)
            {
                MessageBox.Show("Сначала введите размеры матриц!"); return;
            }
            for (int i=0; i < matrix1.GetLength(0); i++)
            {
                for (int j=0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = Math.Round(new Random().NextDouble() * 10, 2);
                }
            }
            initializeGrid(grid1, matrix1);
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = Math.Round(new Random().NextDouble() * 10, 2);
                }
            }
            initializeGrid(grid2, matrix2);
        }

        private void matrixDimentions_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_firstRows == null
                || tb_firstCols == null
                || tb_secondRows == null
                || tb_secondCols == null)
                return;
            
            var fr = tb_firstRows.Text;
            var fc = tb_firstCols.Text;
            var sr = tb_secondRows.Text;
            var sc = tb_secondCols.Text;


            if (!(int.TryParse(fr, out var firstRows) & int.TryParse(fc, out var firstCols)
                & int.TryParse(sr, out var secondRows) & int.TryParse(sc, out var secondCols)))
            {
                MessageBox.Show("Неправильный ввод размеров матриц!");
                matrix1 = null;
                matrix1 = null;
                return;
            }
            matrix1 = new double[firstRows, firstCols];
            matrix2 = new double[secondRows, secondCols];
            matrixRes = new double[firstRows, secondCols];

            initializeGrid(grid1, matrix1);
            initializeGrid(grid2, matrix2);
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            getValuesFromGrid(grid1, matrix1);
            getValuesFromGrid(grid2, matrix2);
            try
            {
                matrixRes = multiplyMatrices(matrix1, matrix2);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            initializeGrid(gridRes, matrixRes);
        }
    }
}
