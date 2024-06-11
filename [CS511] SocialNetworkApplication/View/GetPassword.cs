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

namespace _CS511__SocialNetworkApplication.View
{
    public partial class GetPassword : UserControl
    {
        public event EventHandler ButtonClicked;
        public GetPassword()
        {
            InitializeComponent();
            Backbutton.Cursor = Cursors.Hand;
            GetPwButton.Cursor = Cursors.Hand;
            GetPwButton.MouseEnter += (sender, e) => GetPwButton.BackColor = Color.LightCoral;
            GetPwButton.MouseLeave += (sender, e) => GetPwButton.BackColor = Color.IndianRed;
            Backbutton.MouseEnter += (sender, e) => Backbutton.BackColor = Color.LightCoral;
            Backbutton.MouseLeave += (sender, e) => Backbutton.BackColor = Color.IndianRed;
        }
        private void Backbutton_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void GetPwButton_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserList.txt");
            bool checkacc = false;
            foreach (string line in lines)
            {
                string[] parts = line.Split('*');
                if (parts[0] == username.Text && parts[4] == gmail.Text)
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
                        message.Body = "Mật khẩu của bạn là: " + parts[5];
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
