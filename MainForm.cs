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
    public partial class MainFrm: Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picBoxbookshop_Click(object sender, EventArgs e)
        {

        }
        
        private void btnKhosach_Click(object sender, EventArgs e)
        {
       
            panelChildForm.Controls.Clear(); // Xóa nội dung cũ
            UC_KhoSach uc = new UC_KhoSach(); // Tạo mới UserControl
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); // Hiển thị vào panelMain
        

    }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear(); // Xóa nội dung cũ
            UC_Banhang uc = new UC_Banhang(); // Tạo mới UserControl
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); // Hiển thị vào panelMain

        }

        private void btnNhacungcap_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear(); // Xóa nội dung cũ
            UC_NhaCungCap uc = new UC_NhaCungCap(); // Tạo mới UserControl
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); // Hiển thị vào panelMain
        }

        private void btnNhaxuatban_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear(); // Xóa nội dung cũ
            UC_NhaXuatBan uc = new UC_NhaXuatBan(); // Tạo mới UserControl
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); // Hiển thị vào panelMain
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear(); 
            UC_NhanVien uc = new UC_NhanVien(); 
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); 

        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear(); 
            UC_KhachHang uc = new UC_KhachHang(); 
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc); 
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            panelChildForm.Controls.Clear();
            UC_Banhang uc = new UC_Banhang();
            uc.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(uc);
        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {

        }
    }
}
