namespace NumericalMethods_CourseWork
{
    partial class Main_Form
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
            this.Table = new System.Windows.Forms.DataGridView();
            this.Field_a = new System.Windows.Forms.TextBox();
            this.Field_h = new System.Windows.Forms.TextBox();
            this.Euler_button = new System.Windows.Forms.Button();
            this.Adams_button = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Time_label = new System.Windows.Forms.Label();
            this.Field_y0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(12, 154);
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.Size = new System.Drawing.Size(776, 284);
            this.Table.TabIndex = 10;
            this.Table.TabStop = false;
            this.Table.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Table_RowsAdded);
            // 
            // Field_a
            // 
            this.Field_a.Location = new System.Drawing.Point(78, 38);
            this.Field_a.Name = "Field_a";
            this.Field_a.Size = new System.Drawing.Size(100, 20);
            this.Field_a.TabIndex = 1;
            this.Field_a.Text = "0";
            // 
            // Field_h
            // 
            this.Field_h.Location = new System.Drawing.Point(78, 64);
            this.Field_h.Name = "Field_h";
            this.Field_h.Size = new System.Drawing.Size(100, 20);
            this.Field_h.TabIndex = 2;
            this.Field_h.Text = "0,1";
            // 
            // Euler_button
            // 
            this.Euler_button.Location = new System.Drawing.Point(526, 125);
            this.Euler_button.Name = "Euler_button";
            this.Euler_button.Size = new System.Drawing.Size(128, 23);
            this.Euler_button.TabIndex = 5;
            this.Euler_button.Text = "Euler method";
            this.Euler_button.UseVisualStyleBackColor = true;
            this.Euler_button.Click += new System.EventHandler(this.Euler_button_Click);
            // 
            // Adams_button
            // 
            this.Adams_button.Location = new System.Drawing.Point(660, 125);
            this.Adams_button.Name = "Adams_button";
            this.Adams_button.Size = new System.Drawing.Size(128, 23);
            this.Adams_button.TabIndex = 6;
            this.Adams_button.Text = "Adams method";
            this.Adams_button.UseVisualStyleBackColor = true;
            this.Adams_button.Click += new System.EventHandler(this.Adams_button_Click);
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Location = new System.Drawing.Point(42, 130);
            this.Time_label.Name = "Time_label";
            this.Time_label.Size = new System.Drawing.Size(13, 13);
            this.Time_label.TabIndex = 7;
            this.Time_label.Text = "0";
            // 
            // Field_y0
            // 
            this.Field_y0.Location = new System.Drawing.Point(78, 90);
            this.Field_y0.Name = "Field_y0";
            this.Field_y0.Size = new System.Drawing.Size(100, 20);
            this.Field_y0.TabIndex = 8;
            this.Field_y0.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "a = ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "h = ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "y0 = ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(184, 36);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.TabIndex = 3;
            this.Add_button.Text = "Add";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(184, 62);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_button.TabIndex = 4;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Field_y0);
            this.Controls.Add(this.Time_label);
            this.Controls.Add(this.Adams_button);
            this.Controls.Add(this.Euler_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.Field_h);
            this.Controls.Add(this.Field_a);
            this.Controls.Add(this.Table);
            this.Name = "Main_Form";
            this.Text = "NumericalMethods";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TextBox Field_a;
        private System.Windows.Forms.TextBox Field_h;
        private System.Windows.Forms.Button Euler_button;
        private System.Windows.Forms.Button Adams_button;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label Time_label;
        private System.Windows.Forms.TextBox Field_y0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Delete_button;
    }
}

