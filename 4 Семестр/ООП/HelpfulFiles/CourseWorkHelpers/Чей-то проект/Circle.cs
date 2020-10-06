using System;

namespace ObjectOriented
{
    internal class Circle : Point
    {
        public double R { get; private set; }
        public Circle() : base()
        {
            R = 1;
        }
        public Circle(Point p, double r) : base(p)
        {
            R = r;
        }
        public Circle(Circle c) : base(c.X, c.Y)
        {
            R = c.R;
        }
        public double Square()
        {
            return Math.PI * Math.Pow(R, 2);
        }
        public bool IsPointHere(Point p)
        {
            return Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2) <= Math.Pow(R, 2);
        }
    }
}
