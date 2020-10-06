using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Table.Columns.Add("x", "x");
        }

        double f(double x, double y)
        {
            return 2 * x * y + 5 * x - y + Math.Pow(y, 2);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (double.TryParse(A.Text, out _) && double.TryParse(H.Text, out _))
            {
                Table.Rows.Add();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count > 1)
            {
                Table.Rows.Remove(Table.Rows[Table.Rows.Count - 1]);
            }
        }

        private void Table_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double a = Convert.ToDouble(A.Text), h = Convert.ToDouble(H.Text);
            for (int i = 0; i < Table.Rows.Count; ++i)
            {
                Table.Rows[i].Cells[0].Value = a + i * h;
            }
        }

        private void Euler_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            double a = Convert.ToDouble(A.Text), h = Convert.ToDouble(H.Text), y0 = Convert.ToDouble(Y0.Text);
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
            Table.Rows[0].Cells[2].Value = f(x, y);
            double fxy = Convert.ToDouble(Table.Rows[0].Cells[2].Value);
            for (int i = 1; i < Table.Rows.Count; ++i)
            {
                Table.Rows[i].Cells[1].Value = y + h * fxy;
                x = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[2].Value = f(x, y);
                fxy = Convert.ToDouble(Table.Rows[i].Cells[2].Value);
            }
            Time.Text = $"Время выполнения составило {DateTime.Now - t:s\\.FFFFFFF} секунд";
        }

        private void Adams_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            double h = Convert.ToDouble(H.Text), y0 = Convert.ToDouble(Y0.Text);
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
            Table.Rows[0].Cells[3].Value = f(x[0], y[0]);
            fxy[0] = Convert.ToDouble(Table.Rows[0].Cells[3].Value);
            for (int i = 1; i < 4; ++i)
            {
                Table.Rows[i].Cells[1].Value = y[i - 1] + h * fxy[i - 1];
                x[i] = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y[i] = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[3].Value = f(x[i], y[i]);
                fxy[i] = Convert.ToDouble(Table.Rows[i].Cells[3].Value);
            }

            for (int i = 0; i < 4; ++i)
            {
                x[i] = Convert.ToDouble(Table.Rows[i].Cells[0].Value);
                y[i] = Convert.ToDouble(Table.Rows[i].Cells[1].Value);
                Table.Rows[i].Cells[3].Value = f(x[i], y[i]);
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
                Table.Rows[k + 4].Cells[3].Value = f(Convert.ToDouble(Table.Rows[k + 4].Cells[0].Value), Convert.ToDouble(Table.Rows[k + 4].Cells[1].Value));
                Table.Rows[k + 4].Cells[4].Value = h * Convert.ToDouble(Table.Rows[k + 4].Cells[3].Value);
            }
            Time.Text = $"Время выполнения составило {DateTime.Now - t:s\\.FFFFFFF} секунд";
        }
    }
}
