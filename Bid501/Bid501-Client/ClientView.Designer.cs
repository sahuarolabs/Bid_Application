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
            this.UxListView = new System.Windows.Forms.ListView();
            this.ProductLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UxItemName
            // 
            this.UxItemName.BackColor = System.Drawing.SystemColors.Control;
            this.UxItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxItemName.Enabled = false;
            this.UxItemName.Location = new System.Drawing.Point(60, 80);
            this.UxItemName.Name = "UxItemName";
            this.UxItemName.Size = new System.Drawing.Size(333, 20);
            this.UxItemName.TabIndex = 0;
            this.UxItemName.Text = "ItemName";
            // 
            // UxTimeLeft
            // 
            this.UxTimeLeft.BackColor = System.Drawing.SystemColors.Control;
            this.UxTimeLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxTimeLeft.Enabled = false;
            this.UxTimeLeft.Location = new System.Drawing.Point(60, 118);
            this.UxTimeLeft.Name = "UxTimeLeft";
            this.UxTimeLeft.Size = new System.Drawing.Size(178, 20);
            this.UxTimeLeft.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLabel.Enabled = false;
            this.StatusLabel.Location = new System.Drawing.Point(60, 155);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 20);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status:";
            // 
            // UxStatus
            // 
            this.UxStatus.BackColor = System.Drawing.SystemColors.Control;
            this.UxStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxStatus.Enabled = false;
            this.UxStatus.Location = new System.Drawing.Point(105, 155);
            this.UxStatus.Name = "UxStatus";
            this.UxStatus.Size = new System.Drawing.Size(20, 20);
            this.UxStatus.TabIndex = 3;
            // 
            // UxBidAmt
            // 
            this.UxBidAmt.BackColor = System.Drawing.SystemColors.Control;
            this.UxBidAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxBidAmt.Location = new System.Drawing.Point(88, 206);
            this.UxBidAmt.Name = "UxBidAmt";
            this.UxBidAmt.Size = new System.Drawing.Size(102, 20);
            this.UxBidAmt.TabIndex = 4;
            // 
            // UxAmountBids
            // 
            this.UxAmountBids.BackColor = System.Drawing.SystemColors.Control;
            this.UxAmountBids.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxAmountBids.Enabled = false;
            this.UxAmountBids.Location = new System.Drawing.Point(196, 206);
            this.UxAmountBids.Name = "UxAmountBids";
            this.UxAmountBids.Size = new System.Drawing.Size(70, 20);
            this.UxAmountBids.TabIndex = 5;
            // 
            // UxMinBid
            // 
            this.UxMinBid.BackColor = System.Drawing.SystemColors.Control;
            this.UxMinBid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UxMinBid.Enabled = false;
            this.UxMinBid.Location = new System.Drawing.Point(60, 245);
            this.UxMinBid.Name = "UxMinBid";
            this.UxMinBid.Size = new System.Drawing.Size(206, 20);
            this.UxMinBid.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "Place Bid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UxListView
            // 
            this.UxListView.HideSelection = false;
            this.UxListView.Location = new System.Drawing.Point(399, 80);
            this.UxListView.Name = "UxListView";
            this.UxListView.Size = new System.Drawing.Size(209, 301);
            this.UxListView.TabIndex = 8;
            this.UxListView.UseCompatibleStateImageBehavior = false;
            // 
            // ProductLabel
            // 
            this.ProductLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ProductLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductLabel.Enabled = false;
            this.ProductLabel.Location = new System.Drawing.Point(476, 54);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(50, 13);
            this.ProductLabel.TabIndex = 9;
            this.ProductLabel.Text = "Products";
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.UxListView);
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
        private System.Windows.Forms.ListView UxListView;
        private System.Windows.Forms.TextBox ProductLabel;
    }
}