﻿using System;
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

       
    }

 }
