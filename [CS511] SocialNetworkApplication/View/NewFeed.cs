using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class NewFeed : UserControl
    {
        public event EventHandler<DataRow> UploadFeed;
        private DataRow postRow;

        public NewFeed(int index, DataTable postList)
        {
            InitializeComponent();
            postRow = postList.NewRow();
            postRow["User_id"] = index;
        }

        private void tbContent_TextChanged(object sender, EventArgs e)
        {
            int lineIndex = tbContent.GetLineFromCharIndex(tbContent.TextLength) + 1;
            int space = 6;
            tbContent.Height = lineIndex * (tbContent.Font.Height) + space;
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

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btPost_Click(object sender, EventArgs e)
        {
            UploadFeed?.Invoke(this, postRow);
        }
    }
}
