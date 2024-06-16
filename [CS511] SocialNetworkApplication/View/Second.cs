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
using CsvHelper;
using CsvHelper.Configuration;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Second : UserControl
    {
        public UserUC userUC2 = new UserUC();
        static DataTable postList = new DataTable();
        static DataTable userList = new DataTable();
        static int index = -1;
        List<UserIndividual> userMessList = new List<UserIndividual>();
        List<Control> friendControl = new List<Control>();
        public Second()
        {
            InitializeComponent();
        }
        public Second(int idx) 
        {
            InitializeComponent();
            index = idx;
            ChatSmall.Visible = false;
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

            userUC2 = new UserUC(index);
            userUC2.changeButton += UserUC2_changeButton;
            userUC.Controls.Add(userUC2);
            //showPost();
            flowPost.FlowDirection = FlowDirection.TopDown;
            flowPost.WrapContents = false;
            flowPost.AutoScroll = true;
            socialUC.Controls.Add(flowPost);
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            showListMessageFr(index);
        }

        private void UserUC2_changeButton(object sender, EventArgs e)
        {
            if (sender is string option)
            {
                if(option == "Mess")
                {
                    MessageUC messageUC = new MessageUC(userList, index);
                    messageUC.backButton += MessageUC_backButton;
                    Panel Message = new Panel();
                    Message.Width = this.Width;
                    Message.Height = this.Height;
                    Message.Location = this.Location;
                    Message.Visible = true;
                    Message.Dock = DockStyle.Fill;
                    Controls.Add(Message);
                    Controls.SetChildIndex(Message, 0);
                    Message.Controls.Add(messageUC);
                }
                if(option == "Friend")
                {
                    Friends friends = new Friends(userList, index);
                    friends.changeButton += Friends_changeButton;
                    flowPost.Controls.Clear();
                    flowPost.Controls.Add(friends);
                }    
                if(option == "User")
                {
                    //Head head = new Head();
                    Panel User = new Panel();
                    User.Width = this.Width;
                    User.Height = this.Height;
                    User.Location = this.Location;
                    User.Visible = true;
                    User.Dock = DockStyle.Fill;
                    //User.Controls.Add(head);
                    //Controls.Add(User);
                    //Controls.SetChildIndex(User, 0);

                    MainUserUC mainUserUC = new MainUserUC(userList, index, "User");
                    mainUserUC.backButton += MainUserUC_backButton;
                    User.Controls.Add(mainUserUC);
                    Controls.Add(User);
                    Controls.SetChildIndex(User, 0);
                }    
            }    
        }


        private void Friends_changeButton(object sender, EventArgs e)
        {
            if (sender is int index2)
            {
                Panel User = new Panel();
                User.Width = this.Width;
                User.Height = this.Height;
                User.Location = this.Location;
                User.Visible = true;
                User.Dock = DockStyle.Fill;
                MainUserUC mainUserUC = new MainUserUC(userList, index2, "Other");
                mainUserUC.backButton += MainUserUC_backButton;
                User.Controls.Add(mainUserUC);
                Controls.Add(User);
                Controls.SetChildIndex(User, 0);
            }    
        }

        private void MainUserUC_backButton(object sender, EventArgs e)
        {
            DataTable userList2 = new DataTable();
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
                    userList2.Columns.Add(header);
                }

                // Đọc các dòng còn lại và thêm vào DataTable
                while (csv.Read())
                {
                    var row = userList2.NewRow();
                    foreach (DataColumn column in userList2.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    userList2.Rows.Add(row);
                }
            }
            userUC2.userIndividual.Avatar.ImageLocation = userList2.Rows[index]["Avatar"].ToString();
            userUC2.userIndividual.NameUser.Text = userList2.Rows[index]["Name"].ToString();
            userList = userList2;
            Controls.RemoveAt(0);
        }

        private void MessageUC_backButton(object sender, EventArgs e)
        {
            Controls.RemoveAt(0);
        }

        public void showPost(string username)
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
                foreach (DataRow row in postList.Rows)
                {
                    
                    MessageBox.Show(row[3].ToString());
                }
            }
        }
        private void showListMessageFr(int index) 
        {
            for (int i = 0; i < userList.Rows.Count; i++) 
            {
                userMessList.Add(new UserIndividual(i, "Mess"));
                userMessList[i].ChangeButton += Second_ChangeButton;
                flowLayoutPanel2.Controls.Add(userMessList[i]);
               
            }
            for (int i = 0; i < 6; i++)
            {
                flowLayoutPanel2.Controls.Add(new blank());
            }    
        }

        private void Second_ChangeButton(object sender, EventArgs e)
        {
            if(sender is int receiver_index) 
            {
                ChatsmallUC chatsmallUC = new ChatsmallUC(userList, receiver_index);
                chatsmallUC.exitButton += ChatsmallUC_exitButton;
                if (ChatSmall.Controls.Count == 0)
                {
                    ChatSmall.Controls.Add(chatsmallUC);
                    ChatSmall.Visible = true;
                }
                else
                {
                    ChatSmall.Controls.Clear();
                    ChatSmall.Controls.Add(chatsmallUC);
                    //ChatSmall.Visible = true;
                }    
            }
        }

        private void ChatsmallUC_exitButton(object sender, EventArgs e)
        {
            ChatSmall.Visible = false;
            ChatSmall.Controls.Clear();
        }
    }
}
