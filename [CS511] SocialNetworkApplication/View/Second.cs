using System;
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
    public partial class Second : UserControl
    {
        UserUC userUC2 = new UserUC();

        public Second()
        {
            InitializeComponent();
        }
        public Second(string username) 
        {
            InitializeComponent();
            userUC2 = new UserUC(username);
            userUC.Controls.Add(userUC2);
            showPost(username);
            socialUC.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            socialUC.Controls.Add(flowLayoutPanel1);
        }
        public void showPost(string username) 
        {
            string[] lines = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\Post.txt");
            foreach (string line in lines)
            {
                string[] list = line.Split('*');
                flowLayoutPanel1.Controls.Add(new Post(list));
                flowLayoutPanel1.Controls.Add(new Post(list));
            }
        }
    }
}
