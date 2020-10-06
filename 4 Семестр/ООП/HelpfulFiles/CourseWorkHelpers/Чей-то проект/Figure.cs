using System;

namespace ObjectOriented
{
    class Figure
    {
        private readonly Circle c;
        private readonly Triangle t;
        private readonly Rect r;
        public Figure()
        {
            c = new Circle();
            t = new Triangle();
            r = new Rect();
        }
        public Figure(Point d, Point e, Point b, Point o)
        {
            c = new Circle(o, e.Y - o.Y);
            t = new Triangle(b, e, o);
            r = new Rect(b, d);
        }
        public Figure(Figure f)
        {
            c = f.c;
            t = f.t;
            r = f.r;
        }
        public double Square()
        {
            return c.Square() / 4 + t.Square();
        }
        public bool IsPointHere(Point p)
        {
            return p.X < t.O.X ? t.IsPointHere(p) : c.IsPointHere(p);
        }
        public void MonteCarlo()
        {
            double S = Square(), mcrS = r.Square();
            Console.WriteLine($"Площадь фигуры debo равна {S}");
            Console.WriteLine($"Площадь прямоугольника Монте-Карло равна {mcrS}");
            Random rnd = new Random();
            for (int N = 1000; N <= 10000000; N *= 10)
            {
                int M = 0;
                DateTime time = DateTime.Now;
                for (int i = 0; i < N; ++i)
                {
                    Point p = new Point(r.X + r.DX * rnd.NextDouble(), r.Y + r.DY * rnd.NextDouble());
                    if (IsPointHere(p))
                    {
                        ++M;
                    }
                }
                TimeSpan dt = DateTime.Now - time;
                double mcS = mcrS * M / N;
                Console.WriteLine($"N = {N}:\tПлощадь фигуры debo примерно равна {mcS}.\tПогрешность вычислений - {Math.Abs(1 - mcS / S) * 100}%.\tРезультат получен за {dt:s\\.FFFFFFF} с.");
            }
        }
    }
}
