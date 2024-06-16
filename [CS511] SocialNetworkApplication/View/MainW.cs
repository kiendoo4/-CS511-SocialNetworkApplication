using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class MainW : Form
    {
        First First = new First();
        Second second = new Second();
        public MainW()
        {
            InitializeComponent();
            CurrentUC.Controls.Add(First);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 20, 20);
            GraphicsPath closePath = new GraphicsPath();
            closePath.AddEllipse(0, 0, 20, 20);
            First.changeSession += First_changeSession;
        }

        private void First_changeSession(object sender, EventArgs e)
        {
            if (sender is int lmeo)
            {
                CurrentUC.Controls.Clear();
                second = new Second(lmeo);
                CurrentUC.Controls.Add(second);
            }
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
