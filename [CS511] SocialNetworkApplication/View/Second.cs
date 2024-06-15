using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Second : UserControl
    {
        UserUC userUC2 = new UserUC();
        static DataTable postList = new DataTable();
        static DataTable userList = new DataTable();
        static int index = -1;
        public Second()
        {
            InitializeComponent();
        }
        public Second(int idx)
        {
            InitializeComponent();
            index = idx;
            string csvFilePath = "../../Data/User.csv";
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                BadDataFound = null
            }))
            {
                // Đọc header của CSV và tạo các cột tương ứng trong DataTable
                csv.Read();
                csv.ReadHeader();
                foreach (var header in csv.HeaderRecord)
                {
                    userList.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = userList.NewRow();
                    foreach (DataColumn column in userList.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    userList.Rows.Add(row);
                }
            }

            userUC2 = new UserUC(userList.Rows[idx]["Username"].ToString());
            userUC.Controls.Add(userUC2);
            showPost(index);
            flowPost.FlowDirection = FlowDirection.TopDown;
            flowPost.WrapContents = false;
            flowPost.AutoScroll = true;
            socialUC.Controls.Add(flowPost);
        }
        public void showPost(int index)
        {
            string csvFilePath = "../../Data/Post.csv";
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                BadDataFound = null
            }))
            {
                // Đọc header của CSV và tạo các cột tương ứng trong DataTable
                csv.Read();
                csv.ReadHeader();
                foreach (var header in csv.HeaderRecord)
                {
                    postList.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = postList.NewRow();
                    foreach (DataColumn column in postList.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    postList.Rows.Add(row);
                }
                for (int i = postList.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = postList.Rows[i];
                    Post post = new Post(row);
                    post.get_current(index);
                    post.showDetail += showPostDetail;
                    flowPost.Controls.Add(post);
                }
            }
        }

        private void showPostDetail(object sender, List<string> e)
        {
            FlowLayoutPanel flowDetail = new FlowLayoutPanel();
            flowDetail.AutoSize = false;
            flowDetail.AutoScroll = true;
            flowDetail.FlowDirection = FlowDirection.LeftToRight;
            flowDetail.Size = socialUC.Size;
            int x = (this.Width - flowDetail.Width) / 2;
            int y = (this.Height - flowDetail.Height) / 2;
            flowDetail.Location = new Point(x, y);

            PictureBox closeButt = new PictureBox();
            closeButt.Image = Image.FromFile("../../Image/close-button.png");
            closeButt.SizeMode = PictureBoxSizeMode.StretchImage;
            closeButt.Width = 30;
            closeButt.Height = 30;

            int xc = (this.Width + flowDetail.Width) / 2 - 50;
            int yc = (this.Height - flowDetail.Height) / 2;
            closeButt.Location = new Point(xc, yc);

            closeButt.Click += (the_sender, temp_e) =>
            {
                flowDetail.Dispose();
                this.Controls.Remove(flowDetail);
                closeButt.Dispose();
                this.Controls.Remove(closeButt);
            };
            this.Controls.Add(closeButt);

            foreach (string path in e)
            {
                if (Post.IsImageFile(path))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(path);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = flowDetail.Width - 30;
                    pictureBox.Height = (int)(pictureBox.Width / (double)pictureBox.Image.Width * (double)pictureBox.Image.Height);
                    flowDetail.Controls.Add(pictureBox);
                }
                else
                {
                    VidPlayer player = new VidPlayer(path);
                    flowDetail.Controls.Add(player);
                    player.Width = flowDetail.Width - 30;
                    player.Height = player.Width * 4 / 6;
                }
            }
            this.Controls.Add(flowDetail);
            this.Controls.SetChildIndex(flowDetail, 0);
            this.Controls.SetChildIndex(closeButt, 0);
        }

        private void tbNewFeed_Click(object sender, EventArgs e)
        {
            FormFeed formFeed = new FormFeed(index, postList);
            formFeed.UploadFeed += (form_sender, row_e) =>
            {
                postList.Rows.Add(row_e);
                Post.WriteDataTableToCSV(postList, "../../Data/Post.csv");
                postList.Clear();
                postList.Columns.Clear();
                flowPost.Controls.Clear();
                showPost(index);
            };
            formFeed.ShowDialog();
        }
    }
}
