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
    tg.MaTG,
    nxb.MaNXB,
    lv.MaLinhVuc,
    nn.MaNgonNgu,
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

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                cmd.Parameters.AddWithValue("@TenSach", tenSach);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                cmd.Parameters.AddWithValue("@MaTG", maTG);
                cmd.Parameters.AddWithValue("@MaNXB", maNXB);
                cmd.Parameters.AddWithValue("@MaLV", maLV);
                cmd.Parameters.AddWithValue("@MaNN", maNN);
                cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                cmd.Parameters.AddWithValue("@Anh", hinhAnh);

                cmd.ExecuteNonQuery();
            }
        }


        public static void Update(string maSach, string tenSach, int soLuong, decimal donGiaNhap, decimal donGiaBan,
     string maLoai, string maTG, string maNXB, string maLV, string maNN, int soTrang, string hinhAnh)
        {
            string query = @"UPDATE KhoSach SET TenSach=@TenSach, SoLuong=@SoLuong, DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan,
             MaLoai=@MaLoai, MaTG=@MaTG, MaNXB=@MaNXB, MaLinhVuc=@MaLinhVuc, MaNgonNgu=@MaNgonNgu, SoTrang=@SoTrang, Anh=@Anh
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
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    cmd.Parameters.AddWithValue("@MaTG", maTG);
                    cmd.Parameters.AddWithValue("@MaNXB", maNXB);
                    cmd.Parameters.AddWithValue("@MaLinhVuc", maLV);
                    cmd.Parameters.AddWithValue("@MaNgonNgu", maNN);
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
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                //onn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
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
            var query = new StringBuilder("SELECT * FROM KhoSach WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maSach))
            {
                query.Append(" AND MaSach LIKE @MaSach");
                parameters.Add(new SqlParameter("@MaSach", "%" + maSach + "%"));
            }
            if (!string.IsNullOrEmpty(tenSach))
            {
                query.Append(" AND TenSach LIKE @TenSach");
                parameters.Add(new SqlParameter("@TenSach", "%" + tenSach + "%"));
            }
            if (!string.IsNullOrEmpty(maLoai))
            {
                query.Append(" AND MaLoai = @MaLoai");
                parameters.Add(new SqlParameter("@MaLoai", maLoai));
            }
            if (!string.IsNullOrEmpty(maTG))
            {
                query.Append(" AND MaTG = @MaTG");
                parameters.Add(new SqlParameter("@MaTG", maTG));
            }
            if (!string.IsNullOrEmpty(maNXB))
            {
                query.Append(" AND MaNXB = @MaNXB");
                parameters.Add(new SqlParameter("@MaNXB", maNXB));
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query.ToString(), conn);
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }



    }
}
