using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class ChangingPassword : UserControl
    {
        public event EventHandler backButton, ButtonClicked;
        bool checkingPw = false;
        int index = -1;
        DataTable userList2 = new DataTable();
        string sixDigitNumber = "";
        CheckGmailForRegistration checkgm = new CheckGmailForRegistration();
        public ChangingPassword()
        {
            InitializeComponent();
        }
        public ChangingPassword(DataTable userList, int idx)
        {
            InitializeComponent();
            userList2 = userList;
            index = idx;
            panel1.Visible = false;
            DoneButton.Click += DoneButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            backButton?.Invoke(this, EventArgs.Empty);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (recentpass.Text == "" || confirmpass.Text == "" || recentpass.Text == "")
            {
                MessageBox.Show("Không được để trống các trường", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (newpass.Text != confirmpass.Text || recentpass.Text != userList2.Rows[index]["Password"].ToString())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                }   
                else
                {
                    Random random = new Random();
                    int number = random.Next(0, 1000000); // Generates a number between 0 and 999999
                    sixDigitNumber = number.ToString("D6");
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("koke36354@gmail.com", "jqnw uqwm rlzo vbdl");
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("koke36354@gmail.com");
                    message.To.Add(userList2.Rows[index]["Email"].ToString());
                    message.Subject = "Mã xác nhận";
                    message.Body = "Mã xác nhận của bạn là: " + sixDigitNumber;
                    client.Send(message);
                    MessageBox.Show("Chúng tôi đã gửi mã xác nhận (gồm 6 chữ số) về gmail của bạn, vui lòng kiểm tra và nhập mã", "Thông báo", MessageBoxButtons.OK);
                    checkgm = new CheckGmailForRegistration(sixDigitNumber);
                    checkgm.buttonclick += Checkgm_buttonclick;
                    checkgm.backbuttonclick += Checkgm_backbuttonclick;
                    checkgm.sendcodeclick += Checkgm_sendcodeclick;
                    panel1.Controls.Add(checkgm);
                    panel1.Visible = true;
                }
            }    
        }

        private void Checkgm_sendcodeclick(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(0, 1000000); // Generates a number between 0 and 999999
            sixDigitNumber = number.ToString("D6");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("koke36354@gmail.com", "jqnw uqwm rlzo vbdl");
            MailMessage message = new MailMessage();
            message.From = new MailAddress("koke36354@gmail.com");
            message.To.Add(userList2.Rows[index]["Email"].ToString());
            message.Subject = "Mã xác nhận";
            message.Body = "Mã xác nhận của bạn là: " + sixDigitNumber;
            client.Send(message);
            MessageBox.Show("Chúng tôi đã gửi mã xác nhận (gồm 6 chữ số) về gmail của bạn, vui lòng kiểm tra và nhập mã", "Thông báo", MessageBoxButtons.OK);
            checkgm = new CheckGmailForRegistration(sixDigitNumber);
            checkgm.buttonclick += Checkgm_buttonclick;
            checkgm.backbuttonclick += Checkgm_backbuttonclick;
            checkgm.sendcodeclick += Checkgm_sendcodeclick;
            panel1.Controls.Clear();
            panel1.Controls.Add(checkgm);
        }

        private void Checkgm_backbuttonclick(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Controls.Clear();
        }

        private void Checkgm_buttonclick(object sender, EventArgs e)
        {
            if (sender is true)
            {
                checkingPw = true;
                userList2.Rows[index]["Password"] = newpass.Text;
                WriteDataTableToCsv("../../Data/User.csv", userList2);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);              
                panel1.Visible = false;
                panel1.Controls.Clear();
            }
            else
            {
                checkingPw = false;
                MessageBox.Show("Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
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
