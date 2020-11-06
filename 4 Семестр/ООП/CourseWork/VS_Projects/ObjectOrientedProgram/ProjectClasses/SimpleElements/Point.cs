using System;
namespace ObjectOrientedProgram {
    public class Point {
        public double X { get; set; }
        public double Y { get; set; }
        // Конструктор по умолчанию
        public Point() 
        {
            X = 0;
            Y = 0;
        }
        // Конструктор инициализации(заполнения)
        public Point(double x, double y) 
        {
            X = x;
            Y = y;
        }
        // Конструктор копирования
        public Point(Point p) 
        {
            X = p.X;
            Y = p.Y;
        } 
    }
}
