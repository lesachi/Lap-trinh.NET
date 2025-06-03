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
using BookStore;
using OfficeOpenXml;
//using OfficeOpenXml.License;
using System.IO;
using OfficeOpenXml.Style;



namespace BookStore
{
    public partial class UC_BaoCaoSach : UserControl
    {
        public UC_BaoCaoSach()
        {
            InitializeComponent();
            SetupControls();
        }

        private void UC_BaoCaoSach_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
        }
        private void SetupControls()
        {
            // Năm hiện tại và vài năm trước để chọn
            numericUpDownYear.Minimum = 2020;
            numericUpDownYear.Maximum = DateTime.Now.Year;
            numericUpDownYear.Value = DateTime.Now.Year;

            // Tháng: 0 = tất cả tháng, 1->12 tháng
            numericUpDownMonth.Minimum = 0;
            numericUpDownMonth.Maximum = 12;
            numericUpDownMonth.Value = 0;

            // Top N
            numericUpDownTop.Minimum = 1;
            numericUpDownTop.Maximum = 100;
            numericUpDownTop.Value = 10;

            btnHienthi.Click += btnHienthi_Click;
            LoadFilterData();
        }
            private void btnHienthi_Click(object sender, EventArgs e)
            {
            int year = (int)numericUpDownYear.Value;
            int month = (int)numericUpDownMonth.Value;
            int topN = (int)numericUpDownTop.Value;
            string maLoai = cboLoaiSach.SelectedValue?.ToString();
            string maLV = cboLinhVuc.SelectedValue?.ToString();
            if (cboLinhVuc.SelectedIndex < 0) maLV = null;

            if (cboLoaiSach.SelectedIndex < 0) maLoai = null;

            DataTable dt = GetTopSellingBooks(year, month, topN, maLoai, maLV);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện lọc.");
            }
            dataGridViewBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewBook.DataSource = dt;
            dataGridViewBook.Refresh();
            dataGridViewBook.Columns["MaSach"].HeaderText = "Mã sách";
            dataGridViewBook.Columns["TenSach"].HeaderText = "Tên sách";
            dataGridViewBook.Columns["TenTG"].HeaderText = "Tác giả";
            dataGridViewBook.Columns["TenLoai"].HeaderText = "Loại sách";
            dataGridViewBook.Columns["TenNXB"].HeaderText = "Nhà xuất bản";
            dataGridViewBook.Columns["TongSoLuongBan"].HeaderText = "Số lượng bán";
            dataGridViewBook.Columns["TongDoanhThu"].HeaderText = "Doanh thu";

        }
        private DataTable GetTopSellingBooks(int year, int month, int topN, string maLoai, string maLV)
        {
            DataTable dt = new DataTable();

            string sql = @"
        SELECT TOP (@TopN) 
            ks.MaSach, ks.TenSach, tg.TenTG, ls.TenLoai, nxb.TenNXB,
            SUM(ct.SoLuongBan) AS TongSoLuongBan,
            SUM(ct.ThanhTien) AS TongDoanhThu
        FROM ChiTietHDB ct
        INNER JOIN HoaDonBan hdb ON ct.SoHDB = hdb.SoHDB
        INNER JOIN KhoSach ks ON ct.MaSach = ks.MaSach
        INNER JOIN TacGia tg ON ks.MaTG = tg.MaTG
        INNER JOIN LoaiSach ls ON ks.MaLoai = ls.MaLoai
        INNER JOIN NXB nxb ON ks.MaNXB = nxb.MaNXB
        WHERE YEAR(hdb.NgayBan) = @Year
    ";

            if (month > 0)
                sql += " AND MONTH(hdb.NgayBan) = @Month";
            if (!string.IsNullOrEmpty(maLoai))
                sql += " AND ks.MaLoai = @MaLoai";
            if (!string.IsNullOrEmpty(maLV))
                sql += " AND ks.MaLinhVuc = @MaLinhVuc";

            sql += @"
        GROUP BY ks.MaSach, ks.TenSach, tg.TenTG, ls.TenLoai, nxb.TenNXB
        ORDER BY TongSoLuongBan DESC, TongDoanhThu DESC";

            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TopN", topN);
                    cmd.Parameters.AddWithValue("@Year", year);
                    if (month > 0)
                        cmd.Parameters.AddWithValue("@Month", month);
                    if (!string.IsNullOrEmpty(maLoai))
                        cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    if (!string.IsNullOrEmpty(maLV))
                        cmd.Parameters.AddWithValue("@MaLinhVuc", maLV);
                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void LoadFilterData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                // Loại sách
                SqlDataAdapter daLoai = new SqlDataAdapter("SELECT MaLoai, TenLoai FROM LoaiSach", conn);
                DataTable dtLoai = new DataTable();
                daLoai.Fill(dtLoai);
                cboLoaiSach.DataSource = dtLoai;
                cboLoaiSach.DisplayMember = "TenLoai";
                cboLoaiSach.ValueMember = "MaLoai";
                cboLoaiSach.SelectedIndex = -1;

                //Lĩnh vực
                SqlDataAdapter daLV = new SqlDataAdapter("SELECT MaLinhVuc, TenLinhVuc FROM LinhVuc", conn);
                DataTable dtLV = new DataTable();
                daLV.Fill(dtLV);
                cboLinhVuc.DataSource = dtLV;
                cboLinhVuc.DisplayMember = "TenLinhVuc";
                cboLinhVuc.ValueMember = "MaLinhVuc";
                cboLinhVuc.SelectedIndex = -1;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Đường dẫn file tạm (ví dụ: Desktop)
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "BaoCaoSach.xlsx"
            );

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Báo cáo");

                // Ghi tiêu đề cột
                for (int i = 0; i < dataGridViewBook.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dataGridViewBook.Columns[i].HeaderText;
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                    ws.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                // Ghi dữ liệu
                for (int i = 0; i < dataGridViewBook.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewBook.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dataGridViewBook.Rows[i].Cells[j].Value;
                    }
                }

                ws.Cells.AutoFitColumns();

                // Lưu file
                File.WriteAllBytes(filePath, pck.GetAsByteArray());
            }

            // Mở file Excel ngay lập tức
            System.Diagnostics.Process.Start(filePath);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Parent.Controls.Remove(this);
            }
        }
    }
}



 
       

        
    

