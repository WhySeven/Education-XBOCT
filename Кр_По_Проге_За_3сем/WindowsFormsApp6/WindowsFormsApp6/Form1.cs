using Flee.PublicTypes;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double x0 = Convert.ToDouble(x_start.Text);
            double y0 = Convert.ToDouble(y_start.Text);
            double epsel = Convert.ToDouble(form_eps.Text);
            string formulaX = formulaX_txt.Text;
            string formulaY = formulaY_txt.Text;
            Method_sukuchih(formulaX, formulaY, x0, y0);
        }

        public void Method_sukuchih(string formula1, string formula2, double x, double y)
        {
            double[,] W = new double[2, 2];
            W[0, 0] = F(x, y, txt00.Text);
            W[0, 1] = F(x, y, txt01.Text);
            W[1, 0] = F(x, y, txt10.Text);
            W[1, 1] = F(x, y, txt11.Text);
            // Заполняем матрицу

            double[,] A = InverseMatrix(W);
            PrintMatrix(A);
            // Строим обратную матрицу

            double[] F0 = new double[2];
            F0 [0] = F(x, y, formula1);
            F0 [1] = F(x, y, formula2);
            //Значение функций, используя точки начального приближения

            txt_f_1.Text = Convert.ToString(F0[0]);
            txt_f_2.Text = Convert.ToString(F0[1]);

            double[] s0 = new double[2];
            s0[0] = -(F0[0] * A[0, 0] + F0[1] * A[0, 1]);
            s0[1] = -(F0[0] * A[1, 0] + F0[1] * A[1, 1]);
            //s0

            s0_0.Text = Convert.ToString(s0[0]);
            s0_1.Text = Convert.ToString(s0[1]);



            double x1 = x + s0[0];
            double y1 = y + s0[1];

            double[] F1 = new double[2];
            F1[0] = F(x1, y1, formula1);
            F1[1] = F(x1, y1, formula2);
            ////Значение функций, используя точки x1,y1

            double[] Fy = new double[2];
            Fy[0] = F1[0] - F0[0];
            Fy[1] = F1[1] - F0[1];
            // y0
            

            double[] y0_a0s0 = new double [2] ;
            y0_a0s0[0] = Fy[0] - (W[0, 0] * s0[0] + W[0, 1] * s0[1]);
            y0_a0s0[1] = Fy[1] - (W[1, 0] * s0[0] + W[1, 1] * s0[1]);

            double s0ts0 = Math.Pow(s0[0], 2) + Math.Pow(s0[1],2);
            double[,] y0_a0s0_st0  = new double[2,2];

            y0_a0s0_st0[0, 0] = y0_a0s0[0] * s0[0];
            y0_a0s0_st0[0, 1] = y0_a0s0[0] * s0[1];
            y0_a0s0_st0[1, 0] = y0_a0s0[1] * s0[0];
            y0_a0s0_st0[1, 1] = y0_a0s0[1] * s0[1];

            y0_a0s0_st0 = MatrixDecrease(y0_a0s0_st0, s0ts0);



            double[,] A1 = MatrixAddition(y0_a0s0_st0,W);

            PrintMatrix(A1);

            resotto.Text = Convert.ToString(y0_a0s0_st0);
            


        }
        public double[,] MatrixAddition (double[,] W, double[,] A)
        {
            W[0, 0] += A[0, 0];
            W[0, 1] += A[0, 1];
            W[1, 0] += A[1, 0];
            W[1, 1] += A[1, 1];
            return W;
        }
        public void PrintMatrix(double[,] W)
        {
            txt00.Text = Convert.ToString(W[0, 0]);
            txt01.Text = Convert.ToString(W[0, 1]);
            txt10.Text = Convert.ToString(W[1, 0]);
            txt11.Text = Convert.ToString(W[1, 1]);
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
            double[,] res = new double[2,2];
            res[0, 0] = A[1, 1] / d;
            res[1, 1] = A[0, 0] / d;
            res[0, 1] = A[1, 0] / (-d);
            res[1, 0] = A[0, 1] / (-d);



            return res;
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

        public double F(double x, double y, string formula)
        {
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = x;
            context.Variables["y"] = y;

            IDynamicExpression eDynamic = context.CompileDynamic(formula+"+x*0");
            IGenericExpression<double> eGeneric = context.CompileGeneric<double>(formula + "+x*0");
            double result = (double)eDynamic.Evaluate();
            result = eGeneric.Evaluate();
            return result;
        }

        public class Point
        {
            public double x;
            public double y;
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public void Derivative(string formula)
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = x;
            context.Variables["y"] = y;
            context.Variables["z"] = z;
            IDynamicExpression eDynamic = context.CompileDynamic(formula);
            IGenericExpression<double> eGeneric = context.CompileGeneric<double>(formula);
            double res = (double)eDynamic.Evaluate();
            res = eGeneric.Evaluate();
            List<List<double>> table = new List<List<double>>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i][j] = 1;
                }
            }
        }

        public string SysUravneniy(double x, double y, double eps, string formulaX, string formulaY)
        {
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = x;
            context.Variables["y"] = y;

            IDynamicExpression eDynamicX = context.CompileDynamic(formulaX);
            IGenericExpression<double> eGenericX = context.CompileGeneric<double>(formulaX);
            double resX = (double)eDynamicX.Evaluate();
            resX = eGenericX.Evaluate();

            IDynamicExpression eDynamicY = context.CompileDynamic(formulaY);
            IGenericExpression<double> eGenericY = context.CompileGeneric<double>(formulaY);
            double resY = (double)eDynamicY.Evaluate();
            resY = eGenericY.Evaluate();

            double xtmp = 0;
            double ytmp = 0;
            do
            {
                xtmp = x;
                ytmp = y;
                context.Variables["x"] = x;
                context.Variables["y"] = y;
                resX = eGenericX.Evaluate();
                resY = eGenericY.Evaluate();
                x = resX;
                y = resY;
            } 
            while ((Math.Abs(xtmp - x) > eps)||(Math.Abs(ytmp-y)>eps));

            string s = "x = " + x + " ; y = " + y + " ;"; 

            return s;
        }
        public double SoloUravnenie(double a, double b, double eps, string formula)
        {
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = 0.0;
            IDynamicExpression eDynamic = context.CompileDynamic(formula);
            IGenericExpression<double> eGeneric = context.CompileGeneric<double>(formula);

            // Evaluate the expressions
            double result = (double)eDynamic.Evaluate();
            result = eGeneric.Evaluate();

            context.Variables["x"] = a;
            result = eGeneric.Evaluate();
            double res_a = result;
            context.Variables["x"] = b;
            result = eGeneric.Evaluate();
            double res_b = result;

            double x;
            double tmp;

            do
            {
                x = a;
                a = a - (res_a * (b - a)) / (res_b - res_a);
                tmp = a;
                context.Variables["x"] = a;
                result = eGeneric.Evaluate();
                res_a = result;

            } while (Math.Abs(x - tmp) > eps);
            return a;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt00_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void formulaX_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
