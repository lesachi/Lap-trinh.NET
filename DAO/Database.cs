using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookStore
{
    public class Database
    {
        private static string conn = "Data Source=DESKTOP-GGAFB0R;Initial Catalog=QuanLyCuaHangSach;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
            return connection;
            //return new SqlConnection(conn);
        }

        public static bool CheckKey(string sql)
        {
            bool result = false;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
            

        }

        public static void FillDataToCombo(ComboBox cmb, string sql, string value, string display)
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            cmb.DataSource = dt;
            cmb.ValueMember = value;
            cmb.DisplayMember = display;
            
        }
        public static string TaoMaNXBTuDong()
        {
            using (SqlConnection conn = GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "SELECT TOP 1 MaNXB FROM NXB ORDER BY CAST(SUBSTRING(MaNXB, 4, LEN(MaNXB) - 3) AS INT) DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // đảm bảo tự đóng
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string maCuoi = result.ToString(); // ví dụ "NXB015"
                        int so = int.Parse(maCuoi.Substring(3)); // Lấy số
                        return "NXB" + (so + 1).ToString("D3");
                    }
                    else
                    {
                        return "NXB001";
                    }
                }
            }

        }
    }

}
    

 
