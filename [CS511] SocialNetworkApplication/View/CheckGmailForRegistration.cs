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
    public partial class CheckGmailForRegistration : UserControl
    {
        string check2;
        public event EventHandler backbuttonclick, sendcodeclick, buttonclick;

        private void button2_Click(object sender, EventArgs e)
        {
            sendcodeclick?.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (code.Text == check2)
                buttonclick?.Invoke(true, EventArgs.Empty);
            else
                buttonclick?.Invoke(false, EventArgs.Empty);
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            backbuttonclick?.Invoke(this, EventArgs.Empty);
        }

        public CheckGmailForRegistration()
        {
            InitializeComponent();
        }
        public CheckGmailForRegistration(string check)
        {
            InitializeComponent();
            check2 = check;
        }

    }
}
