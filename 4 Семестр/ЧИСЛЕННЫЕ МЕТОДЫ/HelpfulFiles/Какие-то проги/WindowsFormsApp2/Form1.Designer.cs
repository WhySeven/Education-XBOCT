namespace WindowsFormsApp2
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
            if (disposing && ( components != null ))
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
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.eulerDataGrid = new System.Windows.Forms.DataGridView();
            this.adamsDataGrid = new System.Windows.Forms.DataGridView();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.timeTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.stepBox = new System.Windows.Forms.ToolStripTextBox();
            this.leftBorderBox = new System.Windows.Forms.ToolStripTextBox();
            this.rightBorderBox = new System.Windows.Forms.ToolStripTextBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.x_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dy_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d3q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.LY0 = new System.Windows.Forms.Label();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eulerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamsDataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(43, 28);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(179, 20);
            this.yTextBox.TabIndex = 0;
            // 
            // eulerDataGrid
            // 
            this.eulerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eulerDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y,
            this.dy});
            this.eulerDataGrid.Location = new System.Drawing.Point(12, 78);
            this.eulerDataGrid.Name = "eulerDataGrid";
            this.eulerDataGrid.RowHeadersVisible = false;
            this.eulerDataGrid.Size = new System.Drawing.Size(385, 360);
            this.eulerDataGrid.TabIndex = 1;
            // 
            // adamsDataGrid
            // 
            this.adamsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adamsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x_,
            this.y_,
            this.dy_,
            this.f,
            this.q,
            this.dq,
            this.d2q,
            this.d3q});
            this.adamsDataGrid.Location = new System.Drawing.Point(403, 78);
            this.adamsDataGrid.Name = "adamsDataGrid";
            this.adamsDataGrid.RowHeadersVisible = false;
            this.adamsDataGrid.Size = new System.Drawing.Size(385, 359);
            this.adamsDataGrid.TabIndex = 2;
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Эйлер",
            "Адамс"});
            this.methodComboBox.Location = new System.Drawing.Point(276, 28);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 21);
            this.methodComboBox.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.stepBox,
            this.toolStripLabel2,
            this.leftBorderBox,
            this.toolStripLabel3,
            this.rightBorderBox,
            this.toolStripLabel1,
            this.timeTextBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(196, 25);
            // 
            // stepBox
            // 
            this.stepBox.Name = "stepBox";
            this.stepBox.Size = new System.Drawing.Size(150, 25);
            // 
            // leftBorderBox
            // 
            this.leftBorderBox.Name = "leftBorderBox";
            this.leftBorderBox.Size = new System.Drawing.Size(150, 25);
            // 
            // rightBorderBox
            // 
            this.rightBorderBox.Name = "rightBorderBox";
            this.rightBorderBox.Size = new System.Drawing.Size(150, 25);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(403, 28);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(385, 23);
            this.Calculate.TabIndex = 5;
            this.Calculate.Text = "Вычислить выбранным методом";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // x_
            // 
            this.x_.HeaderText = "x";
            this.x_.Name = "x_";
            // 
            // y_
            // 
            this.y_.HeaderText = "y";
            this.y_.Name = "y_";
            // 
            // dy_
            // 
            this.dy_.HeaderText = "Δy";
            this.dy_.Name = "dy_";
            // 
            // f
            // 
            this.f.HeaderText = "y\'";
            this.f.Name = "f";
            // 
            // q
            // 
            this.q.HeaderText = "q";
            this.q.Name = "q";
            // 
            // dq
            // 
            this.dq.HeaderText = "Δq";
            this.dq.Name = "dq";
            // 
            // d2q
            // 
            this.d2q.HeaderText = "Δ²q";
            this.d2q.Name = "d2q";
            // 
            // d3q
            // 
            this.d3q.HeaderText = "Δ³q";
            this.d3q.Name = "d3q";
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            // 
            // dy
            // 
            this.dy.HeaderText = "Δy";
            this.dy.Name = "dy";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Время:";
            // 
            // LY0
            // 
            this.LY0.AutoSize = true;
            this.LY0.Location = new System.Drawing.Point(12, 31);
            this.LY0.Name = "LY0";
            this.LY0.Size = new System.Drawing.Size(25, 13);
            this.LY0.TabIndex = 6;
            this.LY0.Text = "y₀ =";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel2.Text = "a =";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel3.Text = "b =";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel4.Text = "h =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Метод:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "y\'=2xy+5x-y+y²";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LY0);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.adamsDataGrid);
            this.Controls.Add(this.eulerDataGrid);
            this.Controls.Add(this.yTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.eulerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamsDataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.DataGridView eulerDataGrid;
        private System.Windows.Forms.DataGridView adamsDataGrid;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox timeTextBox;
        private System.Windows.Forms.ToolStripTextBox stepBox;
        private System.Windows.Forms.ToolStripTextBox leftBorderBox;
        private System.Windows.Forms.ToolStripTextBox rightBorderBox;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn dy;
        private System.Windows.Forms.DataGridViewTextBoxColumn x_;
        private System.Windows.Forms.DataGridViewTextBoxColumn y_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dy_;
        private System.Windows.Forms.DataGridViewTextBoxColumn f;
        private System.Windows.Forms.DataGridViewTextBoxColumn q;
        private System.Windows.Forms.DataGridViewTextBoxColumn dq;
        private System.Windows.Forms.DataGridViewTextBoxColumn d2q;
        private System.Windows.Forms.DataGridViewTextBoxColumn d3q;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label LY0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

