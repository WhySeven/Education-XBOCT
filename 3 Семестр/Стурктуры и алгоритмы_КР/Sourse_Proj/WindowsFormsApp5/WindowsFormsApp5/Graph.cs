using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp5
{
    class Graph
    {
        Pen pen;
        Graphics graphics;
        Form1 form;
        float h;
        float x;
        float y;
        int i;
        public Graph(int i, Graph_space graph_space)
        {
            this.i = i;
            graphics = graph_space.graphics;
            pen = new Pen(Color.Black);
            form = graph_space.formMain;
            h = (form.graph_space.Width - 1) / (Convert.ToSingle(Math.Pow(2, i)) - 1);
            x = 0;
            y = (form.graph_space.Width - 1);
        }
        public void Draw()
        {
            Hilbert(i, h, x, y, graphics, pen);
        }
        private void Hilbert(int level, float h, float x_start, float y_start, Graphics graphics, Pen pen)
        {
            List<Point> p = new List<Point>();
            float l = h;
            p.Add(new Point(x_start, y_start));
            p.Add(new Point(x_start, y_start - h));
            p.Add(new Point(x_start + h, y_start - h));
            p.Add(new Point(x_start + h, y_start));
            for (int i = 0; i < level - 1; i++)
            {
                List<Point> new_p = new List<Point>();
                for (int j = 0; j < p.Count; j++)
                {
                    new_p.Add(new Point(-p[j].y + y_start, -p[j].x + y_start));
                }
                for (int j = 0; j < p.Count; j++)
                {
                    new_p.Add(new Point(p[j].x, p[j].y - l - h));
                }
                for (int j = 0; j < p.Count; j++)
                {
                    new_p.Add(new Point(p[j].x + l + h, p[j].y - l - h));
                }
                for (int j = 0; j < p.Count; j++)
                {
                    new_p.Add(new Point(p[j].y + 2 * l + h - y_start, p[j].x + y_start - l));
                }
                p = new_p;
                l = l * 2 + h;
            }
            for (int i = 1; i < p.Count; i++)
            {
                DrawLine(graphics, pen, p[i - 1], p[i]);
            }
        }
        private void DrawLine(Graphics graphics, Pen pen, Point p1, Point p2)
        {
            graphics.DrawLine(pen, p1.x, p1.y, p2.x, p2.y);
        }
    }
}
