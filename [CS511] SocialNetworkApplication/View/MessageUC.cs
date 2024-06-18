using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class MessageUC : UserControl
    {
        public event EventHandler pinnedB, deleteB;
        List<string> hehe = new List<string>();
        public MessageUC()
        {
            InitializeComponent();
            this.richTextBox1.AutoSize = true;
            richTextBox1.BackColor = Color.Transparent;
            Fullname.BackColor = Color.Transparent;
        }
        public MessageUC(DataTable userList, string fullname, string message, string time, string receiver, string type, string pinned)
        {
            InitializeComponent();
            hehe.Add(fullname);
            hehe.Add(message);
            hehe.Add(time);
            hehe.Add(receiver);
            hehe.Add(type);
            pinnedButton.Click += PinnedButton_Click;
            deleteButton.Click += DeleteButton_Click;
            if (pinned == "1") pinnedButton.ImageLocation = "..\\..\\Image\\icons8-pin-30.png";
            panel1.Width = 0;
            panel1.Height = 0;
            int ful = Convert.ToInt32(fullname), rec = Convert.ToInt32(receiver);
            if (type == "Text")
            {
                richTextBox1.Text = message;
                int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 1;
                richTextBox1.Height = lineIndex * 32 + 4;
                pictureBox2.Visible = false;
            }
            else if (type == "Image")
            {
                pictureBox2.ImageLocation = message;
                pictureBox2.Location = new Point(70, 50);
                pictureBox2.Width = pictureBox2.MaximumSize.Width;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Visible = true;
                richTextBox1.Visible = false;
            }
            else if (type == "Icon")
            {
                pictureBox2.ImageLocation = message;
                pictureBox2.Location = new Point(70, 50);
                pictureBox2.Cursor = Cursors.Default;
                pictureBox2.Click -= pictureBox2_Click;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox2.Visible = true;
                richTextBox1.Visible = false;
            }
            else if (type == "Video")
            {
                panel1.AutoSize = true;
                panel1.Location = richTextBox1.Location;
                VidPlayer vidPlayer = new VidPlayer(message);
                panel1.Controls.Add(vidPlayer);
            }
            this.richTextBox1.AutoSize = true;
            Fullname.BackColor = Color.Transparent;
            this.Fullname.Text = userList.Rows[ful]["Name"].ToString() + ", đã gửi lúc: " + time;
            this.AutoSize = true;
            Fullname.AutoSize = true;
            pictureBox1.ImageLocation = userList.Rows[ful]["Avatar"].ToString();
            pinnedButton.Location = new Point(Fullname.Location.X + Fullname.Width + 10, Fullname.Location.Y);
            deleteButton.Location = new Point(pinnedButton.Location.X + pinnedButton.Width + 10, Fullname.Location.Y);
        }

        private void PinnedButton_Click(object sender, EventArgs e)
        {
            pinnedB?.Invoke(hehe, e);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            deleteB?.Invoke(hehe, e);
        }

        private void picLoad(object sender, AsyncCompletedEventArgs e)
        {
            pictureBox2.Height = pictureBox2.Width * pictureBox2.Image.Height / pictureBox2.Image.Width;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (Form imageForm = new Form())
            {
                imageForm.StartPosition = FormStartPosition.CenterScreen;
                imageForm.Size = new Size(800, 600); // Set the size of the form
                PictureBox largePictureBox = new PictureBox();
                largePictureBox.Dock = DockStyle.Fill; // Fill the entire form with the PictureBox
                largePictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ensure the image fits in the PictureBox
                largePictureBox.Image = pictureBox2.Image; // Set the same image as the PictureBox
                imageForm.Controls.Add(largePictureBox);
                imageForm.ShowDialog(); 
            }

        }
    }
}
