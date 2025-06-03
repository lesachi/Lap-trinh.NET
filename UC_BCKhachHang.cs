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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace BookStore
{
    public partial class UC_BCKhachHang : UserControl
    {
        public UC_BCKhachHang()
        {
            InitializeComponent();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            string tempExcelFilePath = string.Empty;
            try
            {
                excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Không thể khởi tạo ứng dụng Excel...", "Lỗi Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "KhachHangThanThiet";
                // --- BEGIN: Thêm thông tin cửa hàng và báo cáo ---
                int currentRow = 1;
                int numberOfColumnsToMerge = dataKHTT.Columns.Count > 0 ? dataKHTT.Columns.Count : 5; // Giả sử báo cáo KH có 5 cột
                string tenCuaHang = "Cửa Hàng sách";
                string diaChi = "12 Chùa Bộc, Hà Nội";
                string dienThoai = "0888450813";
                Excel.Range currentRange;
                worksheet.Cells[currentRow, 1].Value = tenCuaHang;
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 1].Font.Size = 14;
                currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow++;
                worksheet.Cells[currentRow, 1].Value = "Địa chỉ: " + diaChi;
                currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRow++;
                worksheet.Cells[currentRow, 1].Value = "Điện thoại: " + dienThoai;
                currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRow++;
                currentRow++;
                string reportTitle = "BÁO CÁO KHÁCH HÀNG THÂN THIẾT";
                worksheet.Cells[currentRow, 1].Value = reportTitle;
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 1].Font.Size = 16;
                currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow++;
                // dtpStartDate, dtpEndDate là tên DateTimePicker của bạn
                string dateRangeInfo = $"Từ ngày: {dateNgay1.Value:dd/MM/yyyy} Đến ngày: {dateNgay2.Value:dd/MM/yyyy}";
                worksheet.Cells[currentRow, 1].Value = dateRangeInfo;
                currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow++;
                // txtSoLanMua, txtTongHoaDon là tên TextBox filter
                string soLanMuaFilterInfo = txtSoLanMua.Text.Trim();
                if (!string.IsNullOrEmpty(soLanMuaFilterInfo))
                {
                    worksheet.Cells[currentRow, 1].Value = $"Điều kiện số lần mua: {soLanMuaFilterInfo}";
                    currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRow++;

                    string tongHoaDonFilterInfo = txtTongChi.Text.Trim();
                    if (!string.IsNullOrEmpty(tongHoaDonFilterInfo))
                    {
                        worksheet.Cells[currentRow, 1].Value = $"Điều kiện tổng hóa đơn: {tongHoaDonFilterInfo}";
                        currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRow++;
                    }
                    string exportDateInfo = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    worksheet.Cells[currentRow, 1].Value = exportDateInfo;
                    currentRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, numberOfColumnsToMerge]]; currentRange.Merge(); currentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight; currentRow++;
                    currentRow++;
                    // --- END: Thêm thông tin ---
                    if (dataKHTT.Columns.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (workbook != null) { workbook.Close(false); }
                        return;
                    }
                    // (Ghi tiêu đề và dữ liệu từ dataGridView1 tương tự như hàm trên)
                    for (int i = 0; i < dataKHTT.Columns.Count; i++) { /* ... */ Excel.Range cell = worksheet.Cells[currentRow, i + 1]; cell.Value = dataKHTT.Columns[i].HeaderText; cell.Font.Bold = true; cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray); cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; }
                    for (int i = 0; i < dataKHTT.Rows.Count; i++) { if (dataKHTT.Rows[i].IsNewRow) continue; for (int j = 0; j < dataKHTT.Columns.Count; j++) { /* ... */ var value = dataKHTT.Rows[i].Cells[j].Value; Excel.Range currentCell = worksheet.Cells[i + currentRow + 1, j + 1]; if (value is float || value is double || value is decimal || value is int) { currentCell.NumberFormat = "#,##0"; currentCell.Value = value; } else if (value is DateTime dateValue) { currentCell.NumberFormat = "dd/MM/yyyy"; currentCell.Value = dateValue; } else if (DateTime.TryParse(value?.ToString(), out DateTime parsedDate)) { currentCell.NumberFormat = "dd/MM/yyyy"; currentCell.Value = parsedDate; } else { currentCell.Value = value?.ToString(); } currentCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; } }
                    worksheet.Columns.AutoFit();
                    // --- Bước 1: Lưu vào file tạm ---
                    tempExcelFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "_KhachHangPreview.xlsx");
                    workbook.SaveAs(tempExcelFilePath);
                    // --- Quan trọng: Đóng và giải phóng COM object TRƯỚC KHI mở preview ---
                    if (worksheet != null) { Marshal.ReleaseComObject(worksheet); worksheet = null; }
                    if (workbook != null) { workbook.Close(false); Marshal.ReleaseComObject(workbook); workbook = null; }
                    if (excelApp != null) { excelApp.Quit(); Marshal.ReleaseComObject(excelApp); excelApp = null; }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    // --- Bước 2: Mở file tạm để xem trước ---
                    DialogResult userAction = DialogResult.Cancel;
                    Process excelProcess = null;
                    try
                    {
                        excelProcess = Process.Start(tempExcelFilePath);
                        userAction = MessageBox.Show(
                            "Báo cáo Khách Hàng Thân Thiết đã được mở để xem trước.\n\nBạn có muốn LƯU file này không?",
                            "Xác Nhận Lưu File Excel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    }
                    // ... (Phần catch và xử lý userAction, SaveFileDialog, File.Copy như hàm trên) ...
                    catch (Exception exPreview)
                    {
                        MessageBox.Show("Không thể mở bản xem trước Excel: " + exPreview.Message +
                                        "\n\nBạn vẫn có thể chọn để lưu file.", "Lỗi Xem Trước", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        userAction = MessageBox.Show(
                            "Không thể mở xem trước. Bạn có muốn tiếp tục lưu file Excel này không?",
                            "Xác Nhận Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    if (userAction == DialogResult.Yes)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Excel files (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls",
                            Title = "Chọn nơi lưu file Báo Cáo Khách Hàng",
                            FileName = "BaoCaoKhachHangThanThiet.xlsx" // Tên file mặc định
                        };
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // (Copy logic File.Copy, MessageBox, Process.Start như hàm trên)
                            try
                            {
                                if (excelProcess != null && !excelProcess.HasExited)
                                {
                                    try { excelProcess.CloseMainWindow(); excelProcess.WaitForExit(1000); } catch { /* ignore */ }
                                }
                                File.Copy(tempExcelFilePath, saveFileDialog.FileName, true);
                                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                try { Process.Start(saveFileDialog.FileName); }
                                catch (Exception exOpenFinal) { MessageBox.Show("Không thể mở file Excel đã lưu: " + exOpenFinal.Message, "Lỗi Mở File", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            }
                            catch (IOException ioEx) { MessageBox.Show($"Lỗi khi lưu file Excel: {ioEx.Message}\nVui lòng đóng file Excel xem trước (nếu đang mở) và thử lại.", "Lỗi Lưu File", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            catch (Exception exSaveFinal) { MessageBox.Show("Lỗi khi lưu file Excel cuối cùng: " + exSaveFinal.Message, "Lỗi Lưu File", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else { MessageBox.Show("Thao tác lưu file Excel đã được hủy.", "Đã hủy", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else { MessageBox.Show("Thao tác xuất file Excel đã được hủy.", "Đã hủy", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel (Khách hàng): " + ex.ToString(), "Lỗi Xuất File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                ReleaseComObject(worksheet);
                ReleaseComObject(workbook);
                ReleaseComObject(excelApp);

                if (!string.IsNullOrEmpty(tempExcelFilePath) && File.Exists(tempExcelFilePath))
                {
                    try { File.Delete(tempExcelFilePath); }
                    catch (IOException ioExDel) { Console.WriteLine($"Lỗi khi xóa file Excel tạm ({tempExcelFilePath}): {ioExDel.Message}."); }
                    catch (Exception exDeleteTemp) { Console.WriteLine("Lỗi không xác định khi xóa file Excel tạm: " + exDeleteTemp.Message); }
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateNgay1.Value;
            DateTime endDate = dateNgay2.Value;

            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgay2.Focus();
                return;
            }

            try
            {
                DataTable dt = GetLoyalCustomers(startDate, endDate);
                dataKHTT.DataSource = null;

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataKHTT.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có khách hàng nào thỏa điều kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public DataTable GetLoyalCustomers(DateTime startDate, DateTime endDate)
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"
                SELECT KH.MaKhach, KH.TenKhach, 
                       COUNT(HD.SoHDB) AS SoLanMua,
                       SUM(HD.TongTien) AS TongChi
                FROM KhachHang KH
                JOIN HoaDonBan HD ON KH.MaKhach = HD.MaKhach
                WHERE HD.NgayBan BETWEEN @startDate AND @endDate
                GROUP BY KH.MaKhach, KH.TenKhach
                HAVING COUNT(HD.SoHDB) = (
                    SELECT MAX(SoLanMua)
                    FROM (
                        SELECT COUNT(HD1.SoHDB) AS SoLanMua
                        FROM KhachHang KH1
                        JOIN HoaDonBan HD1 ON KH1.MaKhach = HD1.MaKhach
                        WHERE HD1.NgayBan BETWEEN @startDate AND @endDate
                        GROUP BY KH1.MaKhach
                    ) AS Sub
                    )
                    ORDER BY TongChi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    
    private void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null && Marshal.IsComObject(obj))
                {
                    Marshal.ReleaseComObject(obj);
                }
            }
            catch
            {
                // Bỏ qua lỗi khi giải phóng COM object
            }
        }

        private void txtSoLanMua_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataKHTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataKHTT.Rows[e.RowIndex];
                txtSoLanMua.Text = row.Cells["SoLanMua"].Value.ToString();
                txtTongChi.Text = row.Cells["TongChi"].Value.ToString();
            }
        }
    }
}
