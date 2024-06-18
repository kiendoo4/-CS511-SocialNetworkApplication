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
using _CS511__SocialNetworkApplication.View.InsideMainUserUC;
using CsvHelper.Configuration;
using CsvHelper;
using System.Collections;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class MainUserUC : UserControl
    {
        public event EventHandler backButton;
        Head head1 = new Head();
        Infomation infomation = new Infomation();
        Panel main = new Panel();
        FlowLayoutPanel insideMain = new FlowLayoutPanel();
        FlowLayoutPanel infoinMain = new FlowLayoutPanel();
        FlowLayoutPanel friendList = new FlowLayoutPanel();
        FlowLayoutPanel listF = new FlowLayoutPanel();
        DataTable userList2 = new DataTable();
        int index = -1;
        List<EachFriend> lf = new List<EachFriend>();
        public MainUserUC()
        {
            InitializeComponent();
        }
        public MainUserUC(DataTable userList, int idx, string role)
        {
            InitializeComponent();
            userList2 = userList;
            index = idx;
            // Create and configure the main panel
            
            main.Location = new Point(0, 0);  // Set location relative to the form
            main.Size = this.ClientSize;  // Set size relative to the form's client area
            main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;  // Ensure it resizes with the form

            // Create and configure the insideMain panel

            insideMain.Dock = DockStyle.Fill;  // Fill the main panel
            insideMain.FlowDirection = FlowDirection.TopDown;
            insideMain.WrapContents = false;
            insideMain.AutoScroll = true;

            infoinMain.Dock = DockStyle.Fill;
            infoinMain.FlowDirection = FlowDirection.LeftToRight;
            infoinMain.WrapContents = false;
            infoinMain.AutoSize = true;

            friendList.Dock = DockStyle.Fill;
            friendList.FlowDirection = FlowDirection.TopDown;
            friendList.WrapContents = false;
            friendList.AutoSize = true;

            // Add insideMain to main panel
            main.Controls.Add(insideMain);

            // Add main panel to the UserControl
            this.Controls.Add(main);

            // Add controls based on role
            if (role == "User")
            {
                Head head1 = new Head(userList, idx, role);
                head1.backButton += Head1_backButton;
                head1.friendButton += Head1_friendButton;
                head1.postButton += Head1_postButton;
                insideMain.Controls.Add(head1);
                Infomation infomation = new Infomation(userList, idx, role);
                infomation.Location = new Point(head1.Location.X + head1.Width + 20, head1.Location.Y + head1.Height + 20);
                infoinMain.Controls.Add(infomation);
                insideMain.Controls.Add(infoinMain);
            }
            if (role == "Other")
            {
                head1 = new Head(userList, idx, role);
                head1.backButton += Head1_backButton;
                head1.friendButton += Head1_friendButton;
                head1.postButton += Head1_postButton;
                insideMain.Controls.Add(head1);
                infomation = new Infomation(userList, idx, role);
                infomation.Location = new Point(head1.Location.X + head1.Width + 20, head1.Location.Y + head1.Height + 20);
                infoinMain.Controls.Add(infomation);
                insideMain.Controls.Add(infoinMain);
            }    
        }

        private void Head1_postButton(object sender, EventArgs e)
        {
            if (sender is int ind)
            {
                MessageBox.Show(ind.ToString());
            }    
        }

        private void Head1_friendButton(object sender, EventArgs e)
        {
            friendList.Controls.Clear();
            listF.Controls.Clear();
            lf.Clear();
            //string[] test = new string[];
            Label theme = new Label();
            theme.Name = "themeLabel";
            theme.AutoSize = true;
            theme.Font = new Font("Paytone One", 20, FontStyle.Bold);
            theme.ForeColor = Color.Black;
            theme.Text = "Danh sách bạn bè";
            theme.Margin = new Padding(0, 0, 0, 0);  // Add some left margin
            // Add the theme label to the new panel
            friendList.Controls.Add(theme);
            listF.FlowDirection = FlowDirection.LeftToRight;
            listF.Width = 1220;
            listF.Height = 354;
            listF.AutoScroll = true;
            listF.WrapContents = false;
            listF.BorderStyle = BorderStyle.FixedSingle;
            List<string> frList = userList2.Rows[index]["FriendList"].ToString().Split('*').ToList();
            foreach (string invite in frList)
                {
                    if (invite == "") continue;
                    lf.Add(new EachFriend(userList2, Convert.ToInt32(invite), "Friend"));
                    lf[lf.Count - 1].changeButton += Friends_changeButton;
                    lf[lf.Count - 1].optionButton += Friends_optionButton;
                    listF.Controls.Add(lf[lf.Count - 1]);
                }
            
            friendList.Controls.Add(listF);
            infoinMain.Controls.Add(friendList);
        }

        private void Friends_optionButton(object sender, EventArgs e)
        {
            if(sender is int index2)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn hủy kết bạn với người này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string[] frList = userList2.Rows[index]["FriendList"].ToString().Split('*');
                    List<string> frListAsList = new List<string>(frList);
                    string elementToRemove = Convert.ToString(index2);
                    frListAsList.Remove(elementToRemove);
                    frList = frListAsList.ToArray();
                    userList2.Rows[index]["FriendList"] = string.Join("*", frList);
                    WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);

                    string[] frList2 = userList2.Rows[index2]["FriendList"].ToString().Split('*');
                    List<string> frListAsList2 = new List<string>(frList2);
                    string elementToRemove2 = Convert.ToString(index);
                    frListAsList2.Remove(elementToRemove2);
                    frList2 = frListAsList2.ToArray();

                    userList2.Rows[index2]["FriendList"] = string.Join("*", frList2);
                    WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);
                    listF.Controls.Clear();
                    frList = userList2.Rows[index]["FriendList"].ToString().Split('*');
                    lf.Clear();
                    //head1.numofFriend.Text = frList.Length.ToString() + " bạn bè";
                    Label numofFriend = new Label();
                    numofFriend.Font = new Font("Quicksand", 14, FontStyle.Bold);
                    numofFriend.AutoSize = true;
                    head1.panel6.Controls.Clear();
                    head1.panel6.Controls.Add(numofFriend);

                    foreach (string invite in frList)
                    {
                        if(invite == "") continue;
                        lf.Add(new EachFriend(userList2, Convert.ToInt32(invite), "Friend"));
                        lf[lf.Count - 1].changeButton += Friends_changeButton;
                        lf[lf.Count - 1].optionButton += Friends_optionButton;
                        listF.Controls.Add(lf[lf.Count - 1]);
                    }
                    head1.Lmeoo_Click(userList2, index);
                    head1.Invalidate();
                    head1.Refresh();
                    //changeInfo?.Invoke(frList.ToString().Split('*').Length, EventArgs.Empty);
                    MessageBox.Show("Đã xóa khỏi danh sách", "Thông báo", MessageBoxButtons.OK);
                }
            }    
        }

        private void Friends_changeButton(object sender, EventArgs e)
        {
            //MessageBox.Show("Bạn có muốn hủy kết bạn với người này?");
            //DialogResult result = MessageBox.Show("Would you like to proceed?", "Choose an option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (result == DialogResult.Yes)
            //{
            //    MessageBox.Show("You clicked Yes!");
            //}
            //else if (result == DialogResult.No)
            //{
            //    MessageBox.Show("You clicked No!");
            //}
        }

        private void Head1_backButton(object sender, EventArgs e)
        {
            backButton?.Invoke(sender, e);
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
