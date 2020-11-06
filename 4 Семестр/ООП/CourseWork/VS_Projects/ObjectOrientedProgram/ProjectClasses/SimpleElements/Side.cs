using System;

namespace ObjectOrientedProgram { 
    public class Side
    {
        Point p1;
        Point p2;
        // Конструктор по умолчанию
        public Side() 
        {
            p1 = new Point();
            p2 = new Point();
        }
        // Конструктор инициализации(заполнения)
        public Side(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        // Конструктор копирования
        public Side(Side s) 
        {
            p1 = s.p1;
            p2 = s.p2;
        }
        // Метод возвращающий длину стороны
        public double Length() 
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
