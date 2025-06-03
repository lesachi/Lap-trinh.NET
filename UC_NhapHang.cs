using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookStore.DAO;

namespace BookStore
{
    public partial class UC_NhapHang : UserControl
    {
        private DataTable dtPhieuNhapHang = new DataTable();
        private decimal totalInvoiceAmount = 0;
        private int selectedRowIndex = -1;
        private string selectedSoHDN = null;
        private Dictionary<string, string> maSachToTenSachMap = new Dictionary<string, string>();
        private string currentSoHDN = null;
        private string _maNV;
        public UC_NhapHang(string maNV)
        {
            InitializeComponent();
            _maNV = maNV;
           
            InitializeDataTable();
            LoadComboBoxData();
            //đảm bảo mã nv đăng nhập luôn được chọn 
            cmbMaNV.SelectedItem = _maNV;
            cmbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaNV.Enabled = false;
            //hiển thị tên nhân viên tương ứng với mã nhân viên
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", _maNV);
                cmbTenNV.SelectedItem = cmd.ExecuteScalar()?.ToString() ?? "";
                cmbTenNV.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTenNV.Enabled = false;
            }
            LoadPhieuNhapHang();
            dtPNgayNhapHang.Value = DateTime.Now;
            CalculateTotal();

           
          
            txtSoLuong.TextChanged += (s, e) => CalculateTotal();
            txtDonGia.TextChanged += (s, e) => CalculateTotal();
            txtKhuyenMai.TextChanged += (s, e) => CalculateTotal();
            DataGridViewPhieuNhapHang.SelectionChanged += DataGridViewPhieuNhapHang_SelectionChanged;
            cmbMaSach.SelectedIndexChanged += cmbMaSach_SelectedIndexChanged;
        }

        private void InitializeDataTable()
        {
            dtPhieuNhapHang.Columns.Add("Số hóa đơn nhập", typeof(string));
            dtPhieuNhapHang.Columns.Add("Tên nhân viên", typeof(string));
            dtPhieuNhapHang.Columns.Add("Tên sách", typeof(string));
            dtPhieuNhapHang.Columns.Add("Tên nhà cung cấp", typeof(string));
            dtPhieuNhapHang.Columns.Add("Đơn giá", typeof(decimal));
            dtPhieuNhapHang.Columns.Add("Số lượng", typeof(int));
            dtPhieuNhapHang.Columns.Add("Khuyến mại", typeof(decimal));
            dtPhieuNhapHang.Columns.Add("Thành tiền", typeof(decimal));
            DataGridViewPhieuNhapHang.DataSource = dtPhieuNhapHang;
            DataGridViewPhieuNhapHang.Columns["Tên sách"].Width = 200;
            DataGridViewPhieuNhapHang.Columns["Tên nhà cung cấp"].Width = 200;
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    // Nhân viên
                    using (var cmd = new SqlCommand("SELECT MaNV, TenNV FROM NhanVien", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbMaNV.Items.Clear();
                        cmbTenNV.Items.Clear();
                        while (reader.Read())
                        {
                            cmbMaNV.Items.Add(reader["MaNV"].ToString());
                            cmbTenNV.Items.Add(reader["TenNV"].ToString());
                        }
                    }
                    // Nhà cung cấp
                    using (var cmd = new SqlCommand("SELECT MaNCC, TenNCC FROM NhaCungCap", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbMaNCC.Items.Clear();
                        cmbTenNCC.Items.Clear();
                        while (reader.Read())
                        {
                            cmbMaNCC.Items.Add(reader["MaNCC"].ToString());
                            cmbTenNCC.Items.Add(reader["TenNCC"].ToString());
                        }
                    }
                    // Sách
                    using (var cmd = new SqlCommand("SELECT MaSach, TenSach FROM KhoSach", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbMaSach.Items.Clear();
                        maSachToTenSachMap.Clear();
                        while (reader.Read())
                        {
                            string maSach = reader["MaSach"].ToString();
                            string tenSach = reader["TenSach"].ToString();
                            cmbMaSach.Items.Add(maSach);
                            maSachToTenSachMap[maSach] = tenSach;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message);
                }
            }
        }

        // Khi chọn mã sách, hiển thị tên sách và tồn kho
        private void cmbMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSach.SelectedItem != null)
            {
                string maSach = cmbMaSach.SelectedItem.ToString();
                var row = KhoSachDAO.GetSachByMa(maSach); // Lấy thông tin sách từ DAO
                if (row != null)
                {
                    txtTenSach.Text = row["TenSach"].ToString();
                    // Ví dụ: Hiển thị tồn kho (nếu có label tồn kho)
                    // lblTonKho.Text = "Tồn kho: " + row["SoLuong"].ToString();
                }
                else
                {
                    txtTenSach.Text = "";
                }
            }
            else
            {
                txtTenSach.Text = "";
            }
        }

