using System;

namespace Procedure
{
    class Program
    {
        static bool IsPointInTriangle(Point p, Point b, Point e, Point o)
        {
            Point e_0 = new Point(e.X - b.X, e.Y - b.Y), o_0 = new Point(o.X - b.X, o.Y - b.Y), p_0 = new Point(p.X - b.X, p.Y - b.Y);
            double m = ( p_0.X * e_0.Y - e_0.X * p_0.Y ) / ( o_0.X * e_0.Y - e_0.X * o_0.Y );
            if (m >= 0 && m <= 1)
            {
                double l = ( p_0.X - m * o_0.X ) / e_0.X;
                if (l >= 0 && m + l <= 1)
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsPointInCircle(Point p, Point o, double R)
        {
            return Math.Pow(p.X - o.X, 2) + Math.Pow(p.Y - o.Y, 2) <= Math.Pow(R, 2);
        }
        static void MonteCarlo(Point d, Point e, Point b, Point o)
        {
            double R = e.Y - o.Y;
            double S = ( e.X - b.X ) * ( e.Y - o.Y ) / 2 + Math.PI * Math.Pow(R, 2) / 4, mcrS = ( d.X - b.X ) * ( b.Y - d.Y );
            Console.WriteLine($"Площадь фигуры debo равна {S}");
            Console.WriteLine($"Площадь прямоугольника Монте-Карло равна {mcrS}");
            Random rnd = new Random();
            for (int N = 1000; N <= 10000000; N *= 10)
            {
                int M = 0;
                DateTime time = DateTime.Now;
                for (int i = 0; i < N; ++i)
                {
                    Point p = new Point(b.X + ( d.X - b.X ) * rnd.NextDouble(), d.Y + ( b.Y - d.Y ) * rnd.NextDouble());
                    if (p.X < o.X && IsPointInTriangle(p, b, e, o) || p.X == o.X && p.Y >= o.Y && p.Y <= e.Y || p.X > o.X && IsPointInCircle(p, o, R))
                    {
                        ++M;
                    }
                }
                TimeSpan dt = DateTime.Now - time;
                double mcS = mcrS * M / N;
                Console.WriteLine($"N = {N}:\tПлощадь фигуры debo примерно равна {mcS}.\tПогрешность вычислений - {Math.Abs(1 - mcS / S) * 100}%.\tРезультат получен за {dt:s\\.FFFFFFF} с.");
            }
        }
        static void Manual()
        {
            input: Console.WriteLine("Введите координаты точки d:");
            Console.Write("x = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            double y = Convert.ToDouble(Console.ReadLine());
            Point d = new Point(x, y);
            Console.WriteLine("Введите координаты точки b:");
            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());
            Point b = new Point(x, y), e = new Point(d.X - b.Y + d.Y, b.Y), o = new Point(e.X, d.Y);
            if (d.X <= b.X || b.Y <= d.Y || e.X < b.X)
            {
                Console.WriteLine("Ошибка! Недопустимое расположение точек b и d!");
                goto input;
            }
            Console.WriteLine($"Координаты точки d:\nx = {d.X}\ny = {d.Y}");
            Console.WriteLine($"Координаты точки e:\nx = {e.X}\ny = {e.Y}");
            Console.WriteLine($"Координаты точки b:\nx = {b.X}\ny = {b.Y}");
            Console.WriteLine($"Координаты точки o:\nx = {o.X}\ny = {o.Y}");
            MonteCarlo(d, e, b, o);
        }
        static void Test()
        {
            Point d = new Point(10, 1), e = new Point(8, 3), b = new Point(1, 3), o = new Point(8, 1);
            Console.WriteLine($"Координаты точки d:\nx = {d.X}\ny = {d.Y}");
            Console.WriteLine($"Координаты точки e:\nx = {e.X}\ny = {e.Y}");
            Console.WriteLine($"Координаты точки b:\nx = {b.X}\ny = {b.Y}");
            Console.WriteLine($"Координаты точки o:\nx = {o.X}\ny = {o.Y}");
            MonteCarlo(d, e, b, o);
        }
        static void Main()
        {
            string action = "";
            while (action != "выход")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("[Ввод] - Ручной ввод координат\t[Тест] - Выполнить контрольный пример\t[Выход] - Выйти");
                Console.Write("> ");
                input: action = Console.ReadLine().ToLower();
                switch (action)
                {
                    case "ввод": Manual(); break;
                    case "тест": Test(); break;
                    case "выход": break;
                    default: Console.Write("Действие не найдено. Повторите ввод:\n> "); goto input;
                }
            }
        }
    }
}
