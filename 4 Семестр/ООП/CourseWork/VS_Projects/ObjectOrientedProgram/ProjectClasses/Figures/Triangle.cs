using System;

namespace ObjectOrientedProgram { 
    class Triangle
    {
        // Вершины треугольника
        Point point1, point2, point3;
        // Стороны треугольника
        Side side1, side2, side3;
        double Perimeter;
        public double Area { get; set; }
        // Конструктор по умолчанию
        public Triangle() 
        {
            point1 = new Point();
            point2 = new Point();
            point3 = new Point();
            InitializeOtherFields();
        }
        // Конструктор инициализации(заполнения)
        public Triangle(Point point1, Point point2, Point point3) 
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            InitializeOtherFields();
        }
        // Конструктор копирования
        public Triangle(Triangle triangle) 
        {
            point1 = triangle.point1;
            point2 = triangle.point2;
            point3 = triangle.point3;
            InitializeOtherFields(); 
        }
        // Метод, использующийся для инициализации сторон треугольника
        void InitializeOtherFields() 
        {
            side1 = new Side(point1, point2);
            side2 = new Side(point2, point3);
            side3 = new Side(point3, point1);
            Perimeter = side1.Length() + side2.Length() + side3.Length();
            double p = Perimeter / 2;
            Area = Math.Sqrt(p * (p - side1.Length()) * (p - side2.Length()) * (p - side3.Length()));
        }
        // Метод проверяющий наличие точки 'p' в треугольнике
        public bool CheckPoint(Point point) 
        {
            double vectorProduct1 = (point1.X - point.X) * (point2.Y - point1.Y) - (point2.X - point1.X) * (point1.Y - point.Y);
            double vectorProduct2 = (point2.X - point.X) * (point3.Y - point2.Y) - (point3.X - point2.X) * (point2.Y - point.Y);
            double vectorProduct3 = (point3.X - point.X) * (point1.Y - point3.Y) - (point1.X - point3.X) * (point3.Y - point.Y);
            if ((vectorProduct1 >= 0 && vectorProduct2 >= 0 && vectorProduct3 >= 0) || (vectorProduct1 <= 0 && vectorProduct2 <= 0 && vectorProduct3 <= 0))
            {
                return true;
            }
            else return false;
        }
    }
}
