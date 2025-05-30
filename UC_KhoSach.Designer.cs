namespace BookStore
{
    partial class UC_KhoSach
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
            this.dtGVKhoSach = new System.Windows.Forms.DataGridView();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbSL = new System.Windows.Forms.Label();
            this.lbDGN = new System.Windows.Forms.Label();
            this.lbDGB = new System.Windows.Forms.Label();
            this.lbMaLoai = new System.Windows.Forms.Label();
            this.lbMaNXB = new System.Windows.Forms.Label();
            this.lbMaTG = new System.Windows.Forms.Label();
            this.lbMaLV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSotrang = new System.Windows.Forms.Label();
            this.lbAnh = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtDGN = new System.Windows.Forms.TextBox();
            this.txtDGB = new System.Windows.Forms.TextBox();
            this.cbbMaNXB = new System.Windows.Forms.ComboBox();
            this.cbbMaLoai = new System.Windows.Forms.ComboBox();
            this.cbbMaTG = new System.Windows.Forms.ComboBox();
            this.cbbMaLV = new System.Windows.Forms.ComboBox();
            this.cbbMaNN = new System.Windows.Forms.ComboBox();
            this.txtSoTrang = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKhoSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGVKhoSach
            // 
            this.dtGVKhoSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVKhoSach.Location = new System.Drawing.Point(67, 404);
            this.dtGVKhoSach.Name = "dtGVKhoSach";
            this.dtGVKhoSach.RowHeadersWidth = 62;
            this.dtGVKhoSach.RowTemplate.Height = 28;
            this.dtGVKhoSach.Size = new System.Drawing.Size(1063, 255);
            this.dtGVKhoSach.TabIndex = 0;
            this.dtGVKhoSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(104, 71);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(87, 25);
            this.lbMaSach.TabIndex = 1;
            this.lbMaSach.Text = "Mã sách";
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoSize = true;
            this.lbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(105, 108);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(94, 25);
            this.lbTenSach.TabIndex = 2;
            this.lbTenSach.Text = "Tên sách";
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.Location = new System.Drawing.Point(106, 144);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(90, 25);
            this.lbSL.TabIndex = 3;
            this.lbSL.Text = "Số lượng";
            // 
            // lbDGN
            // 
            this.lbDGN.AutoSize = true;
            this.lbDGN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDGN.Location = new System.Drawing.Point(106, 181);
            this.lbDGN.Name = "lbDGN";
            this.lbDGN.Size = new System.Drawing.Size(128, 25);
            this.lbDGN.TabIndex = 4;
            this.lbDGN.Text = "Đơn giá nhập";
            // 
            // lbDGB
            // 
            this.lbDGB.AutoSize = true;
            this.lbDGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDGB.Location = new System.Drawing.Point(105, 219);
            this.lbDGB.Name = "lbDGB";
            this.lbDGB.Size = new System.Drawing.Size(117, 25);
            this.lbDGB.TabIndex = 5;
            this.lbDGB.Text = "Đơn giá bán";
            // 
            // lbMaLoai
            // 
            this.lbMaLoai.AutoSize = true;
            this.lbMaLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaLoai.Location = new System.Drawing.Point(106, 255);
            this.lbMaLoai.Name = "lbMaLoai";
            this.lbMaLoai.Size = new System.Drawing.Size(75, 25);
            this.lbMaLoai.TabIndex = 6;
            this.lbMaLoai.Text = "Mã loại";
            // 
            // lbMaNXB
            // 
            this.lbMaNXB.AutoSize = true;
            this.lbMaNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNXB.Location = new System.Drawing.Point(537, 71);
            this.lbMaNXB.Name = "lbMaNXB";
            this.lbMaNXB.Size = new System.Drawing.Size(86, 25);
            this.lbMaNXB.TabIndex = 8;
            this.lbMaNXB.Text = "Mã NXB";
            // 
            // lbMaTG
            // 
            this.lbMaTG.AutoSize = true;
            this.lbMaTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaTG.Location = new System.Drawing.Point(106, 291);
            this.lbMaTG.Name = "lbMaTG";
            this.lbMaTG.Size = new System.Drawing.Size(102, 25);
            this.lbMaTG.TabIndex = 7;
            this.lbMaTG.Text = "Mã tác giả";
            // 
            // lbMaLV
            // 
            this.lbMaLV.AutoSize = true;
            this.lbMaLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaLV.Location = new System.Drawing.Point(537, 108);
            this.lbMaLV.Name = "lbMaLV";
            this.lbMaLV.Size = new System.Drawing.Size(111, 25);
            this.lbMaLV.TabIndex = 9;
            this.lbMaLV.Text = "Mã lĩnh vực";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã ngôn ngữ";
            // 
            // lbSotrang
            // 
            this.lbSotrang.AutoSize = true;
            this.lbSotrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSotrang.Location = new System.Drawing.Point(537, 181);
            this.lbSotrang.Name = "lbSotrang";
            this.lbSotrang.Size = new System.Drawing.Size(86, 25);
            this.lbSotrang.TabIndex = 12;
            this.lbSotrang.Text = "Số trang";
            // 
            // lbAnh
            // 
            this.lbAnh.AutoSize = true;
            this.lbAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnh.Location = new System.Drawing.Point(537, 237);
            this.lbAnh.Name = "lbAnh";
            this.lbAnh.Size = new System.Drawing.Size(48, 25);
            this.lbAnh.TabIndex = 13;
            this.lbAnh.Text = "Ảnh";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(244, 70);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(167, 26);
            this.txtMaSach.TabIndex = 14;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(244, 109);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(167, 26);
            this.txtTenSach.TabIndex = 15;
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(244, 145);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(167, 26);
            this.txtSL.TabIndex = 16;
            // 
            // txtDGN
            // 
            this.txtDGN.Location = new System.Drawing.Point(244, 182);
            this.txtDGN.Name = "txtDGN";
            this.txtDGN.Size = new System.Drawing.Size(167, 26);
            this.txtDGN.TabIndex = 17;
            // 
            // txtDGB
            // 
            this.txtDGB.Location = new System.Drawing.Point(244, 220);
            this.txtDGB.Name = "txtDGB";
            this.txtDGB.Size = new System.Drawing.Size(167, 26);
            this.txtDGB.TabIndex = 18;
            // 
            // cbbMaNXB
            // 
            this.cbbMaNXB.FormattingEnabled = true;
            this.cbbMaNXB.Location = new System.Drawing.Point(666, 70);
            this.cbbMaNXB.Name = "cbbMaNXB";
            this.cbbMaNXB.Size = new System.Drawing.Size(187, 28);
            this.cbbMaNXB.TabIndex = 19;
            // 
            // cbbMaLoai
            // 
            this.cbbMaLoai.FormattingEnabled = true;
            this.cbbMaLoai.Location = new System.Drawing.Point(244, 256);
            this.cbbMaLoai.Name = "cbbMaLoai";
            this.cbbMaLoai.Size = new System.Drawing.Size(167, 28);
            this.cbbMaLoai.TabIndex = 20;
            // 
            // cbbMaTG
            // 
            this.cbbMaTG.FormattingEnabled = true;
            this.cbbMaTG.Location = new System.Drawing.Point(244, 292);
            this.cbbMaTG.Name = "cbbMaTG";
            this.cbbMaTG.Size = new System.Drawing.Size(167, 28);
            this.cbbMaTG.TabIndex = 21;
            // 
            // cbbMaLV
            // 
            this.cbbMaLV.FormattingEnabled = true;
            this.cbbMaLV.Location = new System.Drawing.Point(666, 108);
            this.cbbMaLV.Name = "cbbMaLV";
            this.cbbMaLV.Size = new System.Drawing.Size(187, 28);
            this.cbbMaLV.TabIndex = 22;
            // 
            // cbbMaNN
            // 
            this.cbbMaNN.FormattingEnabled = true;
            this.cbbMaNN.Location = new System.Drawing.Point(666, 145);
            this.cbbMaNN.Name = "cbbMaNN";
            this.cbbMaNN.Size = new System.Drawing.Size(187, 28);
            this.cbbMaNN.TabIndex = 23;
            // 
            // txtSoTrang
            // 
            this.txtSoTrang.Location = new System.Drawing.Point(666, 182);
            this.txtSoTrang.Name = "txtSoTrang";
            this.txtSoTrang.Size = new System.Drawing.Size(187, 26);
            this.txtSoTrang.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(666, 220);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 160);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(930, 72);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(93, 34);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(930, 159);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(93, 34);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(930, 211);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(93, 34);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(542, 282);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(93, 34);
            this.btnOpen.TabIndex = 29;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(109, 346);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(93, 34);
            this.btnTimkiem.TabIndex = 30;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(930, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 34);
            this.button2.TabIndex = 31;
            this.button2.Text = "Bỏ qua";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(930, 114);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(93, 39);
            this.btnLuu.TabIndex = 32;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 36);
            this.label1.TabIndex = 33;
            this.label1.Text = "Kho sách";
            // 
            // UC_KhoSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSoTrang);
            this.Controls.Add(this.cbbMaNN);
            this.Controls.Add(this.cbbMaLV);
            this.Controls.Add(this.cbbMaTG);
            this.Controls.Add(this.cbbMaLoai);
            this.Controls.Add(this.cbbMaNXB);
            this.Controls.Add(this.txtDGB);
            this.Controls.Add(this.txtDGN);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.lbAnh);
            this.Controls.Add(this.lbSotrang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMaLV);
            this.Controls.Add(this.lbMaNXB);
            this.Controls.Add(this.lbMaTG);
            this.Controls.Add(this.lbMaLoai);
            this.Controls.Add(this.lbDGB);
            this.Controls.Add(this.lbDGN);
            this.Controls.Add(this.lbSL);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.lbMaSach);
            this.Controls.Add(this.dtGVKhoSach);
            this.Name = "UC_KhoSach";
            this.Size = new System.Drawing.Size(1182, 682);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKhoSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVKhoSach;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbSL;
        private System.Windows.Forms.Label lbDGN;
        private System.Windows.Forms.Label lbDGB;
        private System.Windows.Forms.Label lbMaLoai;
        private System.Windows.Forms.Label lbMaNXB;
        private System.Windows.Forms.Label lbMaTG;
        private System.Windows.Forms.Label lbMaLV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSotrang;
        private System.Windows.Forms.Label lbAnh;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtDGN;
        private System.Windows.Forms.TextBox txtDGB;
        private System.Windows.Forms.ComboBox cbbMaNXB;
        private System.Windows.Forms.ComboBox cbbMaLoai;
        private System.Windows.Forms.ComboBox cbbMaTG;
        private System.Windows.Forms.ComboBox cbbMaLV;
        private System.Windows.Forms.ComboBox cbbMaNN;
        private System.Windows.Forms.TextBox txtSoTrang;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label1;
    }
}
