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
        int postID = -1;
        DataTable userList = new DataTable();
        DataTable cmtList = new DataTable();
        List<string> mediaPath = new List<string>();
        public event EventHandler<List<string>> showDetail;
        public event EventHandler<DataRow> sharing;

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
                cmt.Hide();
            }

            if (postInfo["Share"].ToString() != "")
            {
                System.Windows.Forms.Label author = new System.Windows.Forms.Label();
                author.Text = $"Bài viết gốc của {userList.Rows[Convert.ToInt32(postInfo["Share"])]["Name"].ToString()}";
                author.Font = new Font("Arial", 12, FontStyle.Italic);
                author.Width = flowTitle.Width - 6;
                author.TextAlign = ContentAlignment.MiddleRight;
                flowTitle.Controls.Add(author);
                flowTitle.Controls.SetChildIndex(author, 0);
                flowTitle.Controls.SetChildIndex(panel1, 1);
                flowPost.Location = new Point(flowPost.Location.X, flowPost.Location.Y + author.Height);
            }
        }

        public void get_current(int i, int j)
        {
            current_user = i;
            postID = j;
            CheckLike();
            if (current_user != Convert.ToInt32(postInfo["User_id"])) picEdit.Visible = false;
            if (postInfo["Share"].ToString() != "") picEdit.Visible = false;
        }

        private void gridMedia()
        {
            if (mediaPath.Count <= 1)
            {
                foreach (string path in mediaPath)
                {
                    if (IsImageFile(path))
                    {
                        Image temp = Image.FromFile(path);
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.ImageLocation = path;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Width = flowMedia.Width - 5;
                        pictureBox.Height = (int)(pictureBox.Width / (double)temp.Width * (double)temp.Height);
                        flowMedia.Controls.Add(pictureBox);
                        temp.Dispose();
                    }
                    else
                    {
                        VidPlayer player = new VidPlayer(path);
                        flowMedia.Controls.Add(player);
                        player.Width = flowMedia.Width - 5;
                        player.Height = player.Width * 4 / 6;
                    }
                }
                TableClickRegister(flowMedia.Controls);
                return;
            }

            if (mediaPath.Count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (IsImageFile(mediaPath[i]))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.ImageLocation = mediaPath[i];
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
                    pictureBox.ImageLocation = mediaPath[i];
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
            tbComment.Text = "";

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

        private void btLike_Click(object sender, EventArgs e)
        {
            string[] user_like_raw = File.ReadAllText(postInfo["Like"].ToString()).Split(';');
            List<string> user_like = user_like_raw.ToList();
            if (user_like[0] == "") user_like.Remove("");
            foreach (string a_user in user_like)
            {
                if (Convert.ToInt32(a_user) == current_user)
                {
                    btLike.BackColor = Color.FromArgb(250, 250, 250);
                    user_like.Remove(a_user);
                    File.WriteAllText(postInfo["Like"].ToString(), String.Join(";", user_like));
                    return;
                }
            }
            btLike.BackColor = Color.LightSkyBlue;
            user_like.Add(current_user.ToString());
            File.WriteAllText(postInfo["Like"].ToString(), String.Join(";", user_like));
        }

        private void CheckLike()
        {
            string[] user_like_raw = File.ReadAllText(postInfo["Like"].ToString()).Split(';');
            List<string> user_like = user_like_raw.ToList();
            if (user_like[0] == "") user_like.Remove("");
            foreach (string a_user in user_like)
            {
                if (Convert.ToInt32(a_user) == current_user)
                {
                    btLike.BackColor = Color.LightSkyBlue;
                    return;
                }
            }
        }

        private void picSave_Click(object sender, EventArgs e)
        {
            userList.Rows.Clear();
            userList.Columns.Clear();
            loadUserData();
            string[] saved = userList.Rows[current_user]["Save"].ToString().Split(';');
            List<string> saved_list = saved.ToList();
            if (saved_list[0] == "") saved_list.Remove("");
            if (saved_list.Contains(postID.ToString()))
            {
                saved_list.Remove(postID.ToString());
                MessageBox.Show("Đã bỏ bài viết khỏi Đã lưu.");
            }
            else
            {
                saved_list.Add(postID.ToString());
                MessageBox.Show("Đã thêm bài viết vào Đã lưu.");
            }
            userList.Rows[current_user]["Save"] = String.Join(";", saved_list);
            WriteDataTableToCSV(userList, "../../Data/User.csv");
        }

        private void btComment_Click(object sender, EventArgs e)
        {
            foreach(Control control in flowComment.Controls)
            {
                if (control.Visible == true) control.Hide();
                else control.Show();
            }
        }

        private void btShare_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(postInfo["User_id"]) == current_user)
            {
                MessageBox.Show("Không thể share post của chính bạn.");
                return;
            }
            if (postInfo["Mode"].ToString() != "Công khai")
            {
                MessageBox.Show("Không thể share post không công khai.");
                return;
            }
            sharing?.Invoke(this, postInfo);
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (current_user != Convert.ToInt64(postInfo["User_id"]))
            {
                this.Hide();
            }
            else
            {
                this.Hide();
                DataTable postList = new DataTable();
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
                }
                if (File.Exists(postInfo["Comment"].ToString()))
                {
                    File.Delete(postInfo["Comment"].ToString());
                }
                if (File.Exists(postInfo["Like"].ToString()))
                {
                    File.Delete(postInfo["Like"].ToString());
                }
                postList.Rows.RemoveAt(postID);
                WriteDataTableToCSV(postList, csvFilePath);

                for (int i = 0; i < userList.Rows.Count; i++)
                {
                    string[] saved = userList.Rows[i]["Save"].ToString().Split(';');
                    List<string> saved_list = saved.ToList();
                    if (saved_list[0] == "") saved_list.Remove("");
                    string delete_item = "";
                    foreach (string saved_item in saved_list)
                    {
                        if (saved_item == postID.ToString())
                        {
                            delete_item = saved_item;
                            break;
                        }
                    }
                    saved_list.Remove(delete_item);
                    userList.Rows[i]["Save"] = String.Join(";", saved_list);
                }
                WriteDataTableToCSV(userList, "../../Data/User.csv");
            }
        }

        public bool searching(string keyword)
        {
            if (postInfo["Content"].ToString().Contains(keyword) || userList.Rows[current_user]["Name"].ToString().Contains(keyword)) return true;
            return false;
        }

        private void picEdit_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit(postInfo, mediaPath);
            formEdit.EditFeed += (form_sender, row_e) =>
            {
                postInfo = row_e;

                if (postInfo["Mode"].ToString() == "Công khai") picMode.ImageLocation = "../../Image/global.png";
                else if (postInfo["Mode"].ToString() == "Bạn bè") picMode.ImageLocation = "../../Image/friends.png";
                else picMode.ImageLocation = "../../Image/private.png";
                textPost.Text = postInfo["Content"].ToString();
                resizeTextBox();

                mediaPath.Clear();

                string[] vid_paths = postInfo["Videos"].ToString().Split(';');
                foreach (string vid_path in vid_paths)
                {
                    if (vid_path == "") continue;
                    mediaPath.Add(vid_path);
                }

                string[] img_paths = postInfo["Images"].ToString().Split(';');
                foreach (string img_path in img_paths)
                {
                    if (img_path == "") continue;
                    mediaPath.Add(img_path);
                }

                flowMedia.Controls.Clear();
                gridMedia();

                //Update data

                DataTable postList = new DataTable();
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
                }
                postList.Rows[postID].ItemArray = postInfo.ItemArray;
                WriteDataTableToCSV(postList, "../../Data/Post.csv");
            };
            formEdit.ShowDialog();
        }
    }
}
