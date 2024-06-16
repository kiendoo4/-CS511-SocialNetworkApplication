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
    public partial class MessageUC : UserControl
    {
        public event EventHandler backButton;
        public MessageUC()
        {
            InitializeComponent();
        }
        public MessageUC(DataTable userList, int idx)
        {
            InitializeComponent();
            BackFBButton.Click += BackFBButton_Click;
        }

        private void BackFBButton_Click(object sender, EventArgs e)
        {
            backButton?.Invoke(this, EventArgs.Empty);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
