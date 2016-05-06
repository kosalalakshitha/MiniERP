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
        public PurchaseOrder(int windowIndex)
        {
            InitializeComponent();
            KeyPreview = true;
            this.windowIndex = windowIndex;
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
                    cbOrderNo.SelectAll();
                    btpDate.Value = DateTime.Now;
                    stbRemarks.Text = "";
                    stbInvoiceVal.Text = "";
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
            _dbConnect.NewPurchaseOrder(purchOrder);
            throw new NotImplementedException();
        }

        private void searchPurchaseOrder()
        {
            throw new NotImplementedException();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Focus();
        }
    }
}
