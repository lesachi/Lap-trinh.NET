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
            string sql = @"
        SELECT MaNV, TenNV
        FROM NhanVien 
        WHERE MaNV NOT IN (SELECT MaNV FROM TaiKhoan)";
            Database.FillDataToCombo(cbbManv, sql, "MaNV", "TenNV");
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
    }
}

