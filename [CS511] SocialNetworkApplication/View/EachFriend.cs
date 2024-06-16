using System;
using System.Collections;
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
    public partial class EachFriend : UserControl
    {
        public event EventHandler changeButton, optionButton;
        public int index = -1;
        public string role = "";
        public EachFriend()
        {
            InitializeComponent();
            CenterLabelInButton(NameUser, 78);
        }
        public EachFriend(DataTable userList, int idx, string opt)
        {
            InitializeComponent();
            role = opt;
            CenterLabelInButton(NameUser, 79);
            index = idx;
            this.MouseEnter += EachFriend_MouseEnter;
            this.MouseLeave += EachFriend_MouseLeave;
            Avatar.MouseEnter += EachFriend_MouseEnter;
            Avatar.MouseLeave += EachFriend_MouseLeave;
            NameUser.MouseEnter += EachFriend_MouseEnter;
            NameUser.MouseLeave += EachFriend_MouseLeave;
            NameUser.Text = userList.Rows[idx]["Name"].ToString();
            CenterLabelInButton(NameUser, 79);
            Avatar.ImageLocation = userList.Rows[idx]["Avatar"].ToString();
            if (opt == "Accept")
            {
                label1.Text = "Chấp nhận lời mời";
            }    
            else if (opt == "Friend")
            {
                label1.Text = "Bạn bè";
                label1.Location = new Point(label1.Location.X + 44, label1.Location.Y);
                friendIcon.Location = new Point(friendIcon.Location.X + 44, friendIcon.Location.Y);
                friendIcon.ImageLocation = "D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Image\\icons8-friend-25.png";
            }    
            else
            {
                label1.Text = "Thêm bạn bè mới";
            }
            panel1.Click += option_Click;
            friendIcon.Click += option_Click;
            label1.Click += option_Click;
            this.Click += EachFriend_Click;
            Avatar.Click += EachFriend_Click;
            NameUser.Click += EachFriend_Click;
        }

        private void EachFriend_Click(object sender, EventArgs e)
        {
            changeButton?.Invoke(index, EventArgs.Empty);
        }

        private void EachFriend_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void EachFriend_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.Gainsboro;
        }

        private void option_Click(object sender, EventArgs e)
        {
            optionButton?.Invoke(index, EventArgs.Empty);  
        }
        
        private void CenterLabelInButton(Label label, int add)
        {
            label.AutoSize = true;
            int newLabelX = (Width - label.Width) / 2;
            int newLabelY = (Height - label.Height) / 2 + add;
            label.Location = new Point(newLabelX, newLabelY);
        }
    }
}
