namespace ObjectOrientedProgram
{
    public class Point
    {
        public double x, y; // Поля класса
        public Point() // Конструктор по умолчанию
        {
            x = 0;
            y = 0;
        }
        public Point(double x, double y) // Конструктор инициализации(заполнения)
        {
            this.x = x;
            this.y = y;
        }
        public Point(Point p) // Конструктор копирования
        {
            x = p.x;
            y = p.y;
        }
    }
}
