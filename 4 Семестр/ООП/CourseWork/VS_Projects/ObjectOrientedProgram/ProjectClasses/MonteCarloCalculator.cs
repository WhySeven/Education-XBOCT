using System;
using System.Diagnostics;

namespace ObjectOrientedProgram.ProjectClasses {
    public class MonteCarloCalculator {
        // Треугольник и квадрант
        private readonly Quadrant quadrant;
        private readonly Triangle triangle;
        // Точки фигуры dego
        private readonly Point d, e, g, o;
        // Точки, лежащие на главной диагонали прямоугольника
        private readonly Point a, c;
        // Кол-во бросков точки
        private readonly int N;
        // площадь прямоугольника в котором находится наша фигура dego
        private readonly double rectangle_Square;
        // Координаты точки, которую мы будем бросать в прямоугольник
        private double x, y;
        // Относительная погрешность
        private double relError;
        // Точная площадь
        private double dego_Square;
        // Поле в которое будет записана площадь, вычисленная методом Монте-Карло
        private double monte_carlo_Square;
        // Поле в которое будет записано время затраченное на метод Calculate
        private long ms;
        // Заполняем наши поля с помощью конструктора
        public MonteCarloCalculator(Point a, Point e, Point g, int N) // Конструктор инициализации
        {
            this.a = a;
            c = new Point(e.X + (e.Y - a.Y), e.Y);
            d = new Point(e.X + (e.Y - a.Y), a.Y);
            this.e = e;
            this.g = g;
            o = new Point(e.X, a.Y);
            triangle = new Triangle(this.e, this.g, o);
            quadrant = new Quadrant(o, d);
            this.N = N;
            rectangle_Square = (c.X - a.X) * (c.Y - a.Y);
        }
        // Метод возвращающий точную площадь dego
        private double GetSquare() {
            return triangle.Square() + quadrant.Square();
        }
        // Метод возвращающий площадь dego, вычисленную методом Монте-Карло
        private double MonteCarloSquare() {
            Random random = new Random();
            int count = 0;
            for (int i = 0; i < N; i++) {
                x = random.NextDouble() * (c.X - a.X) + a.X;
                y = random.NextDouble() * (c.Y - a.Y) + a.Y;
                Point p = new Point(x, y);
                if (triangle.CheckPoint(p) || quadrant.CheckPoint(p)) {
                    count++;
                }
            }
            return rectangle_Square * count / N;
        }
        public void Calculate() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Вычисление точной площади
            dego_Square = GetSquare();
            // Вычисление площади методом Монте-Карло
            monte_carlo_Square = MonteCarloSquare();
            // Вычисление погрешности вычислений (relative error)
            relError = Math.Abs((dego_Square - monte_carlo_Square) / dego_Square) * 100;
            // Стоп таймера
            sw.Stop();
            // Подсчёт милисекунд
            ms = sw.ElapsedMilliseconds;
        }
        // Вывод таблицы в консоль
        public void DrawTable() {
            int[] tableCellSizes = new int[] { 14, 24, 30, 26, 12 };
            DrawCells(tableCellSizes);
            void DrawCells(int[] tableCellSizes) {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ ms = {4,-5} ║", N, Math.Round(dego_Square, 3), Math.Round(monte_carlo_Square, 3), Math.Round(relError, 3), ms);
                DrawHorizontalLine("╚", "╩", "╝", tableCellSizes);
            }
            void DrawHorizontalLine(string a, string b, string c, int[] tableCellSizes) {
                Console.Write(a);
                for (int j = 0; j < tableCellSizes.Length; j++) {
                    for (int i = 0; i < tableCellSizes[j]; i++) {
                        Console.Write("═");
                    }
                    if (j != tableCellSizes.Length - 1) {
                        Console.Write(b);
                    }
                }
                Console.WriteLine(c);
            }
        }
    }
}

