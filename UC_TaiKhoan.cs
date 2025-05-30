using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BookStore.DAO;
using System.Collections;

namespace BookStore
{
    public partial class UC_TaiKhoan : UserControl
    {
        public UC_TaiKhoan()
        {
            InitializeComponent();
            dtGVTaikhoan.DataSource = TaiKhoanDAO.LoadData();

        }

        private void dtGVTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtGVTaikhoan.Rows[e.RowIndex];

                // Gán dữ liệu vào các TextBox
                txtusername.Text = row.Cells["Username"].Value.ToString();
                txtpass.Text = row.Cells["PasswordHash"].Value.ToString();
                txtChucvu.Text = row.Cells["Role"].Value.ToString();
                txtTrangthai.Text = row.Cells["TrangThai"].Value.ToString();

                // hiển thị lại MaNV vào ComboBox
                string maNV = row.Cells["MaNV"].Value.ToString();
                cbbManv.SelectedValue = maNV;
            }
            btnLuu.Enabled = false;
        }

        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTatCaNhanVien();
            LoadDataToGridView();
            btnLuu.Enabled = false;
        }

        private void LoadNhanVienChuaCoTaiKhoan()
        {

            {

                string sql = @"
                    SELECT MaNV, TenNV
                    FROM NhanVien 
                    WHERE MaNV NOT IN (SELECT MaNV FROM TaiKhoan)";

                Database.FillDataToCombo(cbbManv, sql, "MaNV", "TenNV");
                cbbManv.SelectedIndex = -1; // Không chọn sẵn ai cả
            }
        }

        private void LoadTatCaNhanVien()
        {
            string sql = "SELECT MaNV, TenNV FROM NhanVien";
            Database.FillDataToCombo(cbbManv, sql, "MaNV", "TenNV");
        }

        private void LoadDataToGridView()
        {
            LoadTatCaNhanVien();
            DataTable dt = new DataTable();
            dt = TaiKhoanDAO.LoadData();
            dtGVTaikhoan.DataSource = dt;
            dtGVTaikhoan.Columns[0].HeaderText = "Mã nhân viên";
            dtGVTaikhoan.Columns[1].HeaderText = "Tên đăng nhập";
            dtGVTaikhoan.Columns[2].HeaderText = "Mật khẩu";
            dtGVTaikhoan.Columns[3].HeaderText = "Vai trò";
            dtGVTaikhoan.Columns[4].HeaderText = "Trạng thái";

            dtGVTaikhoan.Columns[0].Width = 100;
            dtGVTaikhoan.Columns[1].Width = 200;
            dtGVTaikhoan.Columns[2].Width = 200;
            dtGVTaikhoan.Columns[3].Width = 200;
            dtGVTaikhoan.Columns[4].Width = 150;
            dtGVTaikhoan.AllowUserToAddRows = false;
            dtGVTaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemtk_Click(object sender, EventArgs e)
        {
            LoadNhanVienChuaCoTaiKhoan(); // Chỉ hiện NV chưa có tài khoản
            ResetValues();
            txtTrangthai.Text = "1"; // Mặc định trạng thái là 1 (hoạt động)
            btnLuu.Enabled = true;
        }
        private void ResetValues()
        {
            cbbManv.Text = "";
            txtusername.Text = "";
            txtpass.Text = "";
            txtChucvu.Text = "";
            txtTrangthai.Text = "";

        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
            {
                using (SqlConnection conn = Database.GetConnection())
                {

                    string query = "UPDATE TaiKhoan SET TrangThai = 0 WHERE Username = @TenDangNhap";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtusername.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã khóa tài khoản.");
                        TaiKhoanDAO.LoadData();
                        LoadDataToGridView(); // Cập nhật lại dữ liệu hiển thị
                    }
                }

                txtTrangthai.Text = "0"; // Cập nhật trạng thái hiển thị


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {


                        string query = "DELETE FROM TaiKhoan WHERE Username = @TenDangNhap";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenDangNhap", txtusername.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đã xóa tài khoản");
                                TaiKhoanDAO.LoadData();
                                LoadDataToGridView(); // Cập nhật lại dữ liệu hiển thị
                                // Xóa dữ liệu hiển thị trên form nếu cần
                                txtusername.Clear();
                                txtpass.Clear();
                                txtChucvu.Clear();
                                txtTrangthai.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản để xóa.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập cần xóa.");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                //conn.Open();

                // Kiểm tra tài khoản tồn tại
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @TenDangNhap";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@TenDangNhap", txtusername.Text);
                int count = (int)checkCmd.ExecuteScalar();

                string query;
                if (count > 0)
                {
                    query = "UPDATE TaiKhoan SET PasswordHash = @MatKhau, TrangThai = @TrangThai, MaNV = @MaNV, Role = @Role WHERE Username = @TenDangNhap";
                }
                else
                {
                    query = "INSERT INTO TaiKhoan (Username, PasswordHash, TrangThai, MaNV, Role) VALUES (@TenDangNhap, @MatKhau, @TrangThai, @MaNV, @Role)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", txtusername.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtpass.Text);

                // Bắt buộc chọn mã nhân viên
                if (cbbManv.SelectedValue != null)
                {
                    cmd.Parameters.AddWithValue("@MaNV", cbbManv.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên!");
                    return;
                }
                int trangThai = 1; // mặc định là 1
                if (!string.IsNullOrWhiteSpace(txtTrangthai.Text))
                {
                    if (!int.TryParse(txtTrangthai.Text, out trangThai) || (trangThai != 0 && trangThai != 1))
                    {
                        MessageBox.Show("Trạng thái không hợp lệ. Vui lòng nhập số 0 hoặc 1.");
                        return;
                    }
                }
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                // Bổ sung tham số Role
                string role = string.IsNullOrWhiteSpace(txtChucvu.Text) ? "User" : txtChucvu.Text;
                cmd.Parameters.AddWithValue("@Role", role);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã lưu tài khoản.");

                TaiKhoanDAO.LoadData();
                LoadDataToGridView();
            }
        }

        private void btnMotk_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
            {
                using (SqlConnection conn = Database.GetConnection())
                {

                    string query = "UPDATE TaiKhoan SET TrangThai = 1 WHERE Username = @TenDangNhap";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtusername.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã mở tài khoản.");
                        TaiKhoanDAO.LoadData();
                        LoadDataToGridView(); // Cập nhật lại dữ liệu hiển thị
                    }
                }

                txtTrangthai.Text = "1"; // Cập nhật trạng thái hiển thị
            }
        }
    }
}

