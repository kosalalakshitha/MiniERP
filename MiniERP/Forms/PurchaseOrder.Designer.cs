namespace MiniERP.Forms
{
    partial class PurchaseOrder
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
            this.cbOrderNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stbInvoiceVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.stbRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stbStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOrderNo
            // 
            this.cbOrderNo.FormattingEnabled = true;
            this.cbOrderNo.Location = new System.Drawing.Point(62, 8);
            this.cbOrderNo.Name = "cbOrderNo";
            this.cbOrderNo.Size = new System.Drawing.Size(121, 21);
            this.cbOrderNo.TabIndex = 1;
            this.cbOrderNo.SelectedIndexChanged += new System.EventHandler(this.cbOrderNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order No:";
            // 
            // stbInvoiceVal
            // 
            this.stbInvoiceVal.Enabled = false;
            this.stbInvoiceVal.Location = new System.Drawing.Point(528, 8);
            this.stbInvoiceVal.Name = "stbInvoiceVal";
            this.stbInvoiceVal.Size = new System.Drawing.Size(121, 20);
            this.stbInvoiceVal.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Invoice Value:";
            // 
            // btpDate
            // 
            this.btpDate.Location = new System.Drawing.Point(62, 35);
            this.btpDate.Name = "btpDate";
            this.btpDate.Size = new System.Drawing.Size(121, 20);
            this.btpDate.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Date:";
            // 
            // stbRemarks
            // 
            this.stbRemarks.Location = new System.Drawing.Point(276, 8);
            this.stbRemarks.Multiline = true;
            this.stbRemarks.Name = "stbRemarks";
            this.stbRemarks.Size = new System.Drawing.Size(165, 46);
            this.stbRemarks.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Order Remarks:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineNo,
            this.partNo,
            this.partDescription,
            this.qty,
            this.value});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(670, 455);
            this.dataGridView1.TabIndex = 22;
            // 
            // lineNo
            // 
            this.lineNo.HeaderText = "Line No";
            this.lineNo.Name = "lineNo";
            // 
            // partNo
            // 
            this.partNo.HeaderText = "Part No";
            this.partNo.Name = "partNo";
            // 
            // partDescription
            // 
            this.partDescription.HeaderText = "Part Description";
            this.partDescription.Name = "partDescription";
            this.partDescription.Width = 200;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbOrderNo);
            this.splitContainer1.Panel1.Controls.Add(this.stbInvoiceVal);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btpDate);
            this.splitContainer1.Panel1.Controls.Add(this.stbRemarks);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(670, 521);
            this.splitContainer1.SplitterDistance = 62;
            this.splitContainer1.TabIndex = 23;
            // 
            // stbStatus
            // 
            this.stbStatus.Enabled = false;
            this.stbStatus.Location = new System.Drawing.Point(528, 34);
            this.stbStatus.Name = "stbStatus";
            this.stbStatus.Size = new System.Drawing.Size(121, 20);
            this.stbStatus.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Status:";
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 521);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PurchaseOrder";
            this.Text = "PurchaseOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PurchaseOrder_FormClosing);
            this.Load += new System.EventHandler(this.PurchaseOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseOrder_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stbInvoiceVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker btpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stbRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn partDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox stbStatus;
        private System.Windows.Forms.Label label2;
    }
}