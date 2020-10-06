using System;

namespace ObjectOrientedProgram.ProjectClasses
{
    class Quadrant
    {
        public Point center, p1, p2; // Поля класса
        public Quadrant() // Конструктор по умолчанию
        {
            center = new Point();
            p1 = new Point();
            p2 = new Point();
        }
        public Quadrant(Point center, Point p1) // Конструктор инициализации(заполнения)
        {
            this.center = center;
            this.p1 = p1;
            p2 = new Point(this.center.x, this.center.y + new Side(center, p1).Length());
        }
        public Quadrant(Quadrant q) // Конструктор копирования
        {
            center = q.center;
            p1 = q.p1;
            p2 = q.p2;
        }
        public double Radius() // Метод возвращающий длину радиуса квадранта
        {
            return new Side(center, p1).Length();
        }
        public double Square() // Метод считающий площадь квадранта
        {
            return 0.25 * Math.PI * Math.Pow(Radius(), 2);
        }
        public bool CheckPoint(Point p) // Метод проверящий попадает ли точка в квадрант
        {
            if ((Math.Pow(p.x - center.x, 2) + Math.Pow(p.y - center.y, 2) <= Math.Pow(Radius(), 2)) && (p.x >= center.x) && (p.y >= center.y))
            {
                return true;
            }
            else return false;
        }
    }
}
