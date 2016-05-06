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

namespace MiniERP.Forms
{
    public partial class Administration : Form
    {
        private DBConnect _dbConnect = new DBConnect();
        private int windowIndex;
        public Administration(int windowIndex, bool isSuperUser)
        {
            InitializeComponent();
            this.windowIndex = windowIndex;
            btnSearch.Enabled = MainForm.isSuperUser;
            btnNew.Enabled = MainForm.isSuperUser;
            btnDelete.Enabled = MainForm.isSuperUser;
        }

        private void Administration_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }

        private void SetVisible(bool visible)
        {
            label2.Visible = visible;
            label3.Visible = visible;
            label4.Visible = visible;

            tbOldPass.Visible = visible;
            tbNewPass.Visible = visible;
            tbRePass.Visible = visible;
        }

        private void Enable(bool enable)
        {
            cbSuperUser.Enabled = enable;
            tbOldPass.Enabled = enable;
            tbNewPass.Enabled = enable;
            tbRePass.Enabled = enable;
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            SetVisible(false);
            btnNew.Visible = MainForm.isSuperUser;
            btnDelete.Visible = MainForm.isSuperUser;
            btnSearch.Visible = MainForm.isSuperUser;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            cbUserName.Text = MainForm.userName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetVisible(true);
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            cbSuperUser.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text == tbRePass.Text || (tbRePass.Text == "" && tbNewPass.Text == ""))
            {
                bool result = _dbConnect.SaveUseDetail(cbUserName.Text, tbOldPass.Text, tbNewPass.Text, cbSuperUser.Checked);
                if (result)
                {
                    tbNewPass.Text = "";
                    tbOldPass.Text = "";
                    tbRePass.Text = "";
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = MainForm.isSuperUser;
                    cbSuperUser.Enabled = false;
                    btnDelete.Enabled = MainForm.isSuperUser;
                    SetVisible(false);
                } 
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Enable(true);
            cbUserName.Items.Clear();
            cbUserName.SelectAll();
            cbUserName.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnSearch.Enabled = MainForm.isSuperUser;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchResult = new List<string>();

            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnNew.Enabled = MainForm.isSuperUser;
            cbSuperUser.Enabled = false;
            btnDelete.Enabled = MainForm.isSuperUser;
            SetVisible(false);
            searchResult = Search.ShowAndReturnObject("authentication_tab");

            foreach (string keyVal in searchResult)
            {
                cbUserName.Items.Add(keyVal.Split('=')[1].Split('^')[0]);
            }
            cbUserName.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbUserName.SelectedItem != null)
            {
                if(_dbConnect.DeleteUser(cbUserName.SelectedItem.ToString(), tbOldPass.Text))
                {
                    cbUserName.Items.Clear();
                    cbUserName.Items.Add(MainForm.userName);
                    cbUserName.SelectedIndex = 0;
                }
            }
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSuperUser.Checked = _dbConnect.IsSuperUser(cbUserName.SelectedItem.ToString());
        }
    }
}
