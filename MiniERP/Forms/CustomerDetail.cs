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
    public partial class CustomerDetail : Form
    {
        private bool is_Dirty;
        private readonly DBConnect _dbconnect = new DBConnect();
        private List<string> categories = new List<string>();
        private string operation;
        private int windowIndex;

        public CustomerDetail(int windowIndex)
        {
            InitializeComponent();
            EnableControls(false);
            btnSave.Enabled = false;
            is_Dirty = false;
            this.windowIndex = windowIndex;
        }

        private void EnableControls(bool enable)
        {
            cbCustomerNo.Enabled = enable;
            stbName.Enabled = enable;
            stbAddress.Enabled = enable;
            stbBank.Enabled = enable;
            stbBranch.Enabled = enable;
            stbAccountNo.Enabled = enable;
        }

        private void clearAll()
        {
            cbCustomerNo.Text = "";
            stbName.Text = "";
            stbAddress.Text = "";
            stbBank.Text = "";
            stbBranch.Text = "";
            stbAccountNo.Text = "";
            is_Dirty = false;
            operation = "";
        }

        private int CheckDirty()
        {
            if (is_Dirty)
            {
                DialogResult result = MessageBox.Show("You will loose the changes. Do you want to save?", "Warning!",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    return 0;
                }
                else if (result == DialogResult.No)
                {
                    clearAll();
                    btnSave.Enabled = false;
                    return 1;
                }
                else
                {
                    Save();
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        private int Save()
        {
            Customer customer = new Customer();
            bool result = false;

            customer.CustomerNo = cbCustomerNo.Text;
            customer.CustomerName = stbName.Text;
            customer.Address = stbAddress.Text;
            customer.Bank = stbBank.Text;
            customer.Branch = stbBranch.Text;
            customer.AccountNo = stbAccountNo.Text;
            if (operation.Equals("new"))
            {
                result = _dbconnect.AddCustomer(customer);
                operation = "";
            }
            else
            {
                result = _dbconnect.UpdateCustomer(customer);
            }
            if (result)
            {
                is_Dirty = false;
                btnSave.Enabled = false;
                cbCustomerNo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            return 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchResult = new List<string>();

            if (CheckDirty() != 0)
            {
                searchResult = Search.ShowAndReturnObject("customer_tab");
                cbCustomerNo.Items.Clear();
                foreach (string keys in searchResult)
                {
                    string[] key = keys.Split('^')[0].Split('=');
                    cbCustomerNo.Items.Add(key[1]);
                }
                if (searchResult.Count > 0)
                {
                    cbCustomerNo.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No data matching search query.");
                    return;
                }
                EnableControls(true);
                cbCustomerNo.DropDownStyle = ComboBoxStyle.DropDownList;
                btnSave.Enabled = false;
            }
        }

        private void cbCustomerNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                Customer customer = _dbconnect.GetCustomer(((ComboBox)sender).SelectedItem.ToString());
                stbName.Text = customer.CustomerName;
                stbAddress.Text = customer.Address;
                stbAccountNo.Text = customer.AccountNo;
                stbBank.Text = customer.Bank;
                stbBranch.Text = customer.Branch;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                cbCustomerNo.BackColor = Color.HotPink;
                stbAddress.BackColor = Color.HotPink;
                stbName.BackColor = Color.HotPink;
                cbCustomerNo.DropDownStyle = ComboBoxStyle.DropDown;
                clearAll();
                EnableControls(true);
                btnSave.Enabled = true;
                is_Dirty = true;
                operation = "new";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbCustomerNo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Customer number is mandotory.");
                cbCustomerNo.Focus();
            }
            if (stbName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Customer Name is mandotory.");
                stbName.Focus();
            }
            if (stbAddress.Text.Equals(string.Empty))
            {
                MessageBox.Show("Customer address is mandotory.");
                stbAddress.Focus();
            }
            else
            {
                Save();
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!(textBox.Text.Length > 0))
            {
                textBox.BackColor = Color.HotPink;
            }
            else
            {
                textBox.BackColor = Color.Ivory;
            }
            SetDirty();
        }

        private void cbCustomerNo_TextChanged(object sender, EventArgs e)
        {
            if (!(cbCustomerNo.Text.Length > 0))
            {
                cbCustomerNo.BackColor = Color.HotPink;
            }
            else
            {
                cbCustomerNo.BackColor = Color.Ivory;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                clearAll();
            }
        }

        private void SetDirty()
        {
            is_Dirty = true;
            btnSave.Enabled = true;
        }

        private void stbBank_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbBranch_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbAccountNo_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void CustomerDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }
    }
}
