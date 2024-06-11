using System.Drawing;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    partial class Registration
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
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.ChooseProfileIm = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BornDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CheckPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.username.Location = new System.Drawing.Point(33, 213);
            this.username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(433, 39);
            this.username.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 38);
            this.label3.TabIndex = 12;
            this.label3.Text = "Username";
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.Color.White;
            this.hoten.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.hoten.Location = new System.Drawing.Point(33, 123);
            this.hoten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(433, 39);
            this.hoten.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 38);
            this.label2.TabIndex = 10;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Paytone One", 21F);
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 57);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đăng ký tài khoản";
            // 
            // ProfileImage
            // 
            this.ProfileImage.Location = new System.Drawing.Point(378, 640);
            this.ProfileImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.Size = new System.Drawing.Size(88, 88);
            this.ProfileImage.TabIndex = 40;
            this.ProfileImage.TabStop = false;
            // 
            // ChooseProfileIm
            // 
            this.ChooseProfileIm.BackColor = System.Drawing.Color.IndianRed;
            this.ChooseProfileIm.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProfileIm.ForeColor = System.Drawing.Color.White;
            this.ChooseProfileIm.Location = new System.Drawing.Point(33, 652);
            this.ChooseProfileIm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseProfileIm.Name = "ChooseProfileIm";
            this.ChooseProfileIm.Size = new System.Drawing.Size(234, 50);
            this.ChooseProfileIm.TabIndex = 39;
            this.ChooseProfileIm.Text = "Chọn ảnh đại diện";
            this.ChooseProfileIm.UseVisualStyleBackColor = false;
            this.ChooseProfileIm.Click += new System.EventHandler(this.ChooseProfileIm_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.BackColor = System.Drawing.Color.IndianRed;
            this.Backbutton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backbutton.ForeColor = System.Drawing.Color.White;
            this.Backbutton.Location = new System.Drawing.Point(34, 745);
            this.Backbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(148, 50);
            this.Backbutton.TabIndex = 38;
            this.Backbutton.Text = "Trở lại";
            this.Backbutton.UseVisualStyleBackColor = false;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.IndianRed;
            this.FinishButton.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishButton.ForeColor = System.Drawing.Color.White;
            this.FinishButton.Location = new System.Drawing.Point(318, 745);
            this.FinishButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(148, 50);
            this.FinishButton.TabIndex = 37;
            this.FinishButton.Text = "Đăng ký";
            this.FinishButton.UseVisualStyleBackColor = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(29, 704);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(302, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "(*) Nên chọn những hình có kích cỡ vuông";
            // 
            // BornDate
            // 
            this.BornDate.Font = new System.Drawing.Font("Quicksand SemiBold", 9F);
            this.BornDate.Location = new System.Drawing.Point(33, 313);
            this.BornDate.Name = "BornDate";
            this.BornDate.Size = new System.Drawing.Size(283, 26);
            this.BornDate.TabIndex = 42;
            this.BornDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 38);
            this.label8.TabIndex = 43;
            this.label8.Text = "Ngày sinh";
            // 
            // Gender
            // 
            this.Gender.Font = new System.Drawing.Font("Quicksand SemiBold", 9F);
            this.Gender.FormattingEnabled = true;
            this.Gender.Location = new System.Drawing.Point(345, 310);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(121, 31);
            this.Gender.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(362, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 38);
            this.label9.TabIndex = 46;
            this.label9.Text = "Giới tính";
            // 
            // CheckPassword
            // 
            this.CheckPassword.BackColor = System.Drawing.Color.White;
            this.CheckPassword.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.CheckPassword.Location = new System.Drawing.Point(34, 590);
            this.CheckPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckPassword.Name = "CheckPassword";
            this.CheckPassword.PasswordChar = '•';
            this.CheckPassword.Size = new System.Drawing.Size(433, 39);
            this.CheckPassword.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 38);
            this.label5.TabIndex = 51;
            this.label5.Text = "Xác nhận mật khẩu";
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.White;
            this.Password.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.Password.Location = new System.Drawing.Point(34, 493);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '•';
            this.Password.Size = new System.Drawing.Size(432, 39);
            this.Password.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 38);
            this.label6.TabIndex = 49;
            this.label6.Text = "Mật khẩu";
            // 
            // gmail
            // 
            this.gmail.BackColor = System.Drawing.Color.White;
            this.gmail.Font = new System.Drawing.Font("Quicksand SemiBold", 15F);
            this.gmail.Location = new System.Drawing.Point(34, 396);
            this.gmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gmail.Name = "gmail";
            this.gmail.Size = new System.Drawing.Size(433, 39);
            this.gmail.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 38);
            this.label4.TabIndex = 47;
            this.label4.Text = "Gmail";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 661);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 150);
            this.panel1.TabIndex = 53;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CheckPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BornDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ProfileImage);
            this.Controls.Add(this.ChooseProfileIm);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registration";
            this.Size = new System.Drawing.Size(500, 814);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public TextBox username;
        public Label label3;
        public TextBox hoten;
        public Label label2;
        public Label label1;
        public PictureBox ProfileImage;
        public Button ChooseProfileIm;
        public Button Backbutton;
        public Button FinishButton;
        public Label label7;
        private DateTimePicker BornDate;
        public Label label8;
        private ComboBox Gender;
        public Label label9;
        public TextBox CheckPassword;
        public Label label5;
        public TextBox Password;
        public Label label6;
        public TextBox gmail;
        public Label label4;
        private Panel panel1;
    }
}
