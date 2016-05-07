using MiniERP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.Forms
{
    public partial class PurchaseOrder : Form
    {
        private DBConnect _dbConnect = new DBConnect();
        private int windowIndex;
        private bool is_Dirty;
        private bool save;

        public PurchaseOrder(int windowIndex)
        {
            InitializeComponent();
            KeyPreview = true;
            this.windowIndex = windowIndex;
            is_Dirty = false;
            save = false;
        }

        private void PurchaseOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }

        private void PurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    cbOrderNo.Items.Clear();
                    cbOrderNo.Enabled = false;
                    cbOrderNo.Items.Add(Classes.PurchaseOrder.NextOrderNo);
                    cbOrderNo.SelectedIndex = 0;
                    cbOrderNo.SelectAll();
                    btpDate.Value = DateTime.Now;
                    stbRemarks.Text = "";
                    stbInvoiceVal.Text = "0";
                    stbStatus.Text = Status.Planned.ToString();
                    break;
                case Keys.F12:
                    savePurchaseOrder();
                    break;
                case Keys.F3:
                    searchPurchaseOrder();
                    break;
                case Keys.F8:
                    break;
            }
        }

        private void savePurchaseOrder()
        {
            Classes.PurchaseOrder purchOrder = new Classes.PurchaseOrder();
            purchOrder.OrderNo = cbOrderNo.SelectedItem.ToString();
            purchOrder.Date = btpDate.Value;
            purchOrder.Remarks = stbRemarks.Text;
            purchOrder.InvoiceVal = double.Parse(stbInvoiceVal.Text);
            purchOrder.status = (Status)Enum.Parse(typeof(Status), stbStatus.Text);
            _dbConnect.SavePurchaseOrder(purchOrder);
        }

        private void searchPurchaseOrder()
        {
            List<string> searchResult = new List<string>();

            if (CheckDirty() != 0)
            {
                searchResult = Search.ShowAndReturnObject("purchase_order_tab");
                cbOrderNo.Items.Clear();
                if (searchResult != null && searchResult.Count > 0)
                {
                    foreach (string keys in searchResult)
                    {
                        string[] key = keys.Split('^')[0].Split('=');
                        cbOrderNo.Items.Add(key[1]);
                    }
                }
                else
                {
                    return;
                }
                EnableControl(true);
                cbOrderNo.DropDownStyle = ComboBoxStyle.DropDownList;
                save = false;
                cbOrderNo.SelectedIndex = 0;
            }
        }

        private void EnableControl(bool enable)
        {
            cbOrderNo.Enabled = enable;
            btpDate.Enabled = enable;
            stbRemarks.Enabled = enable;
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Focus();
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
                    ClearAll();
                    save = false;
                    is_Dirty = false;
                    return 1;
                }
                else
                {
                    SaveOrder(true);
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        private void SaveOrder(bool v)
        {
            throw new NotImplementedException();
        }

        private void ClearAll()
        {
            throw new NotImplementedException();
        }

        private void cbOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes.PurchaseOrder order = _dbConnect.GetPurchaseOrder(((ComboBox)sender).SelectedItem.ToString());
            btpDate.Value = order.Date;
            stbRemarks.Text = order.Remarks;
            stbInvoiceVal.Text = order.InvoiceVal.ToString();
            stbStatus.Text = order.status.ToString();
            is_Dirty = false;
            dataGridView1.Enabled = order.status.Equals(Status.Planned);
            PopulateOrderLines(order.OrderNo);
        }

        private void PopulateOrderLines(string orderNo)
        {
            throw new NotImplementedException();
        }
    }
}
