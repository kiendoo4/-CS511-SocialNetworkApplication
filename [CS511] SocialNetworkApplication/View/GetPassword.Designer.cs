namespace _CS511__SocialNetworkApplication.View
{
    partial class GetPassword
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Backbutton = new System.Windows.Forms.Button();
            this.GetPwButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gmail
            // 
            this.gmail.BackColor = System.Drawing.Color.White;
            this.gmail.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.gmail.Location = new System.Drawing.Point(55, 301);
            this.gmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gmail.Name = "gmail";
            this.gmail.Size = new System.Drawing.Size(400, 39);
            this.gmail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 38);
            this.label3.TabIndex = 12;
            this.label3.Text = "Gmail để lấy lại mật khẩu";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.username.Location = new System.Drawing.Point(54, 186);
            this.username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(400, 39);
            this.username.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 38);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Paytone One", 21F);
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 57);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lấy lại mật khẩu";
            // 
            // Backbutton
            // 
            this.Backbutton.BackColor = System.Drawing.Color.IndianRed;
            this.Backbutton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backbutton.ForeColor = System.Drawing.Color.White;
            this.Backbutton.Location = new System.Drawing.Point(54, 386);
            this.Backbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(148, 50);
            this.Backbutton.TabIndex = 40;
            this.Backbutton.Text = "Trở lại";
            this.Backbutton.UseVisualStyleBackColor = false;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // GetPwButton
            // 
            this.GetPwButton.BackColor = System.Drawing.Color.IndianRed;
            this.GetPwButton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetPwButton.ForeColor = System.Drawing.Color.White;
            this.GetPwButton.Location = new System.Drawing.Point(306, 386);
            this.GetPwButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetPwButton.Name = "GetPwButton";
            this.GetPwButton.Size = new System.Drawing.Size(148, 50);
            this.GetPwButton.TabIndex = 39;
            this.GetPwButton.Text = "Gửi mã";
            this.GetPwButton.UseVisualStyleBackColor = false;
            this.GetPwButton.Click += new System.EventHandler(this.GetPwButton_Click);
            // 
            // GetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.GetPwButton);
            this.Controls.Add(this.gmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GetPassword";
            this.Size = new System.Drawing.Size(500, 481);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox gmail;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox username;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Backbutton;
        public System.Windows.Forms.Button GetPwButton;

    }
}
