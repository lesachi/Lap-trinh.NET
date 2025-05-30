namespace BookStore
{
    partial class UC_NhanVien
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
            this.dataGVNhanVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtHoTenNV = new System.Windows.Forms.TextBox();
            this.txtDiaChiNV = new System.Windows.Forms.TextBox();
            this.txtEmailNV = new System.Windows.Forms.TextBox();
            this.xtSDTNV = new System.Windows.Forms.TextBox();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.btnLuuNV = new System.Windows.Forms.Button();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.btnXoaNV = new System.Windows.Forms.Button();
            this.btnBoquaNV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNuNV = new System.Windows.Forms.RadioButton();
            this.radNamNV = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemNV = new System.Windows.Forms.Button();
            this.cboTKNV = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radTKNVNu = new System.Windows.Forms.RadioButton();
            this.radTKNVNam = new System.Windows.Forms.RadioButton();
            this.txtTimKiemNV = new System.Windows.Forms.TextBox();
            this.dateNV = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGVNhanVien
            // 
            this.dataGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVNhanVien.Location = new System.Drawing.Point(0, 310);
            this.dataGVNhanVien.Name = "dataGVNhanVien";
            this.dataGVNhanVien.Size = new System.Drawing.Size(808, 187);
            this.dataGVNhanVien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(375, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "SĐT";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(107, 43);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(245, 20);
            this.txtMaNV.TabIndex = 8;
            this.txtMaNV.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtHoTenNV
            // 
            this.txtHoTenNV.Location = new System.Drawing.Point(107, 92);
            this.txtHoTenNV.Name = "txtHoTenNV";
            this.txtHoTenNV.Size = new System.Drawing.Size(245, 20);
            this.txtHoTenNV.TabIndex = 9;
            // 
            // txtDiaChiNV
            // 
            this.txtDiaChiNV.Location = new System.Drawing.Point(107, 286);
            this.txtDiaChiNV.Name = "txtDiaChiNV";
            this.txtDiaChiNV.Size = new System.Drawing.Size(245, 20);
            this.txtDiaChiNV.TabIndex = 10;
            this.txtDiaChiNV.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtEmailNV
            // 
            this.txtEmailNV.Location = new System.Drawing.Point(422, 44);
            this.txtEmailNV.Name = "txtEmailNV";
            this.txtEmailNV.Size = new System.Drawing.Size(265, 20);
            this.txtEmailNV.TabIndex = 11;
            // 
            // xtSDTNV
            // 
            this.xtSDTNV.Location = new System.Drawing.Point(422, 92);
            this.xtSDTNV.Name = "xtSDTNV";
            this.xtSDTNV.Size = new System.Drawing.Size(265, 20);
            this.xtSDTNV.TabIndex = 12;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.Location = new System.Drawing.Point(715, 21);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(75, 23);
            this.btnThemNV.TabIndex = 13;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = true;
            // 
            // btnLuuNV
            // 
            this.btnLuuNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuNV.Location = new System.Drawing.Point(715, 65);
            this.btnLuuNV.Name = "btnLuuNV";
            this.btnLuuNV.Size = new System.Drawing.Size(75, 23);
            this.btnLuuNV.TabIndex = 14;
            this.btnLuuNV.Text = "Lưu";
            this.btnLuuNV.UseVisualStyleBackColor = true;
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNV.Location = new System.Drawing.Point(715, 115);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(75, 23);
            this.btnSuaNV.TabIndex = 15;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.UseVisualStyleBackColor = true;
            // 
            // btnXoaNV
            // 
            this.btnXoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNV.Location = new System.Drawing.Point(715, 166);
            this.btnXoaNV.Name = "btnXoaNV";
            this.btnXoaNV.Size = new System.Drawing.Size(75, 23);
            this.btnXoaNV.TabIndex = 16;
            this.btnXoaNV.Text = "Xóa";
            this.btnXoaNV.UseVisualStyleBackColor = true;
            // 
            // btnBoquaNV
            // 
            this.btnBoquaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoquaNV.Location = new System.Drawing.Point(715, 222);
            this.btnBoquaNV.Name = "btnBoquaNV";
            this.btnBoquaNV.Size = new System.Drawing.Size(75, 23);
            this.btnBoquaNV.TabIndex = 17;
            this.btnBoquaNV.Text = "Bỏ qua";
            this.btnBoquaNV.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNuNV);
            this.groupBox1.Controls.Add(this.radNamNV);
            this.groupBox1.Location = new System.Drawing.Point(107, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // radNuNV
            // 
            this.radNuNV.AutoSize = true;
            this.radNuNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNuNV.Location = new System.Drawing.Point(92, 20);
            this.radNuNV.Name = "radNuNV";
            this.radNuNV.Size = new System.Drawing.Size(42, 20);
            this.radNuNV.TabIndex = 1;
            this.radNuNV.TabStop = true;
            this.radNuNV.Text = "Nữ";
            this.radNuNV.UseVisualStyleBackColor = true;
            // 
            // radNamNV
            // 
            this.radNamNV.AutoSize = true;
            this.radNamNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNamNV.Location = new System.Drawing.Point(0, 20);
            this.radNamNV.Name = "radNamNV";
            this.radNamNV.Size = new System.Drawing.Size(54, 20);
            this.radNamNV.TabIndex = 0;
            this.radNamNV.TabStop = true;
            this.radNamNV.Text = "Nam";
            this.radNamNV.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimKiemNV);
            this.groupBox2.Controls.Add(this.cboTKNV);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtTimKiemNV);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(378, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 179);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnTimKiemNV
            // 
            this.btnTimKiemNV.Location = new System.Drawing.Point(125, 150);
            this.btnTimKiemNV.Name = "btnTimKiemNV";
            this.btnTimKiemNV.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemNV.TabIndex = 21;
            this.btnTimKiemNV.Text = "Tìm kiếm";
            this.btnTimKiemNV.UseVisualStyleBackColor = true;
            // 
            // cboTKNV
            // 
            this.cboTKNV.FormattingEnabled = true;
            this.cboTKNV.Items.AddRange(new object[] {
            "Mã Nhân viên",
            "Họ tên",
            "Chức vụ",
            "Ngày sinh",
            "Địa chỉ",
            "Email",
            "SĐT"});
            this.cboTKNV.Location = new System.Drawing.Point(44, 19);
            this.cboTKNV.Name = "cboTKNV";
            this.cboTKNV.Size = new System.Drawing.Size(265, 24);
            this.cboTKNV.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radTKNVNu);
            this.groupBox3.Controls.Add(this.radTKNVNam);
            this.groupBox3.Location = new System.Drawing.Point(44, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 55);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // radTKNVNu
            // 
            this.radTKNVNu.AutoSize = true;
            this.radTKNVNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTKNVNu.Location = new System.Drawing.Point(92, 20);
            this.radTKNVNu.Name = "radTKNVNu";
            this.radTKNVNu.Size = new System.Drawing.Size(42, 20);
            this.radTKNVNu.TabIndex = 1;
            this.radTKNVNu.TabStop = true;
            this.radTKNVNu.Text = "Nữ";
            this.radTKNVNu.UseVisualStyleBackColor = true;
            // 
            // radTKNVNam
            // 
            this.radTKNVNam.AutoSize = true;
            this.radTKNVNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTKNVNam.Location = new System.Drawing.Point(0, 20);
            this.radTKNVNam.Name = "radTKNVNam";
            this.radTKNVNam.Size = new System.Drawing.Size(54, 20);
            this.radTKNVNam.TabIndex = 0;
            this.radTKNVNam.TabStop = true;
            this.radTKNVNam.Text = "Nam";
            this.radTKNVNam.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemNV
            // 
            this.txtTimKiemNV.Location = new System.Drawing.Point(44, 119);
            this.txtTimKiemNV.Name = "txtTimKiemNV";
            this.txtTimKiemNV.Size = new System.Drawing.Size(265, 22);
            this.txtTimKiemNV.TabIndex = 0;
            this.txtTimKiemNV.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // dateNV
            // 
            this.dateNV.Location = new System.Drawing.Point(107, 237);
            this.dateNV.Name = "dateNV";
            this.dateNV.Size = new System.Drawing.Size(245, 20);
            this.dateNV.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Chức vụ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Items.AddRange(new object[] {
            "admin",
            "Nhân viên"});
            this.cboChucVu.Location = new System.Drawing.Point(107, 136);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(245, 21);
            this.cboChucVu.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // UC_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateNV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBoquaNV);
            this.Controls.Add(this.btnXoaNV);
            this.Controls.Add(this.btnSuaNV);
            this.Controls.Add(this.btnLuuNV);
            this.Controls.Add(this.btnThemNV);
            this.Controls.Add(this.xtSDTNV);
            this.Controls.Add(this.txtEmailNV);
            this.Controls.Add(this.txtDiaChiNV);
            this.Controls.Add(this.txtHoTenNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGVNhanVien);
            this.Name = "UC_NhanVien";
            this.Size = new System.Drawing.Size(808, 497);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtHoTenNV;
        private System.Windows.Forms.TextBox txtDiaChiNV;
        private System.Windows.Forms.TextBox txtEmailNV;
        private System.Windows.Forms.TextBox xtSDTNV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnLuuNV;
        private System.Windows.Forms.Button btnSuaNV;
        private System.Windows.Forms.Button btnXoaNV;
        private System.Windows.Forms.Button btnBoquaNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNuNV;
        private System.Windows.Forms.RadioButton radNamNV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiemNV;
        private System.Windows.Forms.ComboBox cboTKNV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radTKNVNu;
        private System.Windows.Forms.RadioButton radTKNVNam;
        private System.Windows.Forms.TextBox txtTimKiemNV;
        private System.Windows.Forms.DateTimePicker dateNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label label9;
    }
}
