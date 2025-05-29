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
            string text1 = this.txtusername.Text;
            string text2 = this.txtpass.Text;
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                int num1 = (int)MessageBox.Show("Vui lòng nhập thông tin.");
            }
            else if (LoginForm.CheckLogin(text1, text2) != null)
            {
                this.Hide();
                new MainFrm().Show();
            }
            else
            {
                int num2 = (int)MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
            }
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
