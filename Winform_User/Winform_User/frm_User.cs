using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ET;
namespace Winform_User
{
    public partial class frm_User : Form
    {
        BUS_User bsUser = new BUS_User();   
        public frm_User()
        {
            InitializeComponent();
        }

        private void frm_User_Load(object sender, EventArgs e)
        {
            dtgvTTUser.DataSource = bsUser.FetchData();
            dtgvTTUser.Columns[0].HeaderText = "Id";
            dtgvTTUser.Columns[1].HeaderText = "Full name";
            dtgvTTUser.Columns[2].HeaderText = "User name";
            dtgvTTUser.Columns[2].HeaderText = "Password";
        }
    }
}
