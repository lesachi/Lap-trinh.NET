namespace BookStore
{
    partial class RegisterForm
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.cbPass = new System.Windows.Forms.CheckBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lbpassword = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.lbcreate = new System.Windows.Forms.Label();
            this.panelsideLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSidetop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.lbconfirm = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.panelSidetop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.BurlyWood;
            this.btnRegister.Font = new System.Drawing.Font("Lucida Bright", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(373, 360);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(240, 42);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // cbPass
            // 
            this.cbPass.AutoSize = true;
            this.cbPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbPass.Location = new System.Drawing.Point(373, 308);
            this.cbPass.Name = "cbPass";
            this.cbPass.Size = new System.Drawing.Size(148, 24);
            this.cbPass.TabIndex = 18;
            this.cbPass.Text = "Show Password";
            this.cbPass.UseVisualStyleBackColor = true;
            this.cbPass.CheckedChanged += new System.EventHandler(this.cbPass_CheckedChanged);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(373, 209);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(240, 26);
            this.txtpass.TabIndex = 17;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(373, 151);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(240, 26);
            this.txtusername.TabIndex = 16;
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbpassword.Location = new System.Drawing.Point(369, 185);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(93, 21);
            this.lbpassword.TabIndex = 15;
            this.lbpassword.Text = "Password";
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusername.ForeColor = System.Drawing.Color.SeaShell;
            this.lbusername.Location = new System.Drawing.Point(369, 127);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(100, 21);
            this.lbusername.TabIndex = 14;
            this.lbusername.Text = "Username";
            // 
            // lbcreate
            // 
            this.lbcreate.AutoSize = true;
            this.lbcreate.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcreate.ForeColor = System.Drawing.Color.SeaShell;
            this.lbcreate.Location = new System.Drawing.Point(403, 84);
            this.lbcreate.Name = "lbcreate";
            this.lbcreate.Size = new System.Drawing.Size(189, 28);
            this.lbcreate.TabIndex = 13;
            this.lbcreate.Text = "Create Account";
            // 
            // panelsideLeft
            // 
            this.panelsideLeft.BackColor = System.Drawing.Color.BurlyWood;
            this.panelsideLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsideLeft.Location = new System.Drawing.Point(0, 46);
            this.panelsideLeft.Name = "panelsideLeft";
            this.panelsideLeft.Size = new System.Drawing.Size(295, 419);
            this.panelsideLeft.TabIndex = 12;
            // 
            // panelSidetop
            // 
            this.panelSidetop.BackColor = System.Drawing.Color.Sienna;
            this.panelSidetop.Controls.Add(this.label1);
            this.panelSidetop.Controls.Add(this.btnX);
            this.panelSidetop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidetop.Location = new System.Drawing.Point(0, 0);
            this.panelSidetop.Name = "panelSidetop";
            this.panelSidetop.Size = new System.Drawing.Size(672, 46);
            this.panelSidetop.TabIndex = 11;
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
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnX.Location = new System.Drawing.Point(597, 0);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(75, 35);
            this.btnX.TabIndex = 0;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // lbconfirm
            // 
            this.lbconfirm.AutoSize = true;
            this.lbconfirm.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbconfirm.ForeColor = System.Drawing.Color.SeaShell;
            this.lbconfirm.Location = new System.Drawing.Point(369, 252);
            this.lbconfirm.Name = "lbconfirm";
            this.lbconfirm.Size = new System.Drawing.Size(173, 21);
            this.lbconfirm.TabIndex = 21;
            this.lbconfirm.Text = "Confirm Password";
            this.lbconfirm.Click += new System.EventHandler(this.lbconfirm_Click);
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(373, 276);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(240, 26);
            this.txtconfirm.TabIndex = 22;
            this.txtconfirm.UseSystemPasswordChar = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(672, 465);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.lbconfirm);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.cbPass);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lbpassword);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lbcreate);
            this.Controls.Add(this.panelsideLeft);
            this.Controls.Add(this.panelSidetop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.panelSidetop.ResumeLayout(false);
            this.panelSidetop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox cbPass;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.Label lbcreate;
        private System.Windows.Forms.FlowLayoutPanel panelsideLeft;
        private System.Windows.Forms.Panel panelSidetop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lbconfirm;
        private System.Windows.Forms.TextBox txtconfirm;
    }
}