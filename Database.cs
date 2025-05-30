using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Database
    {
        private static string conn = "Data source=DESKTOP-K2HPB48\\SQLEXPRESS01;Initial Catalog=QlyCuaHangSach;Integrated Security=True";
        
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
    }
}
