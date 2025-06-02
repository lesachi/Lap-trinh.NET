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
    public partial class UC_NhaCungCap : UserControl
    {
        public UC_NhaCungCap()
        {
            InitializeComponent();
        }

        private void UC_NhaCungCap_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
            LoadDataToGridView();
        }
        private void LoadDataToGridView()
        {
            string sql = "Select * from NhaCungCap";
            DataTable dt = new DataTable();

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.Fill(dt);
            }

            DataGridView1.DataSource = dt;
            DataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            DataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            DataGridView1.Columns[2].HeaderText = "Địa chỉ";
            DataGridView1.Columns[3].HeaderText = "Điện thoại";

            DataGridView1.Columns[0].Width = 80;
            DataGridView1.Columns[1].Width = 180;
            DataGridView1.Columns[2].Width = 120;
            DataGridView1.Columns[3].Width = 100;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Rows.Count > 0)
            {
                txtMaNCC.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenNCC.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDiachi.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDienthoai.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }
        private void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            txtMaNCC.Text = SinhMaNCC();
            txtMaNCC.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            string TenNCC = txtTenNCC.Text;
            string DiaChi = txtDiachi.Text;
            string SDT = txtDienthoai.Text;

            /*if (MaNCC == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp!");
                txtMaNCC.Focus();
                return;
            }*/
            if (TenNCC == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp!");
                txtTenNCC.Focus();
                return;
            }
            if (DiaChi == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtDiachi.Focus();
                return;
            }
            if (SDT == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
                txtDienthoai.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(SDT, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                txtDienthoai.Focus();
                return;
            }

            string sqlCheck = "Select * from NhaCungCap where MaNCC = N'" + MaNCC + "'";
            if (!Database.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO NhaCungCap VALUES (N'" + MaNCC +
             "', N'" + TenNCC +
             "', N'" + DiaChi +
             "', N'" + SDT + "')";

                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); return;
                }
                LoadDataToGridView();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp bị trùng"); return;
            }
            txtMaNCC.ReadOnly = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            string TenNCC = txtTenNCC.Text;
            string DiaChi = txtDiachi.Text;
            string SDT = txtDienthoai.Text;
            string oldMaNCC = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MaNCC != oldMaNCC)
            {
                MessageBox.Show("Không được sửa mã nhà cung cấp!");
                txtMaNCC.Text = oldMaNCC;
                return;
            }
            if (TenNCC == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp!");
                txtTenNCC.Focus();
                return;
            }
            if (DiaChi == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ");
                txtDiachi.Focus();
                return;
            }
            if (SDT == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại");
                txtDiachi.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(SDT, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                txtDienthoai.Focus();
                return;
            }

            string sql = "UPDATE NhaCungCap SET " +
             "TenNCC = N'" + TenNCC + "', " +
             "DiaChi = N'" + DiaChi + "', " +
             "DienThoai = N'" + SDT + "' " +
             "WHERE MaNCC = N'" + DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private string SinhMaNCC()
        {
            string sql = "SELECT TOP 1 MaNCC FROM NhaCungCap ORDER BY MaNCC DESC";
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastMa = result.ToString(); // ví dụ: "NCC009"
                    int number = int.Parse(lastMa.Substring(3)); // lấy "009" -> 9
                    return "NCC" + (number + 1).ToString("D3"); // thành "NCC010"
                }
                else
                {
                    return "NCC001"; // chưa có nhà cung cấp nào
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Không có bản ghi nào");
                return;
            }

            string MaNCC = DataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Bạn muốn xóa nhà cung cấp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM NhaCungCap WHERE MaNCC = N'" + MaNCC + "'";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
       
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Parent.Controls.Remove(this);
            }
        }
    }
    
}