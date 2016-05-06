using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.Classes;
using MiniERP.Forms;

namespace MiniERP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DBConnect DBConnection = new DBConnect();

            if (DBConnection.Authenticate(stbUserId.Text, stbPassword.Text, out MainForm.isSuperUser, out MainForm.userName))
            {
                new MainForm().Show();
                //new PartDetails().Show();
                this.Dispose(false);
            }
            else
            {
                new MainForm().Show();
                this.Dispose(false);
                //new PartDetails().Show();
                //MessageBox.Show("Log in unsuccess..... :(");
            }
        }

        private void stbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(sender, e);
            }
        }

        private void stbUserId_Enter(object sender, EventArgs e)
        {
            stbUserId.SelectAll();
        }

        private void stbPassword_Enter(object sender, EventArgs e)
        {
            stbPassword.SelectAll();
        }
    }
}
