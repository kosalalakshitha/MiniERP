namespace MiniERP.Forms
{
    partial class CustomerDetail
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
            this.stbBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stbAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stbBranch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stbAccountNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbCustomerNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer No:";
            // 
            // stbBank
            // 
            this.stbBank.Location = new System.Drawing.Point(89, 160);
            this.stbBank.Name = "stbBank";
            this.stbBank.Size = new System.Drawing.Size(152, 20);
            this.stbBank.TabIndex = 3;
            this.stbBank.TextChanged += new System.EventHandler(this.stbBank_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bank:";
            // 
            // stbAddress
            // 
            this.stbAddress.Location = new System.Drawing.Point(89, 64);
            this.stbAddress.Multiline = true;
            this.stbAddress.Name = "stbAddress";
            this.stbAddress.Size = new System.Drawing.Size(152, 90);
            this.stbAddress.TabIndex = 5;
            this.stbAddress.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address:";
            // 
            // stbName
            // 
            this.stbName.Location = new System.Drawing.Point(89, 38);
            this.stbName.Name = "stbName";
            this.stbName.Size = new System.Drawing.Size(152, 20);
            this.stbName.TabIndex = 7;
            this.stbName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // stbBranch
            // 
            this.stbBranch.Location = new System.Drawing.Point(89, 186);
            this.stbBranch.Name = "stbBranch";
            this.stbBranch.Size = new System.Drawing.Size(152, 20);
            this.stbBranch.TabIndex = 9;
            this.stbBranch.TextChanged += new System.EventHandler(this.stbBranch_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Branch:";
            // 
            // stbAccountNo
            // 
            this.stbAccountNo.Location = new System.Drawing.Point(89, 212);
            this.stbAccountNo.Name = "stbAccountNo";
            this.stbAccountNo.Size = new System.Drawing.Size(152, 20);
            this.stbAccountNo.TabIndex = 11;
            this.stbAccountNo.TextChanged += new System.EventHandler(this.stbAccountNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Account No:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(108, 305);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(189, 305);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(270, 305);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(351, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbCustomerNo
            // 
            this.cbCustomerNo.FormattingEnabled = true;
            this.cbCustomerNo.Location = new System.Drawing.Point(89, 11);
            this.cbCustomerNo.Name = "cbCustomerNo";
            this.cbCustomerNo.Size = new System.Drawing.Size(152, 21);
            this.cbCustomerNo.TabIndex = 24;
            this.cbCustomerNo.SelectedIndexChanged += new System.EventHandler(this.cbCustomerNo_SelectedIndexChanged);
            this.cbCustomerNo.TextChanged += new System.EventHandler(this.cbCustomerNo_TextChanged);
            // 
            // CustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 340);
            this.Controls.Add(this.cbCustomerNo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.stbAccountNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stbBranch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stbAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stbBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomerDetail";
            this.Text = "Customer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerDetail_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stbBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stbAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stbBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stbAccountNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbCustomerNo;
    }
}