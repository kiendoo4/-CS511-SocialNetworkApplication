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
using System.Xml.Linq;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class FormFeed : Form
    {
        public event EventHandler<DataRow> UploadFeed;
        private DataRow postRow;

        public FormFeed(int index, DataTable postList)
        {
            InitializeComponent();
            postRow = postList.NewRow();
            postRow["User_id"] = index;
            cbMode.SelectedIndex = 0;
        }

        public FormFeed(int index, DataTable postList, DataRow shareRow)
        {
            InitializeComponent();
            postRow = postList.NewRow();
            postRow["User_id"] = index;
            postRow["Content"] = shareRow["Content"];
            tbContent.Text = postRow["Content"].ToString();
            string temp1 = shareRow["Images"].ToString();
            string temp2 = shareRow["Videos"].ToString();
            temp1 = temp1 + temp2;
            if (temp1[0] == ';') temp1 =  temp1.Substring(1);
            if (temp1.Length > 0 && temp1[temp1.Length - 1] == ';')
            {
                temp1 = temp1.Substring(0, temp1.Length - 1);
            }
            picAttach.Tag = temp1;
            tbContent.Enabled = false;
            picAttach.Enabled = false;
            postRow["Share"] = shareRow["User_id"];
            cbMode.SelectedIndex = 0;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPost_Click(object sender, EventArgs e)
        {
            if (picAttach.Tag == null && tbContent.Text == "")
            {
                MessageBox.Show("Bạn chưa thêm nội dung.");
                return;
            }
            postRow["Mode"] = cbMode.Text;
            postRow["Post_time"] = DateTime.Now;
            postRow["Content"] = tbContent.Text;

            if (picAttach.Tag != null)
            {
                string[] mediaPath = picAttach.Tag.ToString().Split(';');
                StringBuilder imgPath = new StringBuilder();
                StringBuilder vidPath = new StringBuilder();
                foreach (string filePath in mediaPath)
                {
                    if (Post.IsImageFile(filePath))
                    {
                        string new_path = "../../Data/Images/" + Path.GetFileName(filePath);
                        if (postRow["Share"].ToString() == "") File.Copy(filePath, new_path, true);
                        imgPath.Append(new_path).Append(';');
                    }
                    else
                    {
                        string new_path = "../../Data/Images/" + Path.GetFileName(filePath);
                        if (postRow["Share"].ToString() == "") File.Copy(filePath, new_path, true);
                        vidPath.Append(new_path).Append(';');
                    }
                }
                if (imgPath.Length > 0)
                {
                    imgPath.Length--; // Xóa ký tự cuối cùng
                }
                if (vidPath.Length > 0)
                {
                    vidPath.Length--; // Xóa ký tự cuối cùng
                }
                postRow["Images"] = imgPath.ToString();
                postRow["Videos"] = vidPath.ToString();
            }
            else
            {
                postRow["Images"] = "";
                postRow["Videos"] = "";
            }

            postRow["Comment"] = GetUniqueFilePath("../../Data/Post_cmt/", "Cmt", ".csv");
            File.Copy("../../Data/Post_cmt/Cmt_template.csv", postRow["Comment"].ToString());
            postRow["Like"] = GetUniqueFilePath("../../Data/Post_like/", "Like", ".txt");
            File.WriteAllText(postRow["Like"].ToString(), "");

            UploadFeed?.Invoke(this, postRow);
            this.Close();
        }

        private void picAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
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

        private void cbEmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbContent.Text = tbContent.Text + cbEmo.Text.Trim();
        }

        private static string GetUniqueFilePath(string directoryPath, string baseFileName, string fileExtension)
        {
            // Tạo tên file không trùng
            string filePath;
            int counter = 0;

            do
            {
                filePath = directoryPath + baseFileName + $"_{counter}" + fileExtension;
                counter++;
            }
            while (File.Exists(filePath));

            return filePath;
        }
    }
}
