namespace WindowsFormsApp5
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
            this.graph_space = new System.Windows.Forms.PictureBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.l_log = new System.Windows.Forms.Label();
            this.l_pass = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.reg_button = new System.Windows.Forms.Button();
            this.l_level = new System.Windows.Forms.Label();
            this.txt_level = new System.Windows.Forms.TextBox();
            this.start_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graph_space)).BeginInit();
            this.SuspendLayout();
            // 
            // graph_space
            // 
            this.graph_space.BackColor = System.Drawing.Color.White;
            this.graph_space.Location = new System.Drawing.Point(37, 31);
            this.graph_space.Name = "graph_space";
            this.graph_space.Size = new System.Drawing.Size(701, 701);
            this.graph_space.TabIndex = 0;
            this.graph_space.TabStop = false;
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(898, 55);
            this.txt_login.MaxLength = 10;
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(225, 20);
            this.txt_login.TabIndex = 1;
            this.txt_login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_login_KeyPress);
            // 
            // l_log
            // 
            this.l_log.AutoSize = true;
            this.l_log.Location = new System.Drawing.Point(827, 58);
            this.l_log.Name = "l_log";
            this.l_log.Size = new System.Drawing.Size(38, 13);
            this.l_log.TabIndex = 2;
            this.l_log.Text = "Логин";
            // 
            // l_pass
            // 
            this.l_pass.AutoSize = true;
            this.l_pass.Location = new System.Drawing.Point(827, 100);
            this.l_pass.Name = "l_pass";
            this.l_pass.Size = new System.Drawing.Size(45, 13);
            this.l_pass.TabIndex = 4;
            this.l_pass.Text = "Пароль";
            // 
            // txt_pass
            // 
            this.txt_pass.CausesValidation = false;
            this.txt_pass.Location = new System.Drawing.Point(898, 97);
            this.txt_pass.MaxLength = 10;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(225, 20);
            this.txt_pass.TabIndex = 3;
            this.txt_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pass_KeyPress);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(898, 141);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(112, 46);
            this.login_button.TabIndex = 5;
            this.login_button.Text = "Вход";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // reg_button
            // 
            this.reg_button.Location = new System.Drawing.Point(1011, 141);
            this.reg_button.Name = "reg_button";
            this.reg_button.Size = new System.Drawing.Size(112, 46);
            this.reg_button.TabIndex = 6;
            this.reg_button.Text = "Регистрация";
            this.reg_button.UseVisualStyleBackColor = true;
            this.reg_button.Click += new System.EventHandler(this.reg_button_Click);
            // 
            // l_level
            // 
            this.l_level.AutoSize = true;
            this.l_level.Location = new System.Drawing.Point(827, 349);
            this.l_level.Name = "l_level";
            this.l_level.Size = new System.Drawing.Size(51, 13);
            this.l_level.TabIndex = 7;
            this.l_level.Text = "Порядок";
            this.l_level.Visible = false;
            // 
            // txt_level
            // 
            this.txt_level.Location = new System.Drawing.Point(898, 346);
            this.txt_level.MaxLength = 1;
            this.txt_level.Name = "txt_level";
            this.txt_level.Size = new System.Drawing.Size(225, 20);
            this.txt_level.TabIndex = 8;
            this.txt_level.Visible = false;
            this.txt_level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_level_KeyPress);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(898, 389);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(225, 46);
            this.start_button.TabIndex = 9;
            this.start_button.Text = "старт";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Visible = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 776);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.txt_level);
            this.Controls.Add(this.l_level);
            this.Controls.Add(this.reg_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.l_pass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.l_log);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.graph_space);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph_space)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.Label l_log;
        private System.Windows.Forms.Label l_pass;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button reg_button;
        private System.Windows.Forms.Label l_level;
        private System.Windows.Forms.TextBox txt_level;
        private System.Windows.Forms.Button start_button;
        public System.Windows.Forms.PictureBox graph_space;
    }
}

