namespace ObjectOrientedProgram {
    public class Point {
        public double x, y;
        // Конструктор по умолчанию
        public Point() 
        {
            x = 0;
            y = 0;
        }
        // Конструктор инициализации(заполнения)
        public Point(double x, double y) 
        {
            this.x = x;
            this.y = y;
        }
        // Конструктор копирования
        public Point(Point p) 
        {
            x = p.x;
            y = p.y;
        }
    }
}
