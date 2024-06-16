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
    public partial class ChatsmallUC : UserControl
    {
        public event EventHandler exitButton;
        public ChatsmallUC()
        {
            InitializeComponent();
        }
        public ChatsmallUC(DataTable userList, int idx)
        {
            InitializeComponent();
            NameUser.Text = userList.Rows[idx]["Name"].ToString();
            Avatar.ImageLocation = userList.Rows[idx]["Avatar"].ToString();
            CloseButton.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exitButton?.Invoke(this, EventArgs.Empty);
        }
    }
}
