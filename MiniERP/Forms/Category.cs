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
    public partial class Category : Form
    {
        private DBConnect _dbConnect = new DBConnect();
        private int windowIndex;
        public Category(int windowIndex)
        {
            InitializeComponent();
            cbCategory.Enabled = false;
            btnSave.Enabled = false;
            this.windowIndex = windowIndex;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            cbCategory.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            cbCategory.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchResult = new List<string>();

            cbCategory.Enabled = true;
            searchResult = Search.ShowAndReturnObject("category_tab");
            cbCategory.Items.Clear();
            foreach (string keys in searchResult)
            {
                string[] key = keys.Split('^')[0].Split('=');
                cbCategory.Items.Add(_dbConnect.GetCategory(int.Parse(key[1])));
            }
            if (searchResult.Count > 0)
            {
                cbCategory.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No data matching search query.");
                return;
            }
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dbConnect.AddCategory(cbCategory.Text))
            {
                btnSave.Enabled = false;
                cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_dbConnect.CheckForeCategoryDelete(cbCategory.Text))
            {
                _dbConnect.DeleteCategory(cbCategory.Text);
            }
            else
            {
                MessageBox.Show("You cannot delete the category " + cbCategory.Text + ". It is beign used by parts.");
            }
        }

        private void Category_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }
    }
}
