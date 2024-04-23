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
            this.productList.ItemHeight = 20;
            this.productList.Location = new System.Drawing.Point(12, 12);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(299, 324);
            this.productList.TabIndex = 0;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(79, 364);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(164, 60);
            this.addProductButton.TabIndex = 3;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            // 
            // AddProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 450);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.productList);
            this.Name = "AddProductView";
            this.Text = "AddProductView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox productList;
        private System.Windows.Forms.Button addProductButton;
    }
}