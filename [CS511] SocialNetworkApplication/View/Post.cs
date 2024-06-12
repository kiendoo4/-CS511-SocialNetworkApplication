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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Post : UserControl
    {
        DataRow postInfo;

        public Post()
        {
            InitializeComponent();
        }
        public Post(DataRow row)
        {
            InitializeComponent();
            postInfo = row;
            
        }

        private void textPost_TextChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;
            ResizeRichTextBoxToFitContent(richTextBox);
        }
        private void ResizeRichTextBoxToFitContent(RichTextBox richTextBox)
        {
            // Measure the size of the text
            Size textSize = TextRenderer.MeasureText(richTextBox.Text, richTextBox.Font);

            // Resize the RichTextBox to fit the content
            richTextBox.Width = Math.Max(textSize.Width, 250); // Keep a minimum width
            richTextBox.Height = Math.Max(textSize.Height, 20); // Keep a minimum height
        }
        private void AddPictureBoxToPanel(PictureBox pictureBox)
        {
            panel1.Controls.Add(pictureBox);
        }
        private void ArrangePictureBoxes()
        {
            int count = panel1.Controls.Count;
            if (count == 1)
            {
                // If there's only one picture box, fill the panel with it
                panel1.Controls[0].Dock = DockStyle.Fill;
            }
            else if (count > 1 && count <= 4)
            {
                // If there are multiple picture boxes (up to 4), arrange them within the panel
                int rows = (int)Math.Ceiling(Math.Sqrt(count));
                int cols = (int)Math.Ceiling((double)count / rows);
                int index = 0;
                int width = panel1.Width / cols;
                int height = panel1.Height / rows;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (index >= count)
                            return;

                        Control control = panel1.Controls[index++];
                        control.Location = new Point(j * width, i * height);
                        control.Size = new Size(width, height);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot display more than 4 picture boxes.");
            }
        }
    }
}
