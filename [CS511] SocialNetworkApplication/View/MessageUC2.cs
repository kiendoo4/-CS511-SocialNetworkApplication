using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Eventing.Reader;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class MessageUC2 : UserControl
    {
        public event EventHandler backButton;
        List<string> messidx = new List<string>();
        DataTable userList2 = new DataTable();
        DataTable messageList = new DataTable();
        int index = -1, curr = -1;
        public MessageUC2()
        {
            InitializeComponent();
        }
        public MessageUC2(DataTable userList, int idx)
        {
            InitializeComponent();
            panel4.Click += option_Click;
            friendIcon.Click += option_Click;
            label3.Click += option_Click;
            string csvFilePath = "../../Data/Messages.csv";
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
                    messageList.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = messageList.NewRow();
                    foreach (DataColumn column in messageList.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    messageList.Rows.Add(row);
                }
            }
            //System.Windows.Forms.MessageBox.Show(messageList.Rows[0]["Message"].ToString(), "lmeo");
            userList2 = userList;
            index = idx;
            BackFBButton.Click += BackFBButton_Click;
            ReactionButton.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            //yourus = us;
            flowLayoutPanel1.Visible = false;
            label2.Text = userList.Rows[idx]["Name"].ToString();
            Avatar.ImageLocation = userList.Rows[idx]["Avatar"].ToString();
            ReactionButton.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            ChattingUI cui = new ChattingUI();
            //panel4.Controls.Add(cui);
            ReactionButton.FlatAppearance.BorderSize = 0;
            SendButton.MouseEnter += (sender, e) => SendButton.BackColor = Color.LightCoral;
            SendButton.MouseLeave += (sender, e) => SendButton.BackColor = Color.IndianRed;
            SendButton.Cursor = Cursors.Hand;
            AccountList.FlowDirection = FlowDirection.TopDown;
            AccountList.WrapContents = true;
            panel1.AutoScroll = true;
            AccountList.AutoScroll = true;
            AccountList.WrapContents = false;
            panel1.Controls.Add(AccountList);
            for (int i = 0; i < messageList.Rows.Count; i++)
            {
                if (messageList.Rows[i]["Sender"].ToString() == Convert.ToString(idx))
                {
                    if (!messidx.Contains(messageList.Rows[i]["Receiver"].ToString()))
                        messidx.Add(messageList.Rows[i]["Receiver"].ToString());
                }
            }
            for (int i = 0; i < messidx.Count; i++)
            {
                int oppoidx = Convert.ToInt32(messidx[i]);
                UserIndividual userIndividual = new UserIndividual(oppoidx, "Riel");
                userIndividual.MessageChatButton += UserIndividual_MessageChatButton;
                AccountList.Controls.Add(userIndividual);
            }
            for (int i = 0; i < 8; i++) 
            {
                AccountList.Controls.Add(new blank2());
            }
        }

        private void option_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Xem tin nhắn đã ghim")
            {
                label3.Text = "Trở lại";
                MessageList.Controls.Clear();
                bool check = false;
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    List<string> parts = new List<string>();
                    parts.Add(messageList.Rows[i]["Sender"].ToString());
                    parts.Add(messageList.Rows[i]["Message"].ToString());
                    parts.Add(messageList.Rows[i]["Date"].ToString());
                    parts.Add(messageList.Rows[i]["Receiver"].ToString());
                    parts.Add(messageList.Rows[i]["Type"].ToString());
                    if ((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString() ||
                            Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()
                            ) && messageList.Rows[i]["Deleted"].ToString() == "0" && messageList.Rows[i]["Pinned"].ToString() == "1")
                    {
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                        messageUC.pinnedB += MessageUC_pinnedB2;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        MessageList.ScrollControlIntoView(messageUC);
                    }
                }
            }
            else
            {
                label3.Text = "Xem tin nhắn đã ghim";
                MessageList.Controls.Clear();
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    List<string> parts = new List<string>();
                    parts.Add(messageList.Rows[i]["Sender"].ToString());
                    parts.Add(messageList.Rows[i]["Message"].ToString());
                    parts.Add(messageList.Rows[i]["Date"].ToString());
                    parts.Add(messageList.Rows[i]["Receiver"].ToString());
                    parts.Add(messageList.Rows[i]["Type"].ToString());
                    if ((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString() ||
                            Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()
                            ) && messageList.Rows[i]["Deleted"].ToString() == "0")
                    {
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                        messageUC.pinnedB += MessageUC_pinnedB;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        MessageList.ScrollControlIntoView(messageUC);
                    }
                }
            }    
        }

        private void MessageUC_pinnedB2(object sender, EventArgs e)
        {
            if (sender is List<string> hehe)
            {    
                DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn muốn bỏ ghim tin nhắn này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageList.Controls.Clear();
                    for (int i = 0; i < messageList.Rows.Count; i++)
                    {
                        List<string> parts = new List<string>();
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        if ((hehe[0] == parts[0] && hehe[3] == parts[3] && hehe[2] == parts[2] && hehe[1] == parts[1]
                                ) && messageList.Rows[i]["Deleted"].ToString() == "0" && messageList.Rows[i]["Pinned"].ToString() == "1"
                                )
                        {
                            messageList.Rows[i]["Pinned"] = "0";
                            WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                            parts.Add(messageList.Rows[i]["Sender"].ToString());
                            parts.Add(messageList.Rows[i]["Message"].ToString());
                            parts.Add(messageList.Rows[i]["Date"].ToString());
                            parts.Add(messageList.Rows[i]["Receiver"].ToString());
                            parts.Add(messageList.Rows[i]["Type"].ToString());
                            MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                            messageUC.pinnedB += MessageUC_pinnedB2;
                            messageUC.deleteB += MessageUC_deleteB;
                            MessageList.Controls.Add(messageUC);
                            MessageList.ScrollControlIntoView(messageUC);
                        }
                    }
                    for (int i = 0; i < messageList.Rows.Count; i++)
                    {
                        if (((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString())
                        || (Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()))
                        && messageList.Rows[i]["Deleted"].ToString() == "0" && messageList.Rows[i]["Pinned"].ToString() == "1")
                        {
                            List<string> parts = new List<string>();
                            parts.Add(messageList.Rows[i]["Sender"].ToString());
                            parts.Add(messageList.Rows[i]["Message"].ToString());
                            parts.Add(messageList.Rows[i]["Date"].ToString());
                            parts.Add(messageList.Rows[i]["Receiver"].ToString());
                            parts.Add(messageList.Rows[i]["Type"].ToString());
                            MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                            messageUC.pinnedB += MessageUC_pinnedB;
                            messageUC.deleteB += MessageUC_deleteB;
                            MessageList.Controls.Add(messageUC);
                            MessageList.ScrollControlIntoView(messageUC);
                        }
                    }    
                    System.Windows.Forms.MessageBox.Show("Đã bỏ ghim tin nhắn này", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void UserIndividual_MessageChatButton(object sender, EventArgs e)
        {
            if(sender is int index2)
            {
                curr = index2;
                //System.Windows.Forms.MessageBox.Show(Convert.ToString(index2), "Thông báo", MessageBoxButtons.OK);
                MessageList.Controls.Clear();
                MessageBox.Text = "";
                string imagePath = userList2.Rows[index2]["Avatar"].ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    pictureBox2.ImageLocation = imagePath;
                }
                Username.Text = userList2.Rows[index2]["Name"].ToString();
                //string[] lines2 = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\Messages.txt");
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    if (((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(index2) == messageList.Rows[i]["Receiver"].ToString()) 
                        || (Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(index2) == messageList.Rows[i]["Sender"].ToString()))
                        && messageList.Rows[i]["Deleted"].ToString() == "0")
                    {
                        List<string> parts = new List<string>();
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                        messageUC.pinnedB += MessageUC_pinnedB;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        MessageList.ScrollControlIntoView(messageUC);
                    }
                }
            }    
        }

        private void MessageUC_deleteB(object sender, EventArgs e)
        {
            if (sender is List<string> hehe)
            {
                if (hehe[0] == Convert.ToString(index))
                {
                    DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn muốn xóa tin nhắn này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < messageList.Rows.Count; i++)
                        {
                            if ((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString())
                                && messageList.Rows[i]["Deleted"].ToString() == "0"
                                && messageList.Rows[i]["Message"].ToString() == hehe[1]
                                && messageList.Rows[i]["Date"].ToString() == hehe[2])
                            {
                                messageList.Rows[i]["Deleted"] = "1";
                                WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                                MessageList.Controls.Clear();
                                MessageBox.Text = "";
                                string imagePath = userList2.Rows[curr]["Avatar"].ToString();
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    pictureBox2.ImageLocation = imagePath;
                                }
                                Username.Text = userList2.Rows[curr]["Name"].ToString();
                                for (int j = 0; j < messageList.Rows.Count; j++)
                                {
                                    if (((Convert.ToString(index) == messageList.Rows[j]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[j]["Receiver"].ToString())
                                        || (Convert.ToString(index) == messageList.Rows[j]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[j]["Sender"].ToString()))
                                        && messageList.Rows[j]["Deleted"].ToString() == "0")
                                    {
                                        List<string> parts = new List<string>();
                                        parts.Add(messageList.Rows[j]["Sender"].ToString());
                                        parts.Add(messageList.Rows[j]["Message"].ToString());
                                        parts.Add(messageList.Rows[j]["Date"].ToString());
                                        parts.Add(messageList.Rows[j]["Receiver"].ToString());
                                        parts.Add(messageList.Rows[j]["Type"].ToString());
                                        MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                                        messageUC.pinnedB += MessageUC_pinnedB;
                                        messageUC.deleteB += MessageUC_deleteB;
                                        MessageList.Controls.Add(messageUC);
                                        MessageList.ScrollControlIntoView(messageUC);
                                    }
                                }
                                System.Windows.Forms.MessageBox.Show("Đã xóa tin nhắn này", "Thông báo", MessageBoxButtons.OK);
                                break;
                            }
                        }

                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Bạn không thể xóa tin nhắn này", "Thông báo", MessageBoxButtons.OK);
                }    
            }
        }

        private void MessageUC_pinnedB(object sender, EventArgs e)
        {
            if (sender is List<string> hehe)
            {
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    if (((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString())
                        || (Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()))
                        && messageList.Rows[i]["Deleted"].ToString() == "0"
                        && messageList.Rows[i]["Message"].ToString() == hehe[1]
                        && messageList.Rows[i]["Date"].ToString() == hehe[2])
                    {
                        if (messageList.Rows[i]["Pinned"].ToString() == "0")
                        {
                            DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn muốn ghim tin nhắn này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                messageList.Rows[i]["Pinned"] = "1";
                                WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                                System.Windows.Forms.MessageBox.Show("Đã ghim tin nhắn này", "Thông báo", MessageBoxButtons.OK);
                                break;
                            }
                        }
                        else
                        {
                            DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn muốn bỏ ghim tin nhắn này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                messageList.Rows[i]["Pinned"] = "0";
                                WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                                System.Windows.Forms.MessageBox.Show("Đã bỏ ghim tin nhắn này", "Thông báo", MessageBoxButtons.OK);
                                break;
                            }
                        }    
                    }
                }
                
            }
        }

        private void BackFBButton_Click(object sender, EventArgs e)
        {
            backButton?.Invoke(this, EventArgs.Empty);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private Dictionary<System.Windows.Forms.Button, string> buttonImagePaths = new Dictionary<System.Windows.Forms.Button, string>();
        private void ReactionButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Visible == false)
            {
                string[] imageFiles = Directory.GetFiles("D:\\CS511\\Thuchanh\\[CS511]btth1\\[CS511]btth1\\Resources\\ReactionList\\", "*.*")
                    .Where(file => file.ToLower().EndsWith(".jpg") ||
                                   file.ToLower().EndsWith(".jpeg") ||
                                   file.ToLower().EndsWith(".png") ||
                                   file.ToLower().EndsWith(".gif") ||
                                   file.ToLower().EndsWith(".bmp"))
                    .ToArray();

                foreach (string imagePath in imageFiles)
                {
                    System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.White;
                    button.Cursor = Cursors.Hand;
                    button.AutoSize = true;
                    System.Drawing.Image buttonImage = System.Drawing.Image.FromFile(imagePath);
                    button.Image = buttonImage;
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    button.Click += Button_Click;
                    buttonImagePaths.Add(button, imagePath);
                    flowLayoutPanel1.Controls.Add(button);
                }

                flowLayoutPanel1.Visible = true;
            }
            else
            {
                flowLayoutPanel1.Visible = false;
            }
        }
        public bool AreImagesEqual(System.Drawing.Image image1, System.Drawing.Image image2)
        {
            // Convert images to Bitmap
            using (Bitmap bitmap1 = new Bitmap(image1))
            using (Bitmap bitmap2 = new Bitmap(image2))
            {
                // Compare dimensions
                if (bitmap1.Width != bitmap2.Width || bitmap1.Height != bitmap2.Height)
                {
                    return false;
                }

                // Compare pixel data
                for (int y = 0; y < bitmap1.Height; y++)
                {
                    for (int x = 0; x < bitmap1.Width; x++)
                    {
                        if (bitmap1.GetPixel(x, y) != bitmap2.GetPixel(x, y))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button button)
            {
                string date = Convert.ToString(DateTime.Now);
                DataRow newRow = messageList.NewRow();
                newRow["Sender"] = Convert.ToString(index);
                string[] imageFiles = Directory.GetFiles("D:\\CS511\\Thuchanh\\[CS511]btth1\\[CS511]btth1\\Resources\\ReactionList\\", "*.*")
                    .Where(file => file.ToLower().EndsWith(".jpg") ||
                                   file.ToLower().EndsWith(".jpeg") ||
                                   file.ToLower().EndsWith(".png") ||
                                   file.ToLower().EndsWith(".gif") ||
                                   file.ToLower().EndsWith(".bmp"))
                    .ToArray();

                foreach (string imagePath in imageFiles)
                {
                    if (AreImagesEqual(button.Image, System.Drawing.Image.FromFile(imagePath)))
                    {
                        newRow["Message"] = imagePath;
                        break;
                    }    
                }    
                newRow["Date"] = date;
                newRow["Receiver"] = Convert.ToString(curr);
                newRow["Type"] = "Icon";
                newRow["Pinned"] = "0";
                newRow["Deleted"] = "0";
                messageList.Rows.Add(newRow);
                WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                MessageUC messageUC = new MessageUC(userList2, Convert.ToString(index), newRow["Message"].ToString(), date, Convert.ToString(curr), "Icon");
                messageUC.pinnedB += MessageUC_pinnedB;
                messageUC.deleteB += MessageUC_deleteB;
                MessageList.Controls.Add(messageUC);
                foreach (Control control in AccountList.Controls)
                {
                    if (control is UserIndividual lmeo)
                        if (lmeo.index == curr)
                        {
                            AccountList.Controls.SetChildIndex(control, 0);
                        }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AccountList.Controls.Clear();
            if (textBox1.Text != "")
            {
                for (int i = 0; i < userList2.Rows.Count; i++)
                {
                    if (userList2.Rows[i]["Name"].ToString().ToLower().Contains(textBox1.Text.ToLower())
                        || userList2.Rows[i]["Username"].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        UserIndividual userIndividual = new UserIndividual(i, "Riel");
                        userIndividual.MessageChatButton += UserIndividual_MessageChatButton;
                        AccountList.Controls.Add(userIndividual);
                    }
                }
            }
            else
            {
                messidx.Clear();
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    if (messageList.Rows[i]["Sender"].ToString() == Convert.ToString(index))
                    {
                        if (!messidx.Contains(messageList.Rows[i]["Receiver"].ToString()))
                            messidx.Add(messageList.Rows[i]["Receiver"].ToString());
                    }
                }

                for (int i = 0; i < messidx.Count; i++)
                {
                    int oppoidx = Convert.ToInt32(messidx[i]);
                    UserIndividual userIndividual = new UserIndividual(oppoidx, "Riel");
                    userIndividual.MessageChatButton += UserIndividual_MessageChatButton;
                    AccountList.Controls.Add(userIndividual);
                }
                for (int i = 0; i < 8; i++)
                {
                    AccountList.Controls.Add(new blank2());
                }
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = Convert.ToString(DateTime.Now);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image and Video Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.mp4; *.avi; *.mov; *.wmv)|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.mp4; *.avi; *.mov; *.wmv|Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|Video Files (*.mp4; *.avi; *.mov; *.wmv)|*.mp4; *.avi; *.mov; *.wmv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    string extension = System.IO.Path.GetExtension(fileName).ToLower();
                    if (extension == ".mp4" || extension == ".avi" || extension == ".mov" || extension == ".wmv")
                    {
                        DataRow newRow = messageList.NewRow();
                        newRow["Sender"] = Convert.ToString(index);
                        newRow["Message"] = fileName;
                        newRow["Date"] = date;
                        newRow["Receiver"] = Convert.ToString(curr);
                        newRow["Type"] = "Video";
                        newRow["Pinned"] = "0";
                        newRow["Deleted"] = "0";
                        messageList.Rows.Add(newRow);
                        WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                        MessageUC messageUC = new MessageUC(userList2, Convert.ToString(index), fileName, date, Convert.ToString(curr), "Video");
                        messageUC.pinnedB += MessageUC_pinnedB;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        foreach (Control control in AccountList.Controls)
                        {
                            if (control is UserIndividual lmeo)
                                if (lmeo.index == curr)
                                {
                                    AccountList.Controls.SetChildIndex(control, 0);
                                }
                        }
                    } 
                    else
                    {
                        DataRow newRow = messageList.NewRow();
                        newRow["Sender"] = Convert.ToString(index);
                        newRow["Message"] = fileName;
                        newRow["Date"] = date;
                        newRow["Receiver"] = Convert.ToString(curr);
                        newRow["Type"] = "Image";
                        newRow["Pinned"] = "0";
                        newRow["Deleted"] = "0";
                        messageList.Rows.Add(newRow);
                        WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
                        MessageUC messageUC = new MessageUC(userList2, Convert.ToString(index), fileName, date, Convert.ToString(curr), "Image");
                        messageUC.pinnedB += MessageUC_pinnedB;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        foreach (Control control in AccountList.Controls)
                        {
                            if (control is UserIndividual lmeo)
                                if (lmeo.index == curr)
                                {
                                    AccountList.Controls.SetChildIndex(control, 0);
                                }
                        }
                    }
                }
            }
        }

        private void findtext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageList.Controls.Clear();
                if (findtext.Text != "")
                {
                    bool check = false;
                    for (int i = 0; i < messageList.Rows.Count; i++)
                    {
                        List<string> parts = new List<string>();
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        
                        if ((Convert.ToInt32(parts[0]) == index && Convert.ToInt32(parts[3]) == curr 
                            || Convert.ToInt32(parts[3]) == index && Convert.ToInt32(parts[0]) == curr
                            ) && messageList.Rows[i]["Deleted"].ToString() == "0")
                        {
                            MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                            messageUC.pinnedB += MessageUC_pinnedB;
                            messageUC.deleteB += MessageUC_deleteB;
                            if (parts[4] != "Text") continue;
                            if (messageUC.richTextBox1.Text.ToLower().Contains(findtext.Text.ToLower()))
                            {
                                int startIndex = messageUC.richTextBox1.Find(findtext.Text);

                                // Set the length of the text to highlight
                                int length = findtext.Text.Length;

                                // Check if the text to highlight was found
                                if (startIndex != -1)
                                {
                                    // Set the selection to the specified text range
                                    messageUC.richTextBox1.Select(startIndex, length);
                                    messageUC.richTextBox1.SelectionBackColor = Color.Red;
                                    check = true;
                                }
                                MessageList.Controls.Add(messageUC);
                                MessageList.ScrollControlIntoView(messageUC);
                            }
                        }
                    }
                    if (!check)
                    {
                        System.Windows.Forms.MessageBox.Show("Đoạn tin nhắn không tìm thấy", "Thông báo");
                    }
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show(Convert.ToString(index2), "Thông báo", MessageBoxButtons.OK);
                    MessageList.Controls.Clear();
                    MessageBox.Text = "";
                    string imagePath = userList2.Rows[curr]["Avatar"].ToString();
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        pictureBox2.ImageLocation = imagePath;
                    }
                    Username.Text = userList2.Rows[curr]["Name"].ToString();
                    //string[] lines2 = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\Messages.txt");
                    for (int i = 0; i < messageList.Rows.Count; i++)
                    {
                        if ((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString() ||
                            Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()
                            ) && messageList.Rows[i]["Deleted"].ToString() == "0")
                        {
                            List<string> parts = new List<string>();
                            parts.Add(messageList.Rows[i]["Sender"].ToString());
                            parts.Add(messageList.Rows[i]["Message"].ToString());
                            parts.Add(messageList.Rows[i]["Date"].ToString());
                            parts.Add(messageList.Rows[i]["Receiver"].ToString());
                            parts.Add(messageList.Rows[i]["Type"].ToString());
                            MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                            messageUC.pinnedB += MessageUC_pinnedB;
                            messageUC.deleteB += MessageUC_deleteB;
                            MessageList.Controls.Add(messageUC);
                            MessageList.ScrollControlIntoView(messageUC);
                        }
                    }
                }
            }
        }

        private void findtext_TextChanged(object sender, EventArgs e)
        {
            if (findtext.Text == "")
            {
                MessageList.Controls.Clear();
                MessageBox.Text = "";
                string imagePath = userList2.Rows[curr]["Avatar"].ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    pictureBox2.ImageLocation = imagePath;
                }
                Username.Text = userList2.Rows[curr]["Name"].ToString();
                for (int i = 0; i < messageList.Rows.Count; i++)
                {
                    if (((Convert.ToString(index) == messageList.Rows[i]["Sender"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Receiver"].ToString() 
                        || Convert.ToString(index) == messageList.Rows[i]["Receiver"].ToString() && Convert.ToString(curr) == messageList.Rows[i]["Sender"].ToString()))
                        && messageList.Rows[i]["Deleted"].ToString() == "0")
                    {
                        List<string> parts = new List<string>();
                        parts.Add(messageList.Rows[i]["Sender"].ToString());
                        parts.Add(messageList.Rows[i]["Message"].ToString());
                        parts.Add(messageList.Rows[i]["Date"].ToString());
                        parts.Add(messageList.Rows[i]["Receiver"].ToString());
                        parts.Add(messageList.Rows[i]["Type"].ToString());
                        MessageUC messageUC = new MessageUC(userList2, parts[0], parts[1], parts[2], parts[3], parts[4]);
                        messageUC.pinnedB += MessageUC_pinnedB;
                        messageUC.deleteB += MessageUC_deleteB;
                        MessageList.Controls.Add(messageUC);
                        MessageList.ScrollControlIntoView(messageUC);
                    }
                }
            }    
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string date = Convert.ToString(DateTime.Now);
            DataRow newRow = messageList.NewRow();
            newRow["Sender"] = Convert.ToString(index);
            newRow["Message"] = Convert.ToString(MessageBox.Text);
            newRow["Date"] = date;
            newRow["Receiver"] = Convert.ToString(curr);
            newRow["Type"] = "Text";
            newRow["Pinned"] = "0";
            newRow["Deleted"] = "0";
            messageList.Rows.Add(newRow);
            WriteDataTableToCsv("..\\..\\Data\\Messages.csv", messageList);
            MessageUC messageUC = new MessageUC(userList2, Convert.ToString(index), MessageBox.Text, date, Convert.ToString(curr), "Text");
            messageUC.pinnedB += MessageUC_pinnedB;
            messageUC.deleteB += MessageUC_deleteB;
            MessageList.Controls.Add(messageUC);
            MessageBox.Text = "";
            foreach (Control control in AccountList.Controls)
            {
                if (control is UserIndividual lmeo)
                    if (lmeo.index == curr)
                    {
                        AccountList.Controls.SetChildIndex(control, 0);
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

        private void Friends_Load(object sender, EventArgs e)
        {

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
