namespace MiniERP.Forms
{
    partial class CustomerOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stbStatus = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.stbChequeNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.stbInvoiceVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stbDiscAmmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stbNetAmmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btpDelDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.stbDelAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stbCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stbCustomerNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOrderNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountedPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.stbStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.stbChequeNo);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.cbPaymentType);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.stbInvoiceVal);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.stbDiscAmmount);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.stbNetAmmount);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btpDelDate);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.stbDelAddress);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.stbCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.stbCustomerNo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbOrderNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1195, 533);
            this.splitContainer1.SplitterDistance = 91;
            this.splitContainer1.TabIndex = 0;
            // 
            // stbStatus
            // 
            this.stbStatus.Location = new System.Drawing.Point(721, 12);
            this.stbStatus.Name = "stbStatus";
            this.stbStatus.Size = new System.Drawing.Size(121, 20);
            this.stbStatus.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(637, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Status:";
            // 
            // stbChequeNo
            // 
            this.stbChequeNo.Location = new System.Drawing.Point(721, 66);
            this.stbChequeNo.Name = "stbChequeNo";
            this.stbChequeNo.Size = new System.Drawing.Size(121, 20);
            this.stbChequeNo.TabIndex = 6;
            this.stbChequeNo.TextChanged += new System.EventHandler(this.TextChanged);
            this.stbChequeNo.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(637, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cheque No:";
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.Location = new System.Drawing.Point(721, 39);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(121, 21);
            this.cbPaymentType.TabIndex = 5;
            this.cbPaymentType.SelectedIndexChanged += new System.EventHandler(this.TextChanged);
            this.cbPaymentType.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(637, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Payment Type:";
            // 
            // stbInvoiceVal
            // 
            this.stbInvoiceVal.Location = new System.Drawing.Point(1062, 65);
            this.stbInvoiceVal.Name = "stbInvoiceVal";
            this.stbInvoiceVal.Size = new System.Drawing.Size(121, 20);
            this.stbInvoiceVal.TabIndex = 9;
            this.stbInvoiceVal.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(957, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Invoice Value:";
            // 
            // stbDiscAmmount
            // 
            this.stbDiscAmmount.Location = new System.Drawing.Point(1062, 12);
            this.stbDiscAmmount.Name = "stbDiscAmmount";
            this.stbDiscAmmount.Size = new System.Drawing.Size(121, 20);
            this.stbDiscAmmount.TabIndex = 7;
            this.stbDiscAmmount.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(957, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tot. Disc. Ammount:";
            // 
            // stbNetAmmount
            // 
            this.stbNetAmmount.Location = new System.Drawing.Point(1062, 39);
            this.stbNetAmmount.Name = "stbNetAmmount";
            this.stbNetAmmount.Size = new System.Drawing.Size(121, 20);
            this.stbNetAmmount.TabIndex = 8;
            this.stbNetAmmount.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(957, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tot. Net. Ammount:";
            // 
            // btpDelDate
            // 
            this.btpDelDate.Location = new System.Drawing.Point(510, 65);
            this.btpDelDate.Name = "btpDelDate";
            this.btpDelDate.Size = new System.Drawing.Size(121, 20);
            this.btpDelDate.TabIndex = 3;
            this.btpDelDate.ValueChanged += new System.EventHandler(this.TextChanged);
            this.btpDelDate.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Del. Date:";
            // 
            // stbDelAddress
            // 
            this.stbDelAddress.Location = new System.Drawing.Point(510, 39);
            this.stbDelAddress.Name = "stbDelAddress";
            this.stbDelAddress.Size = new System.Drawing.Size(121, 20);
            this.stbDelAddress.TabIndex = 2;
            this.stbDelAddress.TextChanged += new System.EventHandler(this.TextChanged);
            this.stbDelAddress.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Del. Address:";
            // 
            // stbCustomerName
            // 
            this.stbCustomerName.Location = new System.Drawing.Point(307, 39);
            this.stbCustomerName.Name = "stbCustomerName";
            this.stbCustomerName.Size = new System.Drawing.Size(121, 20);
            this.stbCustomerName.TabIndex = 10;
            this.stbCustomerName.TextChanged += new System.EventHandler(this.TextChanged);
            this.stbCustomerName.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer Name:";
            // 
            // stbCustomerNo
            // 
            this.stbCustomerNo.Location = new System.Drawing.Point(89, 39);
            this.stbCustomerNo.Name = "stbCustomerNo";
            this.stbCustomerNo.Size = new System.Drawing.Size(121, 20);
            this.stbCustomerNo.TabIndex = 1;
            this.stbCustomerNo.TextChanged += new System.EventHandler(this.TextChanged);
            this.stbCustomerNo.Enter += new System.EventHandler(this.TextBox_Enter);
            this.stbCustomerNo.Validating += new System.ComponentModel.CancelEventHandler(this.stbCustomerNo_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer No:";
            // 
            // cbOrderNo
            // 
            this.cbOrderNo.FormattingEnabled = true;
            this.cbOrderNo.Location = new System.Drawing.Point(89, 12);
            this.cbOrderNo.Name = "cbOrderNo";
            this.cbOrderNo.Size = new System.Drawing.Size(121, 21);
            this.cbOrderNo.TabIndex = 0;
            this.cbOrderNo.SelectedIndexChanged += new System.EventHandler(this.cbOrderNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CustomerOrder No:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.PartNo,
            this.PartDesc,
            this.category,
            this.Qty,
            this.UnitPrice,
            this.Discount,
            this.DiscountedPrice});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1195, 438);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "Line No";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 50;
            // 
            // PartNo
            // 
            this.PartNo.HeaderText = "Part No";
            this.PartNo.Name = "PartNo";
            // 
            // PartDesc
            // 
            this.PartDesc.HeaderText = "Part Descripton";
            this.PartDesc.Name = "PartDesc";
            this.PartDesc.ReadOnly = true;
            this.PartDesc.Width = 200;
            // 
            // category
            // 
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // DiscountedPrice
            // 
            this.DiscountedPrice.HeaderText = "Discounted Price";
            this.DiscountedPrice.Name = "DiscountedPrice";
            this.DiscountedPrice.Width = 200;
            // 
            // CustomerOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 533);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomerOrder";
            this.Text = "CustomerOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerOrder_FormClosing);
            this.Load += new System.EventHandler(this.CustomerOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerOrder_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stbCustomerNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stbCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stbDelAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker btpDelDate;
        private System.Windows.Forms.TextBox stbNetAmmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox stbInvoiceVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stbDiscAmmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox stbChequeNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox stbStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountedPrice;
    }
}