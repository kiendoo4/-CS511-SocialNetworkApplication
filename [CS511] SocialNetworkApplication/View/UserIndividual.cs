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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class UserIndividual : UserControl
    {
        public event EventHandler MessageChatButton;
        public event EventHandler ChangeButton;
        private Color borderColor = Color.White;
        private bool isMouseOver = false;
        public DataTable userList = new DataTable();
        public int index = -1;
        public UserIndividual()
        {
            InitializeComponent();
        }
        public UserIndividual(int idx, string role)
        {
            InitializeComponent();
            index = idx;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            this.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
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
                int i = 0;
                while (csv.Read())
                {
                    var row = userList.NewRow();
                    foreach (DataColumn column in userList.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    
                    userList.Rows.Add(row);
                    if (i == idx)
                    {
                        NameUser.Text = row["Name"].ToString();
                        Avatar.ImageLocation = row["Avatar"].ToString();
                    }
                    i++;
                }  
            }
            Avatar.Cursor = Cursors.Hand;
            Avatar.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            Avatar.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            NameUser.Cursor = Cursors.Hand;
            NameUser.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            NameUser.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            this.Cursor = Cursors.Hand;
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, Avatar.Width - 1, Avatar.Height - 1);
                Region region = new Region(gp);
                Avatar.Region = region;
            }
            if (role == "Main")
            {
                this.Click += UserIndividual_Click;
                NameUser.Click += UserIndividual_Click;
                Avatar.Click += UserIndividual_Click;
            }
            if (role == "Mess")
            {
                this.Click += UserIndividual_Click1;
                NameUser.Click += UserIndividual_Click1;
                Avatar.Click += UserIndividual_Click1;
            }
            if(role == "Riel")
            {
                this.Click += UserIndividual_Click3;
                NameUser.Click += UserIndividual_Click3;
                Avatar.Click += UserIndividual_Click3;
            }    
        }
        private void UserIndividual_Click3(object sender, EventArgs e)
        {
            MessageChatButton?.Invoke(index, e);
        }
        private void UserIndividual_Click1(object sender, EventArgs e)
        {
            ChangeButton?.Invoke(index, e);
        }

        private void UserIndividual_Click(object sender, EventArgs e)
        {
            ChangeButton?.Invoke(Convert.ToString(index), e);
        }

        public UserIndividual(int idx, string role, string path)
        {
            InitializeComponent();
            index = idx;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            this.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            Avatar.Cursor = Cursors.Hand;
            Avatar.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            Avatar.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            NameUser.Cursor = Cursors.Hand;
            NameUser.MouseEnter += new EventHandler(MyUserControl_MouseEnter);
            NameUser.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
            this.Cursor = Cursors.Hand;
            Avatar.ImageLocation = path;
            NameUser.Text = role;
            this.Click += UserIndividual_Click2;
            NameUser.Click += UserIndividual_Click2;
            Avatar.Click += UserIndividual_Click2;
        }

        private void UserIndividual_Click2(object sender, EventArgs e)
        {
            ChangeButton?.Invoke("Opt", e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageChatButton?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;
            borderColor = Color.Blue; // Change border color on mouse enter
            this.Invalidate(); // Force the control to be redrawn
        }

        private void MyUserControl_MouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            borderColor = Color.White; // Revert border color on mouse leave
            this.Invalidate(); // Force the control to be redrawn
        }
    }
}