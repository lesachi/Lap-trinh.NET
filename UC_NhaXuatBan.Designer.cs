namespace BookStore
{
    partial class UC_NhaXuatBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_NhaXuatBan));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pboKimDong = new System.Windows.Forms.PictureBox();
            this.pboTre = new System.Windows.Forms.PictureBox();
            this.pboGiaoduc = new System.Windows.Forms.PictureBox();
            this.pboHoinhavan = new System.Windows.Forms.PictureBox();
            this.pboVanhoc = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboKimDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboTre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboGiaoduc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboHoinhavan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboVanhoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHÀ XUẤT BẢN";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pboVanhoc);
            this.panel1.Controls.Add(this.pboHoinhavan);
            this.panel1.Controls.Add(this.pboGiaoduc);
            this.panel1.Controls.Add(this.pboTre);
            this.panel1.Controls.Add(this.pboKimDong);
            this.panel1.Location = new System.Drawing.Point(34, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 440);
            this.panel1.TabIndex = 1;
            // 
            // pboKimDong
            // 
            this.pboKimDong.Image = ((System.Drawing.Image)(resources.GetObject("pboKimDong.Image")));
            this.pboKimDong.Location = new System.Drawing.Point(255, 26);
            this.pboKimDong.Name = "pboKimDong";
            this.pboKimDong.Size = new System.Drawing.Size(168, 168);
            this.pboKimDong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboKimDong.TabIndex = 0;
            this.pboKimDong.TabStop = false;
            // 
            // pboTre
            // 
            this.pboTre.Image = ((System.Drawing.Image)(resources.GetObject("pboTre.Image")));
            this.pboTre.Location = new System.Drawing.Point(28, 26);
            this.pboTre.Name = "pboTre";
            this.pboTre.Size = new System.Drawing.Size(168, 168);
            this.pboTre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboTre.TabIndex = 1;
            this.pboTre.TabStop = false;
            // 
            // pboGiaoduc
            // 
            this.pboGiaoduc.Image = ((System.Drawing.Image)(resources.GetObject("pboGiaoduc.Image")));
            this.pboGiaoduc.Location = new System.Drawing.Point(510, 26);
            this.pboGiaoduc.Name = "pboGiaoduc";
            this.pboGiaoduc.Size = new System.Drawing.Size(168, 168);
            this.pboGiaoduc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboGiaoduc.TabIndex = 2;
            this.pboGiaoduc.TabStop = false;
            // 
            // pboHoinhavan
            // 
            this.pboHoinhavan.Image = ((System.Drawing.Image)(resources.GetObject("pboHoinhavan.Image")));
            this.pboHoinhavan.Location = new System.Drawing.Point(28, 224);
            this.pboHoinhavan.Name = "pboHoinhavan";
            this.pboHoinhavan.Size = new System.Drawing.Size(168, 168);
            this.pboHoinhavan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboHoinhavan.TabIndex = 3;
            this.pboHoinhavan.TabStop = false;
            // 
            // pboVanhoc
            // 
            this.pboVanhoc.Image = ((System.Drawing.Image)(resources.GetObject("pboVanhoc.Image")));
            this.pboVanhoc.Location = new System.Drawing.Point(255, 224);
            this.pboVanhoc.Name = "pboVanhoc";
            this.pboVanhoc.Size = new System.Drawing.Size(168, 168);
            this.pboVanhoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboVanhoc.TabIndex = 4;
            this.pboVanhoc.TabStop = false;
            // 
            // UC_NhaXuatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UC_NhaXuatBan";
            this.Size = new System.Drawing.Size(833, 545);
            this.Load += new System.EventHandler(this.UC_NhaXuatBan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboKimDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboTre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboGiaoduc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboHoinhavan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboVanhoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pboKimDong;
        private System.Windows.Forms.PictureBox pboTre;
        private System.Windows.Forms.PictureBox pboGiaoduc;
        private System.Windows.Forms.PictureBox pboVanhoc;
        private System.Windows.Forms.PictureBox pboHoinhavan;
    }
}
