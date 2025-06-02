using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.DAO
{
    public class TaiKhoanDAO
    {
        public static string CheckLogin(string username, string password)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "SELECT Role FROM TaiKhoan WHERE Username = @user AND PasswordHash = @pass AND TrangThai = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                conn.Open();
                object role = cmd.ExecuteScalar();
                return role?.ToString();
            }
        }
        

        public static bool Exist(string username)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private string GetNextMaNV()
        {
            ;
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, LEN(MaNV)) AS INT)), 0) + 1 
                        FROM TaiKhoan WHERE MaNV LIKE 'NV%'";

                SqlCommand cmd = new SqlCommand(query, conn);
                int nextNumber = (int)cmd.ExecuteScalar();

                return $"NV{nextNumber:D2}"; // NV01
            }
        }

        

        public static void AddNewAccount(string username, string password, string role = "Staff")
        {
            {
                try
                {

                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    string maNV = taiKhoanDAO.GetNextMaNV();
                   

                    string sql = "INSERT INTO TaiKhoan (MaNV, Username, PassWordHash, Role) VALUES (@MaNV, @TenDangNhap, @MatKhau, @Role)";
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@TenDangNhap", username);
                        cmd.Parameters.AddWithValue("@MatKhau",password);
                        cmd.Parameters.AddWithValue("@Role", "Staff");
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Thêm tài khoản thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public static DataTable LoadData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TaiKhoan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
