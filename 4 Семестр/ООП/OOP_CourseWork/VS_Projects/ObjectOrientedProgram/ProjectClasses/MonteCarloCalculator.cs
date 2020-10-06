using System;
using System.Diagnostics;

namespace ObjectOrientedProgram.ProjectClasses
{
    public class MonteCarloCalculator
    {
        // Поля нашего класса
        private readonly Quadrant quadrant;
        private readonly Triangle triangle;
        private readonly Point d, e, g, o, p1, p2;
        private readonly int N;
        private readonly double s; // площадь прямоугольника в котором находится наша фигура dego

        // Заполняем наши поля с помощью конструктора
        public MonteCarloCalculator(Point p1, Point p2, double g, int N) // g - отступ точки g от точки a
        {
            this.p1 = p1;
            this.p2 = p2;
            d = new Point(p2.x, p1.y);
            e = new Point(p2.x - (p2.y - p1.y), p2.y);
            this.g = new Point(p1.x, p1.y + g);
            o = new Point(p2.x - (p2.y - p1.y), p1.y);
            triangle = new Triangle(e, this.g, o);
            quadrant = new Quadrant(o, d);
            this.N = N;
            s = (p2.x - p1.x) * (p2.y - p1.y);
        }
        private double GetSquare() // Получение площади dego
        {
            return triangle.Square() + quadrant.Square();
        }
        private double MonteCarloSquare() // Получение площади dego методом Монте-Карло
        {
            Random rand = new Random();
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                double x = rand.NextDouble() * (p2.x - p1.x) + p1.x;
                double y = rand.NextDouble() * (p2.y - p1.y) + p1.y;
                Point p = new Point(x, y);
                if (triangle.CheckPoint(p) || quadrant.CheckPoint(p))
                {
                    count++;
                }
            }
            return s * count / N;
        }
        public void DrawTable()
        {
            // Вычисление данных для таблицы
            double figure_S = GetSquare();
            double mc_S;
            double relError;
            Stopwatch st = new Stopwatch();
            st.Start();
            mc_S = MonteCarloSquare();
            relError = Math.Abs((figure_S - mc_S) / figure_S) * 100;
            st.Stop();
            long tc = st.ElapsedTicks;

            //Непосредственно отрисовка таблицы
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 18 };
            static void DrawHorizontal(string a, string b, string c, int[] tableCellSizes)
            {
                Console.Write(a);
                for (int j = 0; j < tableCellSizes.Length; j++)
                {
                    for (int i = 0; i < tableCellSizes[j]; i++)
                    {
                        Console.Write("═");
                    }
                    if (j != tableCellSizes.Length - 1)
                    {
                        Console.Write(b);
                    }
                }
                Console.WriteLine(c);
            }
            void DrawCellLine(int[] tableCellSizes)
            {
                DrawHorizontal("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ tiks = {4,-9} ║", N, Math.Round(figure_S, 3), Math.Round(mc_S, 3), Math.Round(relError, 3), tc);
                DrawHorizontal("╚", "╩", "╝", tableCellSizes);
            }
            DrawCellLine(tableCellSizes);
        }
    }
}
