using System;

namespace ObjectOriented
{
    class Triangle
    {
        public Point B { get; private set; }
        public Point E { get; private set; }
        public Point O { get; private set; }
        public Triangle()
        {
            B = new Point(0, 0);
            E = new Point(1, 0);
            O = new Point(0, 1);
        }
        public Triangle(Point b, Point e, Point o)
        {
            B = b;
            E = e;
            O = o;
        }
        public Triangle(Triangle t)
        {
            B = t.B;
            E = t.E;
            O = t.O;
        }
        public double Square()
        {
            return ( E.X - B.X ) * ( E.Y - O.Y ) / 2;
        }
        public bool IsPointHere(Point p)
        {
            Point e_0 = new Point(E.X - B.X, E.Y - B.Y), o_0 = new Point(O.X - B.X, O.Y - B.Y), p_0 = new Point(p.X - B.X, p.Y - B.Y);
            double m = ( p_0.X * e_0.Y - e_0.X * p_0.Y ) / ( o_0.X * e_0.Y - e_0.X * o_0.Y );
            if (m >= 0 && m <= 1)
            {
                double l = ( p_0.X - m * o_0.X ) / e_0.X;
                if (l >= 0 && m + l <= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
