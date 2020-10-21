using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    public class MonteCarloCalculator {
        // Треугольник и квадрант
        private readonly Quadrant quadrant;
        private readonly Triangle triangle;
        // Точки фигуры dego
        private readonly Point d, e, g, o;
        // Точки, лежащие на главной диагонали прямоугольника
        private readonly Point a, c;
        // Шаг метода
        public int step = 0;
        // площадь прямоугольника в котором находится наша фигура dego
        private readonly double rectangle_Square;
        // Координаты точки, которую мы будем бросать в прямоугольник
        private double x, y;
        //Случайное число от 0 до 1
        Random random = new Random();
        // Точная площадь
        public double dego_Square;
        // Поле в которое будет записана площадь, вычисленная методом Монте-Карло
        public List<double> monte_carlo_Square = new List<double>();
        // Относительная погрешность
        public List<double> relError = new List<double>();
        // Поле в которое будет записано время затраченное на метод Calculate
        public List<long> ms = new List<long>();
        // Заполняем наши поля с помощью конструктора
        public MonteCarloCalculator(Point a, Point e, Point g) // Конструктор инициализации
        {
            this.a = a;
            c = new Point(e.x + (e.y - a.y), e.y);
            d = new Point(e.x + (e.y - a.y), a.y);
            this.e = e;
            this.g = g;
            o = new Point(e.x, a.y);
            triangle = new Triangle(this.e, this.g, o);
            quadrant = new Quadrant(o, d);
            rectangle_Square = (c.x - a.x) * (c.y - a.y);
        }
        // Метод возвращающий точную площадь dego
        private double GetSquare() 
        {
            return triangle.Square()+ quadrant.Square();
        }
        // Метод возвращающий площадь dego, вычисленную методом Монте-Карло
        private double MonteCarloSquare(int N) 
        { 
            int count = 0;
            for (int i = 0; i < N; i++) 
            {
                x = random.NextDouble() * (c.x - a.x) + a.x;
                y = random.NextDouble() * (c.y - a.y) + a.y;
                Point p = new Point(x, y);
                if (triangle.CheckPoint(p) || quadrant.CheckPoint(p)) 
                {
                    count++;
                }
            }
            return rectangle_Square * count / N;
        }
        public void Calculate() {
            for (int N = Convert.ToInt32(Math.Pow(10, 3)); N <= Math.Pow(10, 7); N *= 10) {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                // Вычисление точной площади
                dego_Square = GetSquare();
                // Вычисление площади методом Монте-Карло
                monte_carlo_Square.Add(MonteCarloSquare(N));
                // Вычисление погрешности вычислений (relative error)
                relError.Add(Math.Abs((dego_Square - monte_carlo_Square[step]) / dego_Square) * 100);
                // Стоп таймера       
                sw.Stop();
                // Подсчёт милисекунд
                ms.Add(sw.ElapsedMilliseconds);
                step++;
            }           
        }
    }
}

