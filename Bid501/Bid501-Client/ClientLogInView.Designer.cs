namespace Bid501_Client
{
    partial class ClientLogIn
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
            this.UxLoginBtn = new System.Windows.Forms.Button();
            this.UxUsername = new System.Windows.Forms.TextBox();
            this.UxPassword = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UxLoginBtn
            // 
            this.UxLoginBtn.Location = new System.Drawing.Point(303, 206);
            this.UxLoginBtn.Name = "UxLoginBtn";
            this.UxLoginBtn.Size = new System.Drawing.Size(166, 64);
            this.UxLoginBtn.TabIndex = 0;
            this.UxLoginBtn.Text = "Login";
            this.UxLoginBtn.UseVisualStyleBackColor = true;
            this.UxLoginBtn.Click += new System.EventHandler(this.UxLoginBtn_Click);
            // 
            // UxUsername
            // 
            this.UxUsername.Location = new System.Drawing.Point(303, 113);
            this.UxUsername.Name = "UxUsername";
            this.UxUsername.Size = new System.Drawing.Size(166, 20);
            this.UxUsername.TabIndex = 1;
            // 
            // UxPassword
            // 
            this.UxPassword.Location = new System.Drawing.Point(303, 155);
            this.UxPassword.Name = "UxPassword";
            this.UxPassword.Size = new System.Drawing.Size(166, 20);
            this.UxPassword.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(245, 120);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Username";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(245, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(49, 13);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Password";
            // 
            // ClientLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.UxPassword);
            this.Controls.Add(this.UxUsername);
            this.Controls.Add(this.UxLoginBtn);
            this.Name = "ClientLogIn";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UxLoginBtn;
        private System.Windows.Forms.TextBox UxUsername;
        private System.Windows.Forms.TextBox UxPassword;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

