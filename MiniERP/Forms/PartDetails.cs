using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.Classes;

namespace MiniERP.Forms
{
    public partial class PartDetails : Form
    {
        private bool is_Dirty;
        private readonly DBConnect _dbconnect = new DBConnect();
        private List<string> categories = new List<string>();
        private string operation;
        private int windowIndex;
        public PartDetails(int windowIndex)
        {
            InitializeComponent();
            categories = _dbconnect.GetCategories();
            foreach (string category in categories)
            {
                cbCatagory.Items.Add(category);
            }
            EnableControls(false);
            btnSave.Enabled = false;
            is_Dirty = false;
            cbCatagory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.windowIndex = windowIndex;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchResult = new List<string>();

            if (CheckDirty() != 0)
            {
                searchResult = Search.ShowAndReturnObject("part_tab");
                cbPartNo.Items.Clear();
                if (searchResult.Count>0)
                {
                    foreach (string keys in searchResult)
                    {
                        string[] key = keys.Split('^')[0].Split('=');
                        cbPartNo.Items.Add(key[1]);
                    } 
                }
                else
                {
                    MessageBox.Show("No data matching search query.");
                    return;
                }
                cbPartNo.SelectedIndex = 0;
                EnableControls(true);
                cbPartNo.DropDownStyle = ComboBoxStyle.DropDownList;
                btnSave.Enabled = false;
            }
        }

        private void EnableControls(bool enable)
        {
            cbPartNo.Enabled = enable;
            cbCatagory.Enabled = enable;
            stbSize.Enabled = enable;
            stbQtyInStock.Enabled = enable;
            stbDiscount.Enabled = enable;
            stbPartDesc.Enabled = enable;
            stbUOM.Enabled = enable;
            stbPrice.Enabled = enable;
        }

        private void clearAll()
        {
            cbPartNo.Text = "";
            cbCatagory.Text = "";
            stbSize.Text = "";
            stbQtyInStock.Text = "";
            stbDiscount.Text = "";
            stbPartDesc.Text = "";
            stbUOM.Text = "";
            stbPrice.Text = "";
            is_Dirty = false;
            operation = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                cbPartNo.BackColor = Color.HotPink;
                cbPartNo.DropDownStyle = ComboBoxStyle.DropDown;
                clearAll();
                EnableControls(true);
                btnSave.Enabled = true;
                is_Dirty = true;
                operation = "new";
                cbPartNo.Focus();
            }
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
            Part part = new Part();
            bool result = false;

            part.PartNo = cbPartNo.Text;
            part.PartDescription = stbPartDesc.Text;
            part.Catagory = cbCatagory.Text;
            part.Size = double.Parse(stbSize.Text);
            part.UOM = stbUOM.Text;
            part.QtyInStock = int.Parse(stbQtyInStock.Text);
            part.Price = double.Parse(stbPrice.Text);
            part.Discount = double.Parse(stbDiscount.Text);
            if (operation.Equals("new"))
            {
                result = _dbconnect.AddPart(part);
                operation = "";
            }
            else
            {
                result = _dbconnect.UpdatePart(part);
            }
            if (result)
            {
                is_Dirty = false;
                btnSave.Enabled = false;
                cbPartNo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            return 0;
        }

        private void cbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                Part part = _dbconnect.GetPart(((ComboBox)sender).SelectedItem.ToString());
                stbPartDesc.Text = part.PartDescription;
                cbCatagory.SelectedIndex = cbCatagory.FindStringExact(part.Catagory);
                stbSize.Text = part.Size.ToString();
                stbUOM.Text = part.UOM;
                stbQtyInStock.Text = part.QtyInStock.ToString();
                stbPrice.Text = part.Price.ToString();
                stbDiscount.Text = part.Discount.ToString();
            }
        }

        private void cbPartNo_TextChanged(object sender, EventArgs e)
        {
            if (!(cbPartNo.Text.Length > 0))
            {
                cbPartNo.BackColor = Color.HotPink;
            }
            else
            {
                cbPartNo.BackColor = Color.Ivory;
            }
        }

        private void cbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void SetDirty()
        {
            is_Dirty = true;
            btnSave.Enabled = true;
        }

        private void stbSize_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbQtyInStock_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbPrice_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbDiscount_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbPartDesc_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void stbUOM_TextChanged(object sender, EventArgs e)
        {
            SetDirty();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
            cbPartNo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPartNo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Part number is mandotory.");
                cbPartNo.Focus();
            }
            else
            {
                Save();
            }
        }

        private void stbSize_Validating(object sender, CancelEventArgs e)
        {
            double n;
            if (!double.TryParse(stbSize.Text, out n))
            {
                e.Cancel = true;
                MessageBox.Show("Only numeric values allowe.");
                stbSize.Focus();
            }
        }

        private void stbQtyInStock_Validating(object sender, CancelEventArgs e)
        {
            int n;
            if (!int.TryParse(stbQtyInStock.Text, out n))
            {
                e.Cancel = true;
                MessageBox.Show("Only numeric values allowe.");
                stbQtyInStock.Focus();
            }
        }

        private void stbPrice_Validating(object sender, CancelEventArgs e)
        {
            double n;
            if (!double.TryParse(stbPrice.Text, out n))
            {
                e.Cancel = true;
                MessageBox.Show("Only numeric values allowe.");
                stbPrice.Focus();
            }
        }

        private void stbDiscount_Validating(object sender, CancelEventArgs e)
        {
            double n;
            if (!double.TryParse(stbDiscount.Text, out n))
            {
                e.Cancel = true;
                MessageBox.Show("Only numeric values allowe.");
                stbDiscount.Focus();
            }
        }

        private void PartDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }
    }
}
