using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    class PointValidator {
        readonly Point a, e, g;
        public PointValidator(Point a, Point e, Point g) {
            this.a = a;
            this.e = e;
            this.g = g;
        }
        public List<string> ValidatePoints() {
            List<string> error_list = new List<string>();
            if (g.Y - a.Y <= 0)
                error_list.Add("Error: AG length equal 0 or point G below point A;");
            if (e.Y - a.Y <= 0)
                error_list.Add("Error: AB length equal 0 or point E below point A");
            if (e.X - a.X <= 0)
                error_list.Add("Error: AO length equal 0 or point E is to the left of point A");
            if (a.X != g.X)
                error_list.Add("Error: AG are not parallel to the axis Y");
            if (Math.Abs(g.Y - a.Y) >= Math.Abs(e.Y - a.Y))
                error_list.Add("Error: AG length more than length AB");
            return error_list;
        }
    }
}
