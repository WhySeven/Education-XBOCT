namespace Procedure
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
