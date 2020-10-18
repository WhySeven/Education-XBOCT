using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram {
    class PointValidator {
        Point a, e, g;

        public PointValidator(Point a, Point e, Point g) {
            this.a = a;
            this.e = e;
            this.g = g;
        }

        public List<string> ValidatePoints() {
            var errorMessages = new List<string>();
            if (g.Y - a.Y <= 0)
                errorMessages.Add("Error: AG length equal 0 or point G below point A;");
            if (e.Y - a.Y <= 0)
                errorMessages.Add("AB length equal 0 or point E below point A");
            if (e.X - a.X <= 0)
                errorMessages.Add("AO length equal 0 or point E is to the left of point A");
            if (a.X != g.X)
                errorMessages.Add("AG are not parallel to the axis Y");
            if (Math.Abs(g.Y - a.Y) >= Math.Abs(e.Y - a.Y))
                errorMessages.Add("AG length more than length AB");
            return errorMessages;
        }
    }
}
