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
using BookStore.DAO;

namespace BookStore
{
    public partial class UC_BanHang : UserControl
    {
        private DataTable dtHoaDonBan;
        private string currentSoHDB = "";
       // private decimal totalAmount = 0;

        public UC_BanHang()
        {
            InitializeComponent();
            SetupDataGridView(); // Initialize dtHoaDonBan first
            LoadData(); // Then load data, which calls LoadHoaDonBan()
            dtPNgayNhapBanHang.Value = DateTime.Now;

            // Attach event handlers
            cmbMaNV.SelectedIndexChanged += cmbMaNV_SelectedIndexChanged;
            cmbMaKH.SelectedIndexChanged += cmbMaKH_SelectedIndexChanged;
            cmbMaSach.SelectedIndexChanged += cmbMaSach_SelectedIndexChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;
            DataGridViewHoaDonBan.CellClick += DataGridViewHoaDonBan_CellClick;
        }

        private void LoadData()
        {
            // Load Nhân Viên
            using (SqlConnection conn = Database.GetConnection())
            {
                //conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNV, TenNV FROM NhanVien", conn);
                DataTable dtNV = new DataTable();
                da.Fill(dtNV);
                cmbMaNV.DataSource = dtNV;
                cmbMaNV.DisplayMember = "MaNV";
                cmbMaNV.ValueMember = "MaNV";
            }

            // Load Khách Hàng
            using (SqlConnection conn = Database.GetConnection())
            {
               // conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaKhach, TenKhach FROM KhachHang", conn);
                DataTable dtKH = new DataTable();
                da.Fill(dtKH);
                cmbMaKH.DataSource = dtKH;
                cmbMaKH.DisplayMember = "MaKhach";
                cmbMaKH.ValueMember = "MaKhach";
            }

            // Load Sách
            using (SqlConnection conn = Database.GetConnection())
            {
              //  conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSach, TenSach, DonGiaBan FROM KhoSach", conn);
                DataTable dtSach = new DataTable();
                da.Fill(dtSach);
                cmbMaSach.DataSource = dtSach;
                cmbMaSach.DisplayMember = "MaSach";
                cmbMaSach.ValueMember = "MaSach";
            }

            LoadHoaDonBan();
        }

        private void SetupDataGridView()
        {
            dtHoaDonBan = new DataTable();
            dtHoaDonBan.Columns.Add("SoHDB", typeof(string));
            dtHoaDonBan.Columns.Add("NgayBan", typeof(DateTime));
            dtHoaDonBan.Columns.Add("TenNV", typeof(string));
            dtHoaDonBan.Columns.Add("TenKH", typeof(string));
            dtHoaDonBan.Columns.Add("TenSach", typeof(string));
            dtHoaDonBan.Columns.Add("SoLuongBan", typeof(int));
            dtHoaDonBan.Columns.Add("TongTien", typeof(decimal));

            DataGridViewHoaDonBan.DataSource = dtHoaDonBan;

            // Đặt chiều rộng cho các cột cần thiết
            DataGridViewHoaDonBan.Columns["TenSach"].Width = 200;      // Tên sách rộng hơn
            DataGridViewHoaDonBan.Columns["TenKH"].Width = 180;        // Tên khách hàng rộng 
            DataGridViewHoaDonBan.Columns["TenNV"].Width = 180;
            
        }

        private void LoadHoaDonBan()
        {
            if (dtHoaDonBan == null)
            {
                SetupDataGridView();
            }

            using (SqlConnection conn = Database.GetConnection())
            {
               // conn.Open();
                string query = @"
                    SELECT hdb.SoHDB, hdb.NgayBan, nv.TenNV, kh.TenKhach, ks.TenSach, cthdb.SoLuongBan, cthdb.ThanhTien
                    FROM HoaDonBan hdb
                    JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
                    JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
                    JOIN ChiTietHDB cthdb ON hdb.SoHDB = cthdb.SoHDB
                    JOIN KhoSach ks ON cthdb.MaSach = ks.MaSach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtHoaDonBan.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dtHoaDonBan.Rows.Add(row["SoHDB"], row["NgayBan"], row["TenNV"], row["TenKhach"], row["TenSach"], row["SoLuongBan"], row["ThanhTien"]);
                }
            }
        }