        private void LoadPhieuNhapHang()
        {
            dtPhieuNhapHang.Clear();
            totalInvoiceAmount = 0;
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string sql = @"
                        SELECT p.SoHDN, nv.TenNV, ks.TenSach, ncc.TenNCC, c.DonGiaNhap AS DonGia, c.SoLuongNhap AS SoLuong, 
                               c.KhuyenMai, c.ThanhTien, c.MaSach
                        FROM HoaDonNhap p
                        JOIN NhanVien nv ON p.MaNV = nv.MaNV
                        JOIN ChiTietHDN c ON p.SoHDN = c.SoHDN
                        JOIN KhoSach ks ON c.MaSach = ks.MaSach
                        JOIN NhaCungCap ncc ON p.MaNCC = ncc.MaNCC
                        ORDER BY CAST(SUBSTRING(p.SoHDN, 4, LEN(p.SoHDN)) AS INT)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dtPhieuNhapHang.Rows.Add(
                                reader["SoHDN"].ToString(),
                                reader["TenNV"].ToString(),
                                reader["TenSach"].ToString(),
                                reader["TenNCC"].ToString(),
                                reader.GetDecimal(reader.GetOrdinal("DonGia")),
                                reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                reader.GetDecimal(reader.GetOrdinal("KhuyenMai")),
                                reader.GetDecimal(reader.GetOrdinal("ThanhTien"))
                            );
                            totalInvoiceAmount += reader.GetDecimal(reader.GetOrdinal("ThanhTien"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải phiếu nhập hàng: " + ex.Message);
                }
            }
        }

