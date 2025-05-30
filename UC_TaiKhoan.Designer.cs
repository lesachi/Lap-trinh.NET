namespace BookStore
{
    partial class UC_TaiKhoan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbmanv = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.dtGVTaikhoan = new System.Windows.Forms.DataGridView();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemtk = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.lbpass = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbbManv = new System.Windows.Forms.ComboBox();
            this.txtChucvu = new System.Windows.Forms.TextBox();
            this.txtTrangthai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách tài khoản";
            // 
            // lbmanv
            // 
            this.lbmanv.AutoSize = true;
            this.lbmanv.Location = new System.Drawing.Point(88, 99);
            this.lbmanv.Name = "lbmanv";
            this.lbmanv.Size = new System.Drawing.Size(103, 20);
            this.lbmanv.TabIndex = 1;
            this.lbmanv.Text = "Mã nhân viên";
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Location = new System.Drawing.Point(88, 161);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(83, 20);
            this.lbusername.TabIndex = 2;
            this.lbusername.Text = "Username";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Location = new System.Drawing.Point(708, 99);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(66, 20);
            this.lbRole.TabIndex = 3;
            this.lbRole.Text = "Chức vụ";
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Location = new System.Drawing.Point(708, 161);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(80, 20);
            this.lbtrangthai.TabIndex = 4;
            this.lbtrangthai.Text = "Trạng thái";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(207, 155);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(178, 26);
            this.txtusername.TabIndex = 6;
            // 
            // dtGVTaikhoan
            // 
            this.dtGVTaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVTaikhoan.Location = new System.Drawing.Point(55, 248);
            this.dtGVTaikhoan.Name = "dtGVTaikhoan";
            this.dtGVTaikhoan.RowHeadersWidth = 62;
            this.dtGVTaikhoan.RowTemplate.Height = 28;
            this.dtGVTaikhoan.Size = new System.Drawing.Size(1044, 227);
            this.dtGVTaikhoan.TabIndex = 9;
            this.dtGVTaikhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVTaikhoan_CellClick);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Location = new System.Drawing.Point(66, 517);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(199, 40);
            this.btnKhoa.TabIndex = 10;
            this.btnKhoa.Text = "Khóa tài khoản";
            this.btnKhoa.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(873, 517);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(217, 40);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa tài khoản";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThemtk
            // 
            this.btnThemtk.Location = new System.Drawing.Point(319, 517);
            this.btnThemtk.Name = "btnThemtk";
            this.btnThemtk.Size = new System.Drawing.Size(199, 40);
            this.btnThemtk.TabIndex = 12;
            this.btnThemtk.Text = "Thêm tài khoản";
            this.btnThemtk.UseVisualStyleBackColor = true;
            this.btnThemtk.Click += new System.EventHandler(this.btnThemtk_Click);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(207, 206);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(178, 26);
            this.txtpass.TabIndex = 14;
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Location = new System.Drawing.Point(88, 212);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(78, 20);
            this.lbpass.TabIndex = 13;
            this.lbpass.Text = "Password";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(589, 517);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(199, 40);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu tài khoản";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // cbbManv
            // 
            this.cbbManv.FormattingEnabled = true;
            this.cbbManv.Location = new System.Drawing.Point(207, 96);
            this.cbbManv.Name = "cbbManv";
            this.cbbManv.Size = new System.Drawing.Size(178, 28);
            this.cbbManv.TabIndex = 16;
            // 
            // txtChucvu
            // 
            this.txtChucvu.Location = new System.Drawing.Point(811, 100);
            this.txtChucvu.Name = "txtChucvu";
            this.txtChucvu.Size = new System.Drawing.Size(175, 26);
            this.txtChucvu.TabIndex = 17;
            // 
            // txtTrangthai
            // 
            this.txtTrangthai.Location = new System.Drawing.Point(811, 161);
            this.txtTrangthai.Name = "txtTrangthai";
            this.txtTrangthai.Size = new System.Drawing.Size(175, 26);
            this.txtTrangthai.TabIndex = 18;
            // 
            // UC_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTrangthai);
            this.Controls.Add(this.txtChucvu);
            this.Controls.Add(this.cbbManv);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.btnThemtk);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnKhoa);
            this.Controls.Add(this.dtGVTaikhoan);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lbtrangthai);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lbmanv);
            this.Controls.Add(this.label1);
            this.Name = "UC_TaiKhoan";
            this.Size = new System.Drawing.Size(1132, 640);
            this.Load += new System.EventHandler(this.UC_TaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTaikhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbmanv;
        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label lbtrangthai;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.DataGridView dtGVTaikhoan;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemtk;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbbManv;
        private System.Windows.Forms.TextBox txtChucvu;
        private System.Windows.Forms.TextBox txtTrangthai;
    }
}
