using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Comment : UserControl
    {
        public Comment(DataRow row)
        {
            InitializeComponent();
            string cmt_content = row["Content"].ToString();
            string cmt_media = row["Media"].ToString();
            if (Post.IsImageFile(cmt_media))
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(cmt_media);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = flowContent.Width / 2;
                pictureBox.Height = (int)(pictureBox.Width / (double)pictureBox.Image.Width * (double)pictureBox.Image.Height);
                flowContent.Controls.Add(pictureBox);
                flowContent.Controls.SetChildIndex(pictureBox, 0);
            }
            else if (Post.IsVideoFile(row["Content"].ToString()))
            {
                VidPlayer player = new VidPlayer(cmt_media);
                flowContent.Controls.Add(player);
                player.Width = flowContent.Width / 2;
                player.Height = player.Width * 4 / 6;
                flowContent.Controls.SetChildIndex(player, 0);
            }
            tbContent.Text = cmt_content;
            flowContent.Controls.SetChildIndex(tbContent, 0);
            resizeTextBox();
            lbTime.Text = row["Date_of_birth"].ToString();
        }

        private void resizeTextBox()
        {
            if (tbContent.TextLength == 0)
            {
                tbContent.Height = 0;
                return;
            }
            int lineIndex = tbContent.GetLineFromCharIndex(tbContent.TextLength) + 1;
            int space = 6;
            tbContent.Height = lineIndex * (tbContent.Font.Height) + space;
        }
    }
}
