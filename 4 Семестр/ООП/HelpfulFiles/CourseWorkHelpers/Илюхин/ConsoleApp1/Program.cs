using System;
using System.Diagnostics;

namespace ПОП
{
    class Program
    {
        static readonly Point[] gef = new Point[3];
        static void Main()
        {
            Comands();
        }
        private static double realSquare()
        {
            double ge = Math.Sqrt(Math.Pow(gef[1].X - gef[0].X, 2) + Math.Pow(gef[1].Y - gef[0].Y, 2));
            double gf = Math.Sqrt(Math.Pow(gef[2].X - gef[0].X, 2) + Math.Pow(gef[0].Y - gef[2].Y, 2));
            double ef = Math.Sqrt(Math.Pow(gef[1].X - gef[2].X, 2) + Math.Pow(gef[1].Y - gef[2].Y, 2));
            double p = ( ge + gf + ef ) / 2;
            return Math.Sqrt(p * ( p - ge ) * ( p - gf ) * ( p - ef ));
        }
        private static double monteCarloSquare(int N, ref int M)
        {
            double k_ge = ( gef[1].Y - gef[0].Y ) / ( gef[1].X - gef[0].X );
            double b_ge = gef[0].Y - gef[0].X * ( gef[1].Y - gef[0].Y ) / ( gef[1].X - gef[0].X );
            double k_gf = ( gef[2].Y - gef[0].Y ) / ( gef[2].X - gef[0].X );
            double b_gf = gef[0].Y - gef[0].X * ( gef[2].Y - gef[0].Y ) / ( gef[2].X - gef[0].X );
            double k_ef = ( gef[2].Y - gef[1].Y ) / ( gef[2].X - gef[1].X );
            double b_ef = gef[1].Y - gef[1].X * ( gef[2].Y - gef[1].Y ) / ( gef[2].X - gef[1].X );
            Random random = new Random();
            double k = 1.0000000000000002;
            for (int i = 0; i < N; i++)
            {
                double x = ( random.NextDouble() * k * ( gef[1].X - gef[0].X ) ) + gef[0].X;
                double y = ( random.NextDouble() * k * ( gef[1].Y - gef[2].Y ) ) + gef[2].Y;
                if (y <= k_ge * x + b_ge && ( ( x < gef[2].X && y >= k_gf * x + b_gf ) || ( x > gef[2].X && y >= k_ef * x + b_ef ) || x == gef[2].X ))
                    M++;
            }
            return ( (double)M / (double)N ) * ( gef[1].X - gef[0].X ) * ( gef[1].Y - gef[2].Y );
        }
        private static bool isItGEF()
        {
            return gef[0].X < gef[2].X && gef[2].X < gef[1].X && gef[0].Y > gef[2].Y && gef[1].Y > gef[0].Y;
        }
        private static void getValuesForTrin()
        {
            Console.WriteLine("Использовать значения по умолчанию? Введите \"да\" для согласия или что угодно для ручного ввода.");
            string comand = Console.ReadLine().ToLower();
            if (comand == "да")
            {
                gef[0] = new Point(5, 15);
                gef[1] = new Point(25, 20);
                gef[2] = new Point(15, 5);
                Comands();
                return;
            }
            bool first_input = true;
            string s = "GEF";
            while (!isItGEF() || first_input)
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
                            gef[i] = new Point(Convert.ToDouble(coord[0]), Convert.ToDouble(coord[1]));
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
        private static void testMonteCarlo()
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
        private static void Comands()
        {
            Console.WriteLine("Доступные команды: \"Выход\", \"Ввод\", \"Расчёт\". Введите одну из них: ");
            string comand = Console.ReadLine().ToLower();
            if (comand == "выход")
                Environment.Exit(0);
            else if (comand == "ввод")
                getValuesForTrin();
            else if (comand == "расчёт")
            {
                if (gef[2] == null)
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
