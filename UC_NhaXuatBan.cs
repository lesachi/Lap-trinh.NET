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
using BookStore;

namespace BookStore
{
    public partial class UC_NhaXuatBan : UserControl
    {
        private Dictionary<string, NhaXuatBan> nxbList = new Dictionary<string, NhaXuatBan>();
        public UC_NhaXuatBan()
        {
            InitializeComponent();
            LoadNXB();
        }

        private void UC_NhaXuatBan_Load(object sender, EventArgs e)
        {

        }
        private void LoadNXB()
        {
            flowLayoutPanelNXB.Controls.Clear();
            string query = "SELECT * FROM NXB";
            SqlCommand cmd = new SqlCommand(query, Database.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ma = reader["MaNXB"].ToString();
                string ten = reader["TenNXB"].ToString();
                string diachi = reader["DiaChi"].ToString();
                string dienthoai = reader["DienThoai"].ToString();
                Image logo = GetLogoResource(ma);

                nxbList[ma] = new NhaXuatBan
                {
                    Ma = ma,
                    Ten = ten,
                    Diachi = diachi,
                    Dienthoai = dienthoai,
                    Logo = logo
                };

                PictureBox pb = new PictureBox();
                pb.Image = logo;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 100;
                pb.Height = 100;
                pb.Margin = new Padding(10);
                pb.Cursor = Cursors.Hand;

                pb.Tag = ma;

                pb.Click += (s, e) =>
                {
                    PictureBox clicked = (PictureBox)s;
                    string selectedMa = clicked.Tag.ToString();
                    ShowDetail(selectedMa); 
                };

                flowLayoutPanelNXB.Controls.Add(pb);
            }
        }
        private Image GetLogoResource(string maNXB)
        {
            //Image logo = null;  

            switch (maNXB) 
            {
                case "NXB01": return Properties.Resources.LogoNXBTre;
                case "NXB02": return Properties.Resources.LogoKimDong1;
                case "NXB03": return Properties.Resources.LogoGiaoduc;
                case "NXB04": return Properties.Resources.LogoHoiNhaVan;
                case "NXB05": return Properties.Resources.LogoVanhoc;
                default: return Properties.Resources.logo; 
            }
        }

        private void ShowDetail(string key)
        {
            if (nxbList.ContainsKey(key))
            {
                var nxb = nxbList[key];

                var chiTietControl = new UC_ChitietNXB(
                    nxb.Ma,
                    nxb.Ten,
                    nxb.Diachi,
                    nxb.Dienthoai,
                    nxb.Logo    
                );
                chiTietControl.XoaThanhCong += (s, e) =>
                {
                    LoadNXB(); // Refresh lại danh sách
                };

                var detailForm = new Form();
                detailForm.Text = "Chi tiết Nhà Xuất Bản";
                detailForm.Size = new Size(800, 500);
                detailForm.StartPosition = FormStartPosition.CenterParent;

                chiTietControl.Dock = DockStyle.Fill;
                detailForm.Controls.Add(chiTietControl);
                

                detailForm.ShowDialog();
            }
        }

        public class NhaXuatBan
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string Diachi { get; set; }
            public string Dienthoai { get; set; }
            public Image Logo { get; set; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNXB ucThem = new ThemNXB();
            ucThem.Dock = DockStyle.Fill;

            // Gán mã sau khi khởi tạo control
            ucThem.SetMaNXB(Database.TaoMaNXBTuDong());

            // Ẩn giao diện chính
            flowLayoutPanelNXB.Visible = false;
            btnThem.Visible = false;

            // Gán sự kiện khi thêm thành công
            ucThem.NXBThemThanhCong += (s, nxb) =>
            {
                nxbList[nxb.Ma] = nxb;
                LoadNXB();
                ucThem.Dispose(); // Loại bỏ control thêm
                flowLayoutPanelNXB.Visible = true;
                btnThem.Visible = true;
            };

            // Gán sự kiện khi hủy
            ucThem.HuyThemNXB += (s, args) =>
            {
                ucThem.Dispose();
                flowLayoutPanelNXB.Visible = true;
                btnThem.Visible = true;
            };

            this.Controls.Add(ucThem);

        }
    }
}
