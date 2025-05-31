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

namespace BookStore
{
    public partial class UC_ChitietNXB : UserControl
    {
        public event EventHandler XoaThanhCong;

        public UC_ChitietNXB(string ma, string ten, string diachi, string dienthoai, Image logo)
        {
            InitializeComponent();
            txtMaNXB.Text = ma;
            txtTenNXB.Text = ten;
            txtDiachi.Text = diachi;
            txtDienthoai.Text = dienthoai;
            pboLogo.Image = logo;

        }

        private void UC_ChitietNXB_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
            txtMaNXB.ReadOnly = true;
            txtTenNXB.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            string ten = txtTenNXB.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string sdt = txtDienthoai.Text.Trim();

            if (ten == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản!");
                txtTenNXB.Focus();
                return;
            }
            if (diachi == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ!");
                txtDiachi.Focus();
                return;
            }
            if (sdt == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại!");
                txtDienthoai.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                txtDienthoai.Focus();
                return;
            }

            string sql = $"UPDATE NXB SET TenNXB = N'{ten}', DiaChi = N'{diachi}', DienThoai = N'{sdt}' WHERE MaNXB = N'{ma}'";

            SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");

                txtTenNXB.ReadOnly = true;
                txtDiachi.ReadOnly = true;
                txtDienthoai.ReadOnly = true;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();
            string ten = txtTenNXB.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string sdt = txtDienthoai.Text.Trim();

            txtTenNXB.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txtDienthoai.ReadOnly = false;
            txtMaNXB.ReadOnly = true; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Không tìm thấy mã NXB để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn muốn xóa nhà xuất bản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string sql = $"DELETE FROM NXB WHERE MaNXB = N'{ma}'";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    XoaThanhCong?.Invoke(this, EventArgs.Empty);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
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
    }
}

