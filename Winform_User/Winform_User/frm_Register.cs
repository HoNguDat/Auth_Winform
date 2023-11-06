using BUS;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_User
{
    public partial class frm_Register : Form
    {
        BUS_User bsUser = new BUS_User();
        public frm_Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if ( txtFullName.Text == "" || txtUserName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                ET_User etNV = new ET_User(txtId.Text, txtFullName.Text, txtUserName.Text, txtPass.Text);
                if (bsUser.Register(etNV) == 1)
                {
                    MessageBox.Show("Đăng ký thành công !", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công ! !", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
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
    }
}
