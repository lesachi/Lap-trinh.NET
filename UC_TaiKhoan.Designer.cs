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
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.cbbTrangthai = new System.Windows.Forms.ComboBox();
            this.dtGVTaikhoan = new System.Windows.Forms.DataGridView();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
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
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(207, 99);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(178, 26);
            this.txtmanv.TabIndex = 5;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(207, 161);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(178, 26);
            this.txtusername.TabIndex = 6;
            // 
            // cbbRole
            // 
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(811, 91);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(175, 28);
            this.cbbRole.TabIndex = 7;
            // 
            // cbbTrangthai
            // 
            this.cbbTrangthai.FormattingEnabled = true;
            this.cbbTrangthai.Location = new System.Drawing.Point(811, 158);
            this.cbbTrangthai.Name = "cbbTrangthai";
            this.cbbTrangthai.Size = new System.Drawing.Size(175, 28);
            this.cbbTrangthai.TabIndex = 8;
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
            // UC_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnKhoa);
            this.Controls.Add(this.dtGVTaikhoan);
            this.Controls.Add(this.cbbTrangthai);
            this.Controls.Add(this.cbbRole);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txtmanv);
            this.Controls.Add(this.lbtrangthai);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lbmanv);
            this.Controls.Add(this.label1);
            this.Name = "UC_TaiKhoan";
            this.Size = new System.Drawing.Size(1132, 640);
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
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.ComboBox cbbTrangthai;
        private System.Windows.Forms.DataGridView dtGVTaikhoan;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnXoa;
    }
}
