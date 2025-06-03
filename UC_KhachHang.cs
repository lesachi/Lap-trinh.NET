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
                string sql = "SELECT MaKhach, TenKhach, GioiTinh, DiaChi,DienThoai FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, Database.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGVKhachHang.DataSource = dt;
                dataGVKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
                dataGVKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
                dataGVKhachHang.Columns[2].HeaderText = "Giới tính";
                dataGVKhachHang.Columns[3].HeaderText = "Địa chỉ";
                dataGVKhachHang.Columns[4].HeaderText = "SĐT";
                
                
                
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
                
                txtDiaChiKH.Text = row.Cells[3].Value.ToString();
                
                txtSDTKH.Text = row.Cells[4].Value.ToString();
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
            string sqlCheck = "Select * from KhachHang where MaKhach = N'" + makh + "'";
            if (!Database.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO KhachHang (MaKhach, TenKhach, GioiTinh, DiaChi, DienThoai) " +
             "VALUES (@MaKhach, @TenKhach, @GioiTinh, @DiaChi, @DienThoai)";
                using (SqlConnection connection = Database.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKhach", makh);
                        cmd.Parameters.AddWithValue("@TenKhach", hoten);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                        cmd.Parameters.AddWithValue("@DiaChi", diachi);
                        cmd.Parameters.AddWithValue("@DienThoai", sdt);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            LoadDataToGridView();
                            Clear();
                            MessageBox.Show("Lưu khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Đã trùng mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (dataGVKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string makh = txtMaKH.Text;
            string hoten = txtHoTenKH.Text;
            string gioitinh = GetGioiTinh();
            string diachi = txtDiaChiKH.Text;
            string sdt = txtSDTKH.Text;

            if (makh != dataGVKhachHang.CurrentRow.Cells[0].Value.ToString())
            {
                MessageBox.Show("Không được phép sửa mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Text = dataGVKhachHang.CurrentRow.Cells[0].Value.ToString();
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
            string sqlCheck = "Select * from KhachHang where MaKhach = N'" + makh + "'";
            if (Database.CheckKey(sqlCheck))
            {
                string sql = "Update KhachHang set TenKhach = N'" + hoten + "', GioiTinh = N'" + gioitinh + "', DiaChi = N'" + diachi + "', DienThoai = '" + sdt + "' where MaKhach = N'" + makh + "'";
                using (SqlConnection connection = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        Clear();
                        MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (dataGVKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string makh = txtMaKH.Text;
            string sqlCheck = "Select * from KhachHang where MaKhach = N'" + makh + "'";
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
                    string sql = "Delete from KhachHang where MaKhach = N'" + makh + "'";
                    using (SqlConnection connection = Database.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            LoadDataToGridView();
                            Clear();
                            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtHoTenKH.Text.Trim();
            string gioiTinh = GetGioiTinh();
            string diaChi = txtDiaChiKH.Text.Trim();
            string dienThoai = txtSDTKH.Text.Trim();

            DataTable dt = SearchKhachHang(maKH, tenKH, gioiTinh, diaChi, dienThoai);
            dataGVKhachHang.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp với tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static DataTable SearchKhachHang(
    string maKH, string tenKH, string gioiTinh, string diaChi, string dienThoai)
        {
            var query = new StringBuilder(@"
        SELECT MaKhach, TenKhach, GioiTinh, DiaChi, DienThoai
        FROM KhachHang
        WHERE 1=1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maKH))
            {
                query.Append(" AND MaKhach LIKE @MaKH");
                parameters.Add(new SqlParameter("@MaKH", "%" + maKH + "%"));
            }
            if (!string.IsNullOrEmpty(tenKH))
            {
                query.Append(" AND TenKhach LIKE @TenKH");
                parameters.Add(new SqlParameter("@TenKH", "%" + tenKH + "%"));
            }
            if (!string.IsNullOrEmpty(gioiTinh))
            {
                query.Append(" AND GioiTinh = @GioiTinh");
                parameters.Add(new SqlParameter("@GioiTinh", gioiTinh));
            }
            if (!string.IsNullOrEmpty(diaChi))
            {
                query.Append(" AND DiaChi LIKE @DiaChi");
                parameters.Add(new SqlParameter("@DiaChi", "%" + diaChi + "%"));
            }
            if (!string.IsNullOrEmpty(dienThoai))
            {
                query.Append(" AND DienThoai LIKE @DienThoai");
                parameters.Add(new SqlParameter("@DienThoai", "%" + dienThoai + "%"));
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query.ToString(), conn);
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }




        private void btnBoQuaKH_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
