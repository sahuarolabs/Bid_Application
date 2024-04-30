namespace Bid501_Server
{
    partial class AddProductView
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
            this.productList = new System.Windows.Forms.ListBox();
            this.addProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productList
            // 
            this.productList.FormattingEnabled = true;
            this.productList.Location = new System.Drawing.Point(8, 8);
            this.productList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(201, 212);
            this.productList.TabIndex = 0;
            this.productList.SelectedIndexChanged += new System.EventHandler(this.productList_SelectedIndexChanged);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(53, 237);
            this.addProductButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(109, 39);
            this.addProductButton.TabIndex = 3;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // AddProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 292);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.productList);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddProductView";
            this.Text = "AddProductView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox productList;
        private System.Windows.Forms.Button addProductButton;
    }
}