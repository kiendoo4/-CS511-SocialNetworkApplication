﻿using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class UserUC : UserControl
    {
        public event EventHandler changeButton;
        public event EventHandler<string> searchPost;
        UserIndividual homeButton = new UserIndividual();
        public UserIndividual userIndividual = new UserIndividual();
        UserIndividual friendButton = new UserIndividual();
        UserIndividual logoutButton = new UserIndividual();
        UserIndividual savePost = new UserIndividual();
        UserIndividual message = new UserIndividual();
        public UserUC()
        {
            InitializeComponent();
        }
        public UserUC(int idx)
        {
            InitializeComponent();
            userIndividual = new UserIndividual(idx, "Main");
            userIndividual.ChangeButton += UserIndividual_ChangeButton;
            panel1.Controls.Add(userIndividual);
            homeButton = new UserIndividual(idx, "Trang chủ", "../..\\Image\\icons8-home-button-64.png");
            homeButton.ChangeButton += HomeButton_ChangeButton;
            panel2.Controls.Add(homeButton);
            message = new UserIndividual(idx, "Nhắn tin", "../..\\Image\\icons8-message-64.png");
            message.ChangeButton += Message_ChangeButton;
            panel3.Controls.Add(message);
            friendButton = new UserIndividual(idx, "Bạn bè", "../..\\Image\\icons8-friends-64.png");
            friendButton.ChangeButton += FriendButton_ChangeButton;
            panel4.Controls.Add(friendButton);
            //groupButton = new UserIndividual(idx, "Nhóm", "../..\\Image\\icons8-group-64.png");
            //panel5.Controls.Add(groupButton);
            savePost = new UserIndividual(idx, "Đã lưu", "../..\\Image\\icons8-save-64.png");
            savePost.ChangeButton += SavePost_ChangeButton;
            panel5.Controls.Add(savePost);
            logoutButton = new UserIndividual(idx, "Đăng xuất", "../..\\Image\\icons8-log-out-48.png");
            logoutButton.ChangeButton += LogoutButton_ChangeButton;
            panel6.Controls.Add(logoutButton);

        }

        private void LogoutButton_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("Logout", e);
        }

        private void FriendButton_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("Friend", e);
        }

        private void Message_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("Mess", e);
        }

        private void HomeButton_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("Home", e);
        }

        private void UserIndividual_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("User", e);
        }

        private void SavePost_ChangeButton(object sender, EventArgs e)
        {
            changeButton?.Invoke("Save", e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchPost?.Invoke(this, textBox1.Text);
            }
        }
    }
}
