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
    }
}
