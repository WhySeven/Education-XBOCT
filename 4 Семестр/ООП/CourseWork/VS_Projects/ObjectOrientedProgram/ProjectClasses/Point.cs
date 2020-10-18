namespace ObjectOrientedProgram {
    public class Point {
        //double x, y; // Поля класса

        public double X { get; set; }
        public double Y { get; set; }

        public Point() // Конструктор по умолчанию
        {
            X = 0;
            Y = 0;
        }
        public Point(double x, double y) // Конструктор инициализации(заполнения)
        {
            this.X = x;
            this.Y = y;
        }
        public Point(Point p) // Конструктор копирования
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
