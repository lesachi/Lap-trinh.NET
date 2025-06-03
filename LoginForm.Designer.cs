namespace BookStore
{
    partial class LoginForm
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
            this.panelSidetop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.panelsideLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.lbpassword = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.cbPass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelSidetop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidetop
            // 
            this.panelSidetop.BackColor = System.Drawing.Color.Sienna;
            this.panelSidetop.Controls.Add(this.label1);
            this.panelSidetop.Controls.Add(this.btnX);
            this.panelSidetop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidetop.Location = new System.Drawing.Point(0, 0);
            this.panelSidetop.Name = "panelSidetop";
            this.panelSidetop.Size = new System.Drawing.Size(694, 46);
            this.panelSidetop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book Store Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnX.Location = new System.Drawing.Point(619, 0);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(75, 35);
            this.btnX.TabIndex = 0;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // panelsideLeft
            // 
            this.panelsideLeft.BackColor = System.Drawing.Color.BurlyWood;
            this.panelsideLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsideLeft.Location = new System.Drawing.Point(0, 46);
            this.panelsideLeft.Name = "panelsideLeft";
            this.panelsideLeft.Size = new System.Drawing.Size(295, 475);
            this.panelsideLeft.TabIndex = 1;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.ForeColor = System.Drawing.Color.SeaShell;
            this.lbLogin.Location = new System.Drawing.Point(405, 97);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(182, 28);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Login Account";
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusername.ForeColor = System.Drawing.Color.SeaShell;
            this.lbusername.Location = new System.Drawing.Point(369, 169);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(100, 21);
            this.lbusername.TabIndex = 3;
            this.lbusername.Text = "Username";
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbpassword.Location = new System.Drawing.Point(369, 241);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(93, 21);
            this.lbpassword.TabIndex = 4;
            this.lbpassword.Text = "Password";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(373, 193);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(240, 26);
            this.txtusername.TabIndex = 6;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(373, 265);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(240, 26);
            this.txtpass.TabIndex = 7;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // cbPass
            // 
            this.cbPass.AutoSize = true;
            this.cbPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbPass.Location = new System.Drawing.Point(373, 306);
            this.cbPass.Name = "cbPass";
            this.cbPass.Size = new System.Drawing.Size(148, 24);
            this.cbPass.TabIndex = 8;
            this.cbPass.Text = "Show Password";
            this.cbPass.UseVisualStyleBackColor = true;
            this.cbPass.CheckedChanged += new System.EventHandler(this.cbPass_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.BurlyWood;
            this.btnLogin.Font = new System.Drawing.Font("Lucida Bright", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(373, 360);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(240, 42);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(694, 521);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbPass);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lbpassword);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.panelsideLeft);
            this.Controls.Add(this.panelSidetop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelSidetop.ResumeLayout(false);
            this.panelSidetop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSidetop;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelsideLeft;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.CheckBox cbPass;
        private System.Windows.Forms.Button btnLogin;
    }
}