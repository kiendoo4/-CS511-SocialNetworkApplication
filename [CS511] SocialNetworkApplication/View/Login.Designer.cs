using System.Drawing;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AccUs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ForgotPassword = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Paytone One", 21F);
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            // 
            // AccUs
            // 
            this.AccUs.BackColor = System.Drawing.Color.White;
            this.AccUs.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.AccUs.Location = new System.Drawing.Point(55, 148);
            this.AccUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccUs.Name = "AccUs";
            this.AccUs.Size = new System.Drawing.Size(400, 39);
            this.AccUs.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // Pw
            // 
            this.Pw.BackColor = System.Drawing.Color.White;
            this.Pw.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.Pw.Location = new System.Drawing.Point(56, 254);
            this.Pw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pw.Name = "Pw";
            this.Pw.PasswordChar = '•';
            this.Pw.Size = new System.Drawing.Size(400, 39);
            this.Pw.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chưa có tài khoản?";
            // 
            // ForgotPassword
            // 
            this.ForgotPassword.BackColor = System.Drawing.Color.SteelBlue;
            this.ForgotPassword.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPassword.ForeColor = System.Drawing.Color.White;
            this.ForgotPassword.Location = new System.Drawing.Point(56, 324);
            this.ForgotPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ForgotPassword.Name = "ForgotPassword";
            this.ForgotPassword.Size = new System.Drawing.Size(202, 50);
            this.ForgotPassword.TabIndex = 6;
            this.ForgotPassword.Text = "Quên mật khẩu";
            this.ForgotPassword.UseVisualStyleBackColor = false;
            this.ForgotPassword.Click += new System.EventHandler(this.ForgotPassword_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Purple;
            this.LoginButton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(275, 325);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(181, 50);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "Đăng nhập";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click_1);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.BackColor = System.Drawing.Color.IndianRed;
            this.RegistrationButton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrationButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RegistrationButton.Location = new System.Drawing.Point(295, 400);
            this.RegistrationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(161, 50);
            this.RegistrationButton.TabIndex = 8;
            this.RegistrationButton.Text = "Đăng ký";
            this.RegistrationButton.UseVisualStyleBackColor = false;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ForgotPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Pw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AccUs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(500, 481);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label label1;
        public Label label2;
        public TextBox AccUs;
        public Label label3;
        public TextBox Pw;
        public Label label4;
        public Button ForgotPassword;
        public Button LoginButton;
        public Button RegistrationButton;
    }
}
