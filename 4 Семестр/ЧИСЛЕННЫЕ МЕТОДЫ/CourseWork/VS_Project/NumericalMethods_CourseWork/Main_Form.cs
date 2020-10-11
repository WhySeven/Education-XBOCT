using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericalMethods_CourseWork
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            Table.Columns.Add("x", "x");
        }
        double Function(double x, double y) // Наша функция
        {
            return 2 * Math.Pow(x,2) + 5 * x * Math.Sin(y);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Field_a.Text, out _) && double.TryParse(Field_h.Text, out _))
            {
                Table.Rows.Add();
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Field_a.Text, out _) && double.TryParse(Field_h.Text, out _))
            {
                Table.Rows.Add();
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count > 1)
            {
                Table.Rows.RemoveAt(Table.Rows.Count-1);
            }
        }
        private void Table_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double a = Convert.ToDouble(Field_a.Text), h = Convert.ToDouble(Field_h.Text);
            for (int i = 0; i < Table.Rows.Count; ++i)
            {
                Table.Rows[i].Cells[0].Value = a + i * h;
            }
        }

        private void Euler_button_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            double a = Convert.ToDouble(Field_a.Text), h = Convert.ToDouble(Field_h.Text), y0 = Convert.ToDouble(Field_y0.Text);
            for (int i = 0; i < Table.Rows.Count; ++i)
            {
                Table.Rows[i].Cells[0].Value = a + i * h;
            }
            if (Table.Columns.Count == 1)
            {
                Table.Columns.Add("y", "y");
                Table.Columns.Add("f(x, y)", "f(x, y)");
            }
            else if (Table.Columns.Count == 8)
            {
                for (int i = 7; i >= 2; --i)
                {
                    Table.Columns.RemoveAt(i);
                }
                Table.Columns.Add("f(x, y)", "f(x, y)");
            }
            Table.Rows[0].Cells[1].Value = y0;
            double x = Convert.ToDouble(Table.Rows[0].Cells[0].Value), y = Convert.ToDouble(Table.Rows[0].Cells[1].Value);
            Table.Rows[0].Cells[2].Value = Function(x, y);
            double fxy = Convert.ToDouble(Table.Rows[0].Cells[2].Value);
            for (int i = 1; i < Table.Rows.Count; ++i)
            {
                Table.Rows[i].Cells[1].Value = y + h * fxy;
                x = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[2].Value = Function(x, y);
                fxy = Convert.ToDouble(Table.Rows[i].Cells[2].Value);
            }
            Time_label.Text = $"Время выполнения составило {DateTime.Now - t:s\\.FFFFFFF} секунд";
        }

        private void Adams_button_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            double h = Convert.ToDouble(Field_h.Text), y0 = Convert.ToDouble(Field_y0.Text);
            double[] x = new double[Table.Rows.Count], y = new double[Table.Rows.Count], fxy = new double[Table.Rows.Count];
            int temp = Table.Rows.Count;
            if (temp < 4)
            {
                for (int i = 0; i < 4 - temp; ++i)
                {
                    Table.Rows.Add();
                }
            }
            if (Table.Columns.Count == 1)
            {
                Table.Columns.Add("y", "y");
                Table.Columns.Add("Δy", "Δy");
                Table.Columns.Add("f(x, y)", "f(x, y)");
                Table.Columns.Add("q", "q");
                Table.Columns.Add("Δq", "Δq");
                Table.Columns.Add("Δ²q", "Δ²q");
                Table.Columns.Add("Δ³q", "Δ³q");
            }
            else if (Table.Columns.Count == 3)
            {
                Table.Columns.RemoveAt(2);
                Table.Columns.Add("Δy", "Δy");
                Table.Columns.Add("f(x, y)", "f(x, y)");
                Table.Columns.Add("q", "q");
                Table.Columns.Add("Δq", "Δq");
                Table.Columns.Add("Δ²q", "Δ²q");
                Table.Columns.Add("Δ³q", "Δ³q");
            }
            Table.Rows[0].Cells[1].Value = y0;
            x[0] = Convert.ToDouble(Table.Rows[0].Cells[0].Value);
            y[0] = Convert.ToDouble(Table.Rows[0].Cells[1].Value);
            Table.Rows[0].Cells[3].Value = Function(x[0], y[0]);
            fxy[0] = Convert.ToDouble(Table.Rows[0].Cells[3].Value);
            for (int i = 1; i < 4; ++i)
            {
                Table.Rows[i].Cells[1].Value = y[i - 1] + h * fxy[i - 1];
                x[i] = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y[i] = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[3].Value = Function(x[i], y[i]);
                fxy[i] = Convert.ToDouble(Table.Rows[i].Cells[3].Value);
            }

            for (int i = 0; i < 4; ++i)
            {
                x[i] = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y[i] = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[3].Value = Function(x[i], y[i]);
                fxy[i] = Convert.ToDouble(Table.Rows[i].Cells[3].Value);
                Table.Rows[i].Cells[4].Value = h * fxy[i];
            }
            for (int k = 0; k < Table.Rows.Count - 4; ++k)
            {
                for (int j = 3; j > 0; --j)
                {
                    for (int i = 0; i < j; ++i)
                    {
                        Table.Rows[k + i].Cells[8 - j].Value = Convert.ToDouble(Table.Rows[k + i + 1].Cells[6 - j + 1].Value) - Convert.ToDouble(Table.Rows[k + i].Cells[6 - j + 1].Value);
                    }
                }
                Table.Rows[k + 3].Cells[2].Value = Convert.ToDouble(Table.Rows[k + 3].Cells[4].Value) + Convert.ToDouble(Table.Rows[k + 2].Cells[5].Value) / 2 + 5 * Convert.ToDouble(Table.Rows[k + 1].Cells[6].Value) / 12 + 3 * Convert.ToDouble(Table.Rows[k].Cells[7].Value) / 8;
                Table.Rows[k + 4].Cells[1].Value = Convert.ToDouble(Table.Rows[k + 3].Cells[1].Value) + Convert.ToDouble(Table.Rows[k + 3].Cells[2].Value);
                Table.Rows[k + 4].Cells[3].Value = Function(Convert.ToDouble(Table.Rows[k + 4].Cells[0].Value), Convert.ToDouble(Table.Rows[k + 4].Cells[1].Value));
                Table.Rows[k + 4].Cells[4].Value = h * Convert.ToDouble(Table.Rows[k + 4].Cells[3].Value);
            }
            Time_label.Text = $"Время выполнения составило {DateTime.Now - t:s\\.FFFFFFF} секунд";

        }
    }
}
