using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace CH_M
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x0, y0, xn, h;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true || checkBox2.IsChecked == true)
            {
                try
                {
                    x0 = Convert.ToDouble(textBox1.Text);
                    y0 = Convert.ToDouble(textBox2.Text);
                    xn = Convert.ToDouble(textBox3.Text);
                    h = Convert.ToDouble(textBox4.Text);
                    if (x0 >= xn)
                    {
                        MessageBox.Show("Первое значение х должно быть меньше последнего", "Ошибка");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный формат данных.", "Ошибка");
                    return;
                }
                if (checkBox2.IsChecked == true)
                {
                    Runge();
                }
                else if (Math.Abs((xn - x0) / h) < 4)
                {
                    MessageBox.Show("В методе Адамса первые 4 значения (начальный отрезок) находятся любым другим методом (Рунге-Кутты для этого приложения).\nЧтобы увидеть значения, вычисленные методом Адамаса, увеличьте правую границу или уменьшите шаг, так, чтобы |(Xn-Xo)|/h было больше или равно 4", "Внимание!");
                    Adams();
                }
                else
                    Adams();
            }
            else
                MessageBox.Show("Выберете метод решения", "Ошибка");
        }

        private void Adams()
        {
            double double_h = 2 * h;
            double y = y0;
            double[] start_segment = new double[4];//массив для хранения значений начально отрезка для метода Адамса
            //поиск значений начального отрезка (методом рунге-кутты)
            for (var i = x0; i < x0 + (5 * h); i += double_h)
            {
                int index = Convert.ToInt32((i - x0) / double_h);
                start_segment[index] = y;//Значение y для началального отрезка
                double k1 = double_h * F(i, y);
                double k2 = h * F(i + double_h / 2, y + k1 / 2);
                double k3 = h * F(i + double_h / 2, y + k2 / 2);
                double k4 = h * F(i + double_h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            }
            start_segment[3] = y;//значение y3 для начального отрезка
            //расчет q0, q1, q2, q3
            double[] q = new double[] { double_h * F(x0, start_segment[0]), double_h * F(x0 + double_h, start_segment[1]), double_h * F(x0 + (double_h * 2), start_segment[2]), double_h * F(x0 + 3 * double_h, start_segment[3]) };
            //расчет delta q0, delta q1, delta q2
            double[] d_q = new double[] { q[1] - q[0], q[2] - q[1], q[3] - q[2] };
            //расчет delta^2 q0, delta^2 q1
            double[] dd_q = new double[] { d_q[1] - d_q[0], d_q[2] - d_q[1] };
            //расчет delta^3 q0
            double ddd_q = dd_q[1] - dd_q[0];
            double[] H = new double[Convert.ToInt32(Math.Abs((xn - x0) / double_h) + 1)];
            for (var i = x0 + (double_h * 3); i < xn - h; i += double_h)
            {
                int index = Convert.ToInt32((i + double_h) / double_h);
                start_segment[3] += q[3] + 0.5 * d_q[2] + (5 * dd_q[1] / 12) + (3 * ddd_q / 8);//расчет следующего y по формуле Адамаса
                H[index] = start_segment[3];
                //сдвиг начального отрезка y0=y1 y1=y2 y2=y3
                start_segment[0] = start_segment[1]; start_segment[1] = start_segment[2]; start_segment[2] = start_segment[3];
                //сдвиг q, поиск q3
                q[0] = q[1]; q[1] = q[2]; q[2] = q[3]; q[3] = h * F(i + double_h, start_segment[3]);
                //сдвиг delta q, delta^2 q, delta^3 q
                d_q[0] = q[1] - q[0]; d_q[1] = q[2] - q[1]; d_q[2] = q[3] - q[2];
                dd_q[0] = d_q[1] - d_q[0]; dd_q[1] = d_q[2] - d_q[1];
                ddd_q = dd_q[1] - dd_q[0];
            }

            List<MyTable> result = new List<MyTable>(Convert.ToInt32(Math.Abs((xn - x0) / h) + 1));
            Stopwatch timer = new Stopwatch();
            double[] _y = new double[Convert.ToInt32(Math.Abs((xn - x0) / h) + 1)]; //массив значений функции для оценки погрешности рассчета первых 4-х значений 
            result.Add(new MyTable(0, x0, y0, "0"));//добавляем первую строку в таблицу с известными значениями
            double half_h = h / 2;//половинный шаг для оценки погрешности
            y = y0;
            /*рассчет 'y' с половинным шагом для оценки погрешности метода Рунге-Кутты*/
            for (var i = x0; i < x0+(2.5*h); i += half_h)
            {
                int index = Convert.ToInt32((i - x0) / half_h);
                double k1 = half_h * F(i, y);
                double k2 = half_h * F(i + half_h / 2, y + k1 / 2);
                double k3 = half_h * F(i + half_h / 2, y + k2 / 2);
                double k4 = half_h * F(i + half_h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;

                if (index % 2 == 0)
                    _y[index/ 2] = y; //добавляем в массив каждое второе значение
            }
            y = y0;

            timer.Start();
            //поиск значений начального отрезка (методом рунге-кутты)
            for (var i = x0; i < x0+(2.5*h); i += h)
            {
                int index = Convert.ToInt32((i - x0) / h);
                start_segment[index] = y;//Значение y для началального отрезка
                double k1 = h * F(i, y);
                double k2 = h * F(i + h / 2, y + k1 / 2);
                double k3 = h * F(i + h / 2, y + k2 / 2);
                double k4 = h * F(i + h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                result.Add(new MyTable(index + 1, Math.Round(i + h, 5), Math.Round(y, 5), Convert.ToString(Math.Round(Math.Abs(y - _y[index]) / 15, 5))));
            }
            start_segment[3] = y;//значение y3 для начального отрезка
            //расчет q0, q1, q2, q3
            q = new double[] { h * F(x0, start_segment[0]), h * F(x0+ h, start_segment[1]), h * F(x0 + (h * 2), start_segment[2]), h * F(x0 + 3 * h, start_segment[3]) };
            //расчет delta q0, delta q1, delta q2
            d_q = new double[] {q[1] - q[0], q[2] - q[1], q[3] - q[2]};
            //расчет delta^2 q0, delta^2 q1
            dd_q = new double[] {d_q[1] - d_q[0], d_q[2] - d_q[1]};
            //расчет delta^3 q0
            ddd_q = dd_q[1]-dd_q[0];

            for (var i = x0+(h*3); i < xn-half_h; i += h)
            {
                int index = Convert.ToInt32((i +h)/ h);
                start_segment[3] += q[3] + 0.5 * d_q[2] + (5 * dd_q[1] / 12) + (3 * ddd_q / 8);//расчет следующего y по формуле Адамаса
                
                if (index > 7 && index % 2 == 0)
                {
                    result.Add(new MyTable(index, Math.Round(i + h, 5), Math.Round(start_segment[3], 5), Convert.ToString(Math.Round(Math.Abs(H[index%8]-start_segment[3])/15, 5))));//добавление результатов в список
                }
                else
                {
                    result.Add(new MyTable(index, Math.Round(i + h, 5), Math.Round(start_segment[3], 5), ""));//добавление результатов в список
                }
                //сдвиг начального отрезка y0=y1 y1=y2 y2=y3
                start_segment[0] = start_segment[1]; start_segment[ 1] = start_segment[2]; start_segment[2] = start_segment[3];
                //сдвиг q, поиск q3
                q[0] = q[1]; q[1]= q[2]; q[2] = q[3]; q[3] = h * F(i + h, start_segment[3]);
                //сдвиг delta q, delta^2 q, delta^3 q
                d_q[0] = q[1] - q[0]; d_q[1] = q[2] - q[1]; d_q[2] = q[3] - q[2];
                dd_q[0] = d_q[1] - d_q[0]; dd_q[1] = d_q[2] - d_q[1];
                ddd_q = dd_q[1] - dd_q[0];
            }
            timer.Stop();
            label.Content = timer.Elapsed.TotalMilliseconds + " мс";
            grid.ItemsSource = result;
            grid.Columns[0].Header = "#";
            grid.Columns[1].Header = "X";
            grid.Columns[2].Header = "Y";
            grid.Columns[3].Header = "Погрешность";
        }

        private void Runge()
        {
            List < MyTable > result= new List<MyTable>(Convert.ToInt32(Math.Abs((xn - x0) / h)+1));
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double half_h = h / 2;
            double[] _y = new double[Convert.ToInt32(Math.Abs((xn-x0)/h)+1)];
            double y = y0;
            result.Add(new MyTable(0, x0, y0, "0"));
            for (var i = x0; i < xn-half_h; i+=half_h)
            {
                int index = Convert.ToInt32((i - x0 )/ half_h);
                double k1 = half_h * F(i, y);
                double k2 = half_h * F(i + half_h / 2, y + k1/2);
                double k3 = half_h * F(i + half_h / 2, y + k2/2);
                double k4 = half_h * F(i + half_h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4)/ 6;

                if (index % 2 == 0)
                    _y[index/2] = y;
            }
            y = y0;
            for (var i = x0; i < xn-half_h; i+=h)
            {
                int index = Convert.ToInt32((i - x0) / h);
                double k1 = h*F(i, y);
                double k2 = h*F(i + h / 2, y + k1/ 2);
                double k3 = h * F(i + h / 2, y + k2 / 2);
                double k4 = h * F(i + h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4)/ 6;
                result.Add(new MyTable(index+1, Math.Round(i+h,5), Math.Round(y,5), Convert.ToString(Math.Round(Math.Abs(y - _y[index]) / 15, 5))));
            }
            timer.Stop();
            grid.ItemsSource = result;
            grid.Columns[0].Header = "#";
            grid.Columns[1].Header = "X";
            grid.Columns[2].Header = "Y";
            grid.Columns[3].Header = "Погрешность";
            label.Content = timer.Elapsed.TotalMilliseconds + " мс";
        }

        private double F(double x, double y) => 2*Math.Pow(x, 2)+Math.Pow(Math.E, y)+y;

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox2.IsChecked = false;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
        }
    }
}
