using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStore.UC_NhaXuatBan;

namespace BookStore
{
    public partial class ThemNXB : UserControl
    {
        public event EventHandler<NhaXuatBan> NXBThemThanhCong;
        public event EventHandler HuyThemNXB;

        private Image logo;
        public ThemNXB()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = "D:\\";
            ofd.FilterIndex = 2;
            ofd.Title = "Chon hinh anh de hien thi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                logo = Image.FromFile(ofd.FileName);
                pboLogo.Image = logo;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            string ten = txtTenNXB.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string dienthoai = txtDienthoai.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) ||
                string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(dienthoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                string sql = $"INSERT INTO NXB (MaNXB, TenNXB, DiaChi, DienThoai) VALUES (N'{ma}', N'{ten}', N'{diachi}', N'{dienthoai}')";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
                cmd.ExecuteNonQuery();

                var nxb = new NhaXuatBan
                {
                    Ma = ma,
                    Ten = ten,
                    Diachi = diachi,
                    Dienthoai = dienthoai,
                    Logo = logo
                };

                NXBThemThanhCong?.Invoke(this, nxb); // Gửi sự kiện cho UC_NhaXuatBan biết
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HuyThemNXB?.Invoke(this, EventArgs.Empty);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                parentForm?.Close();
            }
        }
        

        public void SetMaNXB(string ma)
        {
            txtMaNXB.Text = ma;
        }


    }
}
