namespace MiniERP.Forms
{
    partial class PartDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.stbPartDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stbSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stbUOM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stbQtyInStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stbDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCatagory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbPartNo = new System.Windows.Forms.ComboBox();
            this.stbPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Part No:";
            // 
            // stbPartDesc
            // 
            this.stbPartDesc.Location = new System.Drawing.Point(285, 12);
            this.stbPartDesc.Multiline = true;
            this.stbPartDesc.Name = "stbPartDesc";
            this.stbPartDesc.Size = new System.Drawing.Size(205, 46);
            this.stbPartDesc.TabIndex = 1;
            this.stbPartDesc.TextChanged += new System.EventHandler(this.stbPartDesc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Catogory:";
            // 
            // stbSize
            // 
            this.stbSize.Location = new System.Drawing.Point(88, 64);
            this.stbSize.Name = "stbSize";
            this.stbSize.Size = new System.Drawing.Size(122, 20);
            this.stbSize.TabIndex = 3;
            this.stbSize.TextChanged += new System.EventHandler(this.stbSize_TextChanged);
            this.stbSize.Validating += new System.ComponentModel.CancelEventHandler(this.stbSize_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Size:";
            // 
            // stbUOM
            // 
            this.stbUOM.Location = new System.Drawing.Point(285, 64);
            this.stbUOM.Name = "stbUOM";
            this.stbUOM.Size = new System.Drawing.Size(205, 20);
            this.stbUOM.TabIndex = 4;
            this.stbUOM.TextChanged += new System.EventHandler(this.stbUOM_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "UOM:";
            // 
            // stbQtyInStock
            // 
            this.stbQtyInStock.Location = new System.Drawing.Point(88, 90);
            this.stbQtyInStock.Name = "stbQtyInStock";
            this.stbQtyInStock.Size = new System.Drawing.Size(122, 20);
            this.stbQtyInStock.TabIndex = 5;
            this.stbQtyInStock.TextChanged += new System.EventHandler(this.stbQtyInStock_TextChanged);
            this.stbQtyInStock.Validating += new System.ComponentModel.CancelEventHandler(this.stbQtyInStock_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Qty In Stock:";
            // 
            // stbDiscount
            // 
            this.stbDiscount.Location = new System.Drawing.Point(88, 142);
            this.stbDiscount.Name = "stbDiscount";
            this.stbDiscount.Size = new System.Drawing.Size(122, 20);
            this.stbDiscount.TabIndex = 7;
            this.stbDiscount.TextChanged += new System.EventHandler(this.stbDiscount_TextChanged);
            this.stbDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.stbDiscount_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Discount:";
            // 
            // cbCatagory
            // 
            this.cbCatagory.FormattingEnabled = true;
            this.cbCatagory.Location = new System.Drawing.Point(89, 37);
            this.cbCatagory.Name = "cbCatagory";
            this.cbCatagory.Size = new System.Drawing.Size(121, 21);
            this.cbCatagory.TabIndex = 2;
            this.cbCatagory.SelectedIndexChanged += new System.EventHandler(this.cbCatagory_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(415, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(334, 172);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 172);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(253, 172);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(172, 172);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbPartNo
            // 
            this.cbPartNo.FormattingEnabled = true;
            this.cbPartNo.Location = new System.Drawing.Point(88, 10);
            this.cbPartNo.Name = "cbPartNo";
            this.cbPartNo.Size = new System.Drawing.Size(121, 21);
            this.cbPartNo.TabIndex = 0;
            this.cbPartNo.SelectedIndexChanged += new System.EventHandler(this.cbPartNo_SelectedIndexChanged);
            this.cbPartNo.TextChanged += new System.EventHandler(this.cbPartNo_TextChanged);
            // 
            // stbPrice
            // 
            this.stbPrice.Location = new System.Drawing.Point(88, 116);
            this.stbPrice.Name = "stbPrice";
            this.stbPrice.Size = new System.Drawing.Size(122, 20);
            this.stbPrice.TabIndex = 6;
            this.stbPrice.TextChanged += new System.EventHandler(this.stbPrice_TextChanged);
            this.stbPrice.Validating += new System.ComponentModel.CancelEventHandler(this.stbPrice_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Price:";
            // 
            // PartDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 440);
            this.Controls.Add(this.stbPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbPartNo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbCatagory);
            this.Controls.Add(this.stbDiscount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stbQtyInStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stbUOM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stbSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stbPartDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PartDetails";
            this.Text = "PartDetails";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartDetails_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stbPartDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stbSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stbUOM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stbQtyInStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox stbDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCatagory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbPartNo;
        private System.Windows.Forms.TextBox stbPrice;
        private System.Windows.Forms.Label label8;
    }
}