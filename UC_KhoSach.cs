using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.DAO;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace BookStore
{
    public partial class UC_KhoSach: UserControl
    {
        public UC_KhoSach()
        {
            InitializeComponent();
            this.Load += UC_KhoSach_Load;
        }

        private string currentImagePath = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtSL.Text) || string.IsNullOrEmpty(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtDGN.Text) || string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(txtDGB.Text)||
                string.IsNullOrWhiteSpace(txtSoTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtSL.Text, out int SoLuong))
            {
                MessageBox.Show("Số lượng phải là số nguyên!");
                return;
            }
            if (!decimal.TryParse(txtDGN.Text, out decimal donGiaNhap))
            {
                MessageBox.Show("Đơn giá nhập phải là số!");
                return;
            }
            if (!decimal.TryParse(txtDGB.Text, out decimal donGiaBan))
            {
                MessageBox.Show("Đơn giá bán phải là số!");
                return;
            }
            if (!int.TryParse(txtSoTrang.Text, out int soTrang))
            {
                MessageBox.Show("Số trang phải là số nguyên!");
                return;
            }
            string maLoai = cbbMaLoai.SelectedValue?.ToString();
            string maTG = cbbMaTG.SelectedValue?.ToString();
            string maNXB = cbbMaNXB.SelectedValue?.ToString();
            string maLV = cbbMaLV.SelectedValue?.ToString();
            string maNN = cbbMaNN.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(maTG) ||
                string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(maLV) || string.IsNullOrEmpty(maNN))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ các mục bắt buộc!");
                return;
            }

            try
            {
                KhoSachDAO.Update(
                    txtMaSach.Text.Trim(),
                    txtTenSach.Text.Trim(),
                    SoLuong,
                    donGiaNhap,
                    donGiaBan,
                    maLoai,
                    maTG,
                    maNXB,
                    maLV,
                    maNN,
                    soTrang,
                    currentImagePath
                );
                MessageBox.Show("Sửa thành công!");
                LoadDataToGridView();
                button2_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sách: " + ex.Message);
            }


        }



        private void UC_KhoSach_Load(object sender, EventArgs e)
        {
          LoadDataToGridView();
          LoadComboBoxes();
            // Reset ComboBox
            ResetComboBoxes();
        }

        private void ResetComboBoxes()
        {
            cbbMaLoai.SelectedIndex = -1;
            cbbMaTG.SelectedIndex = -1;
            cbbMaNXB.SelectedIndex = -1;
            cbbMaLV.SelectedIndex = -1;
            cbbMaNN.SelectedIndex = -1;
        }

        private void LoadDataToGridView()
        {
       
            try
            { 
                DataTable dataTable = KhoSachDAO.LoadData();
                dtGVKhoSach.DataSource = dataTable;
                // Định dạng header cột
                dtGVKhoSach.Columns["MaSach"].HeaderText = "Mã sách";
                dtGVKhoSach.Columns["TenSach"].HeaderText = "Tên sách";
                dtGVKhoSach.Columns["SoLuong"].HeaderText = "Số lượng";
                dtGVKhoSach.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
                dtGVKhoSach.Columns["DonGiaBan"].HeaderText = "Đơn giá bán";
                dtGVKhoSach.Columns["MaLoai"].HeaderText = "Loại sách";
                dtGVKhoSach.Columns["MaTG"].HeaderText = "Tác giả";
                dtGVKhoSach.Columns["MaNXB"].HeaderText = "NXB";
                dtGVKhoSach.Columns["MaLinhVuc"].HeaderText = "Lĩnh vực";
                dtGVKhoSach.Columns["MaNgonNgu"].HeaderText = "Ngôn ngữ";
                dtGVKhoSach.Columns["SoTrang"].HeaderText = "Số trang";
                dtGVKhoSach.Columns["Anh"].HeaderText = "Ảnh";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {

                cbbMaLoai.DataSource = KhoSachDAO.GetLoaiSach();
                cbbMaLoai.DisplayMember = "TenLoai";
                cbbMaLoai.ValueMember = "MaLoai";

                cbbMaTG.DataSource = KhoSachDAO.GetTacGia();
                cbbMaTG.DisplayMember = "TenTG";
                cbbMaTG.ValueMember = "MaTG";

                cbbMaNXB.DataSource = KhoSachDAO.GetNXB();
                cbbMaNXB.DisplayMember = "TenNXB";
                cbbMaNXB.ValueMember = "MaNXB";

                cbbMaLV.DataSource = KhoSachDAO.GetLinhVuc();
                cbbMaLV.DisplayMember = "TenLinhVuc";
                cbbMaLV.ValueMember = "MaLinhVuc";

                cbbMaNN.DataSource = KhoSachDAO.GetNgonNgu();
                cbbMaNN.DisplayMember = "TenNgonNgu";
                cbbMaNN.ValueMember = "MaNgonNgu";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ComboBox: " + ex.Message);
            }
        }
        private void dtGVKhoSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtGVKhoSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                txtSL.Text = row.Cells["SoLuong"].Value.ToString();
                txtDGN.Text = row.Cells["DonGiaBan"].Value.ToString();
                txtDGB.Text = row.Cells["DonGiaNhap"].Value.ToString();
                txtSoTrang.Text = row.Cells["SoTrang"].Value.ToString();

                cbbMaLoai.SelectedValue = row.Cells["MaLoai"].Value.ToString();
                cbbMaTG.SelectedValue = row.Cells["MaTG"].Value.ToString();
                cbbMaNXB.SelectedValue = row.Cells["MaNXB"].Value.ToString();
                cbbMaLV.SelectedValue = row.Cells["MaLinhVuc"].Value.ToString();
                cbbMaNN.SelectedValue = row.Cells["MaNgonNgu"].Value.ToString();


                string imagePath = dtGVKhoSach.Rows[e.RowIndex].Cells["Anh"].Value?.ToString();
                currentImagePath = imagePath; 

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    picAnh.Image = Image.FromFile(imagePath);
                    picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picAnh.Image = null;
                }
                txtMaSach.ReadOnly = true;
            }
            
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trên form
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSL.Clear();
            txtDGN.Clear();
            txtDGB.Clear();
            txtSoTrang.Clear();
            picAnh.Image = null;
            currentImagePath = ""; 
            ResetComboBoxes();
            txtMaSach.ReadOnly = false;


            // Bỏ chọn trong DataGridView
            dtGVKhoSach.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trên form
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSL.Clear();
            txtDGN.Clear();
            txtDGB.Clear();
            txtSoTrang.Clear();
            picAnh.Image = null;
            currentImagePath = "";
            ResetComboBoxes();
            txtMaSach.ReadOnly = false;

            // Bỏ chọn trong DataGridView
            dtGVKhoSach.ClearSelection();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMaSach.ReadOnly = false;
            // Lấy dữ liệu từ các control
            string maSach = txtMaSach.Text.Trim();
            string tenSach = txtTenSach.Text.Trim();
            string maLoai = cbbMaLoai.SelectedValue?.ToString();
            string maTG = cbbMaTG.SelectedValue?.ToString();
            string maNXB = cbbMaNXB.SelectedValue?.ToString();
            string maLV = cbbMaLV.SelectedValue?.ToString();
            string maNN = cbbMaNN.SelectedValue?.ToString();
           
            // Kiểm tra mã sách đã tồn tại chưa
            if (KhoSachDAO.CheckMaSachTonTai(maSach))
            {
                MessageBox.Show("Mã sách đã tồn tại");
                return;
            }


            // Kiểm tra dữ liệu bắt buộc
            if(string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(maTG) ||
                string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(maLV) || string.IsNullOrEmpty(maNN)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSL.Text) ||
                string.IsNullOrWhiteSpace(txtDGN.Text) ||
                string.IsNullOrWhiteSpace(txtDGB.Text) ||
                string.IsNullOrWhiteSpace(txtSoTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Số lượng, Đơn giá nhập, Đơn giá bán, Số trang!");
                return;
            }

            if (!int.TryParse(txtSL.Text, out int SoLuong))
            {
                MessageBox.Show("Số lượng phải là số nguyên!");
                return;
            }
            if (!decimal.TryParse(txtDGN.Text, out decimal donGiaNhap))
            {
                MessageBox.Show("Đơn giá nhập phải là số!");
                return;
            }
            if (!decimal.TryParse(txtDGB.Text, out decimal donGiaBan))
            {
                MessageBox.Show("Đơn giá bán phải là số!");
                return;
            }
            if (!int.TryParse(txtSoTrang.Text, out int soTrang))
            {
                MessageBox.Show("Số trang phải là số nguyên!");
                return;
            }
            


            // Gọi DAO để lưu dữ liệu
            try
            {
                KhoSachDAO.Insert(
                maSach, tenSach, SoLuong, donGiaNhap, donGiaBan,
                maLoai, maTG, maNXB, maLV, maNN, soTrang,
                currentImagePath); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu sách: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    KhoSachDAO.Delete(txtMaSach.Text.Trim());
                    MessageBox.Show("Xóa thành công!");
                    LoadDataToGridView();
                    button2_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sách: " + ex.Message);
                }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMaSach.ReadOnly = false;
            string maSach = txtMaSach.Text.Trim();
            string tenSach = txtTenSach.Text.Trim();
            string maLoai = cbbMaLoai.SelectedValue?.ToString();
            string maTG = cbbMaTG.SelectedValue?.ToString();
            string maNXB = cbbMaNXB.SelectedValue?.ToString();

            DataTable dt = KhoSachDAO.Search(maSach, tenSach, maLoai, maTG, maNXB);
            dtGVKhoSach.DataSource = dt;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = ofd.FileName; // lưu đường dẫn ảnh đã chọn
                picAnh.Image = Image.FromFile(currentImagePath);
                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }

        


    
}
