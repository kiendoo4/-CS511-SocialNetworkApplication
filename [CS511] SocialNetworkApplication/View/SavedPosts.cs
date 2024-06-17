using CsvHelper.Configuration;
using CsvHelper;
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

namespace _CS511__SocialNetworkApplication.View
{
    public partial class SavedPosts : UserControl
    {
        private DataTable postList = new DataTable();
        private DataTable userList = new DataTable();

        public event EventHandler<EventArgs> close_this;

        public SavedPosts(int cur_user)
        {
            InitializeComponent();
            loadUserData();
            loadPostData();
            string[] saved = userList.Rows[cur_user]["Save"].ToString().Split(';');
            List<string> saved_list = saved.ToList();
            if (saved_list[0] == "") saved_list.Remove("");
            foreach (string saved_item in saved_list)
            {
                Post post = new Post(postList.Rows[Convert.ToInt32(saved_item)]);
                post.get_current(cur_user, Convert.ToInt32(saved_item));
                post.showDetail += showPostDetail;
                flowPost.Controls.Add(post);
            }
        }

        private void loadUserData()
        {
            userList.Clear();
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
        }

        private void loadPostData()
        {
            postList.Clear();
            string csvFilePath = "../../Data/Post.csv";
            if (string.IsNullOrEmpty(csvFilePath)) return;
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
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            close_this?.Invoke(this, EventArgs.Empty);
        }

        private void showPostDetail(object sender, List<string> e)
        {
            FlowLayoutPanel flowDetail = new FlowLayoutPanel();
            flowDetail.AutoSize = false;
            flowDetail.AutoScroll = true;
            flowDetail.FlowDirection = FlowDirection.LeftToRight;
            flowDetail.Size = this.Size;
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
                    Image temp = Image.FromFile(path);
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.ImageLocation = path;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = flowDetail.Width - 30;
                    pictureBox.Height = (int)(pictureBox.Width / (double)temp.Width * (double)temp.Height);
                    flowDetail.Controls.Add(pictureBox);
                    temp.Dispose();
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
    }
}
