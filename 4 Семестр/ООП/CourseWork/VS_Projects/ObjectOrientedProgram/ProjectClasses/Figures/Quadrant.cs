using System;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Quadrant
    {
        // Поля класса
        public Point center, p;
        // Конструктор по умолчанию
        public Quadrant() 
        {
            center = new Point();
            p = new Point();
        }
        // Конструктор инициализации(заполнения)
        public Quadrant(Point center, Point p) 
        {
            this.center = center;
            this.p = p;
        }
        // Конструктор копирования
        public Quadrant(Quadrant q) 
        {
            center = q.center;
            p = q.p;
        }
        // Метод возвращающий длину радиуса квадранта
        public double Radius()
        {
            return new Side(center, p).Length();
        }
        // Метод вычисляющий точную площадь квадранта
        public double Square() 
        {
            return 0.25 * Math.PI * Math.Pow(Radius(), 2);
        }
        // Метод проверящий попадает ли точка 'p' в квадрант
        public bool CheckPoint(Point p) 
        {
            if ((Math.Pow(p.x - center.x, 2) + Math.Pow(p.y - center.y, 2) <= Math.Pow(Radius(), 2)) && (p.x >= center.x) && (p.y >= center.y))
            {
                return true;
            }
            else return false;
        }
    }
}
