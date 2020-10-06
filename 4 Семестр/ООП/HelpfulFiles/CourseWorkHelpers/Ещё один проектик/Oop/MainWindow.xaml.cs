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

namespace Oop { 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs ev)
        {
            Point d = new Point(Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox4.Text));
            Point e = new Point((Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)) / 3 * 2, Convert.ToDouble(textBox3.Text));
            Point b = new Point(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox3.Text));
            Point o = new Point((Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)) / 3 * 2, Convert.ToDouble(textBox4.Text));
            int M = 0;
            Figure f = new Figure(d, e, b, o);
            
            labelS.Content += "Точная площадь фигуры равна " + f.Sfigure().ToString() + "; \n";
            List<Table> result = new List<Table>(5);
            Random random = new Random();
            for (int pow = 3; pow < 8; pow++)
            {
                System.Diagnostics.Stopwatch myStopwatch1 = new System.Diagnostics.Stopwatch();
                myStopwatch1.Start();
                double N = Math.Pow(10, pow);

                M = f.Check(f, N);
                myStopwatch1.Stop();
                result.Add(new Table(N, M, f.S(N, M), myStopwatch1.Elapsed.Milliseconds.ToString(), f.Fault(f, N, M)));
                
            }
        grid.ItemsSource = result;
       
        grid.Columns[0].Header = "N точек, шт";
        grid.Columns[1].Header = "Попаданий точек, шт";
        grid.Columns[2].Header = "Площадь фигуры, кв ед";
        grid.Columns[3].Header = "Время выполнений, мс";
        grid.Columns[4].Header = "Погрешность, %";
        


        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
