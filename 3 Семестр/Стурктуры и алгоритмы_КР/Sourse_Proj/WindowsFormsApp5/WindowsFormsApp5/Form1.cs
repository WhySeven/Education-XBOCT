using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';
        }
        private void reg_button_Click(object sender, EventArgs e)
        {
            if (txt_login.Text != "" && txt_pass.Text != "")
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(txt_login.Text + " " + txt_pass.Text + "\n");
                }
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (txt_login.Text != "" && txt_pass.Text != "")
            {
                using (StreamReader sr = new StreamReader("log.txt", System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(' ');
                        if (words[0] == txt_login.Text && words[1] == txt_pass.Text)
                        {
                            login_button.Hide();
                            reg_button.Hide();
                            txt_login.Hide();
                            txt_pass.Hide();
                            l_pass.Hide();
                            l_log.Hide();
                            l_level.Show();
                            txt_level.Show();
                            start_button.Show();
                        }
                    }
                }
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txt_level.Text);
            Graph_space space = new Graph_space(this);
            Graph graph = new Graph(i,space);
            graph.Draw();
        }

        private void txt_level_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 49 && e.KeyChar <= 56) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txt_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
