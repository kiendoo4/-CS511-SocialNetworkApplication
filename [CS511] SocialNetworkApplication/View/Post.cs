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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AxWMPLib;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Post : UserControl
    {
        DataRow postInfo;
        int current_user = -1;
        DataTable userList = new DataTable();
        DataTable cmtList = new DataTable();
        List<string> mediaPath = new List<string>();
        public event EventHandler<List<string>> showDetail;

        public Post(DataRow row)
        {
            InitializeComponent();
            postInfo = row;
            loadUserData();
            loadCmtData();
            DataRow userInfo = userList.Rows[Convert.ToInt32(postInfo["User_id"])];
            lbUser.Text = userInfo["Name"].ToString();
            picAvatar.ImageLocation = userInfo["Avatar"].ToString();
            lbDate.Text = row["Post_time"].ToString();
            if (row["Mode"].ToString() == "Công khai") picMode.ImageLocation = "../../Image/global.png";
            else if (row["Mode"].ToString() == "Bạn bè") picMode.ImageLocation = "../../Image/friends.png";
            else picMode.ImageLocation = "../../Image/private.png";
            textPost.Text = row["Content"].ToString();
            resizeTextBox();

            string[] vid_paths = row["Videos"].ToString().Split(';');
            foreach (string vid_path in vid_paths)
            {
                if (vid_path == "") continue;
                mediaPath.Add(vid_path);
            }

            string[] img_paths = row["Images"].ToString().Split(';');
            foreach (string img_path in img_paths)
            {
                if (img_path == "") continue;
                mediaPath.Add(img_path);
            }

            gridMedia();

            foreach (DataRow item in cmtList.Rows)
            {
                Comment cmt = new Comment(item);
                cmt.picAva.ImageLocation = userList.Rows[Convert.ToInt32(item["User_id"])]["Avatar"].ToString();
                cmt.lbName.Text = userList.Rows[Convert.ToInt32(item["User_id"])]["Name"].ToString();
                flowComment.Controls.Add(cmt);
            }
        }

        public void get_current(int i)
        {
            current_user = i;
        }

        private void gridMedia()
        {
            if (mediaPath.Count <= 1)
            {
                foreach (string path in mediaPath)
                {
                    if (IsImageFile(path))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(path);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Width = flowMedia.Width - 5;
                        pictureBox.Height = (int)(pictureBox.Width / (double)pictureBox.Image.Width * (double)pictureBox.Image.Height);
                        flowMedia.Controls.Add(pictureBox);
                    }
                    else
                    {
                        VidPlayer player = new VidPlayer(path);
                        flowMedia.Controls.Add(player);
                        player.Width = flowMedia.Width - 5;
                        player.Height = player.Width * 4 / 6;
                    }
                }
                TableClickRegister(tableMedia.Controls);
                return;
            }

            if (mediaPath.Count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (IsImageFile(mediaPath[i]))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(mediaPath[i]);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.BackColor = Color.Black;
                        pictureBox.Width = (tableMedia.Width / 2) - 10;
                        pictureBox.Height = pictureBox.Width;
                        tableMedia.Controls.Add(pictureBox);
                    }
                    else
                    {
                        string videoPath = mediaPath[i];
                        string thumbnailPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "thumbnail.jpg");

                        ExtractThumbnail(videoPath, thumbnailPath);

                        if (System.IO.File.Exists(thumbnailPath))
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = Image.FromFile(thumbnailPath);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.BackColor = Color.Black;
                            pictureBox.Width = (tableMedia.Width / 2) - 10;
                            pictureBox.Height = pictureBox.Width;

                            PictureBox subPic = new PictureBox();
                            subPic.Image = Image.FromFile("../../Image/play-button.png");
                            subPic.SizeMode = PictureBoxSizeMode.Zoom;
                            subPic.Width = 50;
                            subPic.Height = 50;
                            int x = (pictureBox.Width - subPic.Width) / 2;
                            int y = (pictureBox.Height - subPic.Height) / 2;
                            subPic.Location = new Point(x, y);

                            pictureBox.Controls.Add(subPic);

                            tableMedia.Controls.Add(pictureBox);
                        }
                    }
                }
                TableClickRegister(tableMedia.Controls);
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (IsImageFile(mediaPath[i]))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(mediaPath[i]);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.BackColor = Color.Black;
                    pictureBox.Width = (tableMedia.Width / 2) - 10;
                    pictureBox.Height = pictureBox.Width;
                    tableMedia.Controls.Add(pictureBox);
                }
                else
                {
                    string videoPath = mediaPath[i];
                    string thumbnailPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "thumbnail.jpg");

                    ExtractThumbnail(videoPath, thumbnailPath);

                    if (System.IO.File.Exists(thumbnailPath))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(thumbnailPath);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.BackColor = Color.Black;
                        pictureBox.Width = (tableMedia.Width / 2) - 10;
                        pictureBox.Height = pictureBox.Width;

                        PictureBox subPic = new PictureBox();
                        subPic.Image = Image.FromFile("../../Image/play-button.png");
                        subPic.SizeMode = PictureBoxSizeMode.Zoom;
                        subPic.Width = 50;
                        subPic.Height = 50;
                        int x = (pictureBox.Width - subPic.Width) / 2;
                        int y = (pictureBox.Height - subPic.Height) / 2;
                        subPic.Location = new Point(x, y);

                        pictureBox.Controls.Add(subPic);

                        tableMedia.Controls.Add(pictureBox);
                    }
                }
            }
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Xem thêm";
            label.Font = new Font("Quicksand", 20, FontStyle.Bold);
            label.Width = (tableMedia.Width / 2) - 10;
            label.Height = (tableMedia.Width / 2) - 10;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Margin = new Padding(3);
            label.BackColor = System.Drawing.Color.FromArgb(230,230,230);
            label.Cursor = Cursors.Hand;
            tableMedia.Controls.Add(label);
            TableClickRegister(tableMedia.Controls);
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

        private void loadCmtData()
        {
            cmtList.Clear();
            string csvFilePath = postInfo["Comment"].ToString();
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
                    cmtList.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = cmtList.NewRow();
                    foreach (DataColumn column in cmtList.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    cmtList.Rows.Add(row);
                }
            }
        }

        private void resizeTextBox()
        {
            if (textPost.TextLength == 0)
            {
                textPost.Height = 0;
                return;
            }
            int lineIndex = textPost.GetLineFromCharIndex(textPost.TextLength) + 1;
            int space = 6;
            textPost.Height = lineIndex * (textPost.Font.Height) + space;
        }

        static public bool IsImageFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".bmp" || ext == ".webp";
        }

        static public bool IsVideoFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            return ext == ".mp4" || ext == ".avi" || ext == ".mov" || ext == ".wmv";
        }

        private void TableClickRegister(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseClick += new MouseEventHandler(TableClickHandler);

                if (control.HasChildren)
                {
                    TableClickRegister(control.Controls);
                }
            }
        }
        
        private void TableClickHandler(object sender, MouseEventArgs e)
        {
            showDetail?.Invoke(this, mediaPath);
        }

        private void ExtractThumbnail(string videoPath, string thumbnailPath)
        {
            var inputFile = new MediaFile { Filename = videoPath };
            var outputFile = new MediaFile { Filename = thumbnailPath };

            var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(1) };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.GetThumbnail(inputFile, outputFile, options);
            }
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            int lineIndex = tbComment.GetLineFromCharIndex(tbComment.TextLength) + 1;
            int space = 6;
            tbComment.Height = lineIndex * (tbComment.Font.Height) + space;
        }

        private void cbEmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbComment.Text = tbComment.Text + cbEmo.Text.Trim();
        }

        private void picSend_Click(object sender, EventArgs e)
        {
            DataRow new_cmt = cmtList.NewRow();
            new_cmt["User_id"] = current_user;
            new_cmt["Content"] = tbComment.Text;
            if (picAttach.Tag != null)
            {
                string new_media = "../../Data/Images/" + Path.GetFileName(picAttach.Tag.ToString());
                File.Copy(picAttach.Tag.ToString(), new_media);
                new_cmt["Media"] = new_media;
            }
            else new_cmt["Media"] = "";
            new_cmt["Date_of_birth"] = DateTime.Now;
            cmtList.Rows.Add(new_cmt);
            picAttach.Tag = null;

            flowComment.Controls.Clear();
            foreach (DataRow item in cmtList.Rows)
            {
                Comment cmt = new Comment(item);
                cmt.picAva.ImageLocation = userList.Rows[Convert.ToInt32(item["User_id"])]["Avatar"].ToString();
                cmt.lbName.Text = userList.Rows[Convert.ToInt32(item["User_id"])]["Name"].ToString();
                flowComment.Controls.Add(cmt);
            }
            WriteDataTableToCSV(cmtList, postInfo["Comment"].ToString());
        }

        private void picAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Video Files|*.mp4;*.avi;*.mkv;*.mov|All Files|*.*";
                openFileDialog.Title = "Select Images and Videos";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;

                    // Sử dụng StringBuilder để xây dựng chuỗi đường dẫn
                    StringBuilder combinedPaths = new StringBuilder();

                    foreach (string filePath in filePaths)
                    {
                        // Thêm đường dẫn vào StringBuilder và ngăn cách bằng dấu chấm phẩy
                        combinedPaths.Append(filePath).Append(';');
                    }

                    // Xóa ký tự dấu chấm phẩy cuối cùng
                    if (combinedPaths.Length > 0)
                    {
                        combinedPaths.Length--; // Xóa ký tự cuối cùng
                    }

                    // Chuyển đổi StringBuilder thành chuỗi
                    string result = combinedPaths.ToString();

                    // Hiển thị kết quả
                    picAttach.Tag = result;
                }
            }
        }

        public static void WriteDataTableToCSV(DataTable dataTable, string csvFilePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(csvFilePath))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                // Ghi header từ DataTable vào file CSV
                foreach (DataColumn column in dataTable.Columns)
                {
                    csvWriter.WriteField(column.ColumnName);
                }
                csvWriter.NextRecord();

                // Ghi dữ liệu từ DataTable vào file CSV
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        csvWriter.WriteField(row[i]);
                    }
                    csvWriter.NextRecord();
                }
            }
        }
    }
}
