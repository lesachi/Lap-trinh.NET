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
    public partial class UC_MatSach : UserControl
    {
        private bool isAdding = false;

        public UC_MatSach()
        {
            InitializeComponent();
        }

        private void UC_MatSach_Load(object sender, EventArgs e)
        {
            Database.GetConnection();
            LoadMaSach();
            LoadDataToGridView();
        }
        private void LoadMaSach()
        {
            string sql = "SELECT MaSach FROM KhoSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Database.GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cboMasach.DataSource = dt;
            cboMasach.DisplayMember = "MaSach";
            cboMasach.ValueMember = "MaSach";
        }

        private void LoadDataToGridView()
        {
            string sql = @"
                SELECT m.MaLanMat, m.MaSach, k.TenSach, m.SoLuongMat, m.NgayMat
                FROM MatSach m
                JOIN KhoSach k ON m.MaSach = k.MaSach";

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Database.GetConnection());
            adapter.Fill(dt);
            dataGridViewMatSach.DataSource = dt;

            dataGridViewMatSach.Columns[0].HeaderText = "Mã Lần Mất";
            dataGridViewMatSach.Columns[1].HeaderText = "Mã Sách";
            dataGridViewMatSach.Columns[2].HeaderText = "Tên Sách";
            dataGridViewMatSach.Columns[3].HeaderText = "Số Lượng Mất";
            dataGridViewMatSach.Columns[4].HeaderText = "Ngày Mất";

            dataGridViewMatSach.Columns[0].Width = 80;
            dataGridViewMatSach.Columns[1].Width = 100;
            dataGridViewMatSach.Columns[2].Width = 260;
            dataGridViewMatSach.Columns[3].Width = 80;
            dataGridViewMatSach.Columns[4].Width = 180;
        }

        private void dataGridViewMatSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewMatSach.Rows.Count > 0)
            {
                txtMamat.Text = dataGridViewMatSach.CurrentRow.Cells[0].Value.ToString();
                cboMasach.Text = dataGridViewMatSach.CurrentRow.Cells[1].Value.ToString();
                txtSoluong.Text = dataGridViewMatSach.CurrentRow.Cells[3].Value.ToString();
                dtpNgaymat.Value = Convert.ToDateTime(dataGridViewMatSach.CurrentRow.Cells[4].Value);
            }

        }
        private void ClearFields()
        {
            txtMamat.Clear();
            txtSoluong.Clear();
            dtpNgaymat.Value = DateTime.Today;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtMamat.Text = SinhMaLanMat();
            txtMamat.ReadOnly = true;
            isAdding = true;

        }
        private string SinhMaLanMat()
        {
            string sql = "SELECT TOP 1 MaLanMat FROM MatSach ORDER BY MaLanMat DESC";
            object result = new SqlCommand(sql, Database.GetConnection()).ExecuteScalar();

            if (result != null)
            {
                string last = result.ToString(); // e.g. MS09
                int num = int.Parse(last.Substring(2));
                return "MS" + (num + 1).ToString("D3");
            }
            return "MS01";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearFields();
            isAdding = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maLanMat = txtMamat.Text.Trim();
            string maSach = cboMasach.SelectedValue.ToString();
            string soLuongMat = txtSoluong.Text.Trim();
            string ngayMat = dtpNgaymat.Value.ToString("yyyy-MM-dd");

            if (soLuongMat == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng mất!");
                txtSoluong.Focus();
                return;
            }

            if (isAdding)
            {
                // Chỉ kiểm tra trùng mã khi đang thêm
                string sqlCheck = "SELECT * FROM MatSach WHERE MaLanMat = N'" + maLanMat + "'";
                if (Database.CheckKey(sqlCheck))
                {
                    MessageBox.Show("Mã lần mất bị trùng!");
                    return;
                }

                // Thêm mới
                string sql = "INSERT INTO MatSach VALUES (N'" + maLanMat + "', N'" + maSach + "', '" + ngayMat + "', " + soLuongMat + ")";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    ClearFields();
                    isAdding = false; // reset trạng thái
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Đang ở chế độ sửa → update
                string sql = "UPDATE MatSach SET MaSach = N'" + maSach + "', NgayMat = '" + ngayMat + "', SoLuongMat = " + soLuongMat +
                             " WHERE MaLanMat = N'" + maLanMat + "'";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewMatSach.CurrentRow == null)
            {
                MessageBox.Show("Không có bản ghi nào được chọn!");
                return;
            }

            string maLanMat = dataGridViewMatSach.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM MatSach WHERE MaLanMat = N'" + maLanMat + "'";
                SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMamat.ReadOnly = true;
            if (dataGridViewMatSach.CurrentRow == null)
            {
                MessageBox.Show("Không có bản ghi nào được chọn!");
                return;
            }

            string maLanMat = txtMamat.Text.Trim(); // không cho người dùng sửa
            string maSach = cboMasach.SelectedValue.ToString();
            string soLuongMat = txtSoluong.Text.Trim();
            string ngayMat = dtpNgaymat.Value.ToString("yyyy-MM-dd");

            if (soLuongMat == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng mất!");
                txtSoluong.Focus();
                return;
            }

            string sql = "UPDATE MatSach SET MaSach = N'" + maSach +
                         "', NgayMat = '" + ngayMat +
                         "', SoLuongMat = " + soLuongMat +
                         " WHERE MaLanMat = N'" + maLanMat + "'";

            SqlCommand cmd = new SqlCommand(sql, Database.GetConnection());
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridView();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Parent.Controls.Remove(this);
            }

        }
    }
}
