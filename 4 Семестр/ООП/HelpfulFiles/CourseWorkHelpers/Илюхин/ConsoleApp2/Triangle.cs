using System;
using System.Diagnostics;

namespace ООП
{
    class Triangle
    {
        Point g;
        Point e;
        Point f;
        public Triangle()
        {
            Comands();
        }
        public Triangle(Point _g, Point _e, Point _f)
        {
            g = new Point(_g);
            e = new Point(_e);
            f = new Point(_f);
            if (!isItGEF())
            {
                g = new Point(5, 15);
                e = new Point(25, 20);
                f = new Point(15, 5);
            }
        }
        public Triangle(Triangle t)
        {
            g = new Point(t.g);
            e = new Point(t.e);
            f = new Point(t.f);
        }
        private double realSquare()
        {
            double ge = Math.Sqrt(Math.Pow(e.X - g.X, 2) + Math.Pow(e.Y - g.Y, 2));
            double gf = Math.Sqrt(Math.Pow(f.X - g.X, 2) + Math.Pow(g.Y - f.Y, 2));
            double ef = Math.Sqrt(Math.Pow(e.X - f.X, 2) + Math.Pow(e.Y - f.Y, 2));
            double p = ( ge + gf + ef ) / 2;
            return Math.Sqrt(p * ( p - ge ) * ( p - gf ) * ( p - ef ));
        }
        private double monteCarloSquare(int N, ref int M)
        {
            double k_ge = ( e.Y - g.Y ) / ( e.X - g.X );
            double b_ge = g.Y - g.X * ( e.Y - g.Y ) / ( e.X - g.X );
            double k_gf = ( f.Y - g.Y ) / ( f.X - g.X );
            double b_gf = g.Y - g.X * ( f.Y - g.Y ) / ( f.X - g.X );
            double k_ef = ( f.Y - e.Y ) / ( f.X - e.X );
            double b_ef = e.Y - e.X * ( f.Y - e.Y ) / ( f.X - e.X );
            Random random = new Random();
            double k = 1.0000000000000002;
            for (int i = 0; i < N; i++)
            {
                double x = ( random.NextDouble() * k * ( e.X - g.X ) ) + g.X;
                double y = ( random.NextDouble() * k * ( e.Y - f.Y ) ) + f.Y;
                if (y <= k_ge * x + b_ge && ( ( x < f.X && y >= k_gf * x + b_gf ) || ( x > f.X && y >= k_ef * x + b_ef ) || x == f.X ))
                    M++;
            }
            return ( (double)M / (double)N ) * ( e.X - g.X ) * ( e.Y - f.Y );
        }
        private bool isItGEF()
        {
            return g != null && e != null && f != null && g.X < f.X && f.X < e.X && g.Y > f.Y && e.Y > g.Y;
        }
        private void getValuesForTrin()
        {
            Console.WriteLine("Использовать значения по умолчанию? Введите \"да\" для согласия или что угодно для ручного ввода.");
            string comand = Console.ReadLine().ToLower();
            if (comand == "да")
            {
                g = new Point(5, 15);
                e = new Point(25, 20);
                f = new Point(15, 5);
                Comands();
                return;
            }
            bool first_input = true;
            string s = "GEF";
            while (first_input || !isItGEF())
            {
                Console.WriteLine("Введите через пробел координаты x и y для каждой точки.");
                for (int i = 0; i < 3; i++)
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.Write(s[i] + ": ");
                        string[] coord = Console.ReadLine().Split();
                        if (coord.Length != 2)
                        {
                            Console.WriteLine("Необходимо ввести ровно два значения.");
                            continue;
                        }
                        try
                        {
                            switch (i)
                            {
                                case 0:
                                    g = new Point(Convert.ToDouble(coord[0]), Convert.ToDouble(coord[1]));
                                    break;
                                case 1:
                                    e = new Point(Convert.ToDouble(coord[0]), Convert.ToDouble(coord[1]));
                                    break;
                                case 2:
                                    f = new Point(Convert.ToDouble(coord[0]), Convert.ToDouble(coord[1]));
                                    break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Неверный формат введённых значений.");
                            continue;
                        }
                        flag = false;
                    }
                }
                if (!isItGEF())
                    Console.WriteLine("Введённые координаты не соответствую треугольнику GEF.");
                first_input = false;
            }
            Comands();
        }
        private void testMonteCarlo()
        {
            double realS = realSquare();
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Точная площадь треугольника = " + realS);
            Console.WriteLine("Результаты нахождения площади методом Монте-Карло:");
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                int M = 0;
                double mc = monteCarloSquare((int)Math.Pow(10, 3 + i), ref M);
                double pogr = Math.Round(Math.Abs(1 - mc / realS) * 100, 2);
                timer.Stop();
                Console.WriteLine("Площадь = " + mc + ". Погрешность вычислений = " + pogr + "%. Время = " + Math.Round(timer.Elapsed.TotalMilliseconds, 3) + " миллисекунд. N = 10^" + ( 3 + i ) + ". M = " + M);
                timer.Reset();
            }
            Comands();
        }
        public void Comands()
        {
            Console.WriteLine("Доступные команды: \"Выход\", \"Ввод\", \"Расчёт\". Введите одну из них: ");
            string comand = Console.ReadLine().ToLower();
            if (comand == "выход")
                Environment.Exit(0);
            else if (comand == "ввод")
                getValuesForTrin();
            else if (comand == "расчёт")
            {
                if (f == null)
                {
                    Console.WriteLine("Отсутствуют координаты вершин.");
                    getValuesForTrin();
                }
                else
                    testMonteCarlo();
            }
            else
            {
                Console.WriteLine("Введённой команды не существует, введите другую.");
                Comands();
            }
        }
    }
}
