using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Database
    {
        private static string conn = "Data source=DESKTOP-K2HPB48\\SQLEXPRESS01;Initial Catalog=Qlycuahangsach;Integrated Security=True";

        public static SqlConnection GetConnection() => new SqlConnection(Database.conn);
    }
}
