
namespace PresensiTes
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogin = new System.Windows.Forms.Button();
            this.txPassword = new System.Windows.Forms.TextBox();
            this.txUsername = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(59, 329);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(232, 30);
            this.buttonLogin.TabIndex = 12;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // txPassword
            // 
            this.txPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPassword.Location = new System.Drawing.Point(59, 202);
            this.txPassword.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.txPassword.Name = "txPassword";
            this.txPassword.Size = new System.Drawing.Size(232, 22);
            this.txPassword.TabIndex = 9;
            this.txPassword.UseSystemPasswordChar = true;
            // 
            // txUsername
            // 
            this.txUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txUsername.Location = new System.Drawing.Point(59, 144);
            this.txUsername.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.txUsername.Name = "txUsername";
            this.txUsername.Size = new System.Drawing.Size(232, 22);
            this.txUsername.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btMinimize);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panel1.Size = new System.Drawing.Size(350, 50);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login";
            // 
            // btMinimize
            // 
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Font = new System.Drawing.Font("Poppins Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMinimize.ForeColor = System.Drawing.Color.White;
            this.btMinimize.Location = new System.Drawing.Point(284, 12);
            this.btMinimize.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(26, 26);
            this.btMinimize.TabIndex = 2;
            this.btMinimize.Text = "_";
            this.btMinimize.UseVisualStyleBackColor = true;
            this.btMinimize.Click += new System.EventHandler(this.btMinimize_Click);
            // 
            // btClose
            // 
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold);
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(315, 12);
            this.btClose.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(26, 26);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(232, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(59, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(59, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipe Login :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(193, 231);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Lihat Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.txPassword);
            this.Controls.Add(this.txUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox txPassword;
        private System.Windows.Forms.TextBox txUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

