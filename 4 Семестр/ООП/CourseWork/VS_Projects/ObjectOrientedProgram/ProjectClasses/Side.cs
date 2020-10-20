using System;

namespace ObjectOrientedProgram { 
    public class Side
    {
        public Point p1, p2;
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
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }
    }
}
