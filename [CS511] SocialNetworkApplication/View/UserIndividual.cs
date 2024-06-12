using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class UserIndividual : UserControl
    {
        public event EventHandler MessageChatButton;
        public string[] info;
        private Color borderColor = Color.White;
        private bool isMouseOver = false;
        public UserIndividual()
        {
            InitializeComponent();
        }
        public UserIndividual(string username)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            this.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            //info = parts;
            //NameUser.Text = parts[1];
            string[] lines = File.ReadAllLines("../..\\Data\\UserList.txt");
            foreach (string line in lines)
            {
                string[] parts2 = line.Split('*');
                if (parts2[0] == username)
                {
                    NameUser.Text = parts2[1];
                    info = parts2;
                    break;
                }    
            }
            Avatar.ImageLocation = info[6];
            Avatar.Cursor = Cursors.Hand;
            Avatar.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            Avatar.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            NameUser.Cursor = Cursors.Hand;
            NameUser.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            NameUser.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            this.Cursor = Cursors.Hand;
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, Avatar.Width - 1, Avatar.Height - 1);
                Region region = new Region(gp);
                Avatar.Region = region;
            }
        }
        public UserIndividual(string username, string role, string path)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            this.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            Avatar.Cursor = Cursors.Hand;
            Avatar.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            Avatar.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            NameUser.Cursor = Cursors.Hand;
            NameUser.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            NameUser.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            this.Cursor = Cursors.Hand;
            Avatar.ImageLocation = path;
            NameUser.Text = role;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageChatButton?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;
            borderColor = Color.Blue; // Change border color on mouse enter
            this.Invalidate(); // Force the control to be redrawn
        }

        private void MyUserControl_MouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            borderColor = Color.White; // Revert border color on mouse leave
            this.Invalidate(); // Force the control to be redrawn
        }
    }
}
