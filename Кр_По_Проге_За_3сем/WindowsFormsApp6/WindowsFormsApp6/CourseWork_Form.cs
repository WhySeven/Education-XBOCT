using Flee.PublicTypes;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class CourseWork_Form : Form
    {
        public CourseWork_Form()
        {
            InitializeComponent();
        }

        private void CourseWork_Form_Load (object sender, EventArgs e)
        {
            
        }
        
        private void calc_button_Click(object sender, EventArgs e)
        { 
            double x = Convert.ToDouble(x_start.Text);
            double y = Convert.ToDouble(y_start.Text);
            double epsel = Convert.ToDouble(form_eps.Text);
            string formulaX = formulaX_txt.Text;
            string formulaY = formulaY_txt.Text;

            
            double[,] W = new double[2, 2];
            W[0, 0] = F(x, y, txt00.Text);
            W[0, 1] = F(x, y, txt01.Text);
            W[1, 0] = F(x, y, txt10.Text);
            W[1, 1] = F(x, y, txt11.Text);
            //Заполнение матрицы якоби.

            
            Secant_Method(formulaX, formulaY, x, y, epsel, W);
            // Вызов Метода Секущих.
        }

        public void Secant_Method(string formula1, string formula2, double x, double y,double eps, double[,] W)
        {
            double[,] invM = InverseMatrix(W);
            // Строим обратную матрицу

            double[] F0 = new double[2];
            F0 [0] = F(x, y, formula1);
            F0 [1] = F(x, y, formula2);
            //Значение функций, используя точки начального приближения

            double[] s0 = new double[2];
            s0[0] = -(F0[0] * invM[0, 0] + F0[1] * invM[0, 1]);
            s0[1] = -(F0[0] * invM[1, 0] + F0[1] * invM[1, 1]);
            //s0

            
            double x1 = x + s0[0];
            double y1 = y + s0[1];
            //Уточнённые координаты искомой точки.

            double[] F1 = new double[2];
            F1[0] = F(x1, y1, formula1);
            F1[1] = F(x1, y1, formula2);
            ////Значение функций, используя точки x1,y1

            double[] Y = new double[2];
            Y[0] = F1[0] - F0[0];
            Y[1] = F1[1] - F0[1];
            // y0
            

            double[] y0_a0s0 = new double [2] ;
            y0_a0s0[0] = Y[0] - (W[0, 0] * s0[0] + W[0, 1] * s0[1]);
            y0_a0s0[1] = Y[1] - (W[1, 0] * s0[0] + W[1, 1] * s0[1]);
            // y0-a0*s0

            double s0ts0 = Math.Pow(s0[0], 2) + Math.Pow(s0[1],2);
            // s0*s0t


            double[,] y0_a0s0_st0  = new double[2,2];
           
            y0_a0s0_st0[0, 0] = y0_a0s0[0] * s0[0];
            y0_a0s0_st0[0, 1] = y0_a0s0[0] * s0[1];
            y0_a0s0_st0[1, 0] = y0_a0s0[1] * s0[0];
            y0_a0s0_st0[1, 1] = y0_a0s0[1] * s0[1];
            //y0-a0*s0-s0t

            y0_a0s0_st0 = MatrixDecrease(y0_a0s0_st0, s0ts0);
            // matrix*(-1)


            double[,] A = MatrixAddition(y0_a0s0_st0,W);
            // Сложение матриц
            
            if (Math.Abs(s0[0]) > eps)
            {
                result_x.Text = String.Format("{0:F3}", x1);
                result_y.Text = String.Format("{0:F3}", y1);
                f1_txt.Text = String.Format("{0:F3}", F1[0]);
                f2_txt.Text = String.Format("{0:F3}", F1[1]);

                Secant_Method(formula1, formula2, x1, y1, eps, A);
                //Рекурсия
            }
        }


        public double[,] MatrixAddition (double[,] W, double[,] A)
        {
            W[0, 0] += A[0, 0];
            W[0, 1] += A[0, 1];
            W[1, 0] += A[1, 0];
            W[1, 1] += A[1, 1];
            return W;
        }
        public double[,] MatrixDecrease(double[,] W, double d)
        {
            W[0, 0] = W[0, 0]/d;
            W[1, 1] = W[1, 1]/d;
            W[1, 0] = W[1, 0]/d;
            W[0, 1] = W[0, 1]/d;
            return W;
        }
        public double[,] MatrixNegation(double[,] W)
        {
            W[0, 0] = -W[0, 0];
            W[1, 1] = -W[1, 1];
            W[1, 0] = -W[1, 0];
            W[0, 1] = -W[0, 1];
            return W;
        }
        public double[,] InverseMatrix(double[,] W)
        {
            double d = W[0, 0] * W[1, 1] - W[0, 1] * W[1, 0];
            double[,] A = TransMatrix(W);
            double[,] invM = new double[2,2];
            invM[0, 0] = A[1, 1] / d;
            invM[1, 1] = A[0, 0] / d;
            invM[0, 1] = A[1, 0] / (-d);
            invM[1, 0] = A[0, 1] / (-d);
            return invM;
        }
        public double[,] TransMatrix(double[,] W)
        {
            double[,] T = new double[2, 2];
            T[0, 0] = W[0, 0];
            T[1, 1] = W[1, 1];
            T[0, 1] = W[1, 0];
            T[1, 0] = W[0, 1];
            return T;
        }
        public void PrintMatrix(double[,] W)
        {
            txt00.Text = Convert.ToString(W[0, 0]);
            txt01.Text = Convert.ToString(W[0, 1]);
            txt10.Text = Convert.ToString(W[1, 0]);
            txt11.Text = Convert.ToString(W[1, 1]);
        }
        //Действия с матрицами.



        public double F(double x, double y, string formula)
        {
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = x;
            context.Variables["y"] = y;

            IDynamicExpression eDynamic = context.CompileDynamic(formula + "+x*0");
            IGenericExpression<double> eGeneric = context.CompileGeneric<double>(formula + "+x*0");
            double result = (double)eDynamic.Evaluate();
            result = eGeneric.Evaluate();
            return result;
        }
        //Метод рассчёта функции, используя строку, как формулу по которой будет произведён рассчёт.



        private void clear_button_Click(object sender, EventArgs e)
        {
            formulaX_txt.Text = "";
            formulaY_txt.Text = "";
            x_start.Text = "";
            y_start.Text = "";
            form_eps.Text = "";
            txt00.Text = "";
            txt01.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            result_x.Text = "0";
            result_y.Text = "0";
            f1_txt.Text = "0";
            f2_txt.Text = "0";

        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            formulaX_txt.Text = "cos(x)+y^2-3";
            formulaY_txt.Text = "x^2*2*y+y^2-9";
            txt00.Text = "-sin(x)";
            txt01.Text = "2*y";
            txt10.Text = "4*x*y";
            txt11.Text = "2*y";
            x_start.Text = "1";
            y_start.Text = "1";
            form_eps.Text = "0,0001";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            formulaX_txt.Text = "x+y-3";
            formulaY_txt.Text = "x^2+y^2-9";
            txt00.Text = "1";
            txt01.Text = "1";
            txt10.Text = "2*x";
            txt11.Text = "2*y";
            x_start.Text = "1";
            y_start.Text = "5";
            form_eps.Text = "0,001";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            formulaX_txt.Text = "x^2+y^2-2";
            formulaY_txt.Text = "e^(x-1)+y^3-2";
            txt00.Text = "2*x";
            txt01.Text = "2*y";
            txt10.Text = "e^(x-1)";
            txt11.Text = "3*y^2";
            x_start.Text = "1,5";
            y_start.Text = "2";
            form_eps.Text = "0,01";
        }
        private void example_button_Click(object sender, EventArgs e)
        {
            contextMenuExample.Show(this.Location.X + 415, this.Location.Y + 309);
        }
        private void choose_color_Click(object sender, EventArgs e)
        {
            bg_color_dialog.ShowDialog();
            this.BackColor = bg_color_dialog.Color;
        }
    }
}
