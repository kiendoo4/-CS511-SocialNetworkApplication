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
using static System.Net.Mime.MediaTypeNames;

namespace _CS511__SocialNetworkApplication.View.InsideMainUserUC
{
    public partial class Head : UserControl
    {
        bool ck = false, ck2 = false; int index = -1;
        DataTable dataTable2 = new DataTable();
        public event EventHandler backButton, friendButton;
        public Head()
        {
            InitializeComponent();
        }
        public Head(DataTable userList, int idx, string role)
        {
            InitializeComponent();
            dataTable2 = userList;
            index = idx;
            numofFriend.Click += NumofFriend_Click;
            panel3.Visible = false;
            backB.Click += BackB_Click;
            dataTable2 = userList;
            NameUser.Text = userList.Rows[idx]["Name"].ToString();
            Avatar.ImageLocation = userList.Rows[idx]["Avatar"].ToString();
            List<string> fr = Convert.ToString(userList.Rows[idx]["FriendList"].ToString()).Split('*').ToList();
            if (fr[0] == "")
            {
                numofFriend.Text = "0 bạn bè";
            }
            else numofFriend.Text = Convert.ToString(userList.Rows[idx]["FriendList"].ToString().Split('*').Length) + " bạn bè";
            if (role != "User")
            {
                changeAvatar.Visible = false;
                panel1.Visible = false;
                camIcon.Visible = false;
                label3.Visible = false;
                label1.Visible = false;
                panel2.Visible = false;
                pictureBox1.Visible = false;
            }
            else
            {
                
            }
            label1.Click += ChangeInfo_Click;
            panel2.Click += ChangeInfo_Click;
            pictureBox1.Click += ChangeInfo_Click;
            string[] lines2 = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserImgBackground.txt");
            foreach (string line in lines2)
            {
                string[] parts = line.Split('*');
                if (parts[0] == Convert.ToString(idx))
                {
                    Background.ImageLocation = parts[1];
                    ck = true;
                    break;
                }    
            }
            if (Convert.ToString(userList.Rows[idx]["Avatar"]) != "")
                ck2 = true;
            panel1.Click += ChangeBackground_Click;
            camIcon.Click += ChangeBackground_Click;
            label3.Click += ChangeBackground_Click;
            changeAvatar.Click += ChangeAvatar_Click;
        }

        public void Lmeoo_Click(DataTable friendL, int index)
        {
            List<string> fr = Convert.ToString(friendL.Rows[index]["FriendList"].ToString()).Split('*').ToList();
            if (fr[0] == "")
            {
                numofFriend.Text = "0 bạn bè";
            }
            else
            {
                int cnt = friendL.Rows[index]["FriendList"].ToString().Split('*').Length;
                if (friendL.Rows[index]["FriendList"].ToString().Split('*')[0] == "")
                    cnt -= 1;
                numofFriend.Text = Convert.ToString(cnt) + " bạn bè";
                numofFriend.Invalidate();
                numofFriend.Update();
                numofFriend.Refresh();
            }
        }
        private void NumofFriend_Click(object sender, EventArgs e)
        {
            friendButton?.Invoke(index, e);
        }

        private void ChangeInfo_Click(object sender, EventArgs e)
        {
            if(panel3.Visible == false)
            {
                ChangeInfo changeInfo = new ChangeInfo(dataTable2, index);
                changeInfo.InfoChanged += ChangeInfo_InfoChanged;
                panel3.Controls.Add(changeInfo);
                panel3.Visible = true;
            }    
            else
            {
                panel3.Controls.Clear();
                panel3.Visible = false;
            }    
        }

        private void ChangeInfo_InfoChanged(object sender, EventArgs e)
        {
            dataTable2 = new DataTable();
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
                    dataTable2.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = dataTable2.NewRow();
                    foreach (DataColumn column in dataTable2.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    dataTable2.Rows.Add(row);
                }
            }
            NameUser.Text = dataTable2.Rows[index]["Name"].ToString();
        }

        private void BackB_Click(object sender, EventArgs e)
        {
            backButton?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Avatar.ImageLocation = filePath;
                    dataTable2.Rows[index]["Avatar"] = filePath;
                    WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", dataTable2);
                    MessageBox.Show("Đã đổi ảnh nền thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void ChangeBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Background.ImageLocation = filePath;
                    if(!ck)
                    {
                        File.WriteAllText("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserImgBackground.txt", Convert.ToString(index) + "*" + filePath);
                    }  
                    else
                    {
                        string[] lines2 = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserImgBackground.txt");
                        for (int i = 0; i < lines2.Length; i++)
                        {
                            string[] parts = lines2[i].Split('*');
                            if (parts[0] == Convert.ToString(index))
                            {
                                parts[1] = filePath;
                                lines2[i] = string.Join("*", parts);
                                break;
                            }
                        }
                        File.WriteAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserImgBackground.txt", lines2);

                    }
                    MessageBox.Show("Đã đổi ảnh nền thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }

        }
        public static List<Dictionary<string, object>> DataTableToList(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }

            return list;
        }
        public static void WriteDataTableToCsv(string filePath, DataTable table)
        {
            var records = DataTableToList(table);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Write the header
                foreach (var column in table.Columns)
                {
                    csv.WriteField(column.ToString());
                }
                csv.NextRecord();
                // Write the rows
                foreach (var record in records)
                {
                    foreach (var value in record.Values)
                    {
                        csv.WriteField(value);
                    }
                    csv.NextRecord();
                }
            }
        }
    }
}
