using System;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Triangle
    {
        // Вершины треугольника
        public Point p1, p2, p3;
        // Стороны треугольника
        public Side a, b, c;
        // Конструктор по умолчанию
        public Triangle() 
        {
            p1 = new Point();
            p2 = new Point();
            p3 = new Point();
            InitializeSides(p1, p2, p3);
        }
        // Конструктор инициализации(заполнения)
        public Triangle(Point p1, Point p2, Point p3) 
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            InitializeSides(this.p1, this.p2, this.p3);
        }
        // Конструктор копирования
        public Triangle(Triangle t) 
        {
            p1 = t.p1;
            p2 = t.p2;
            p3 = t.p3;
            InitializeSides(t.p1, t.p2, t.p3);
        }
        // Метод, использующийся для инициализации сторон треугольника
        private void InitializeSides(Point p1, Point p2, Point p3) 
        {
            a = new Side(p1, p2);
            b = new Side(p2, p3);
            c = new Side(p3, p1);
        }
        // Метод возвращающий периметр
        public double Perimeter() 
        {
            return a.Length() + b.Length() + c.Length();
        }
        // Метод возвращающий точную площадь треугольника по формуле Герона 
        public double Square() 
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a.Length()) * (p - b.Length()) * (p - c.Length()));
        }
        // Метод проверяющий наличие точки 'p' в треугольнике
        public bool CheckPoint(Point p) 
        {
            double buf1 = (p1.X - p.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p1.Y - p.Y);
            double buf2 = (p2.X - p.X) * (p3.Y - p2.Y) - (p3.X - p2.X) * (p2.Y - p.Y);
            double buf3 = (p3.X - p.X) * (p1.Y - p3.Y) - (p1.X - p3.X) * (p3.Y - p.Y);
            if ((buf1 >= 0 && buf2 >= 0 && buf3 >= 0) || (buf1 <= 0 && buf2 <= 0 && buf3 <= 0))
            {
                return true;
            }
            else return false;
        }
    }
}
