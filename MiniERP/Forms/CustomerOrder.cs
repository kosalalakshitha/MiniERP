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
    public partial class CustomerOrder : Form
    {
        private int windowIndex;
        private bool is_Dirty = false;
        private bool lineIs_Dirty;
        private DBConnect _dbConnect = new DBConnect();
        private bool save = false;
        private bool saveOrderLine;
        private string lovTable = "";
        private string lovData = "";
        private static string focus = "";
        private List<int> deletedLines = new List<int>();

        public CustomerOrder(int windowIndex)
        {
            InitializeComponent();
            EnableControl(false);
            stbDiscAmmount.Enabled = false;
            stbNetAmmount.Enabled = false;
            stbInvoiceVal.Enabled = false;
            KeyPreview = true;
            cbPaymentType.Items.Add("Cash");
            cbPaymentType.Items.Add("Cheque");
            cbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.windowIndex = windowIndex;
            //dataGridView1.ReadOnly = true;
        }

        private void EnableControl(bool enable)
        {
            cbOrderNo.Enabled = enable;
            stbCustomerNo.Enabled = enable;
            stbCustomerName.Enabled = enable;
            stbDelAddress.Enabled = enable;
            btpDelDate.Enabled = enable;
            stbStatus.Enabled = enable;
            cbPaymentType.Enabled = enable;
            stbChequeNo.Enabled = enable;
            dataGridView1.Enabled = false;
        }

        private void ClearAll()
        {
            cbOrderNo.Text = "";
            stbCustomerNo.Text = "";
            stbCustomerName.Text = "";
            stbDelAddress.Text = "";
            btpDelDate.Text = "";
            stbStatus.Text = "";
            cbPaymentType.Text = "";
            stbChequeNo.Text = "";
            stbDiscAmmount.Text = "";
            stbNetAmmount.Text = "";
            stbInvoiceVal.Text = "";
            dataGridView1.Rows.Clear();
            //dataGridView1.ReadOnly = true;
        }

        #region OrderHeader

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

        private void CustomerOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (focus.Equals("order"))
                        NewCustomerOrder();
                    else if (focus.Equals("line"))
                        NewCustomerOrderLine();
                    break;
                case Keys.F12:
                    if (focus.Equals("order"))
                        SaveOrder(true);
                    else if (focus.Equals("line"))
                        SaveOrderLines();
                    break;
                case Keys.F3:
                    SearchOrder();
                    break;
                case Keys.F7:

                    break;
                case Keys.F8:
                    if (focus.Equals("order"))
                    {
                        if (stbCustomerNo.Focused)
                        {
                            string result = LOV.ShowAndReturnObject("customer_tab", true, (stbCustomerNo.Text.Equals(null) ? "" : "customer_id^" + stbCustomerNo.Text));
                            if (result != null)
                                stbCustomerNo.Text = result.Substring(12, result.Length - 13);
                        }
                    }
                    //else
                    //{
                    //    dataGridView1_KeyDown(sender, e);
                    //}
                    break;
                case Keys.F6:
                    //result = LOV.ShowAndReturnObject("part_tab", true, "");
                    new LOV("customer_tab", false, "").Show();
                    break;
            }
        }

        private void SearchOrder()
        {
            List<string> searchResult = new List<string>();

            if (CheckDirty() != 0)
            {
                searchResult = Search.ShowAndReturnObject("customer_order_tab");
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

        private void NewCustomerOrder()
        {
            EnableControl(true);
            ClearAll();
            dataGridView1.Enabled = false;
            cbOrderNo.Text = Classes.CustomerOrder.NextOrderNo;
            btpDelDate.Value = DateTime.Now.AddDays(2);
            cbOrderNo.DropDownStyle = ComboBoxStyle.DropDown;
            save = true;
            stbInvoiceVal.Text = "0";
            stbDiscAmmount.Text = "0";
            stbNetAmmount.Text = "0";
            stbStatus.Text = "Planed";
        }

        private void SaveOrder(bool update)
        {
            Classes.CustomerOrder order = new Classes.CustomerOrder();

            if (!save) return;
            if (cbOrderNo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please fill the order no.");
                cbOrderNo.Focus();
            }
            else if ((stbCustomerNo.Text.Equals(string.Empty)) || (!_dbConnect.CustomerCheckExist(stbCustomerNo.Text)))
            {
                MessageBox.Show("Customer No is not found.");
                stbCustomerNo.Focus();
            }
            else if (stbDelAddress.Text.Equals(string.Empty))
            {
                MessageBox.Show("Delivery Address is not found.");
                stbDelAddress.Focus();
            }
            else if (btpDelDate.Text.Equals(string.Empty))
            {
                MessageBox.Show("Delivery Date is not found.");
                btpDelDate.Focus();
            }
            else
            {
                order.OrderNo = cbOrderNo.Text;
                order.CustomerNo = stbCustomerNo.Text;
                order.CustomerName = stbCustomerName.Text;
                order.DelAddress = stbDelAddress.Text;
                order.DelDate = btpDelDate.Value;
                order.NetAmount = double.Parse(stbNetAmmount.Text);
                order.DiscAmount = double.Parse(stbDiscAmmount.Text);
                order.InvoiceVal = double.Parse(stbInvoiceVal.Text);
                order.Status = stbStatus.Text;
                order.PaymentType = cbPaymentType.Text;
                order.ChequeNo = stbChequeNo.Text;

                if (_dbConnect.NewCustomerOrder(order, update))
                {
                    List<string> orderNos = new List<string>();
                    _dbConnect.IncreaseSequence("order_no_sequence", "P");
                    is_Dirty = false;
                    save = false;
                    foreach (string item in cbOrderNo.Items)
                    {
                        orderNos.Add(item);
                    }
                    cbOrderNo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbOrderNo.Items.Clear();
                    foreach (string item in orderNos)
                    {
                        cbOrderNo.Items.Add(item);
                    }
                    dataGridView1.Enabled = true;
                }
            }
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox tbx = (TextBox)sender;
                if (tbx.Name.Equals(stbCustomerNo.Text))
                {
                    stbCustomerNo.BackColor = stbCustomerNo.Text.Equals(string.Empty) ? Color.HotPink : Color.Ivory;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not a Text box");
            }
            is_Dirty = true;
            save = true;
        }

        private void cbOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckDirty() != 0)
            {
                Classes.CustomerOrder order = _dbConnect.GetCustomerOrder(((ComboBox)sender).SelectedItem.ToString());
                stbCustomerNo.Text = order.CustomerNo;
                stbCustomerName.Text = order.CustomerName;
                stbDelAddress.Text = order.DelAddress;
                btpDelDate.Value = order.DelDate;
                stbNetAmmount.Text = order.NetAmount.ToString();
                stbDiscAmmount.Text = order.DiscAmount.ToString();
                stbInvoiceVal.Text = order.InvoiceVal.ToString();
                stbStatus.Text = order.Status;
                cbPaymentType.SelectedIndex = cbPaymentType.FindStringExact(order.PaymentType);
                stbChequeNo.Text = order.ChequeNo;
                is_Dirty = false;
                dataGridView1.Enabled = order.Status.Equals("Planed");
                PopulateOrderLines(order.OrderNo);
            }
        }

        private void stbCustomerNo_Validating(object sender, CancelEventArgs e)
        {
            if (_dbConnect.CustomerCheckExist(stbCustomerNo.Text))
            {
                e.Cancel = false;
                Customer customer = _dbConnect.GetCustomer(stbCustomerNo.Text);
                stbCustomerName.Text = customer.CustomerName;
                stbDelAddress.Text = customer.Address;
                return;
            }
            stbCustomerNo.Focus();
            e.Cancel = true;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            focus = "order";
        }

        private void CustomerOrder_Load(object sender, EventArgs e)
        {
            focus = "order";
            this.splitContainer1.Panel1.Focus();
        }

        private void CustomerOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.childClosed(windowIndex);
        }

        private void calculateTotals()
        {
            double disc = 0, net = 0, val = 0;
            double tempDisc, tempQty, tempNet;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1["Qty", i].Value == null || dataGridView1["UnitPrice", i].Value == null || dataGridView1["Discount", i].Value == null)
                {
                    break;
                }
                double.TryParse(dataGridView1["Qty", i].Value.ToString(), out tempQty);
                double.TryParse(dataGridView1["UnitPrice", i].Value.ToString(), out tempNet);
                double.TryParse(dataGridView1["Discount", i].Value.ToString(), out tempDisc);

                disc += tempNet * tempQty * tempDisc / 100;
                net += tempNet * tempQty;
                val += double.Parse(dataGridView1["DiscountedPrice", i].Value.ToString());
            }
            stbNetAmmount.Text = net.ToString();
            stbDiscAmmount.Text = disc.ToString();
            stbInvoiceVal.Text = val.ToString();
        }

        #endregion

        #region OrderLine

        private void NewCustomerOrderLine()
        {
            saveOrderLine = true;
            dataGridView1.AllowUserToAddRows = true;
            lineIs_Dirty = true;
        }

        private void PopulateOrderLines(string orderNo)
        {
            List<OrderLine> orderLines = _dbConnect.GetCustomerOrderLines(orderNo);

            dataGridView1.Rows.Clear();
            foreach (OrderLine orderLine in orderLines)
            {
                dataGridView1.Rows.Add(orderLine.LineNo, orderLine.PartNo, orderLine.PartDescription, orderLine.partCategory, orderLine.Qty, orderLine.UnitPrice, orderLine.Discount, orderLine.DiscountedPrice);
            }
            if (stbStatus.Text.Equals("Planed"))
                dataGridView1.Enabled = true;
        }

        private void SaveOrderLines()
        {
            bool result = false;
            string orderNo = cbOrderNo.SelectedItem.ToString();

            if (!saveOrderLine) return;
            if (!CheckOrderLines()) return;
            for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
            {
                var orderLine = new OrderLine
                {
                    OrderNo = cbOrderNo.Text,
                    LineNo = int.Parse(dataGridView1["LineNo", i].Value.ToString()),
                    PartNo = dataGridView1["PartNo", i].Value.ToString(),
                    Qty = int.Parse(dataGridView1["Qty", i].Value.ToString()),
                    UnitPrice = double.Parse(dataGridView1["UnitPrice", i].Value.ToString()),
                    Discount = double.Parse(dataGridView1["Discount", i].Value.ToString()),
                    DiscountedPrice = double.Parse(dataGridView1["DiscountedPrice", i].Value.ToString())
                };
                result = _dbConnect.NewCustomerOrderLine(orderLine);
                //if (!result) return;
            }
            foreach (int lineNo in deletedLines)
            {
                result = _dbConnect.DeleteCustomerOrderLine(orderNo, lineNo);
                //if (!result)
                //    return;
            }
            if (result)
            {
                is_Dirty = false;
                saveOrderLine = false;
            }
        }

        private bool CheckOrderLines()
        {
            for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
            {
                if (dataGridView1["PartNo", i].Value.ToString().Equals(string.Empty)) break;
                if (dataGridView1["PartNo", i].Value.ToString().Equals(string.Empty))
                {
                    MessageBox.Show("Part No is mandotory.");
                    dataGridView1["PartNo", i].Selected = true;
                    return false;
                }
                else if (!_dbConnect.PartCheckExist(dataGridView1["PartNo", i].Value.ToString()))
                {
                    MessageBox.Show("Part does not exist.");
                    dataGridView1["PartNo", i].Selected = true;
                    return false;
                }
                else if (dataGridView1["Qty", i].Value.ToString().Equals(string.Empty) || int.Parse(dataGridView1["Qty", i].Value.ToString()) == 0)
                {
                    MessageBox.Show("Qty is shoud be greater than 0");
                    dataGridView1["Qty", i].Selected = true;
                    return false;
                }
            }
            return true;
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            focus = "line";
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int rowCount = dataGridView1.Rows.Count;
            dataGridView1["LineNo", (rowCount - 1)].Value = rowCount - 1;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string value = string.Empty;
                if (dataGridView1.SelectedCells[0].Value != null)
                {
                    value = dataGridView1.SelectedCells[0].Value.ToString();
                }
                if (value.Length > 2 && (!value.Substring(value.Length - 2).Equals("%")))
                {
                    value = "part_id^" + value + "%";
                }
                else if (value.Length > 0)
                {
                    value = "part_id^" + value;
                }

                if (e.KeyCode == Keys.F8)
                {
                    if (dataGridView1.SelectedCells[0].OwningColumn.Name.Equals("PartNo"))
                    {
                        string val = LOV.ShowAndReturnObject("part_tab", true, value);
                        if (val != null)
                            dataGridView1.SelectedCells[0].Value = val.Split('^')[0].Split('=')[1];
                    }
                }
                else if (e.KeyCode == Keys.F12)
                {
                    SaveOrder(true);
                    SaveOrderLines();
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    lineIs_Dirty = true;
                    deletedLines.Add(int.Parse(dataGridView1["LineNo", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()));
                }
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotals();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lineIs_Dirty = true;
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells == null || (!(dataGridView1.SelectedCells.Count > 0)))
            {
                return;
            }
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int colIndex = dataGridView1.SelectedCells[0].ColumnIndex;
            if (colIndex == 1)
            {
                if (dataGridView1.SelectedCells[0].Value != null)
                {
                    Part part = _dbConnect.GetPart(dataGridView1.SelectedCells[0].Value.ToString());
                    if (part.PartNo == null)
                    {
                        MessageBox.Show(this, "Part number does not exist.", "Part Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        dataGridView1[2, rowIndex].Value = part.PartDescription;
                        dataGridView1["UnitPrice", rowIndex].Value = part.Price;
                        dataGridView1["Discount", rowIndex].Value = part.Discount;
                    }
                }
            }
            else if (colIndex == 3 || colIndex == 4 || colIndex == 5)
            {
                calculateDiscPrice(rowIndex);
            }
            else if (colIndex == 6)
            {
                calculateDisc(rowIndex);
            }
        }

        private void calculateDiscPrice(int rowIndex)
        {
            double qty, discPrice, disc, unitPrice;
            if (double.TryParse(dataGridView1["Qty", rowIndex].Value.ToString(), out qty)
                && double.TryParse(dataGridView1["UnitPrice", rowIndex].Value.ToString(), out unitPrice)
                && double.TryParse(dataGridView1["Discount", rowIndex].Value.ToString(), out disc))
            {
                discPrice = qty * unitPrice * (100 - disc) / 100;
                dataGridView1["DiscountedPrice", rowIndex].Value = discPrice;
                calculateTotals();
            }
            else
            {
                dataGridView1["DiscountedPrice", rowIndex].Value = null;
            }
        }

        private void calculateDisc(int rowIndex)
        {
            double qty, discPrice, disc, unitPrice;

            if (double.TryParse(dataGridView1["Qty", rowIndex].Value.ToString(), out qty)
                && double.TryParse(dataGridView1["UnitPrice", rowIndex].Value.ToString(), out unitPrice)
                && double.TryParse(dataGridView1["DiscountedPrice", rowIndex].Value.ToString(), out discPrice))
            {
                disc = 100 - (discPrice * 100 / (qty * unitPrice));
                if (disc < 0)
                {
                    MessageBox.Show(this, "Amount you enterd is not valid discounted value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1["DiscountedPrice", rowIndex].Selected = true;
                }
                else
                {
                    dataGridView1["Discount", rowIndex].Value = disc;
                    calculateTotals();
                }
            }
            else
            {
                dataGridView1["Discount", rowIndex].Value = null;
            }
        }

        private int CheckLinesDirty()
        {
            if (lineIs_Dirty)
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
                    lineIs_Dirty = false;
                    return 1;
                }
                else
                {
                    SaveOrderLines();
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        #endregion
    }
}
