using System;

namespace ObjectOriented
{
    class Rect : Point
    {
        public double DX { get; private set; }
        public double DY { get; private set; }
        public Rect() : base()
        {
            DX = 1;
            DY = 1;
        }
        public Rect(Point p0, Point p) : base(Math.Min(p0.X, p.X), Math.Min(p0.Y, p.Y))
        {
            DX = Math.Abs(p.X - p0.X);
            DY = Math.Abs(p.Y - p0.Y);
        }
        public Rect(Rect r) : base(r.X, r.Y)
        {
            DX = r.DX;
            DY = r.DY;
        }
        public double Square()
        {
            return DX * DY;
        }
    }
}