        private void CalculateTotal()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                decimal.TryParse(txtDonGia.Text, out decimal donGia) &&
                decimal.TryParse(txtKhuyenMai.Text, out decimal khuyenMai))
            {
                decimal thanhTien = (soLuong * donGia) - khuyenMai;
                txtTongTien.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtTongTien.Text = "0";
            }
        }

        private string GetNewSoHDN()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string sql = "SELECT ISNULL(MAX(SoHDN), 'HDN000') FROM HoaDonNhap";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string maxSoHDN = cmd.ExecuteScalar().ToString();
                        int number = int.Parse(maxSoHDN.Replace("HDN", "")) + 1;
                        return "HDN" + number.ToString("D3");
                    }
                }
                catch
                {
                    return "HDN001";
                }
            }
        }

        private void DataGridViewPhieuNhapHang_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewPhieuNhapHang.SelectedRows.Count > 0)
            {
                selectedRowIndex = DataGridViewPhieuNhapHang.SelectedRows[0].Index;
                DataRow row = dtPhieuNhapHang.Rows[selectedRowIndex];
                selectedSoHDN = row["Số hóa đơn nhập"].ToString();

                txtSoHDN.Text = row["Số hóa đơn nhập"].ToString();
                txtTenSach.Text = row["Tên sách"].ToString();
                txtSoLuong.Text = row["Số lượng"].ToString();
                txtDonGia.Text = row["Đơn giá"].ToString();
                txtKhuyenMai.Text = row["Khuyến mại"].ToString();
                txtTongTien.Text = row["Thành tiền"].ToString();

                string tenSach = row["Tên sách"].ToString();
                string maSach = maSachToTenSachMap.FirstOrDefault(x => x.Value == tenSach).Key ?? "";
                cmbMaSach.SelectedItem = maSach;

                using (SqlConnection conn = Database.GetConnection())
                {
                    try
                    {
                        string sql = @"
                            SELECT p.SoHDN, p.MaNV, nv.TenNV, p.MaNCC, ncc.TenNCC, p.NgayNhap
                            FROM HoaDonNhap p
                            JOIN NhanVien nv ON p.MaNV = nv.MaNV
                            JOIN NhaCungCap ncc ON p.MaNCC = ncc.MaNCC
                            WHERE p.SoHDN = @SoHDN";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    cmbMaNV.SelectedItem = reader["MaNV"].ToString();
                                    cmbTenNV.SelectedItem = reader["TenNV"].ToString();
                                    cmbMaNCC.SelectedItem = reader["MaNCC"].ToString();
                                    cmbTenNCC.SelectedItem = reader["TenNCC"].ToString();
                                    dtPNgayNhapHang.Value = reader.GetDateTime(reader.GetOrdinal("NgayNhap"));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải thông tin hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbMaNV.SelectedItem == null || cmbTenNV.SelectedItem == null ||
                cmbMaNCC.SelectedItem == null || cmbTenNCC.SelectedItem == null ||
                cmbMaSach.SelectedItem == null || string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtKhuyenMai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương!");
                return;
            }
            if (!decimal.TryParse(txtKhuyenMai.Text, out decimal khuyenMai) || khuyenMai < 0)
            {
                MessageBox.Show("Khuyến mại phải là số dương!");
                return;
            }

            decimal thanhTien = (soLuong * donGia) - khuyenMai;

            if (string.IsNullOrEmpty(currentSoHDN))
                currentSoHDN = GetNewSoHDN();

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tạo hóa đơn nếu chưa có
                            string checkSql = "SELECT COUNT(*) FROM HoaDonNhap WHERE SoHDN = @SoHDN";
                            using (SqlCommand checkCmd = new SqlCommand(checkSql, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@SoHDN", currentSoHDN);
                                bool exists = (int)checkCmd.ExecuteScalar() > 0;
                                if (!exists)
                                {
                                    string sqlHDN = @"INSERT INTO HoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC, TongTien) 
                                                    VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC, @TongTien)";
                                    using (SqlCommand cmdHDN = new SqlCommand(sqlHDN, conn, transaction))
                                    {
                                        cmdHDN.Parameters.AddWithValue("@SoHDN", currentSoHDN);
                                        cmdHDN.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedItem.ToString());
                                        cmdHDN.Parameters.AddWithValue("@NgayNhap", dtPNgayNhapHang.Value);
                                        cmdHDN.Parameters.AddWithValue("@MaNCC", cmbMaNCC.SelectedItem.ToString());
                                        cmdHDN.Parameters.AddWithValue("@TongTien", 0);
                                        cmdHDN.ExecuteNonQuery();
                                    }
                                }
                            }
                            // Thêm chi tiết hóa đơn
                            string sqlCTHDN = @"INSERT INTO ChiTietHDN (SoHDN, MaSach, SoLuongNhap, DonGiaNhap, KhuyenMai, ThanhTien) 
                                              VALUES (@SoHDN, @MaSach, @SoLuong, @DonGia, @KhuyenMai, @ThanhTien)";
                            using (SqlCommand cmdCTHDN = new SqlCommand(sqlCTHDN, conn, transaction))
                            {
                                cmdCTHDN.Parameters.AddWithValue("@SoHDN", currentSoHDN);
                                cmdCTHDN.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedItem.ToString());
                                cmdCTHDN.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdCTHDN.Parameters.AddWithValue("@DonGia", donGia);
                                cmdCTHDN.Parameters.AddWithValue("@KhuyenMai", khuyenMai);
                                cmdCTHDN.Parameters.AddWithValue("@ThanhTien", thanhTien);
                                cmdCTHDN.ExecuteNonQuery();
                            }
                            // Cập nhật tổng tiền hóa đơn
                            string sqlUpdateTongTien = @"UPDATE HoaDonNhap 
                                                        SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHDN WHERE SoHDN = @SoHDN)
                                                        WHERE SoHDN = @SoHDN";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTongTien, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@SoHDN", currentSoHDN);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            transaction.Commit();

                            // Cập nhật tồn kho và giá sách
                            KhoSachDAO.CapNhatNhapHang(cmbMaSach.SelectedItem.ToString(), soLuong, donGia);

                            dtPhieuNhapHang.Rows.Add(currentSoHDN, cmbTenNV.SelectedItem.ToString(),
                                txtTenSach.Text, cmbTenNCC.SelectedItem.ToString(), donGia, soLuong, khuyenMai, thanhTien);
                            totalInvoiceAmount += thanhTien;
                            LoadPhieuNhapHang();
                            ClearInputFields();
                            MessageBox.Show("Thêm chi tiết hóa đơn thành công! Số hóa đơn: " + currentSoHDN);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1 || selectedRowIndex >= dtPhieuNhapHang.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoHDN.Text) || cmbMaNV.SelectedItem == null ||
                cmbTenNV.SelectedItem == null || cmbMaNCC.SelectedItem == null ||
                cmbTenNCC.SelectedItem == null || cmbMaSach.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                string.IsNullOrWhiteSpace(txtKhuyenMai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương!");
                return;
            }
            if (!decimal.TryParse(txtKhuyenMai.Text, out decimal khuyenMai) || khuyenMai < 0)
            {
                MessageBox.Show("Khuyến mại phải là số dương!");
                return;
            }

            decimal newThanhTien = (soLuong * donGia) - khuyenMai;

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlHDN = @"UPDATE HoaDonNhap 
                                            SET MaNV = @MaNV, NgayNhap = @NgayNhap, MaNCC = @MaNCC
                                            WHERE SoHDN = @SoHDN";
                            using (SqlCommand cmdHDN = new SqlCommand(sqlHDN, conn, transaction))
                            {
                                cmdHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                cmdHDN.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedItem.ToString());
                                cmdHDN.Parameters.AddWithValue("@NgayNhap", dtPNgayNhapHang.Value);
                                cmdHDN.Parameters.AddWithValue("@MaNCC", cmbMaNCC.SelectedItem.ToString());
                                cmdHDN.ExecuteNonQuery();
                            }
                            string sqlCTHDN = @"UPDATE ChiTietHDN 
                                              SET SoLuongNhap = @SoLuong, DonGiaNhap = @DonGia, 
                                                  KhuyenMai = @KhuyenMai, ThanhTien = @ThanhTien
                                              WHERE SoHDN = @SoHDN AND MaSach = @MaSach";
                            using (SqlCommand cmdCTHDN = new SqlCommand(sqlCTHDN, conn, transaction))
                            {
                                cmdCTHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                cmdCTHDN.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedItem.ToString());
                                cmdCTHDN.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdCTHDN.Parameters.AddWithValue("@DonGia", donGia);
                                cmdCTHDN.Parameters.AddWithValue("@KhuyenMai", khuyenMai);
                                cmdCTHDN.Parameters.AddWithValue("@ThanhTien", newThanhTien);
                                cmdCTHDN.ExecuteNonQuery();
                            }
                            string sqlUpdateTongTien = @"UPDATE HoaDonNhap 
                                                        SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHDN WHERE SoHDN = @SoHDN)
                                                        WHERE SoHDN = @SoHDN";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTongTien, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            transaction.Commit();

                            // Cập nhật tồn kho và giá sách
                            KhoSachDAO.CapNhatNhapHang(cmbMaSach.SelectedItem.ToString(), soLuong, donGia);

                            decimal oldThanhTien = (decimal)dtPhieuNhapHang.Rows[selectedRowIndex]["Thành tiền"];
                            totalInvoiceAmount -= oldThanhTien;
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Tên nhân viên"] = cmbTenNV.SelectedItem.ToString();
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Tên sách"] = txtTenSach.Text;
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Tên nhà cung cấp"] = cmbTenNCC.SelectedItem.ToString();
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Đơn giá"] = donGia;
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Số lượng"] = soLuong;
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Khuyến mại"] = khuyenMai;
                            dtPhieuNhapHang.Rows[selectedRowIndex]["Thành tiền"] = newThanhTien;
                            totalInvoiceAmount += newThanhTien;

                            DataGridViewPhieuNhapHang.Refresh();
                            MessageBox.Show("Sửa thành công!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSoHDN))
            {
                MessageBox.Show("Không có hóa đơn nào để lưu!");
                return;
            }
            currentSoHDN = null;
            LoadPhieuNhapHang();
            ClearInputFields();
            MessageBox.Show("Đã lưu hóa đơn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedSoHDN))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xóa chi tiết sách này khỏi hóa đơn " + selectedSoHDN + "?\n" +
                "Chọn Yes để xóa chi tiết sách, No để xóa toàn bộ hóa đơn, Cancel để hủy.",
                "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (result == DialogResult.Yes)
                            {
                                string sqlDeleteCTHDN = @"DELETE FROM ChiTietHDN WHERE SoHDN = @SoHDN AND MaSach = @MaSach";
                                using (SqlCommand cmdDeleteCTHDN = new SqlCommand(sqlDeleteCTHDN, conn, transaction))
                                {
                                    cmdDeleteCTHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                    cmdDeleteCTHDN.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedItem.ToString());
                                    cmdDeleteCTHDN.ExecuteNonQuery();
                                }
                                string sqlUpdateTongTien = @"UPDATE HoaDonNhap 
                                                            SET TongTien = (SELECT ISNULL(SUM(ThanhTien), 0) FROM ChiTietHDN WHERE SoHDN = @SoHDN)
                                                            WHERE SoHDN = @SoHDN";
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTongTien, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                                string sqlCheckCTHDN = "SELECT COUNT(*) FROM ChiTietHDN WHERE SoHDN = @SoHDN";
                                using (SqlCommand cmdCheck = new SqlCommand(sqlCheckCTHDN, conn, transaction))
                                {
                                    cmdCheck.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                    if ((int)cmdCheck.ExecuteScalar() == 0)
                                    {
                                        string sqlDeleteHDN = @"DELETE FROM HoaDonNhap WHERE SoHDN = @SoHDN";
                                        using (SqlCommand cmdDeleteHDN = new SqlCommand(sqlDeleteHDN, conn, transaction))
                                        {
                                            cmdDeleteHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                            cmdDeleteHDN.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else if (result == DialogResult.No)
                            {
                                string sqlDeleteCTHDN = @"DELETE FROM ChiTietHDN WHERE SoHDN = @SoHDN";
                                using (SqlCommand cmdDeleteCTHDN = new SqlCommand(sqlDeleteCTHDN, conn, transaction))
                                {
                                    cmdDeleteCTHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                    cmdDeleteCTHDN.ExecuteNonQuery();
                                }
                                string sqlDeleteHDN = @"DELETE FROM HoaDonNhap WHERE SoHDN = @SoHDN";
                                using (SqlCommand cmdDeleteHDN = new SqlCommand(sqlDeleteHDN, conn, transaction))
                                {
                                    cmdDeleteHDN.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                                    cmdDeleteHDN.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                            totalInvoiceAmount -= (decimal)dtPhieuNhapHang.Rows[selectedRowIndex]["Thành tiền"];
                            dtPhieuNhapHang.Rows[selectedRowIndex].Delete();
                            dtPhieuNhapHang.AcceptChanges();
                            LoadPhieuNhapHang();
                            ClearInputFields();
                            selectedRowIndex = -1;
                            selectedSoHDN = null;
                            MessageBox.Show("Xóa thành công!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            currentSoHDN = null;
            MessageBox.Show("Đã hủy!");
        }

        private void btnInPhieuNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedSoHDN))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in!");
                return;
            }
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    string sql = @"
                        SELECT p.SoHDN, nv.TenNV, ncc.TenNCC, p.NgayNhap, p.TongTien, 
                               c.MaSach, ks.TenSach, c.SoLuongNhap, c.DonGiaNhap, c.KhuyenMai, c.ThanhTien
                        FROM HoaDonNhap p
                        JOIN NhanVien nv ON p.MaNV = nv.MaNV
                        JOIN NhaCungCap ncc ON p.MaNCC = ncc.MaNCC
                        JOIN ChiTietHDN c ON p.SoHDN = c.SoHDN
                        JOIN KhoSach ks ON c.MaSach = ks.MaSach
                        WHERE p.SoHDN = @SoHDN";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoHDN", selectedSoHDN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("=== PHIẾU NHẬP HÀNG ===");
                            sb.AppendLine($"Số hóa đơn: {selectedSoHDN}");
                            decimal tongTien = 0;
                            if (reader.Read())
                            {
                                sb.AppendLine($"Nhân viên: {reader["TenNV"]}");
                                sb.AppendLine($"Nhà cung cấp: {reader["TenNCC"]}");
                                sb.AppendLine($"Ngày nhập: {reader["NgayNhap"]}");
                                tongTien = reader.GetDecimal(reader.GetOrdinal("TongTien"));
                                sb.AppendLine("=== Chi tiết hóa đơn ===");
                            }
                            reader.Close();
                            using (SqlDataReader detailReader = cmd.ExecuteReader())
                            {
                                while (detailReader.Read())
                                {
                                    sb.AppendLine($"Mã sách: {detailReader["MaSach"]}");
                                    sb.AppendLine($"Tên sách: {detailReader["TenSach"]}");
                                    sb.AppendLine($"Số lượng: {detailReader["SoLuongNhap"]}");
                                    sb.AppendLine($"Đơn giá: {detailReader["DonGiaNhap"]}");
                                    sb.AppendLine($"Khuyến mại: {detailReader["KhuyenMai"]}");
                                    sb.AppendLine($"Thành tiền: {detailReader["ThanhTien"]}");
                                    sb.AppendLine("---------------------");
                                }
                            }
                            sb.AppendLine($"Tổng tiền: {tongTien:N0}");
                            sb.AppendLine("=====================");
                            MessageBox.Show(sb.ToString(), "In hóa đơn");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message);
                }
            }
        }

        private void ClearInputFields()
        {
            txtSoHDN.Text = "";
            
            cmbTenNV.SelectedIndex = -1;
            cmbMaNCC.SelectedIndex = -1;
            cmbTenNCC.SelectedIndex = -1;
            cmbMaSach.SelectedIndex = -1;
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtKhuyenMai.Text = "";
            txtTongTien.Text = "0";
        }

        private void DataGridViewPhieuNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
