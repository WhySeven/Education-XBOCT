using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    public struct Point
    {
        private double x;
        private double y;
        
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(Point other)
        {
            this = other;
        }
        
        public Point Generation(Figure f, Random random)
        {   
            x = random.NextDouble() + random.Next(Convert.ToInt32(f.GetB().GetX()), Convert.ToInt32(f.GetD().GetX()));
            y = random.NextDouble() + random.Next(Convert.ToInt32(f.GetD().GetY()), Convert.ToInt32(f.GetB().GetY()));  
            
            return this;
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
    }
    

}
