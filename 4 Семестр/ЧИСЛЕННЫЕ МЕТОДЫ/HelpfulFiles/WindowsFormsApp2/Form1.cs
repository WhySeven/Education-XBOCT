using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    using static Convert;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            methodComboBox.SelectedIndex = 0;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (InitializeField(out var initialX, out var finalX, out var step, out var initialY) == false) return;
            var methods = new Methods(eulerDataGrid, adamsDataGrid, timeTextBox);
            var selectedMethod = methodComboBox.SelectedIndex;
            if (selectedMethod == 0)
                methods.EulerMethod(initialX, finalX, step, initialY);
            else if (selectedMethod == 1)
                methods.AdamsMethod(initialX, finalX, step, initialY);
        }

        private bool InitializeField(out double initialX, out double finalX, out double step, out double initialY)
        {
            var ifValidValues = true;
            var errorString = "";
            try
            {
                initialX = ToDouble(leftBorderBox.Text.Replace('.', ','));
            }
            catch
            {
                initialX = 0;
                errorString += "Incorrect left border;\n";
                ifValidValues = false;
            }
            try
            {
                finalX = ToDouble(rightBorderBox.Text.Replace('.', ','));
            }
            catch
            {
                finalX = 0;
                errorString += "Incorrect right border;\n";
                ifValidValues = false;
            }
            try
            {
                step = ToDouble(stepBox.Text.Replace('.', ','));
            }
            catch
            {
                step = 0;
                errorString += "Incorrect step;\n";
                ifValidValues = false;
            }
            try
            {
                initialY = ToDouble(yTextBox.Text.Replace('.', ','));
            }
            catch
            {
                initialY = 0;
                errorString += "Incorrect y0;\n";
                ifValidValues = false;
            }
            if (initialX > finalX)
            {
                errorString += "Left border must be lesser than right;\n";
                ifValidValues = false;
            }
            if (!ifValidValues) MessageBox.Show(errorString);
            return ifValidValues;
        }
    }
}
