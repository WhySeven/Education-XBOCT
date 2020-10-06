using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Methods
    {
        private readonly DataGridView _eulerDataGridView;
        private readonly DataGridView _adamsDataGridView;
        private readonly ToolStripTextBox _time;
        public Methods(DataGridView eulerDataGridView, DataGridView adamsDataGridView, ToolStripTextBox time)
        {
            _eulerDataGridView = eulerDataGridView;
            _adamsDataGridView = adamsDataGridView;
            _time = time;
        }
        public List<List<double>> EulerMethod(double leftBorder, double rightBorder, double step, double initialY, bool fromAdams = false)
        {
            var stopWatch = new Stopwatch();
            if (!fromAdams)
            {
                stopWatch.Start();
            }
            _eulerDataGridView.Rows.Clear();
            _eulerDataGridView.Rows.Add();
            _eulerDataGridView.Rows[0].Cells[0].Value = leftBorder;
            _eulerDataGridView.Rows[0].Cells[1].Value = initialY;
            var listWithXY = new List<List<double>> { new List<double>(), new List<double>() };
            listWithXY[0].Add(leftBorder);
            listWithXY[1].Add(initialY);
            var row = 0;
            var y = initialY;
            for (var i = leftBorder; i < rightBorder - step; i += step)
            {
                _eulerDataGridView.Rows.Add();
                var deltaY = step * F(i, y);
                _eulerDataGridView.Rows[row].Cells[2].Value = deltaY;
                row++;
                _eulerDataGridView.Rows[row].Cells[0].Value = i + step;
                _eulerDataGridView.Rows[row].Cells[1].Value = deltaY + y;
                y = deltaY + y;
                listWithXY[0].Add(i + step);
                listWithXY[1].Add(y);
            }
            if (fromAdams) return listWithXY;
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            _time.Text = ts.ToString();
            stopWatch.Reset();
            return listWithXY;
        }
        public List<List<double>> AdamsMethod(double leftBorder, double rightBorder, double step, double initialY)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            _adamsDataGridView.Rows.Clear();
            List<List<double>> listWithXY = EulerMethod(leftBorder, leftBorder + 4 * step, step, initialY, true);
            List<double> listWithQ = new List<double>();
            List<List<double>> listWithDeltaQ = new List<List<double>> { new List<double>(), new List<double>(), new List<double>() };
            listWithQ.Add(step * F(listWithXY[0][0], listWithXY[1][0]));
            listWithQ.Add(step * F(listWithXY[0][1], listWithXY[1][1]));
            listWithQ.Add(step * F(listWithXY[0][2], listWithXY[1][2]));
            listWithQ.Add(step * F(listWithXY[0][3], listWithXY[1][3]));
            _adamsDataGridView.Rows.Add(listWithXY[0][0], listWithXY[1][0], null, F(listWithXY[0][0], listWithXY[1][0]), listWithQ[0]);
            _adamsDataGridView.Rows.Add(listWithXY[0][1], listWithXY[1][1], null, F(listWithXY[0][1], listWithXY[1][1]), listWithQ[1]);
            _adamsDataGridView.Rows.Add(listWithXY[0][2], listWithXY[1][2], null, F(listWithXY[0][2], listWithXY[1][2]), listWithQ[2]);
            _adamsDataGridView.Rows.Add(listWithXY[0][3], listWithXY[1][3], null, F(listWithXY[0][3], listWithXY[1][3]), listWithQ[3]);
            var iterCondition = 3;
            for (var i = 0; i < 3; i++)
            {
                for (var k = 0; k < iterCondition; k++)
                {
                    if (i == 0)
                    {
                        listWithDeltaQ[i].Add(listWithQ[k + 1] - listWithQ[k]);
                        _adamsDataGridView.Rows[k].Cells[i + 5].Value = listWithDeltaQ[i].Last();
                        continue;
                    }
                    listWithDeltaQ[i].Add(listWithDeltaQ[i - 1][k + 1] - listWithDeltaQ[i - 1][k]);
                    _adamsDataGridView.Rows[k].Cells[i + 5].Value = listWithDeltaQ[i].Last();
                }
                iterCondition--;
            }
            var row = 4;
            for (var x = leftBorder + 4 * step; x < rightBorder; x += step)
            {
                _adamsDataGridView.Rows.Add(x);
                var deltaY = listWithQ[row - 1] +
                                1.0 / 2.0 * listWithDeltaQ[0].Last() +
                                5.0 / 12.0 * listWithDeltaQ[1].Last() +
                                3.0 / 8.0 * listWithDeltaQ[2].Last();
                _adamsDataGridView.Rows[row - 1].Cells[2].Value = deltaY;
                var previousY = listWithXY[1].Last();
                var y = previousY + deltaY;
                listWithXY[1].Add(y);
                _adamsDataGridView.Rows[row].Cells[1].Value = y;
                _adamsDataGridView.Rows[row].Cells[3].Value = F(x, y);
                listWithQ.Add(step * F(x, y));
                _adamsDataGridView.Rows[row].Cells[4].Value = listWithQ.Last();
                listWithDeltaQ[0].Add(listWithQ.Last() - listWithQ[listWithQ.Count - 2]);
                listWithDeltaQ[1].Add(listWithDeltaQ[0].Last() - listWithDeltaQ[0][listWithDeltaQ[0].Count - 2]);
                listWithDeltaQ[2].Add(listWithDeltaQ[1].Last() - listWithDeltaQ[1][listWithDeltaQ[1].Count - 2]);
                _adamsDataGridView.Rows[row - 1].Cells[5].Value = listWithDeltaQ[0].Last();
                _adamsDataGridView.Rows[row - 2].Cells[6].Value = listWithDeltaQ[1].Last();
                _adamsDataGridView.Rows[row - 3].Cells[7].Value = listWithDeltaQ[2].Last();
                row++;
            }
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            _time.Text = ts.ToString();
            stopWatch.Reset();
            return listWithXY;
        }
        private static double F(double x, double y)
        {
            return 2 * x * y + 5 * x - y + Math.Pow(y, 2);
        }
    }
}
