using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class UserUC : UserControl
    {
        UserIndividual homeButton = new UserIndividual();
        UserIndividual userIndividual = new UserIndividual();
        UserIndividual friendButton = new UserIndividual();
        UserIndividual groupButton = new UserIndividual();
        UserIndividual savePost = new UserIndividual();
        UserIndividual message = new UserIndividual();

        public UserUC()
        {
            InitializeComponent();
        }
        public UserUC(string username)
        {
            InitializeComponent();
            userIndividual = new UserIndividual(username);
            panel1.Controls.Add(userIndividual);
            homeButton = new UserIndividual(username, "Trang chủ", "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-home-button-64.png");
            panel2.Controls.Add(homeButton);
            message = new UserIndividual(username, "Nhắn tin", "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-message-64.png");
            panel3.Controls.Add(message);
            friendButton = new UserIndividual(username, "Bạn bè", "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-friends-64.png");
            panel4.Controls.Add(friendButton);
            groupButton = new UserIndividual(username, "Nhóm", "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-group-64.png");
            panel5.Controls.Add(groupButton);
            savePost = new UserIndividual(username, "Đã lưu", "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-save-64.png");
            panel6.Controls.Add(savePost);
            
        }
    }
}
