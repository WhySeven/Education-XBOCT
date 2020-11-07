using System;

namespace ObjectOrientedProgram
{
    class Quadrant
    {
        // Поля класса
        readonly Point centerPoint;
        readonly Point pointOnRadius;
        double radius;
        public double Area { get; set; }
        public Quadrant() // Конструктор по умолчанию
        {
            centerPoint = new Point();
            pointOnRadius = new Point();
            InitializationОfAreaAndRadius(centerPoint, pointOnRadius);
        }    
        public Quadrant(Point centerPoint, Point pointOnRadius) // Конструктор инициализации
        {
            this.centerPoint = centerPoint;
            this.pointOnRadius = pointOnRadius;
            InitializationОfAreaAndRadius(centerPoint, pointOnRadius);
        }
        public Quadrant(Quadrant quadrant) // Конструктор копирования
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
