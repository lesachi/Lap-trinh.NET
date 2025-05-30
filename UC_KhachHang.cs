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
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                string sql = "SELECT * FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, Database.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGVKhachHang.DataSource = dt;
                dataGVKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
                dataGVKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
                dataGVKhachHang.Columns[2].HeaderText = "Giới tính";
                dataGVKhachHang.Columns[3].HeaderText = "Địa chỉ";
                dataGVKhachHang.Columns[4].HeaderText = "SĐT";
                dataGVKhachHang.Columns[0].Width = 100;
                dataGVKhachHang.Columns[1].Width = 150;
                dataGVKhachHang.Columns[2].Width = 100;
                dataGVKhachHang.Columns[3].Width = 100;
                dataGVKhachHang.Columns[4].Width = 200;
                
                
            }
        }

        private void dataGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGVKhachHang.Rows.Count)
            {
                DataGridViewRow row = dataGVKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtHoTenKH.Text = row.Cells[1].Value.ToString();
                SetGioiTinh(row.Cells[2].Value.ToString());
                
                txtDiaChiKH.Text = row.Cells[4].Value.ToString();
                
                txtSDTKH.Text = row.Cells[5].Value.ToString();
            }
        }

        private string GetGioiTinh()
        {
            if (radNam.Checked)
                return "Nam";
            else if (radNu.Checked)
                return "Nữ";
            else
                return "";
        }

        private void SetGioiTinh(string gioiTinh)
        {
            if (gioiTinh == "Nam")
                radNam.Checked = true;
            else if (gioiTinh == "Nữ")
                radNu.Checked = true;
            else
            {
                radNam.Checked = false;
                radNu.Checked = false;
            }
        }

        private void Clear()
        {
            txtMaKH.Clear();
            txtHoTenKH.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            
            txtDiaChiKH.Clear();
            
            txtSDTKH.Clear();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text;
            string hoten = txtHoTenKH.Text;
            string gioitinh = GetGioiTinh();
            
            string diachi = txtDiaChiKH.Text;
            
            string sdt = txtSDTKH.Text;

            if (makh == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            if (hoten == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }
            if (gioitinh == "")
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            if (diachi == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiKH.Focus();
                return;
            }
           
            if (sdt == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            if (sdt.Length < 10 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            if (!long.TryParse(sdt, out _))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            string sqlCheck = "Select * from KhachHang where MaKH = N'" + makh + "'";
            if (!Database.CheckKey(sqlCheck))
            {
                string sql = "Insert into KhachHang values (N'" + makh + "', N'" + hoten + "', N'" + gioitinh + "', N'" + diachi + "', '" + sdt + "')";
                using (SqlConnection connection = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Đã trùng mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (dataGVKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string makh = txtMaKH.Text;
            string hoten = txtHoTenKH.Text;
            string gioitinh = GetGioiTinh();
            
            string diachi = txtDiaChiKH.Text;
            
            string sdt = txtSDTKH.Text;
            if (makh == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (hoten == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }
            if (gioitinh == "")
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            if (diachi == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiKH.Focus();
                return;
            }
          
            if (sdt == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            if (sdt.Length < 10 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            if (!long.TryParse(sdt, out _))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTKH.Focus();
                return;
            }
            string sqlCheck = "Select * from KhachHang where MaKH = N'" + makh + "'";
            if (Database.CheckKey(sqlCheck))
            {
                string sql = "Update KhachHang set HoTenKH = N'" + hoten + "', GioiTinh = N'" + gioitinh + "', DiaChi = N'" + diachi + "', SDT = '" + sdt + "' where MaKH = N'" + makh + "'";
                using (SqlConnection connection = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {

            if (dataGVKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string makh = txtMaKH.Text;
            string sqlCheck = "Select * from KhachHang where MaKH = N'" + makh + "'";
            if (string.IsNullOrEmpty(sqlCheck))
            {
                MessageBox.Show("Mã khách hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (Database.CheckKey(sqlCheck))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = "Delete from KhachHang where MaKH = N'" + makh + "'";
                    using (SqlConnection connection = Database.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            LoadDataToGridView();
                            Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {

            string searchValue = txtTimKiemKH.Text.Trim();
            string filterColumn = cboTimKiemKH.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(searchValue) || string.IsNullOrEmpty(filterColumn))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm và chọn bộ lọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder sql = new StringBuilder($"SELECT * FROM NhanVien WHERE {filterColumn} LIKE N'%{searchValue}%'");

            if (radNam.Checked)
            {
                sql.Append(" AND GioiTinh = N'Nam'");
            }
            else if (radNu.Checked)
            {
                sql.Append(" AND GioiTinh = N'Nữ'");
            }

            using (SqlConnection connection = Database.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGVKhachHang.DataSource = dt;
            }
        }

        private void btnBoQuaKH_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
