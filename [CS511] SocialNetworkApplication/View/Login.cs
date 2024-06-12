﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Login : UserControl
    {
        public event EventHandler ButtonClicked;
        public event EventHandler LoginSuccessClicked;
        public event EventHandler ForgotPasswordClicked;
        public string username, lmeo;
        public Login()
        {
            InitializeComponent();
            ForgotPassword.MouseEnter += (sender, e) => ForgotPassword.BackColor = Color.DeepSkyBlue;
            ForgotPassword.MouseLeave += (sender, e) => ForgotPassword.BackColor = Color.SteelBlue;
            LoginButton.MouseEnter += (sender, e) => LoginButton.BackColor = Color.PaleVioletRed;
            LoginButton.MouseLeave += (sender, e) => LoginButton.BackColor = Color.Purple;
            LoginButton.Click += LoginButton_Click;
            RegistrationButton.MouseEnter += (sender, e) => RegistrationButton.BackColor = Color.LightCoral;
            RegistrationButton.MouseLeave += (sender, e) => RegistrationButton.BackColor = Color.IndianRed;
            RegistrationButton.Click += RegistrationButton_Click;
            ForgotPassword.Click += ForgotPassword_Click;
            ForgotPassword.Cursor = Cursors.Hand;
            LoginButton.Cursor = Cursors.Hand;
            RegistrationButton.Cursor = Cursors.Hand;
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("../..\\Data\\UserList.txt");
            bool checkacc = false;
            foreach (string line in lines)
            {
                string[] parts = line.Split('*');
                if (parts[0] == AccUs.Text || parts[4] == AccUs.Text)
                    if (parts[5] == Pw.Text)
                    {
                        checkacc = true;
                        lmeo = parts[0];
                        break;
                    }
            }
            if (checkacc)
            {
                username = AccUs.Text;
                LoginSuccessClicked?.Invoke(lmeo, EventArgs.Empty);
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không khớp/không tồn tại", "Thông báo", MessageBoxButtons.OK); 
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
