using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BookStore
{
    public partial class RegisterForm: Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lbconfirm_Click(object sender, EventArgs e)
        {

        }

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtpass.UseSystemPasswordChar = !this.cbPass.Checked;
            this.txtconfirm.UseSystemPasswordChar = !this.cbPass.Checked;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtusername.Text.Trim();
            string pass = txtpass.Text.Trim();
            string confirm = txtconfirm.Text.Trim();
            

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            if (TaiKhoanDAO.Exist(txtusername.Text))
            {
                MessageBox.Show("Tài khoản đã tồn tại.");
            }
            else
            {
                RegisterForm register = new RegisterForm();
                register.FormClosed += (s, args) => this.Show(); // Quay lại login khi đóng form đăng ký
                this.Hide();
                register.Show();
            }
        }

private void lbcreate_Click(object sender, EventArgs e)
        {

        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
