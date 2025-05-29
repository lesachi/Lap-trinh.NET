using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Thêm dữ liệu giả định
            nxbList["Tre"] = new NhaXuatBan
            {
                Ma = "NXB01",
                Ten = "Nhà xuất bản Trẻ",
                Diachi = "161B Lý Chính Thắng, Q.3, TP.HCM",
                Dienthoai = "0283843124",
                Logo = Properties.Resources.LogoNXBTre,
            };

            nxbList["KimDong"] = new NhaXuatBan
            {
                Ma = "NXB02",
                Ten = "Nhà xuất bản Kim Đồng",
                Diachi = "55 Quang Trung, Hà Nội",
                Dienthoai = "0243876328",
                Logo = Properties.Resources.LogoKimDong1,
            };

            nxbList["GiaoDuc"] = new NhaXuatBan
            {
                Ma = "NXB03",
                Ten = "Nhà xuất bản Giáo dục",
                Diachi = "81 Trần Hưng Đạo, Hà Nội",
                Dienthoai = "0248220220",
                Logo = Properties.Resources.LogoGiaoduc,
            };

            nxbList["HoiNhaVan"] = new NhaXuatBan
            {
                Ma = "NXB04",
                Ten = "Nhà xuất bản Hội Nhà Văn",
                Diachi = "65 Nguyễn Du, Hà Nội",
                Dienthoai = "0243943134",
                Logo = Properties.Resources.LogoHoiNhaVan,
            };

            nxbList["VanHoc"] = new NhaXuatBan
            {
                Ma = "NXB05",
                Ten = "Nhà xuất bản Văn học",
                Diachi = "94 Lò Đúc, Hà Nội",
                Dienthoai = "0243943908",
                Logo = Properties.Resources.LogoVanhoc,
            };

            pboKimDong.Click += (s, e) => ShowDetail("KimDong");
            pboTre.Click += (s, e) => ShowDetail("Tre");
            pboGiaoduc.Click += (s, e) => ShowDetail("GiaoDuc");
            pboHoinhavan.Click += (s, e) => ShowDetail("HoiNhaVan");
            pboVanhoc.Click += (s, e) => ShowDetail("VanHoc");

        }

        private void ShowDetail(string key)
        {
            if (nxbList.ContainsKey(key))
            {
                var nxb = nxbList[key];
                var chiTietControl = new UC_ChitietNXB(nxb.Ma, nxb.Ten, nxb.Diachi, nxb.Dienthoai, nxb.Logo);
                // Tạo form bao quanh để hiển thị UC
                var detailForm = new Form();
                detailForm.Text = "Chi tiết Nhà Xuất Bản";
                detailForm.Size = new Size(500, 300); 
                detailForm.StartPosition = FormStartPosition.CenterParent;

                // Gắn UC vào form
                chiTietControl.Dock = DockStyle.Fill;
                detailForm.Controls.Add(chiTietControl);

                // Hiển thị modal
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

    }
}
