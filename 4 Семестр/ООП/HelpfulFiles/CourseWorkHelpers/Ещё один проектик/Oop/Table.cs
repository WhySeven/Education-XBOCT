using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    class Table
    {
        public Table(double N, int M, double S, string time, double fault)
        {
            this.N = N;
            this.M = M;
            this.S = S;
            this.time = time;
            this.fault = fault;
        }
        public double N { get; set; }
        public int M { get; set; }
        public double S { get; set; }
        public string time { get; set; }
        public double fault { get; set; }
    }
}
