using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ET;
namespace Winform_User
{
    public partial class frm_Login : Form
    {
        BUS_User bsUser = new BUS_User();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ET_User et = new ET_User(txtUsername.Text, txtPass.Text);
            int n = bsUser.Login(et);
            if (n == 1)
            {
                txtUsername.Text = "";
                txtPass.Text = "";
                lbDangnhap.Hide();
                frm_User frm_User = new frm_User();
                frm_User.Show();
                this.Hide();
            }
            else
            {
                lbDangnhap.Show();
                txtUsername.Text = "";
                txtPass.Text = "";
            }
        }
        private void cbHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienmatkhau.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            lbDangnhap.Hide();
        }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            frm_Register frm_Register = new frm_Register();
            frm_Register.Show();
        }
    }
}
