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
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.UxPlaceBidBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ProductLabel = new System.Windows.Forms.TextBox();
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
            this.StatusLabel.Size = new System.Drawing.Size(89, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status:";
            this.StatusLabel.TextChanged += new System.EventHandler(this.StatusLabel_TextChanged);
            // 
            // UxStatus
            // 
            this.UxStatus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.UxStatus.Enabled = false;
            this.UxStatus.Location = new System.Drawing.Point(98, 170);
            this.UxStatus.Name = "UxStatus";
            this.UxStatus.Size = new System.Drawing.Size(33, 20);
            this.UxStatus.TabIndex = 3;
            // 
            // UxBidAmt
            // 
            this.UxBidAmt.Location = new System.Drawing.Point(60, 222);
            this.UxBidAmt.Name = "UxBidAmt";
            this.UxBidAmt.Size = new System.Drawing.Size(102, 20);
            this.UxBidAmt.TabIndex = 4;
            // 
            // UxAmountBids
            // 
            this.UxAmountBids.BackColor = System.Drawing.SystemColors.Control;
            this.UxAmountBids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UxAmountBids.Enabled = false;
            this.UxAmountBids.Location = new System.Drawing.Point(168, 222);
            this.UxAmountBids.Name = "UxAmountBids";
            this.UxAmountBids.Size = new System.Drawing.Size(81, 13);
            this.UxAmountBids.TabIndex = 5;
            this.UxAmountBids.Text = "(BIDS PLACED)";
            this.UxAmountBids.TextChanged += new System.EventHandler(this.UxAmountBids_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(60, 272);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(206, 13);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "MIN BID $xx.xx";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // UxPlaceBidBtn
            // 
            this.UxPlaceBidBtn.Location = new System.Drawing.Point(88, 331);
            this.UxPlaceBidBtn.Name = "UxPlaceBidBtn";
            this.UxPlaceBidBtn.Size = new System.Drawing.Size(150, 50);
            this.UxPlaceBidBtn.TabIndex = 7;
            this.UxPlaceBidBtn.Text = "Place Bid";
            this.UxPlaceBidBtn.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(399, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(209, 301);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.UxPlaceBidBtn);
            this.Controls.Add(this.textBox7);
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
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button UxPlaceBidBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox ProductLabel;
    }
}