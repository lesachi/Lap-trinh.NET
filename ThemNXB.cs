using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookStore.UC_NhaXuatBan;

namespace BookStore
{
    public partial class ThemNXB : UserControl
    {
        public event EventHandler<NhaXuatBan> NXBThemThanhCong;
        public event EventHandler HuyThemNXB;

        private Image logo;
        public ThemNXB()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = "D:\\";
            //ofd.FilterIndex = 2;
            ofd.Title = "Chon hinh anh de hien thi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                try
                {
                    logo = Image.FromFile(filePath);
                    pboLogo.Image = logo;
                    txtAnh.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                }

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string ma = txtMaNXB.Text.Trim();
            string ten = txtTenNXB.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string dienthoai = txtDienthoai.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(dienthoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(dienthoai, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                txtDienthoai.Focus();
                return;
            }
            bool daThem = false;
            int soThuTu = 0;
            string ma = "";

            while (!daThem)
            {
                try
                {
                    ma = Database.TaoMaNXBTuDong();
                    string sql = "INSERT INTO NXB (MaNXB, TenNXB, DiaChi, DienThoai, Logo) VALUES (@MaNXB, @TenNXB, @DiaChi, @DienThoai, @Logo)";



                    using (SqlConnection conn = Database.GetConnection())
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNXB", ma);
                            cmd.Parameters.AddWithValue("@TenNXB", ten);
                            cmd.Parameters.AddWithValue("@DiaChi", diachi);
                            cmd.Parameters.AddWithValue("@DienThoai", dienthoai);

                            if (logo != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    logo.Save(ms, logo.RawFormat);
                                    byte[] imageBytes = ms.ToArray();
                                    cmd.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = imageBytes;
                                }
                            }
                            else
                            {
                                cmd.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = DBNull.Value;
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }

                    var nxb = new NhaXuatBan
                    {
                        Ma = ma,
                        Ten = ten,
                        Diachi = diachi,
                        Dienthoai = dienthoai,
                        Logo = logo
                    };

                    NXBThemThanhCong?.Invoke(this, nxb); // Gửi sự kiện
                    MessageBox.Show("Thêm nhà xuất bản thành công!");
                    daThem = true;
                    //txtMaNXB.Text = Database.TaoMaNXBTuDong();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("PRIMARY KEY") && ex.Message.Contains("duplicate key"))
                    {
                        soThuTu++;
                        continue; // thử mã mới
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xác định: " + ex.Message);
                    break;
                }
            }

            // Cập nhật textbox sau khi thêm thành công (nếu muốn hiển thị mã mới)
            if (daThem)
            {
                txtMaNXB.Text = ma;
            }
        }
        private void clear()
        {
            txtTenNXB.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {

            clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                HuyThemNXB?.Invoke(this, EventArgs.Empty);
                /*Form parentForm = this.FindForm();
                parentForm?.Close();*/
                if (this.Parent != null)
                {
                    Control parent = this.Parent;
                    parent.Controls.Remove(this);

                    // Load lại UC_NhaXuatBan (nếu bạn đã tạo sẵn nó)
                    UC_NhaXuatBan ucNhaXuatBan = new UC_NhaXuatBan();
                    parent.Controls.Add(ucNhaXuatBan);
                }
            }
        }
        

        public void SetMaNXB(string ma)
        {
            txtMaNXB.Text = ma;
        }

        private void ThemNXB_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNXB.Text))
            {
                txtMaNXB.Text = Database.TaoMaNXBTuDong();
            }
            txtMaNXB.ReadOnly = true;
        }
    }
}
