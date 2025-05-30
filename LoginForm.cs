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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string CheckLogin(string username, string password)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Role FROM TaiKhoan WHERE Username = @user AND PasswordHash = @pass AND TrangThai = 1", connection);
                sqlCommand.Parameters.AddWithValue("@user", (object)username);
                sqlCommand.Parameters.AddWithValue("@pass", (object)password);
                //connection.Open();
                return sqlCommand.ExecuteScalar()?.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtusername.Text.Trim();
            string password = this.txtpass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }

            // Gọi hàm CheckLogin và lưu kết quả vào biến role
            string role = LoginForm.CheckLogin(username, password); 

            if (role != null)
            {
                this.Hide();
                MainFrm main = new MainFrm(role); 
                main.FormClosed += (s, args) => this.Close(); // đóng app khi MainFrm đóng
                main.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtpass.UseSystemPasswordChar = !this.cbPass.Checked;
        }

        private void lbLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().Show();
        }
    }
}
