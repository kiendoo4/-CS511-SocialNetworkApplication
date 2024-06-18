using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class GetPassword : UserControl
    {
        public event EventHandler ButtonClicked;
        DataTable userList = new DataTable();
        public GetPassword()
        {
            InitializeComponent();
            Backbutton.Cursor = Cursors.Hand;
            GetPwButton.Cursor = Cursors.Hand;
            GetPwButton.MouseEnter += (sender, e) => GetPwButton.BackColor = Color.LightCoral;
            GetPwButton.MouseLeave += (sender, e) => GetPwButton.BackColor = Color.IndianRed;
            Backbutton.MouseEnter += (sender, e) => Backbutton.BackColor = Color.LightCoral;
            Backbutton.MouseLeave += (sender, e) => Backbutton.BackColor = Color.IndianRed;
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
        private void Backbutton_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void GetPwButton_Click(object sender, EventArgs e)
        {
            bool checkacc = false;
            for(int i = 0; i < userList.Rows.Count; i++)
            {
                if (username.Text == userList.Rows[i]["Username"].ToString() && fullname.Text == userList.Rows[i]["Name"].ToString() && userList.Rows[i]["Email"].ToString() == gmail.Text)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("koke36354@gmail.com", "jqnw uqwm rlzo vbdl");
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("koke36354@gmail.com");
                        message.To.Add(gmail.Text);
                        message.Subject = "Mật khẩu của bạn";
                        message.Body = "Mật khẩu của bạn là: " + userList.Rows[i]["Password"].ToString();
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    checkacc = true;
                    break;
                }    
            }
            if (checkacc)
                MessageBox.Show("Đã gửi mã", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập", "Thông báo", MessageBoxButtons.OK);
        }
    }
}