        private void cmbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaNV.SelectedValue != null)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                  //  conn.Open();
                    string query = "SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedValue);
                    txtTenNV.Text = cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }

        private void cmbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaKH.SelectedValue != null)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                  //  conn.Open();
                    string query = "SELECT TenKhach FROM KhachHang WHERE MaKhach = @MaKhach";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKhach", cmbMaKH.SelectedValue);
                    txtTenKH.Text = cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }

        private void cmbMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSach.SelectedValue != null)
            {
                DataRowView drv = cmbMaSach.SelectedItem as DataRowView;
                txtTenSach.Text = drv["TenSach"].ToString();
                txtDonGia.Text = drv["DonGiaBan"].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtMaHD.Text = GenerateNewSoHDB();
            currentSoHDB = txtMaHD.Text;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSoHDB) || string.IsNullOrEmpty(cmbMaNV.SelectedValue?.ToString()) ||
                string.IsNullOrEmpty(cmbMaKH.SelectedValue?.ToString()) || string.IsNullOrEmpty(cmbMaSach.SelectedValue?.ToString()) ||
                string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            decimal donGia = decimal.Parse(txtDonGia.Text);
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);
            decimal thanhTien = (donGia * soLuong) * (1 - giamGia / 100);

            using (SqlConnection conn = Database.GetConnection())
            {
              //  conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Update HoaDonBan
                    SqlCommand cmdUpdateHD = new SqlCommand(
                        "UPDATE HoaDonBan SET MaNV = @MaNV, NgayBan = @NgayBan, MaKhach = @MaKhach, TongTien = @TongTien WHERE SoHDB = @SoHDB",
                        conn, transaction);
                    cmdUpdateHD.Parameters.AddWithValue("@SoHDB", currentSoHDB);
                    cmdUpdateHD.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedValue);
                    cmdUpdateHD.Parameters.AddWithValue("@NgayBan", dtPNgayNhapBanHang.Value);
                    cmdUpdateHD.Parameters.AddWithValue("@MaKhach", cmbMaKH.SelectedValue);
                    cmdUpdateHD.Parameters.AddWithValue("@TongTien", thanhTien); // Update total for this specific item
                    cmdUpdateHD.ExecuteNonQuery();

                    // Update or Insert ChiTietHDB (assuming one item per edit for simplicity)
                    SqlCommand cmdCheckCT = new SqlCommand(
                        "SELECT COUNT(*) FROM ChiTietHDB WHERE SoHDB = @SoHDB AND MaSach = @MaSach",
                        conn, transaction);
                    cmdCheckCT.Parameters.AddWithValue("@SoHDB", currentSoHDB);
                    cmdCheckCT.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedValue);
                    int ctCount = (int)cmdCheckCT.ExecuteScalar();

                    if (ctCount > 0)
                    {
                        // Update existing ChiTietHDB
                        SqlCommand cmdUpdateCT = new SqlCommand(
                            "UPDATE ChiTietHDB SET SoLuongBan = @SoLuongBan, KhuyenMai = @KhuyenMai, ThanhTien = @ThanhTien WHERE SoHDB = @SoHDB AND MaSach = @MaSach",
                            conn, transaction);
                        cmdUpdateCT.Parameters.AddWithValue("@SoHDB", currentSoHDB);
                        cmdUpdateCT.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedValue);
                        cmdUpdateCT.Parameters.AddWithValue("@SoLuongBan", soLuong);
                        cmdUpdateCT.Parameters.AddWithValue("@KhuyenMai", giamGia);
                        cmdUpdateCT.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdUpdateCT.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert new ChiTietHDB (if not existing for this book)
                        SqlCommand cmdInsertCT = new SqlCommand(
                            "INSERT INTO ChiTietHDB (SoHDB, MaSach, SoLuongBan, KhuyenMai, ThanhTien) VALUES (@SoHDB, @MaSach, @SoLuongBan, @KhuyenMai, @ThanhTien)",
                            conn, transaction);
                        cmdInsertCT.Parameters.AddWithValue("@SoHDB", currentSoHDB);
                        cmdInsertCT.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedValue);
                        cmdInsertCT.Parameters.AddWithValue("@SoLuongBan", soLuong);
                        cmdInsertCT.Parameters.AddWithValue("@KhuyenMai", giamGia);
                        cmdInsertCT.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdInsertCT.ExecuteNonQuery();
                    }

                    // Recalculate and update total TongTien in HoaDonBan
                    SqlCommand cmdRecalculateTotal = new SqlCommand(
                        "UPDATE HoaDonBan SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHDB WHERE SoHDB = @SoHDB) WHERE SoHDB = @SoHDB",
                        conn, transaction);
                    cmdRecalculateTotal.Parameters.AddWithValue("@SoHDB", currentSoHDB);
                    cmdRecalculateTotal.ExecuteNonQuery();

                    transaction.Commit();
                    LoadHoaDonBan();
                    MessageBox.Show("Cập nhật thành công!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DataGridViewHoaDonBan.SelectedRows.Count > 0)
            {
                string soHDB = DataGridViewHoaDonBan.SelectedRows[0].Cells["SoHDB"].Value.ToString();
                string tenSach = DataGridViewHoaDonBan.SelectedRows[0].Cells["TenSach"].Value.ToString();

                // Prompt user to choose deletion option
                DialogResult result = MessageBox.Show(
                    $"Bạn muốn xóa:\n- Chỉ dòng hiện tại (Sách: {tenSach})?\n- Toàn bộ hóa đơn ({soHDB})?\n\nChọn 'Yes' để xóa dòng, 'No' để xóa toàn bộ hóa đơn, 'Cancel' để hủy.",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNoCancel);

                using (SqlConnection conn = Database.GetConnection())
                {
                  //  conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        if (result == DialogResult.Yes) // Delete only the selected item
                        {
                            string maSach = GetMaSachFromTen(tenSach);
                            SqlCommand cmdDeleteCT = new SqlCommand(
                                "DELETE FROM ChiTietHDB WHERE SoHDB = @SoHDB AND MaSach = @MaSach",
                                conn, transaction);
                            cmdDeleteCT.Parameters.AddWithValue("@SoHDB", soHDB);
                            cmdDeleteCT.Parameters.AddWithValue("@MaSach", maSach);
                            cmdDeleteCT.ExecuteNonQuery();

                            // Recalculate TongTien after deletion
                            SqlCommand cmdRecalculateTotal = new SqlCommand(
                                "UPDATE HoaDonBan SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHDB WHERE SoHDB = @SoHDB) WHERE SoHDB = @SoHDB",
                                conn, transaction);
                            cmdRecalculateTotal.Parameters.AddWithValue("@SoHDB", soHDB);
                            cmdRecalculateTotal.ExecuteNonQuery();

                            // If no items remain, delete the HoaDonBan record
                            SqlCommand cmdCheckCT = new SqlCommand(
                                "SELECT COUNT(*) FROM ChiTietHDB WHERE SoHDB = @SoHDB",
                                conn, transaction);
                            cmdCheckCT.Parameters.AddWithValue("@SoHDB", soHDB);
                            int ctCount = (int)cmdCheckCT.ExecuteScalar();
                            if (ctCount == 0)
                            {
                                SqlCommand cmdDeleteHD = new SqlCommand(
                                    "DELETE FROM HoaDonBan WHERE SoHDB = @SoHDB",
                                    conn, transaction);
                                cmdDeleteHD.Parameters.AddWithValue("@SoHDB", soHDB);
                                cmdDeleteHD.ExecuteNonQuery();
                            }
                        }
                        else if (result == DialogResult.No) // Delete the entire invoice
                        {
                            SqlCommand cmdDeleteCT = new SqlCommand(
                                "DELETE FROM ChiTietHDB WHERE SoHDB = @SoHDB",
                                conn, transaction);
                            cmdDeleteCT.Parameters.AddWithValue("@SoHDB", soHDB);
                            cmdDeleteCT.ExecuteNonQuery();

                            SqlCommand cmdDeleteHD = new SqlCommand(
                                "DELETE FROM HoaDonBan WHERE SoHDB = @SoHDB",
                                conn, transaction);
                            cmdDeleteHD.Parameters.AddWithValue("@SoHDB", soHDB);
                            cmdDeleteHD.ExecuteNonQuery();
                        }
                        else // Cancel
                        {
                            transaction.Rollback();
                            return;
                        }

                        transaction.Commit();
                        LoadHoaDonBan();
                        MessageBox.Show("Xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) || string.IsNullOrEmpty(cmbMaNV.SelectedValue?.ToString()) ||
                string.IsNullOrEmpty(cmbMaKH.SelectedValue?.ToString()) || string.IsNullOrEmpty(cmbMaSach.SelectedValue?.ToString()) ||
                string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng bán phải là số nguyên dương!");
                return;
            }

            // Kiểm tra tồn kho trước khi bán
            string maSach = cmbMaSach.SelectedValue.ToString();
            if (!KhoSachDAO.CheckSoLuongDuDeBan(maSach, soLuong))
            {
                int soLuongTon = KhoSachDAO.GetSoLuongTonKho(maSach);
                MessageBox.Show($"Số lượng tồn kho hiện tại chỉ còn {soLuongTon}.");
                return;
            }

            decimal donGia = decimal.Parse(txtDonGia.Text);
           
            decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);
            decimal thanhTien = (donGia * soLuong) * (1 - giamGia / 100);

            using (SqlConnection conn = Database.GetConnection())
            {
               // conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string soHDB = txtMaHD.Text;
                    currentSoHDB = soHDB;

                    // Check if HoaDonBan record exists, insert or update
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM HoaDonBan WHERE SoHDB = @SoHDB", conn, transaction);
                    cmdCheck.Parameters.AddWithValue("@SoHDB", soHDB);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0)
                    {
                        // Insert new HoaDonBan record
                        SqlCommand cmdInsertHD = new SqlCommand(
                            "INSERT INTO HoaDonBan (SoHDB, MaNV, NgayBan, MaKhach, TongTien) VALUES (@SoHDB, @MaNV, @NgayBan, @MaKhach, @TongTien)",
                            conn, transaction);
                        cmdInsertHD.Parameters.AddWithValue("@SoHDB", soHDB);
                        cmdInsertHD.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedValue);
                        cmdInsertHD.Parameters.AddWithValue("@NgayBan", dtPNgayNhapBanHang.Value);
                        cmdInsertHD.Parameters.AddWithValue("@MaKhach", cmbMaKH.SelectedValue);
                        cmdInsertHD.Parameters.AddWithValue("@TongTien", thanhTien);
                        cmdInsertHD.ExecuteNonQuery();
                    }
                    else
                    {
                        // Update existing HoaDonBan record
                        SqlCommand cmdUpdateHD = new SqlCommand(
                            "UPDATE HoaDonBan SET MaNV = @MaNV, NgayBan = @NgayBan, MaKhach = @MaKhach, TongTien = TongTien + @TongTien WHERE SoHDB = @SoHDB",
                            conn, transaction);
                        cmdUpdateHD.Parameters.AddWithValue("@SoHDB", soHDB);
                        cmdUpdateHD.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedValue);
                        cmdUpdateHD.Parameters.AddWithValue("@NgayBan", dtPNgayNhapBanHang.Value);
                        cmdUpdateHD.Parameters.AddWithValue("@MaKhach", cmbMaKH.SelectedValue);
                        cmdUpdateHD.Parameters.AddWithValue("@TongTien", thanhTien);
                        cmdUpdateHD.ExecuteNonQuery();
                    }

                    // Insert into ChiTietHDB
                    SqlCommand cmdChiTiet = new SqlCommand(
                        "INSERT INTO ChiTietHDB (SoHDB, MaSach, SoLuongBan, KhuyenMai, ThanhTien) VALUES (@SoHDB, @MaSach, @SoLuongBan, @KhuyenMai, @ThanhTien)",
                        conn, transaction);
                    cmdChiTiet.Parameters.AddWithValue("@SoHDB", soHDB);
                    cmdChiTiet.Parameters.AddWithValue("@MaSach", cmbMaSach.SelectedValue);
                    cmdChiTiet.Parameters.AddWithValue("@SoLuongBan", soLuong);
                    cmdChiTiet.Parameters.AddWithValue("@KhuyenMai", giamGia);
                    cmdChiTiet.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    cmdChiTiet.ExecuteNonQuery();

                    // Update total in HoaDonBan
                    SqlCommand cmdUpdateTotal = new SqlCommand(
                        "UPDATE HoaDonBan SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHDB WHERE SoHDB = @SoHDB) WHERE SoHDB = @SoHDB",
                        conn, transaction);
                    cmdUpdateTotal.Parameters.AddWithValue("@SoHDB", soHDB);
                    cmdUpdateTotal.ExecuteNonQuery();

                    transaction.Commit();
                    LoadHoaDonBan();
                    txtTongTien.Text = thanhTien.ToString();
                    MessageBox.Show("Lưu thành công!");
                    // Cập nhật tồn kho sau khi bán hàng
                    KhoSachDAO.CapNhatBanHang(cmbMaSach.SelectedValue.ToString(), soLuong);

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (DataGridViewHoaDonBan.SelectedRows.Count > 0)
            {
                string soHDB = DataGridViewHoaDonBan.SelectedRows[0].Cells["SoHDB"].Value.ToString();
                decimal totalInvoiceAmount = 0;

                using (SqlConnection conn = Database.GetConnection())
                {
                   // conn.Open();
                    // Fetch the total amount from HoaDonBan
                    string queryTotal = "SELECT TongTien FROM HoaDonBan WHERE SoHDB = @SoHDB";
                    SqlCommand cmdTotal = new SqlCommand(queryTotal, conn);
                    cmdTotal.Parameters.AddWithValue("@SoHDB", soHDB);
                    object totalResult = cmdTotal.ExecuteScalar();
                    if (totalResult != null && totalResult != DBNull.Value && decimal.TryParse(totalResult.ToString(), out decimal tempTotal))
                    {
                        totalInvoiceAmount = tempTotal;
                    }

                    // Fetch detailed invoice information, including DonGiaBan and KhuyenMai
                            string query = @"
                        SELECT hdb.SoHDB, hdb.NgayBan, nv.TenNV, kh.TenKhach, ks.TenSach, 
                               ks.DonGiaBan, cthdb.KhuyenMai, cthdb.SoLuongBan, cthdb.ThanhTien
                        FROM HoaDonBan hdb
                        JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
                        JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
                        JOIN ChiTietHDB cthdb ON hdb.SoHDB = cthdb.SoHDB
                        JOIN KhoSach ks ON cthdb.MaSach = ks.MaSach
                        WHERE hdb.SoHDB = @SoHDB";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@SoHDB", soHDB);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string message = "Hóa đơn bán hàng (Thời gian: 01:28 PM +07, Friday, May 30, 2025)\n";
                        message += $"Số hóa đơn: {dt.Rows[0]["SoHDB"]}\n";
                        message += $"Ngày bán: {dt.Rows[0]["NgayBan"]}\n";
                        message += $"Nhân viên: {dt.Rows[0]["TenNV"]}\n";
                        message += $"Khách hàng: {dt.Rows[0]["TenKhach"]}\n";
                        message += "Chi tiết:\n";
                        foreach (DataRow row in dt.Rows)
                        {
                            decimal donGia = row["DonGiaBan"] != DBNull.Value ? Convert.ToDecimal(row["DonGiaBan"]) : 0;
                            decimal khuyenMai = row["KhuyenMai"] != DBNull.Value ? Convert.ToDecimal(row["KhuyenMai"]) : 0;
                            decimal thanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0;
                            message += $"- Sách: {row["TenSach"]}, Đơn giá: {donGia:N0} VND, Số lượng: {row["SoLuongBan"]}, Giảm giá: {khuyenMai}%, Thành tiền: {thanhTien:N0} VND\n";
                        }
                        message += $"Tổng số tiền: {totalInvoiceAmount:N0} VND\n";
                        message += "--------------------------------------------------\n";
                        MessageBox.Show(message, "Chi tiết hóa đơn");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin hóa đơn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
            }
        }


        private void DataGridViewHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridViewHoaDonBan.Rows[e.RowIndex];
                currentSoHDB = row.Cells["SoHDB"].Value.ToString();
                txtMaHD.Text = currentSoHDB;
                dtPNgayNhapBanHang.Value = Convert.ToDateTime(row.Cells["NgayBan"].Value);

                // Load MaNV and TenNV
                string maNV = GetMaNVFromTen(row.Cells["TenNV"].Value.ToString());
                cmbMaNV.SelectedValue = maNV;
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();

                // Load MaKH and TenKH
                string maKH = GetMaKHFromTen(row.Cells["TenKH"].Value.ToString());
                cmbMaKH.SelectedValue = maKH;
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();

                // Load MaSach, TenSach, DonGia, and related data
                string maSach = GetMaSachFromTen(row.Cells["TenSach"].Value.ToString());
                cmbMaSach.SelectedValue = maSach;
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuongBan"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();

                // Fetch DonGia from KhoSach based on MaSach
                using (SqlConnection conn = Database.GetConnection())
                {
                  //  conn.Open();
                    string query = "SELECT DonGiaBan FROM KhoSach WHERE MaSach = @MaSach";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    object result = cmd.ExecuteScalar();
                    txtDonGia.Text = result?.ToString() ?? "0";
                }

                txtGiamGia.Text = "0"; // Reset or calculate discount if needed
                CalculateTongTien(); // Recalculate total based on current values
            }
        }

        private string GenerateNewSoHDB()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
              //  conn.Open();
                string query = "SELECT MAX(SoHDB) FROM HoaDonBan";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                int number = 1; // Default starting number if table is empty

                if (result != null && result != DBNull.Value)
                {
                    string lastSoHDB = result.ToString();
                    string numericPart = lastSoHDB.Replace("HDB", "").Trim();
                    if (int.TryParse(numericPart, out int parsedNumber))
                    {
                        number = parsedNumber + 1;
                    }
                }

                return "HDB" + number.ToString("D3");
            }
        }

        private string GetMaNVFromTen(string tenNV)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
             //   conn.Open();
                string query = "SELECT MaNV FROM NhanVien WHERE TenNV = @TenNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string GetMaKHFromTen(string tenKH)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
             //   conn.Open();
                string query = "SELECT MaKhach FROM KhachHang WHERE TenKhach = @TenKhach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKhach", tenKH);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string GetMaSachFromTen(string tenSach)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
             //   conn.Open();
                string query = "SELECT MaSach FROM KhoSach WHERE TenSach = @TenSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSach", tenSach);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private void ClearFields()
        {
            txtMaHD.Text = "";
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtTongTien.Text = "";
            txtDonGia.Text = "";
            txtTenKH.Text = "";
            txtTenNV.Text = "";
            cmbMaNV.SelectedIndex = -1;
            cmbMaKH.SelectedIndex = -1;
            cmbMaSach.SelectedIndex = -1;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateTongTien();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CalculateTongTien();
        }

        private void CalculateTongTien()
        {
            if (decimal.TryParse(txtDonGia.Text, out decimal donGia) && int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtGiamGia.Text, out decimal giamGia))
            {
                decimal thanhTien = (donGia * soLuong) * (1 - giamGia / 100);
                txtTongTien.Text = thanhTien.ToString();
            }
        }
    }
}






