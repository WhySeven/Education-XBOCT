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

namespace KursOOP
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double SRect = (Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)) * (Convert.ToDouble(textBox3.Text) - Convert.ToDouble(textBox4.Text));
            double[,] coordinates = new double[4, 2];
            coordinates[0, 0] = Convert.ToDouble(textBox1.Text);
            coordinates[0, 1] = Convert.ToDouble(textBox3.Text);
            coordinates[3, 0] = Convert.ToDouble(textBox2.Text);
            coordinates[3, 1] = Convert.ToDouble(textBox4.Text);
            coordinates[1, 0] = (Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)) / 3 * 2;
            coordinates[1, 1] = Convert.ToDouble(textBox3.Text);
            coordinates[2, 0] = (Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)) / 3 * 2;
            coordinates[2, 1] = Convert.ToDouble(textBox4.Text);
            double Sfigure = (coordinates[1, 0] - coordinates[0, 0]) * (coordinates[0, 1] - coordinates[2, 1]) / 2 + Math.PI * Math.Pow(coordinates[3, 0] - coordinates[2, 0], 2) / 4;
            LabelS.Content = "Точная площадь фигуры равна " + Sfigure.ToString() + "; \n";

            bool check;
            Random random = new Random();
            double[,] c = new double[1, 2];
            List<Table> result = new List<Table>(5);
            for (int pow = 3; pow < 8; pow++)
            {
                int M = 0;
                double N = Math.Pow(10, pow);
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                for (int i = 0; i < N; i++)
                {

                    c[0, 0] = random.NextDouble() + random.Next(Convert.ToInt32(coordinates[0, 0]), Convert.ToInt32(coordinates[3, 0]));
                    c[0, 1] = random.NextDouble() + random.Next(Convert.ToInt32(coordinates[3, 1]), Convert.ToInt32(coordinates[0, 1]));
                    check = Check(c, coordinates);

                    if (check == true)
                    {
                        M++;
                    }
                }
                myStopwatch.Stop();
                result.Add(new Table(N, M, Math.Round((SRect * M / N), 3), myStopwatch.Elapsed.Milliseconds.ToString(), Math.Abs(Math.Round((Sfigure - (SRect * M / N)) / (SRect * M / N) * 100, 3))));
            }
            grid.ItemsSource = result;
            grid.Columns[0].Header = "N точек, шт";
            grid.Columns[1].Header = "Попаданий точек, шт";
            grid.Columns[2].Header = "Площадь фигуры, кв ед";
            grid.Columns[3].Header = "Время выполнений, мс";
            grid.Columns[4].Header = "Погрешность, %";
            

        }

        public bool Check(double[,] c, double[,] coord)
        {
            bool check = false;
            if (c[0, 0] < coord[1, 0])
            {
                double first = (coord[0, 0] - c[0, 0]) * (coord[1, 1] - coord[0, 1]) - (coord[1, 0] - coord[0, 0]) * (coord[0, 1] - c[0, 1]);
                double second = (coord[1, 0] - c[0, 0]) * (coord[2, 1] - coord[1, 1]) - (coord[2, 0] - coord[1, 0]) * (coord[1, 1] - c[0, 1]);
                double third = (coord[2, 0] - c[0, 0]) * (coord[0, 1] - coord[2, 1]) - (coord[0, 0] - coord[2, 0]) * (coord[2, 1] - c[0, 1]);
                if (first > 0 && second > 0 && third > 0)
                {
                    check = true;
                }
                else if (first < 0 && second < 0 && third < 0)
                {
                    check = true;
                }
                else if (first == 0 && second == 0 && third == 0)
                {
                    check = true;
                }
                /*
                (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0)
                (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0)
                (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0)
                */
            }
            else if (c[0, 0] >= coord[2, 0])
            {
                double centerY = coord[2, 1];
                double centerX = coord[2, 0];
                //(a-x)^2 + (b-y)^2 < R^2
                if (Math.Pow((centerX - c[0, 0]), 2) + Math.Pow((centerY - c[0, 1]), 2) <= Math.Pow((coord[3, 0] - coord[2, 0]), 2))
                {
                    check = true;
                }
            }

            return check;
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
