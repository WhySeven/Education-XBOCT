using System;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Triangle
    {
        public Point p1, p2, p3;
        public Side a, b, c;
        public Triangle() // Конструктор по умолчанию
        {
            p1 = new Point();
            p2 = new Point();
            p3 = new Point();
            InitializeSides(p1, p2, p3);
        }
        public Triangle(Point p1, Point p2, Point p3) // Конструктор инициализации(заполнения)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            InitializeSides(this.p1, this.p2, this.p3);
        }
        public Triangle(Triangle t) // Конструктор копирования
        {
            p1 = t.p1;
            p2 = t.p2;
            p3 = t.p3;
            InitializeSides(t.p1, t.p2, t.p3);
        }
        private void InitializeSides(Point p1, Point p2, Point p3) // Метод для заоплнения полей сторон
        {
            a = new Side(p1, p2);
            b = new Side(p2, p3);
            c = new Side(p3, p1);
        }
        public double Perimeter() // Метод возвращающий периметр
        {
            return a.Length() + b.Length() + c.Length();
        }
        public double Square() // Метод возвращающий площадь треугольника по полупериметру.
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a.Length()) * (p - b.Length()) * (p - c.Length()));
        }

        public bool CheckPoint(Point p) // Метод проверяющий наличие точки в треугольнике
        {
            double buf1 = (p1.x - p.x) * (p2.y - p1.y) - (p2.x - p1.x) * (p1.y - p.y);
            double buf2 = (p2.x - p.x) * (p3.y - p2.y) - (p3.x - p2.x) * (p2.y - p.y);
            double buf3 = (p3.x - p.x) * (p1.y - p3.y) - (p1.x - p3.x) * (p3.y - p.y);
            if ((buf1 >= 0 && buf2 >= 0 && buf3 >= 0) || (buf1 <= 0 && buf2 <= 0 && buf3 <= 0))
            {
                return true;
            }
            else return false;
        }
    }
}
