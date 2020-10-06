using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    public struct Figure {
       
        private Point d;
        private Point e;
        private Point b;
        private Point o;
        public Figure(Point d, Point e, Point b, Point o)
        {
            this.d = d;
            this.e = e;
            this.b = b;
            this.o = o;
        }
        public Figure(Figure other)
        {
            this = other;
        }
        public Point GetD()
        {
            return d;
        }
        public Point GetE()
        {
            return e;
        }
        public Point GetB()
        {
            return b;
        }
        public Point GetO()
        {
            return o;
        }
        public int Check(Figure f, double N)
        {
            Point p = new Point();
            int M = 0;
            Random random = new Random();
            bool check = false;
            for (int i = 0; i < N; i++)
            {
                p = new Point(p.Generation(f, random));
                if (p.GetX() < f.GetE().GetX())
                {
                    double first = (f.GetB().GetX() - p.GetX()) * (f.GetE().GetY() - f.GetB().GetY()) - (f.GetE().GetX() - f.GetB().GetX()) * (f.GetB().GetY() - p.GetY());
                    double second = (f.GetE().GetX() - p.GetX()) * (f.GetO().GetY() - f.GetE().GetY()) - (f.GetO().GetX() - f.GetE().GetX()) * (f.GetE().GetY() - p.GetY());
                    double third = (f.GetO().GetX() - p.GetX()) * (f.GetB().GetY() - f.GetO().GetY()) - (f.GetB().GetX() - f.GetO().GetX()) * (f.GetO().GetY() - p.GetY());
                    if (first > 0 && second > 0 && third > 0)
                    {
                      check = true;
                    }
                    else if (first < 0 && second < 0 && third < 0)
                    {
                       check = true;
                    } else if (first == 0 && second == 0 && third == 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                    /*
                    (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0)
                    (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0)
                    (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0)
                    */
                }
               else if (p.GetX() > f.GetE().GetX())
                {
                    
                    double centerY = f.GetO().GetY();
                    double centerX = f.GetO().GetX();
                    //(a-x)^2 + (b-y)^2 < R^2
                    if (Math.Pow((centerX - p.GetX()), 2) + Math.Pow((centerY - p.GetY()), 2) <= Math.Pow(((f.GetD().GetX()-f.GetB().GetX()) / 3), 2))
                    {
                       check = true;
                    }
                   
                    else
                    {
                        check = false;
                    }
                }
                if (check == true)
                {
                    M++;
                }
                
            }

            return M;
        }
        public double Sfigure()
        {
            return Math.Round((e.GetX() - b.GetX()) * (e.GetY() - o.GetY()) / 2 + Math.PI * Math.Pow(d.GetX() / 3, 2) / 4, 3);
        }
        public double SRect()
        {
            return (d.GetX() - b.GetX()) * (b.GetY() - d.GetY()); 
        }
        public double Fault(Figure f, double N, double M)
        {
            double fault = Math.Round(Math.Abs((f.Sfigure() - (f.SRect() * M / N))/f.Sfigure()*100), 3);
            return fault;
        }
        public double S(double N, int M)
        {
            return Math.Round((this.SRect() * M / N), 3);
        }
    }
}


