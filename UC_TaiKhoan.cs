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
using BookStore.DAO;

namespace BookStore
{
    public partial class UC_TaiKhoan: UserControl
    {
        public UC_TaiKhoan()
        {
            InitializeComponent();
            dtGVTaikhoan.DataSource = TaiKhoanDAO.LoadData();

        }
    }
}
