using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class UC_ChitietNXB : UserControl
    {
        public UC_ChitietNXB(string ma, string ten, string diachi, string dienthoai, Image logo)
        {
            InitializeComponent();
            txtMaNXB.Text = ma;
            txtTenNXB.Text = ten;
            txtDiachi.Text = diachi;
            txtDienthoai.Text = dienthoai;
            pboLogo.Image = logo;

        }

        private void UC_ChitietNXB_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
