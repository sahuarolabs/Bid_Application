namespace Bid501_Client
{
    partial class ClientView
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
            this.UxItemName = new System.Windows.Forms.TextBox();
            this.UxTimeLeft = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.TextBox();
            this.UxStatus = new System.Windows.Forms.TextBox();
            this.UxBidAmt = new System.Windows.Forms.TextBox();
            this.UxAmountBids = new System.Windows.Forms.TextBox();
            this.UxMinBid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ProductLabel = new System.Windows.Forms.TextBox();
            this.UxListView = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UxItemName
            // 
            this.UxItemName.BackColor = System.Drawing.SystemColors.Control;
            this.UxItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxItemName.Enabled = false;
            this.UxItemName.Location = new System.Drawing.Point(60, 80);
            this.UxItemName.Name = "UxItemName";
            this.UxItemName.Size = new System.Drawing.Size(333, 13);
            this.UxItemName.TabIndex = 0;
            this.UxItemName.Text = "ItemName";
            this.UxItemName.TextChanged += new System.EventHandler(this.UxItemName_TextChanged);
            // 
            // UxTimeLeft
            // 
            this.UxTimeLeft.BackColor = System.Drawing.SystemColors.Control;
            this.UxTimeLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxTimeLeft.Enabled = false;
            this.UxTimeLeft.Location = new System.Drawing.Point(60, 131);
            this.UxTimeLeft.Name = "UxTimeLeft";
            this.UxTimeLeft.Size = new System.Drawing.Size(178, 13);
            this.UxTimeLeft.TabIndex = 1;
            this.UxTimeLeft.Text = "TIME LEFT";
            this.UxTimeLeft.TextChanged += new System.EventHandler(this.UxTimeLeft_TextChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusLabel.Enabled = false;
            this.StatusLabel.Location = new System.Drawing.Point(60, 173);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status:";
            // 
            // UxStatus
            // 
            this.UxStatus.BackColor = System.Drawing.SystemColors.Control;
            this.UxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxStatus.Enabled = false;
            this.UxStatus.Location = new System.Drawing.Point(105, 155);
            this.UxStatus.Name = "UxStatus";
<<<<<<< HEAD
            this.UxStatus.Size = new System.Drawing.Size(33, 20);
=======
            this.UxStatus.Size = new System.Drawing.Size(20, 13);
>>>>>>> main
            this.UxStatus.TabIndex = 3;
            // 
            // UxBidAmt
            // 
            this.UxBidAmt.BackColor = System.Drawing.SystemColors.Control;
            this.UxBidAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxBidAmt.Location = new System.Drawing.Point(88, 206);
            this.UxBidAmt.Name = "UxBidAmt";
            this.UxBidAmt.Size = new System.Drawing.Size(102, 13);
            this.UxBidAmt.TabIndex = 4;
            // 
            // UxAmountBids
            // 
            this.UxAmountBids.BackColor = System.Drawing.SystemColors.Control;
            this.UxAmountBids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxAmountBids.Enabled = false;
            this.UxAmountBids.Location = new System.Drawing.Point(168, 222);
            this.UxAmountBids.Name = "UxAmountBids";
<<<<<<< HEAD
            this.UxAmountBids.Size = new System.Drawing.Size(81, 13);
=======
            this.UxAmountBids.Size = new System.Drawing.Size(70, 13);
>>>>>>> main
            this.UxAmountBids.TabIndex = 5;
            this.UxAmountBids.Text = "(BIDS PLACED)";
            this.UxAmountBids.TextChanged += new System.EventHandler(this.UxAmountBids_TextChanged);
            // 
            // UxMinBid
            // 
            this.UxMinBid.BackColor = System.Drawing.SystemColors.Control;
            this.UxMinBid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxMinBid.Enabled = false;
            this.UxMinBid.Location = new System.Drawing.Point(60, 245);
            this.UxMinBid.Name = "UxMinBid";
            this.UxMinBid.Size = new System.Drawing.Size(206, 13);
            this.UxMinBid.TabIndex = 6;
            // 
            // UxPlaceBidBtn
            // 
            this.button1.Location = new System.Drawing.Point(88, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "Place Bid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductLabel
            // 
            this.ProductLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ProductLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductLabel.Enabled = false;
            this.ProductLabel.Location = new System.Drawing.Point(494, 62);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(50, 13);
            this.ProductLabel.TabIndex = 9;
            this.ProductLabel.Text = "Products";
            // 
            // UxListView
            // 
            this.UxListView.FormattingEnabled = true;
            this.UxListView.Location = new System.Drawing.Point(409, 80);
            this.UxListView.Margin = new System.Windows.Forms.Padding(2);
            this.UxListView.Name = "UxListView";
            this.UxListView.Size = new System.Drawing.Size(214, 355);
            this.UxListView.TabIndex = 10;
            this.UxListView.SelectedIndexChanged += new System.EventHandler(this.UxListView_SelectedIndexChanged);
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.UxListView);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UxMinBid);
            this.Controls.Add(this.UxAmountBids);
            this.Controls.Add(this.UxBidAmt);
            this.Controls.Add(this.UxStatus);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.UxTimeLeft);
            this.Controls.Add(this.UxItemName);
            this.Name = "ClientView";
            this.Text = "ClientView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientView_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxItemName;
        private System.Windows.Forms.TextBox UxTimeLeft;
        private System.Windows.Forms.TextBox StatusLabel;
        private System.Windows.Forms.TextBox UxStatus;
        private System.Windows.Forms.TextBox UxBidAmt;
        private System.Windows.Forms.TextBox UxAmountBids;
        private System.Windows.Forms.TextBox UxMinBid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ProductLabel;
        private System.Windows.Forms.ListBox UxListView;
    }
}