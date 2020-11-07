using System;
namespace ObjectOrientedProgram { 
    public class Side
    {
        readonly Point p1;
        readonly Point p2;
        public Side() // Конструктор по умолчанию
        {
            p1 = new Point();
            p2 = new Point();
        }       
        public Side(Point p1, Point p2) // Конструктор инициализации
        {
            this.p1 = p1;
            this.p2 = p2;
        }  
        public Side(Side s) // Конструктор копирования
        {
            p1 = s.p1;
            p2 = s.p2;
        }
        public double Length() // Метод возвращающий длину стороны
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
