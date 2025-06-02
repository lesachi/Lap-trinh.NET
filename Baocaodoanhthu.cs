using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
namespace BookStore
{
    public partial class Baocaodoanhthu : UserControl
    {
        public Baocaodoanhthu()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                DateTime tuNgay = dtpTu.Value;
                DateTime denNgay = dtpDen.Value;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get revenue range inputs
                decimal doanhThuTren = 0;
                decimal doanhThuDuoi = decimal.MaxValue;

                if (!string.IsNullOrEmpty(txtDoanhThuTren.Text) && !decimal.TryParse(txtDoanhThuTren.Text, out doanhThuTren))
                {
                    MessageBox.Show("Doanh thu trên phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(txtDoanhThuDuoi.Text) && !decimal.TryParse(txtDoanhThuDuoi.Text, out doanhThuDuoi))
                {
                    MessageBox.Show("Doanh thu dưới phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(txtDoanhThuTren.Text) && !string.IsNullOrEmpty(txtDoanhThuDuoi.Text) && doanhThuTren > doanhThuDuoi)
                {
                    MessageBox.Show("Doanh thu trên không được lớn hơn doanh thu dưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construct SQL query
                string query = @"
                    SELECT SoHDB, MaKhach, NgayBan, TongTien, MaNV
                    FROM HoaDonBan
                    WHERE NgayBan BETWEEN @TuNgay AND @DenNgay";

                // Add revenue filters if provided
                if (!string.IsNullOrEmpty(txtDoanhThuTren.Text))
                {
                    query += " AND TongTien >= @DoanhThuTren";
                }
                if (!string.IsNullOrEmpty(txtDoanhThuDuoi.Text))
                {
                    query += " AND TongTien <= @DoanhThuDuoi";
                }

                // Set up database connection and command
                using (SqlConnection conn = Database.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                        if (!string.IsNullOrEmpty(txtDoanhThuTren.Text))
                        {
                            cmd.Parameters.AddWithValue("@DoanhThuTren", doanhThuTren);
                        }
                        if (!string.IsNullOrEmpty(txtDoanhThuDuoi.Text))
                        {
                            cmd.Parameters.AddWithValue("@DoanhThuDuoi", doanhThuDuoi);
                        }

                        // Create a DataTable to hold the results
                        DataTable dt = new DataTable();

                        // Use SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            //   conn.Open();
                            adapter.Fill(dt);
                            //   conn.Close();
                        }

                        // Bind the DataTable to the DataGridView
                        DataGridViewBaoCaoDoanhThu.DataSource = dt;

                        // Optional: Customize column headers for better display
                        if (dt.Columns.Contains("SoHDB"))
                            DataGridViewBaoCaoDoanhThu.Columns["SoHDB"].HeaderText = "Số Hóa Đơn";
                        if (dt.Columns.Contains("MaKhach"))
                            DataGridViewBaoCaoDoanhThu.Columns["MaKhach"].HeaderText = "Mã Khách Hàng";
                        if (dt.Columns.Contains("NgayBan"))
                            DataGridViewBaoCaoDoanhThu.Columns["NgayBan"].HeaderText = "Ngày Bán";
                        if (dt.Columns.Contains("TongTien"))
                            DataGridViewBaoCaoDoanhThu.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        if (dt.Columns.Contains("MaNV"))
                            DataGridViewBaoCaoDoanhThu.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

                        // Optional: Format the date and currency columns
                        if (dt.Columns.Contains("NgayBan"))
                            DataGridViewBaoCaoDoanhThu.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        if (dt.Columns.Contains("TongTien"))
                            DataGridViewBaoCaoDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N2"; // Format as currency with 2 decimal places

                        // Calculate and display total revenue
                        decimal tongDoanhThu = 0;
                        if (dt.Rows.Count > 0)
                        {
                            tongDoanhThu = dt.AsEnumerable()
                                             .Sum(row => row.Field<decimal?>("TongTien") ?? 0);
                        }
                        lbTongdoanhthu.Text = $"Tổng doanh thu: {tongDoanhThu:N2} VND";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // hiển thị thông tin vừa tìm kiếm lên chart theo tên nhân viên
            try
            {
                // Clear existing series
                chartBaoCaoDoanhThu.Series.Clear();
                // Create a new series for the chart
                Series series = new Series("Doanh Thu");
                series.ChartType = SeriesChartType.Column; // Set chart type to column
                // Add data points to the series
                foreach (DataRow row in ((DataTable)DataGridViewBaoCaoDoanhThu.DataSource).Rows)
                {
                    string maNV = row["MaNV"].ToString();
                    decimal tongTien = Convert.ToDecimal(row["TongTien"]);
                    series.Points.AddXY(maNV, tongTien);
                }
                // Add the series to the chart
                chartBaoCaoDoanhThu.Series.Add(series);
                // Set chart title and labels
                chartBaoCaoDoanhThu.Titles.Clear();
                chartBaoCaoDoanhThu.Titles.Add("Báo cáo doanh thu theo nhân viên");
                chartBaoCaoDoanhThu.ChartAreas[0].AxisX.Title = "Mã Nhân Viên";
                chartBaoCaoDoanhThu.ChartAreas[0].AxisY.Title = "Tổng Doanh Thu (VND)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            // xuất dữ liệu từ DataGridView ra file Excel
            try
            {
                if (DataGridViewBaoCaoDoanhThu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Tạo một ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true; // hiện cửa sổ Excel
                // Tạo một workbook mới
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                // Xuất tiêu đề cột
                for (int i = 0; i < DataGridViewBaoCaoDoanhThu.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = DataGridViewBaoCaoDoanhThu.Columns[i].HeaderText;
                }
                // Xuất dữ liệu từ DataGridView, định dạng đúng ngày để xuất ra cho đúng
                worksheet.Columns["C"].NumberFormat = "dd/mm/yyyy"; // Giả sử cột Ngày Bán là cột C
                for (int i = 0; i < DataGridViewBaoCaoDoanhThu.Rows.Count; i++)
                {
                    for (int j = 0; j < DataGridViewBaoCaoDoanhThu.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = DataGridViewBaoCaoDoanhThu.Rows[i].Cells[j].Value;
                    }
                }
                // Hiển thị hộp thoại lưu tệp
                // SaveFileDialog saveFileDialog = new SaveFileDialog();
                //  saveFileDialog.Filter = "Excel Files|*.xlsx";
                //  saveFileDialog.Title = "Lưu báo cáo doanh thu";
                //  if (saveFileDialog.ShowDialog() == DialogResult.OK)
                //  {
                //      workbook.SaveAs(saveFileDialog.FileName);
                //      MessageBox.Show("Đã xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  }
                // Đóng workbook và ứng dụng Excel
                //  workbook.Close(false);
                //  excelApp.Quit();
                //  }
                //   catch (Exception ex)
                //   {
                //      MessageBox.Show($"Đã xảy ra lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  }
                // Không cần lưu file, chỉ cần hiện Excel cho người dùng xem
                MessageBox.Show("Đã xuất dữ liệu ra Excel, vui lòng xem trên màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }

