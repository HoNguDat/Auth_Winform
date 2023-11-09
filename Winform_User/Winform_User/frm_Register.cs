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
using Winform_User.Libs;

namespace Winform_User
{
    public partial class frm_Register : Form
    {
        BUS_User bsUser = new BUS_User();
        FileHelper fileHelper = new FileHelper();

        public frm_Register()
        {
            InitializeComponent();
        }

        //Write valid user info to text file
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                var arrUserInfo = new string[] { txtUserName.Text, txtPass.Text };
                fileHelper.writeUser(fileHelper.parseToString(arrUserInfo));

                MessageBox.Show("Đăng ký thành công !", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }
    }

}
