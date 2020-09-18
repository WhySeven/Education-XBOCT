namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.formulaX_txt = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.y_start = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.form_eps = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.x_start = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.result_txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.formulaY_txt = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txt11 = new System.Windows.Forms.RichTextBox();
            this.txt10 = new System.Windows.Forms.RichTextBox();
            this.txt01 = new System.Windows.Forms.RichTextBox();
            this.txt00 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.s0_0 = new System.Windows.Forms.RichTextBox();
            this.s0_1 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_f_2 = new System.Windows.Forms.RichTextBox();
            this.txt_f_1 = new System.Windows.Forms.RichTextBox();
            this.resotto = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formulaX_txt
            // 
            this.formulaX_txt.Location = new System.Drawing.Point(59, 128);
            this.formulaX_txt.Name = "formulaX_txt";
            this.formulaX_txt.Size = new System.Drawing.Size(341, 31);
            this.formulaX_txt.TabIndex = 0;
            this.formulaX_txt.Text = "x+y-3";
            this.formulaX_txt.TextChanged += new System.EventHandler(this.formulaX_txt_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.y_start, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.form_eps, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.x_start, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 67);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // y_start
            // 
            this.y_start.Location = new System.Drawing.Point(113, 3);
            this.y_start.Name = "y_start";
            this.y_start.Size = new System.Drawing.Size(100, 25);
            this.y_start.TabIndex = 7;
            this.y_start.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "eps";
            // 
            // form_eps
            // 
            this.form_eps.Location = new System.Drawing.Point(220, 3);
            this.form_eps.Name = "form_eps";
            this.form_eps.Size = new System.Drawing.Size(100, 25);
            this.form_eps.TabIndex = 8;
            this.form_eps.Text = "0,0001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "x0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "y0";
            // 
            // x_start
            // 
            this.x_start.Location = new System.Drawing.Point(3, 3);
            this.x_start.Name = "x_start";
            this.x_start.Size = new System.Drawing.Size(100, 25);
            this.x_start.TabIndex = 6;
            this.x_start.Text = "1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem2.Text = "123";
            // 
            // result_txt
            // 
            this.result_txt.AutoSize = true;
            this.result_txt.Location = new System.Drawing.Point(42, 385);
            this.result_txt.Name = "result_txt";
            this.result_txt.Size = new System.Drawing.Size(13, 13);
            this.result_txt.TabIndex = 3;
            this.result_txt.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "f1(x) =";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Раскалькулировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "x=";
            // 
            // formulaY_txt
            // 
            this.formulaY_txt.Location = new System.Drawing.Point(59, 165);
            this.formulaY_txt.Name = "formulaY_txt";
            this.formulaY_txt.Size = new System.Drawing.Size(341, 31);
            this.formulaY_txt.TabIndex = 13;
            this.formulaY_txt.Text = "x^2+y^2-9";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "f2(x) =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "y=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "0";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txt11, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt01, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt00, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(72, 320);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // txt11
            // 
            this.txt11.Location = new System.Drawing.Point(103, 53);
            this.txt11.Name = "txt11";
            this.txt11.Size = new System.Drawing.Size(94, 44);
            this.txt11.TabIndex = 22;
            this.txt11.Text = "2*y";
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(3, 53);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(94, 44);
            this.txt10.TabIndex = 21;
            this.txt10.Text = "2*x";
            // 
            // txt01
            // 
            this.txt01.Location = new System.Drawing.Point(103, 3);
            this.txt01.Name = "txt01";
            this.txt01.Size = new System.Drawing.Size(94, 44);
            this.txt01.TabIndex = 20;
            this.txt01.Text = "1";
            // 
            // txt00
            // 
            this.txt00.Location = new System.Drawing.Point(3, 3);
            this.txt00.Name = "txt00";
            this.txt00.Size = new System.Drawing.Size(94, 44);
            this.txt00.TabIndex = 19;
            this.txt00.Text = "1";
            this.txt00.TextChanged += new System.EventHandler(this.txt00_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "W(x)";
            // 
            // s0_0
            // 
            this.s0_0.Location = new System.Drawing.Point(512, 317);
            this.s0_0.Name = "s0_0";
            this.s0_0.Size = new System.Drawing.Size(224, 47);
            this.s0_0.TabIndex = 19;
            this.s0_0.Text = "";
            // 
            // s0_1
            // 
            this.s0_1.Location = new System.Drawing.Point(512, 370);
            this.s0_1.Name = "s0_1";
            this.s0_1.Size = new System.Drawing.Size(224, 47);
            this.s0_1.TabIndex = 20;
            this.s0_1.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(623, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "s0";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(370, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "F(x0)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txt_f_2
            // 
            this.txt_f_2.Location = new System.Drawing.Point(282, 373);
            this.txt_f_2.Name = "txt_f_2";
            this.txt_f_2.Size = new System.Drawing.Size(224, 47);
            this.txt_f_2.TabIndex = 23;
            this.txt_f_2.Text = "";
            // 
            // txt_f_1
            // 
            this.txt_f_1.Location = new System.Drawing.Point(282, 317);
            this.txt_f_1.Name = "txt_f_1";
            this.txt_f_1.Size = new System.Drawing.Size(224, 47);
            this.txt_f_1.TabIndex = 22;
            this.txt_f_1.Text = "";
            // 
            // resotto
            // 
            this.resotto.AutoSize = true;
            this.resotto.Location = new System.Drawing.Point(647, 128);
            this.resotto.Name = "resotto";
            this.resotto.Size = new System.Drawing.Size(36, 13);
            this.resotto.TabIndex = 25;
            this.resotto.Text = "f1(x) =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 554);
            this.Controls.Add(this.resotto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_f_2);
            this.Controls.Add(this.txt_f_1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.s0_1);
            this.Controls.Add(this.s0_0);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.formulaY_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.formulaX_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_txt);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox formulaX_txt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label result_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox x_start;
        private System.Windows.Forms.RichTextBox y_start;
        private System.Windows.Forms.RichTextBox form_eps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox formulaY_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox txt11;
        private System.Windows.Forms.RichTextBox txt10;
        private System.Windows.Forms.RichTextBox txt01;
        private System.Windows.Forms.RichTextBox txt00;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox s0_0;
        private System.Windows.Forms.RichTextBox s0_1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txt_f_2;
        private System.Windows.Forms.RichTextBox txt_f_1;
        private System.Windows.Forms.Label resotto;
    }
}

