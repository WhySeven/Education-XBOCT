using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram {
    class PointValidator {
        Point a, e, g;
        public PointValidator(Point a, Point e, Point g) {
            this.a = a;
            this.e = e;
            this.g = g;
        }
        public List<string> ValidatePoints() {
            List<string> error_list = new List<string>();
            if (g.y - a.y <= 0)
                error_list.Add("Error: AG length equal 0 or point G below point A;");
            if (e.y - a.y <= 0)
                error_list.Add("Error: AB length equal 0 or point E below point A");
            if (e.x - a.x <= 0)
                error_list.Add("Error: AO length equal 0 or point E is to the left of point A");
            if (a.x != g.x)
                error_list.Add("Error: AG are not parallel to the axis Y");
            if (Math.Abs(g.y - a.y) >= Math.Abs(e.y - a.y))
                error_list.Add("Error: AG length more than length AB");
            return error_list;
        }
    }
}
