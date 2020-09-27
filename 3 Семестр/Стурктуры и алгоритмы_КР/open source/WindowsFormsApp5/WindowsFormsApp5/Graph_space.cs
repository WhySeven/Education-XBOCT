using System.Drawing;


namespace WindowsFormsApp5
{
    class Graph_space
    {
        public Form1 formMain;
        public Graphics graphics;
        Bitmap bmp;
        public Graph_space(Form1 p_formMain)
        {
            formMain = p_formMain;
            bmp = new Bitmap(formMain.graph_space.Width, formMain.graph_space.Height);
            graphics = Graphics.FromImage(bmp);
            formMain.graph_space.Image = bmp;
        }
    }
}
