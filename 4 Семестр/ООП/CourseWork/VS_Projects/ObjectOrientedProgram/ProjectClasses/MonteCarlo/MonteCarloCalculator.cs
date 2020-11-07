using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    public class MonteCarloCalculator {
        readonly Quadrant quadrant;
        readonly Triangle triangle;
        readonly Point d, e, g, o;
        readonly Point a, c;
        readonly double rectangle_Square;
        double dego_Square;
        readonly List<double> monte_carlo_Square = new List<double>();
        readonly List<double> relError = new List<double>();
        readonly List<long> ms = new List<long>();
        readonly Random random = new Random();
        double x, y;
        readonly int[] tableCellSizes = new int[] { 14, 24, 30, 26, 12 };
        public MonteCarloCalculator(Point a, Point e, Point g) // Конструктор инициализации
        {
            this.a = a;
            c = new Point(e.X + (e.Y - a.Y), e.Y);
            d = new Point(e.X + (e.Y - a.Y), a.Y);
            this.e = e;
            this.g = g;
            o = new Point(e.X, a.Y);
            triangle = new Triangle(this.e, this.g, o);
            quadrant = new Quadrant(o, d);
            rectangle_Square = (c.X - a.X) * (c.Y - a.Y);
        }
        // Метод возвращающий точную площадь dego
        double GetExactArea() 
        {
            return triangle.Area + quadrant.Area;
        }
        bool CheckPoint(Point point) {
            if (triangle.CheckPoint(point) || quadrant.CheckPoint(point)) {
                return true;
            } else return false;
        }
        // Метод возвращающий площадь dego, вычисленную методом Монте-Карло
        double GetMonteCarloSquare(int N) 
        { 
            int count = 0;
            for (int i = 0; i < N; i++) 
            {
                x = random.NextDouble() * (c.X - a.X) + a.X;
                y = random.NextDouble() * (c.Y - a.Y) + a.Y;
                if(CheckPoint(new Point(x,y))){count++;}
            }
            return rectangle_Square * count / N;
        }
        public void Calculate() {
            // Вычисление точной площади
            dego_Square = GetExactArea();
            for (double N = Math.Pow(10, 3); N <= Math.Pow(10, 7); N *= 10) {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                // Вычисление площади методом Монте-Карло
                monte_carlo_Square.Add(GetMonteCarloSquare(Convert.ToInt32(N)));
                // Вычисление погрешности вычислений (relative error)
                relError.Add(Math.Abs((dego_Square - monte_carlo_Square[Convert.ToInt32(Math.Log(N,10)-3)]) / dego_Square) * 100);     
                
                sw.Stop();
                ms.Add(sw.ElapsedMilliseconds);
            }
            DrawTable();
        }
        //Вывод в консоль
        
        void DrawTable() {
            for (int i = 0; i < 5; i++) {
                DrawHorizontalLine("╔", "╦", "╗", tableCellSizes);
                Console.WriteLine("║ N = {0,-8} ║ dego Square = {1,-8} ║ MonteCarlo Square = {2,-8} ║ Relative Error = {3,-6}% ║ ms = {4,-5} ║", Math.Pow(10, 3 + Convert.ToDouble(i)), Math.Round(dego_Square, 3), Math.Round(monte_carlo_Square[i], 3), Math.Round(relError[i], 3), ms[i]);
                DrawHorizontalLine("╚", "╩", "╝", tableCellSizes);
            }
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

