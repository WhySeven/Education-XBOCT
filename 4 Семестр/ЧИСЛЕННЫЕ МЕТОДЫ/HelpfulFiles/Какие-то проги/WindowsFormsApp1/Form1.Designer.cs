namespace WindowsFormsApp1
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
            this.Table = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.TextBox();
            this.H = new System.Windows.Forms.TextBox();
            this.Euler = new System.Windows.Forms.Button();
            this.Y0 = new System.Windows.Forms.TextBox();
            this.LA = new System.Windows.Forms.Label();
            this.LH = new System.Windows.Forms.Label();
            this.LY0 = new System.Windows.Forms.Label();
            this.Adams = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(12, 225);
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowHeadersVisible = false;
            this.Table.Size = new System.Drawing.Size(776, 213);
            this.Table.TabIndex = 10;
            this.Table.TabStop = false;
            this.Table.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Table_RowsAdded);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(12, 38);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 60);
            this.Add.TabIndex = 3;
            this.Add.TabStop = false;
            this.Add.Text = "Добавить узел";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(93, 38);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 60);
            this.Remove.TabIndex = 3;
            this.Remove.TabStop = false;
            this.Remove.Text = "Убрать узел";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(40, 12);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(128, 20);
            this.A.TabIndex = 0;
            // 
            // H
            // 
            this.H.Location = new System.Drawing.Point(202, 12);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(128, 20);
            this.H.TabIndex = 1;
            // 
            // Euler
            // 
            this.Euler.Location = new System.Drawing.Point(174, 38);
            this.Euler.Name = "Euler";
            this.Euler.Size = new System.Drawing.Size(156, 60);
            this.Euler.TabIndex = 4;
            this.Euler.Text = "Рассчитать методом Эйлера";
            this.Euler.UseVisualStyleBackColor = true;
            this.Euler.Click += new System.EventHandler(this.Euler_Click);
            // 
            // Y0
            // 
            this.Y0.Location = new System.Drawing.Point(367, 12);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(125, 20);
            this.Y0.TabIndex = 2;
            // 
            // LA
            // 
            this.LA.AutoSize = true;
            this.LA.Location = new System.Drawing.Point(12, 15);
            this.LA.Name = "LA";
            this.LA.Size = new System.Drawing.Size(22, 13);
            this.LA.TabIndex = 9;
            this.LA.Text = "a =";
            // 
            // LH
            // 
            this.LH.AutoSize = true;
            this.LH.Location = new System.Drawing.Point(174, 15);
            this.LH.Name = "LH";
            this.LH.Size = new System.Drawing.Size(22, 13);
            this.LH.TabIndex = 10;
            this.LH.Text = "h =";
            // 
            // LY0
            // 
            this.LY0.AutoSize = true;
            this.LY0.Location = new System.Drawing.Point(336, 15);
            this.LY0.Name = "LY0";
            this.LY0.Size = new System.Drawing.Size(25, 13);
            this.LY0.TabIndex = 11;
            this.LY0.Text = "y₀ =";
            // 
            // Adams
            // 
            this.Adams.Location = new System.Drawing.Point(336, 38);
            this.Adams.Name = "Adams";
            this.Adams.Size = new System.Drawing.Size(156, 60);
            this.Adams.TabIndex = 5;
            this.Adams.Text = "Рассчитать методом Адамса";
            this.Adams.UseVisualStyleBackColor = true;
            this.Adams.Click += new System.EventHandler(this.Adams_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "y\'=2xy+5x-y+y²";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(13, 209);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 13);
            this.Time.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Adams);
            this.Controls.Add(this.LY0);
            this.Controls.Add(this.LH);
            this.Controls.Add(this.LA);
            this.Controls.Add(this.Y0);
            this.Controls.Add(this.Euler);
            this.Controls.Add(this.H);
            this.Controls.Add(this.A);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Table);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.TextBox H;
        private System.Windows.Forms.Button Euler;
        private System.Windows.Forms.TextBox Y0;
        private System.Windows.Forms.Label LA;
        private System.Windows.Forms.Label LH;
        private System.Windows.Forms.Label LY0;
        private System.Windows.Forms.Button Adams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Time;
    }
}

