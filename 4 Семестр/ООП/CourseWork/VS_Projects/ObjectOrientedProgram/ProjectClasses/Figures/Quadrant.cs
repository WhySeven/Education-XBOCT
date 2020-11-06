using System;

namespace ObjectOrientedProgram
{
    class Quadrant
    {
        // Поля класса
        Point centerPoint;
        Point pointOnRadius;
        double radius;
        public double Area { get; set; }
        // Конструктор по умолчанию
        public Quadrant() 
        {
            centerPoint = new Point();
            pointOnRadius = new Point();
            InitializationОfAreaAndRadius(centerPoint, pointOnRadius);
        }
        // Конструктор инициализации(заполнения)
        public Quadrant(Point centerPoint, Point pointOnRadius) 
        {
            this.centerPoint = centerPoint;
            this.pointOnRadius = pointOnRadius;
            InitializationОfAreaAndRadius(centerPoint, pointOnRadius);
        }
        // Конструктор копирования
        public Quadrant(Quadrant quadrant) 
        {
            centerPoint = quadrant.centerPoint;
            pointOnRadius = quadrant.pointOnRadius;
            InitializationОfAreaAndRadius(centerPoint,pointOnRadius);
        }
        void InitializationОfAreaAndRadius (Point centerPoint, Point pointOnRadius) {
            radius = new Side(centerPoint, pointOnRadius).Length();
            Area = 0.25 * Math.PI * Math.Pow(radius, 2);
        }
        public bool CheckPoint(Point p) 
        {
            if (Math.Pow(p.X - centerPoint.X, 2) + Math.Pow(p.Y - centerPoint.Y, 2) <= Math.Pow(radius, 2) && (p.X >= centerPoint.X))
            {
                return true;
            }
            else return false;
        }
    }
}
