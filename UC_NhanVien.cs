﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataToGridView()
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                string sql = @"
    SELECT nv.MaNV, nv.TenNV, cv.TenCongViec, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.Email, nv.DienThoai
    FROM NhanVien nv
    LEFT JOIN CongViec cv ON nv.MaCV = cv.MaCongViec";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGVNhanVien.DataSource = dt;
                dataGVNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
                dataGVNhanVien.Columns[1].HeaderText = "Họ tên";
                dataGVNhanVien.Columns[2].HeaderText = "Chức vụ";
                dataGVNhanVien.Columns[3].HeaderText = "Giới tính";
                dataGVNhanVien.Columns[4].HeaderText = "Ngày sinh";
                dataGVNhanVien.Columns[5].HeaderText = "Địa chỉ";
                dataGVNhanVien.Columns[6].HeaderText = "Email";
                dataGVNhanVien.Columns[7].HeaderText = "SĐT";
                dataGVNhanVien.Columns[0].Width = 100;
                dataGVNhanVien.Columns[1].Width = 150;
                dataGVNhanVien.Columns[2].Width = 100;
                dataGVNhanVien.Columns[3].Width = 80;
                dataGVNhanVien.Columns[4].Width = 100;
                dataGVNhanVien.Columns[5].Width = 150;
                dataGVNhanVien.Columns[6].Width = 150;
                dataGVNhanVien.Columns[7].Width = 100;
            }
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
            LoadDataToGridView();
            DataTable dtCV = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaCongViec, TenCongViec FROM CongViec", conn);
                da.Fill(dtCV);
            }
            cboChucVu.DataSource = dtCV;
            cboChucVu.DisplayMember = "TenCongViec";
            cboChucVu.ValueMember = "MaCongViec";

        }

        private void dataGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGVNhanVien.Rows.Count)
            {
                DataGridViewRow row = dataGVNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTenNV.Text = row.Cells[1].Value.ToString();
                cboChucVu.Text = row.Cells[2].Value.ToString(); // TenCongViec
                SetGioiTinh(row.Cells[3].Value.ToString());
                if (DateTime.TryParse(row.Cells[4].Value?.ToString(), out DateTime parsedDate))
                    dateNV.Value = parsedDate;
                else
                    dateNV.Value = DateTime.Now;
                txtDiaChiNV.Text = row.Cells[5].Value.ToString();
                txtEmailNV.Text = row.Cells[6].Value.ToString();
                txtSDTNV.Text = row.Cells[7].Value.ToString();

            }
        }

        private string GetGioiTinh()
        {
            if (radNamNV.Checked)
                return "Nam";
            else if (radNuNV.Checked)
                return "Nữ";
            else
                return "";
        }

        private void SetGioiTinh(string gioiTinh)
        {
            if (gioiTinh == "Nam")
                radNamNV.Checked = true;
            else if (gioiTinh == "Nữ")
                radNuNV.Checked = true;
            else
            {
                radNamNV.Checked = false;
                radNuNV.Checked = false;
            }
        }
        private void Clear()
        {
            txtMaNV.Clear();
            txtHoTenNV.Clear();
            cboChucVu.SelectedIndex = -1;
            radNamNV.Checked = false;
            radNuNV.Checked = false;
            dateNV.Value = DateTime.Now;
            txtDiaChiNV.Clear();
            txtEmailNV.Clear();
            txtSDTNV.Clear();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {

            string manv = txtMaNV.Text;
            string hoten = txtHoTenNV.Text;
            string chucvu = cboChucVu.Text;
            string gioitinh = GetGioiTinh();
            DateTime ngaysinh = dateNV.Value;
            string dienthoai = txtSDTNV.Text;
            string diachi = txtDiaChiNV.Text;
            string email = txtEmailNV.Text;


            if (manv == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (hoten == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNV.Focus();
                return;
            }

            if (chucvu == "")
            {
                MessageBox.Show("Bạn chưa chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }

            if (gioitinh == "")
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngaysinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNV.Focus();
                return;
            }

            if (diachi == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiNV.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailNV.Focus();
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailNV.Focus();
                return;
            }
            if (txtSDTNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }
            if (txtSDTNV.Text.Length < 10 || txtSDTNV.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }
            if (!long.TryParse(txtSDTNV.Text, out _))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }
            string sqlCheck = "Select * from NhanVien where MaNV = N'" + manv + "'";
            if (!Database.CheckKey(sqlCheck))
            {
                string macv = cboChucVu.SelectedValue?.ToString() ?? "";
                string sql = "INSERT INTO NhanVien (MaNV, TenNV, MaCV, GioiTinh, NgaySinh, DiaChi, Email, DienThoai) " +
                             "VALUES (N'" + manv + "', N'" + hoten + "', N'" + macv + "', N'" + gioitinh + "', @ngaysinh, N'" + diachi + "', N'" + email + "', '" + txtSDTNV.Text + "')";

                using (SqlConnection connection = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        Clear();
                        MessageBox.Show("Lưu nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Đã trùng mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string hoten = txtHoTenNV.Text;
            string chucvu = cboChucVu.Text;
            string gioitinh = GetGioiTinh();
            DateTime ngaysinh = dateNV.Value;
            string diachi = txtDiaChiNV.Text;
            string email = txtEmailNV.Text;



            if (manv != dataGVNhanVien.CurrentRow.Cells[0].Value.ToString())
            {
                MessageBox.Show("Không được phép sửa mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Text = dataGVNhanVien.CurrentRow.Cells[0].Value.ToString();
                return;
            }

            if (hoten == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenNV.Focus();
                return;
            }

            if (chucvu == "")
            {
                MessageBox.Show("Bạn chưa chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }

            if (gioitinh == "")
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngaysinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNV.Focus();
                return;
            }

            if (diachi == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiNV.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailNV.Focus();
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailNV.Focus();
                return;
            }
            if (txtSDTNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }
            if (txtSDTNV.Text.Length < 10 || txtSDTNV.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }
            if (!long.TryParse(txtSDTNV.Text, out _))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTNV.Focus();
                return;
            }

            string macv = cboChucVu.SelectedValue?.ToString() ?? "";

            string sql = "Update NhanVien set " +
                "TenNV = N'" + hoten + "', MaCV = N'" + macv + "', GioiTinh = N'" + gioitinh + "', NgaySinh = @ngaysinh, DiaChi = N'" + diachi + "', Email = N'" + email + "', DienThoai = '" + txtSDTNV.Text + "'" +
                " Where MaNV = N'" + manv + "'";

            using (SqlConnection connection = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    Clear();
                    MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {

            if (dataGVNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string manv = txtMaNV.Text;
            string sqlCheck = "Select * from NhanVien where MaNV = N'" + manv + "'";
            SqlCommand cmd = new SqlCommand("Delete from NhanVien where MaNV = N'" + manv + "'", Database.GetConnection());
            if (Database.CheckKey(sqlCheck))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        Clear();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên"); return;
            }

        }

        private void btnBoquaNV_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text.Trim();
            string hoten = txtHoTenNV.Text.Trim();
            string chucvu = cboChucVu.Text.Trim();
            string gioitinh = GetGioiTinh();
            string diachi = txtDiaChiNV.Text.Trim();
            string email = txtEmailNV.Text.Trim();
            string sdt = txtSDTNV.Text.Trim();

            
            DateTime? ngaysinh = null;
            if (dateNV is DateTimePicker dtp && dtp.ShowCheckBox && dtp.Checked)
                ngaysinh = dtp.Value.Date;

            

            DataTable dt = SearchNhanVien(manv, hoten, chucvu, gioitinh, ngaysinh, diachi, email, sdt);
            dataGVNhanVien.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp với tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static DataTable SearchNhanVien(
    string maNV, string hoTen, string chucVu, string gioiTinh,
    DateTime? ngaySinh, string diaChi, string email, string sdt)
        {
            var query = new StringBuilder(@"
    SELECT nv.*, cv.TenCongViec
    FROM NhanVien nv
    LEFT JOIN CongViec cv ON nv.MaCV = cv.MaCongViec
    WHERE 1=1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maNV))
            {
                query.Append(" AND MaNV LIKE @MaNV");
                parameters.Add(new SqlParameter("@MaNV", "%" + maNV + "%"));
            }
            if (!string.IsNullOrEmpty(hoTen))
            {
                query.Append(" AND TenNV LIKE @HoTen");
                parameters.Add(new SqlParameter("@HoTen", "%" + hoTen + "%"));
            }
            if (!string.IsNullOrEmpty(chucVu))
            {
                query.Append(" AND cv.TenCongViec LIKE @ChucVu");
                parameters.Add(new SqlParameter("@ChucVu", "%" + chucVu + "%"));
            }
            if (!string.IsNullOrEmpty(gioiTinh))
            {
                query.Append(" AND GioiTinh = @GioiTinh");
                parameters.Add(new SqlParameter("@GioiTinh", gioiTinh));
            }
            if (ngaySinh.HasValue)
            {
                query.Append(" AND NgaySinh = @NgaySinh");
                parameters.Add(new SqlParameter("@NgaySinh", ngaySinh.Value.Date));
            }
            if (!string.IsNullOrEmpty(diaChi))
            {
                query.Append(" AND DiaChi LIKE @DiaChi");
                parameters.Add(new SqlParameter("@DiaChi", "%" + diaChi + "%"));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query.Append(" AND Email LIKE @Email");
                parameters.Add(new SqlParameter("@Email", "%" + email + "%"));
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                query.Append(" AND DienThoai LIKE @SDT");
                parameters.Add(new SqlParameter("@SDT", "%" + sdt + "%"));
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
    }
}

