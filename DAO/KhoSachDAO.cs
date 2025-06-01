using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class KhoSachDAO
    {
        public static DataTable LoadData()
        {
            string query = @"
                SELECT 
                    s.MaSach,
                    s.TenSach,
                    s.SoLuong,
                    s.DonGiaNhap,
                    s.DonGiaBan,
                    l.MaLoai,
                    l.TenLoai,
                    tg.MaTG,
                    tg.TenTG,
                    nxb.MaNXB,
                    nxb.TenNXB,
                    lv.MaLinhVuc,
                    lv.TenLinhVuc,
                    nn.MaNgonNgu,
                    nn.TenNgonNgu,
                    s.SoTrang,
                    s.Anh
                FROM KhoSach s
                LEFT JOIN LoaiSach l ON s.MaLoai = l.MaLoai
                LEFT JOIN TacGia tg ON s.MaTG = tg.MaTG
                LEFT JOIN NXB nxb ON s.MaNXB = nxb.MaNXB
                LEFT JOIN LinhVuc lv ON s.MaLinhVuc = lv.MaLinhVuc
                LEFT JOIN NgonNgu nn ON s.MaNgonNgu = nn.MaNgonNgu
                ORDER BY s.MaSach";

            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetLoaiSach()
        {
            string query = "SELECT MaLoai, TenLoai FROM LoaiSach ORDER BY TenLoai";
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetTacGia()
        {
            string query = "SELECT MaTG, TenTG FROM TacGia ORDER BY TenTG";
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetNXB()
        {
            string query = "SELECT MaNXB, TenNXB FROM NXB ORDER BY TenNXB";
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetLinhVuc()
        {
            string query = "SELECT MaLinhVuc, TenLinhVuc FROM LinhVuc ORDER BY TenLinhVuc";
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetNgonNgu()
        {
            string query = "SELECT MaNgonNgu, TenNgonNgu FROM NgonNgu ORDER BY TenNgonNgu";
            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static void Insert(string maSach, string tenSach, int soLuong,
                            decimal donGiaNhap, decimal donGiaBan,
                            string maLoai, string maTG, string maNXB,
                            string maLV, string maNN, int soTrang,
                            string hinhAnh)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO KhoSach 
                         (MaSach, TenSach, SoLuong, DonGiaNhap, DonGiaBan,
                          MaLoai, MaTG, MaNXB, MaLinhVuc, MaNgonNgu, SoTrang, Anh)
                         VALUES 
                         (@MaSach, @TenSach, @SoLuong, @DonGiaNhap, @DonGiaBan,
                          @MaLoai, @MaTG, @MaNXB, @MaLV, @MaNN, @SoTrang, @Anh)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    cmd.Parameters.AddWithValue("@TenSach", tenSach);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                    cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaTG", maTG ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNXB", maNXB ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaLV", maLV ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNN", maNN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                    cmd.Parameters.AddWithValue("@Anh", hinhAnh ?? (object)DBNull.Value);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(string maSach, string tenSach, int soLuong, decimal donGiaNhap, decimal donGiaBan,
            string maLoai, string maTG, string maNXB, string maLV, string maNN, int soTrang, string hinhAnh)
        {
            string query = @"UPDATE KhoSach SET 
                TenSach=@TenSach, 
                SoLuong=@SoLuong, 
                DonGiaNhap=@DonGiaNhap, 
                DonGiaBan=@DonGiaBan,
                MaLoai=@MaLoai, 
                MaTG=@MaTG, 
                MaNXB=@MaNXB, 
                MaLinhVuc=@MaLinhVuc, 
                MaNgonNgu=@MaNgonNgu, 
                SoTrang=@SoTrang, 
                Anh=@Anh
             WHERE MaSach=@MaSach";

            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    cmd.Parameters.AddWithValue("@TenSach", tenSach);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                    cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaTG", maTG ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNXB", maNXB ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaLinhVuc", maLV ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNgonNgu", maNN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                    cmd.Parameters.AddWithValue("@Anh", hinhAnh ?? (object)DBNull.Value);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool CheckMaSachTonTai(string maSach)
        {
            string sql = "SELECT COUNT(*) FROM KhoSach WHERE MaSach = @MaSach";
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Kiểm tra số lượng tồn kho
        public static int GetSoLuongTonKho(string maSach)
        {
            string sql = "SELECT SoLuong FROM KhoSach WHERE MaSach = @MaSach";
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? (int)result : 0;
                }
            }
        }

        // Kiểm tra số lượng có đủ để bán không
        public static bool CheckSoLuongDuDeBan(string maSach, int soLuongBan)
        {
            int soLuongTon = GetSoLuongTonKho(maSach);
            return soLuongTon >= soLuongBan;
        }

        public static void Delete(string maSach)
        {
            string query = "DELETE FROM KhoSach WHERE MaSach=@MaSach";
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable Search(string maSach, string tenSach, string maLoai, string maTG, string maNXB)
        {
            var query = new StringBuilder(@"
                SELECT 
                    s.MaSach,
                    s.TenSach,
                    s.SoLuong,
                    s.DonGiaNhap,
                    s.DonGiaBan,
                    l.MaLoai,
                    l.TenLoai,
                    tg.MaTG,
                    tg.TenTG,
                    nxb.MaNXB,
                    nxb.TenNXB,
                    lv.MaLinhVuc,
                    lv.TenLinhVuc,
                    nn.MaNgonNgu,
                    nn.TenNgonNgu,
                    s.SoTrang,
                    s.Anh
                FROM KhoSach s
                LEFT JOIN LoaiSach l ON s.MaLoai = l.MaLoai
                LEFT JOIN TacGia tg ON s.MaTG = tg.MaTG
                LEFT JOIN NXB nxb ON s.MaNXB = nxb.MaNXB
                LEFT JOIN LinhVuc lv ON s.MaLinhVuc = lv.MaLinhVuc
                LEFT JOIN NgonNgu nn ON s.MaNgonNgu = nn.MaNgonNgu
                WHERE 1=1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maSach))
            {
                query.Append(" AND s.MaSach LIKE @MaSach");
                parameters.Add(new SqlParameter("@MaSach", "%" + maSach + "%"));
            }
            if (!string.IsNullOrEmpty(tenSach))
            {
                query.Append(" AND s.TenSach LIKE @TenSach");
                parameters.Add(new SqlParameter("@TenSach", "%" + tenSach + "%"));
            }
            if (!string.IsNullOrEmpty(maLoai))
            {
                query.Append(" AND s.MaLoai = @MaLoai");
                parameters.Add(new SqlParameter("@MaLoai", maLoai));
            }
            if (!string.IsNullOrEmpty(maTG))
            {
                query.Append(" AND s.MaTG = @MaTG");
                parameters.Add(new SqlParameter("@MaTG", maTG));
            }
            if (!string.IsNullOrEmpty(maNXB))
            {
                query.Append(" AND s.MaNXB = @MaNXB");
                parameters.Add(new SqlParameter("@MaNXB", maNXB));
            }

            query.Append(" ORDER BY s.MaSach");

            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query.ToString(), conn);
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Khi nhập hàng - Cập nhật tồn kho và giá
        public static bool CapNhatNhapHang(string maSach, int soLuongNhap, decimal donGiaNhap)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    // Tính giá bán = giá nhập * 1.1 (110%)
                    decimal donGiaBan = donGiaNhap * 1.1m;

                    string query = @"
                        UPDATE KhoSach
                        SET 
                            SoLuong = SoLuong + @SoLuongNhap,
                            DonGiaNhap = @DonGiaNhap,
                            DonGiaBan = @DonGiaBan
                        WHERE MaSach = @MaSach";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                        cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                        cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                        cmd.Parameters.AddWithValue("@MaSach", maSach);

                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhập hàng: {ex.Message}");
            }
        }

        // Khi bán hàng - Giảm tồn kho
        public static bool CapNhatBanHang(string maSach, int soLuongBan)
        {
            try
            {
                // Kiểm tra số lượng tồn kho trước khi bán
                if (!CheckSoLuongDuDeBan(maSach, soLuongBan))
                {
                    throw new Exception("Số lượng tồn kho không đủ để bán!");
                }

                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = @"
                UPDATE KhoSach
                SET SoLuong = SoLuong - @SoLuongBan
                WHERE MaSach = @MaSach";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                        cmd.Parameters.AddWithValue("@MaSach", maSach);

                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật bán hàng: {ex.Message}");
            }
        }

        // Lấy thông tin sách theo mã
        public static DataRow GetSachByMa(string maSach)
        {
            string query = @"
            SELECT 
                s.MaSach,
                s.TenSach,
                s.SoLuong,
                s.DonGiaNhap,
                s.DonGiaBan,
                l.MaLoai,
                l.TenLoai,
                tg.MaTG,
                tg.TenTG,
                nxb.MaNXB,
                nxb.TenNXB,
                lv.MaLinhVuc,
                lv.TenLinhVuc,
                nn.MaNgonNgu,
                nn.TenNgonNgu,
                s.SoTrang,
                s.Anh
            FROM KhoSach s
            LEFT JOIN LoaiSach l ON s.MaLoai = l.MaLoai
            LEFT JOIN TacGia tg ON s.MaTG = tg.MaTG
            LEFT JOIN NXB nxb ON s.MaNXB = nxb.MaNXB
            LEFT JOIN LinhVuc lv ON s.MaLinhVuc = lv.MaLinhVuc
            LEFT JOIN NgonNgu nn ON s.MaNgonNgu = nn.MaNgonNgu
            WHERE s.MaSach = @MaSach";

            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaSach", maSach);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                return null;
            }
        }

        // Lấy danh sách sách sắp hết (số lượng < 10)
        public static DataTable GetSachSapHet(int minQuantity = 10)
        {
          string query = @"
            SELECT 
                s.MaSach,
                s.TenSach,
                s.SoLuong,
                s.DonGiaNhap,
                s.DonGiaBan,
                l.TenLoai,
                tg.TenTG,
                nxb.TenNXB
            FROM KhoSach s
            LEFT JOIN LoaiSach l ON s.MaLoai = l.MaLoai
            LEFT JOIN TacGia tg ON s.MaTG = tg.MaTG
            LEFT JOIN NXB nxb ON s.MaNXB = nxb.MaNXB
            WHERE s.SoLuong < @MinQuantity AND s.SoLuong >= 0
            ORDER BY s.SoLuong ASC, s.TenSach";

            using (SqlConnection conn = Database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MinQuantity", minQuantity);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}