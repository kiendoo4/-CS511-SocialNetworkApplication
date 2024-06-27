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

namespace _CS511__SocialNetworkApplication.View
{
    public partial class FormEdit : Form
    {
        public event EventHandler<DataRow> EditFeed;
        private DataRow postRow;

        public FormEdit(DataRow row, List<string> mediaPath)
        {
            InitializeComponent();
            postRow = row;
            cbMode.SelectedIndex = cbMode.Items.IndexOf(row["Mode"]);
            tbContent.Text = row["Content"].ToString();
            if (mediaPath.Count > 0)
            {
                picAttach.Tag = String.Join(";", mediaPath);
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
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

        private void btPost_Click(object sender, EventArgs e)
        {
            if (picAttach.Tag == null && tbContent.Text == "")
            {
                MessageBox.Show("Bạn chưa thêm nội dung.");
                return;
            }
            postRow["Mode"] = cbMode.Text;
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
                    else if (Post.IsVideoFile(filePath))
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

            EditFeed?.Invoke(this, postRow);
            this.Close();
        }
    }
}
