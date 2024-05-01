namespace Bid501_Server
{
    partial class AdminView
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
            this.activeProductList = new System.Windows.Forms.ListBox();
            this.activeClientList = new System.Windows.Forms.ListBox();
            this.addProductButton = new System.Windows.Forms.Button();
            this.uxEndBidBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activeProductList
            // 
            this.activeProductList.FormattingEnabled = true;
            this.activeProductList.ItemHeight = 20;
            this.activeProductList.Location = new System.Drawing.Point(22, 28);
            this.activeProductList.Name = "activeProductList";
            this.activeProductList.Size = new System.Drawing.Size(217, 384);
            this.activeProductList.TabIndex = 0;
            this.activeProductList.SelectedIndexChanged += new System.EventHandler(this.activeProductList_SelectedIndexChanged);
            // 
            // activeClientList
            // 
            this.activeClientList.FormattingEnabled = true;
            this.activeClientList.ItemHeight = 20;
            this.activeClientList.Location = new System.Drawing.Point(278, 28);
            this.activeClientList.Name = "activeClientList";
            this.activeClientList.Size = new System.Drawing.Size(217, 384);
            this.activeClientList.TabIndex = 1;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(175, 432);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(164, 60);
            this.addProductButton.TabIndex = 2;
            this.addProductButton.Text = "Add Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // uxEndBidBtn
            // 
            this.uxEndBidBtn.Location = new System.Drawing.Point(43, 432);
            this.uxEndBidBtn.Name = "uxEndBidBtn";
            this.uxEndBidBtn.Size = new System.Drawing.Size(95, 55);
            this.uxEndBidBtn.TabIndex = 3;
            this.uxEndBidBtn.Text = "End Bid";
            this.uxEndBidBtn.UseVisualStyleBackColor = true;
            this.uxEndBidBtn.Click += new System.EventHandler(this.uxEndBidBtn_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 515);
            this.Controls.Add(this.uxEndBidBtn);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.activeClientList);
            this.Controls.Add(this.activeProductList);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox activeProductList;
        private System.Windows.Forms.ListBox activeClientList;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button uxEndBidBtn;
    }
}