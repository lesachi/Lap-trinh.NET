namespace BookStore
{
    partial class UC_BCKhachHang
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataKHTT = new System.Windows.Forms.DataGridView();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.txtSoLanMua = new System.Windows.Forms.TextBox();
            this.txtTongChi = new System.Windows.Forms.TextBox();
            this.dateNgay1 = new System.Windows.Forms.DateTimePicker();
            this.dateNgay2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataKHTT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "KHÁCH HÀNG THÂN THIẾT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lần mua";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tổng chi";
            // 
            // dataKHTT
            // 
            this.dataKHTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataKHTT.Location = new System.Drawing.Point(74, 313);
            this.dataKHTT.Name = "dataKHTT";
            this.dataKHTT.RowHeadersWidth = 62;
            this.dataKHTT.RowTemplate.Height = 28;
            this.dataKHTT.Size = new System.Drawing.Size(872, 240);
            this.dataKHTT.TabIndex = 5;
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(252, 562);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(85, 34);
            this.btnXuat.TabIndex = 6;
            this.btnXuat.Text = "Xuất file";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(669, 559);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(84, 34);
            this.btnHienThi.TabIndex = 7;
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // txtSoLanMua
            // 
            this.txtSoLanMua.Location = new System.Drawing.Point(205, 159);
            this.txtSoLanMua.Name = "txtSoLanMua";
            this.txtSoLanMua.Size = new System.Drawing.Size(339, 26);
            this.txtSoLanMua.TabIndex = 9;
            // 
            // txtTongChi
            // 
            this.txtTongChi.Location = new System.Drawing.Point(205, 248);
            this.txtTongChi.Name = "txtTongChi";
            this.txtTongChi.Size = new System.Drawing.Size(339, 26);
            this.txtTongChi.TabIndex = 10;
            // 
            // dateNgay1
            // 
            this.dateNgay1.Location = new System.Drawing.Point(205, 73);
            this.dateNgay1.Name = "dateNgay1";
            this.dateNgay1.Size = new System.Drawing.Size(296, 26);
            this.dateNgay1.TabIndex = 11;
            // 
            // dateNgay2
            // 
            this.dateNgay2.Location = new System.Drawing.Point(632, 73);
            this.dateNgay2.Name = "dateNgay2";
            this.dateNgay2.Size = new System.Drawing.Size(299, 26);
            this.dateNgay2.TabIndex = 12;
            // 
            // UC_BCKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateNgay2);
            this.Controls.Add(this.dateNgay1);
            this.Controls.Add(this.txtTongChi);
            this.Controls.Add(this.txtSoLanMua);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.dataKHTT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UC_BCKhachHang";
            this.Size = new System.Drawing.Size(1044, 596);
            ((System.ComponentModel.ISupportInitialize)(this.dataKHTT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataKHTT;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.TextBox txtSoLanMua;
        private System.Windows.Forms.TextBox txtTongChi;
        private System.Windows.Forms.DateTimePicker dateNgay1;
        private System.Windows.Forms.DateTimePicker dateNgay2;
    }
}
