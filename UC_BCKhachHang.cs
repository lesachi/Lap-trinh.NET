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

namespace BookStore
{
    public partial class UC_BCKhachHang: UserControl
    {
        public UC_BCKhachHang()
        {
            InitializeComponent();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateNgay1.Value;
            DateTime endDate = dateNgay2.Value;
            int minSoLanMua;
            decimal minTongChi;

            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgay2.Focus();
                return;
            }
            if (!int.TryParse(txtSoLanMua.Text, out minSoLanMua) || minSoLanMua < 0)
            {
                MessageBox.Show("Số lần mua phải là một số nguyên không âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLanMua.Focus();
                return;
            }
            if (!decimal.TryParse(txtTongChi.Text, out minTongChi) || minTongChi < 0)
            {
                MessageBox.Show("Tổng hóa đơn phải là một số không âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongChi.Focus();
                return;
            }

            try
            {
                DataTable dt = GetLoyalCustomers(startDate, endDate, minSoLanMua, minTongChi);
                dataKHTT.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataKHTT.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào thỏa mãn điều kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public DataTable GetLoyalCustomers(DateTime startDate, DateTime endDate, int minSoLanMua, decimal minTongChi)
        {
            using (var conn = Database.GetConnection())
            {
                string sql = @"
            SELECT 
                kh.MaKhach, 
                kh.TenKhach, 
                kh.DienThoai, 
                COUNT(DISTINCT hd.SoHDB) AS SoLanMua,
                SUM(hd.TongTien) AS TongTien
            FROM KhachHang kh
            JOIN HoaDonBan hd on kh.MaKhach = hd.MaKhach
            JOIN ChiTietHDB cthdb ON hd.SoHDB = cthdb.SoHDB
            WHERE hd.NgayBan >= @StartDate AND hd.NgayBan <= @EndDate
            GROUP BY kh.MaKhach, kh.TenKhach, kh.DienThoai
            HAVING COUNT(DISTINCT hd.SoHDB) >= @MinSoLanMua
               AND SUM(hd.TongTien) >= @MinTongChi
            ORDER BY TongTien DESC";
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@StartDate", startDate.Date);
                    da.SelectCommand.Parameters.AddWithValue("@EndDate", endDate.Date);
                    da.SelectCommand.Parameters.AddWithValue("@MinSoLanMua", minSoLanMua);
                    da.SelectCommand.Parameters.AddWithValue("@MinTongChi", minTongChi);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




    
}
}
