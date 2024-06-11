using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Registration : UserControl
    {
        public event EventHandler ButtonClicked;
        bool checkingPw = false;
        string sixDigitNumber;
        CheckGmailForRegistration checkgm = new CheckGmailForRegistration();
        public Registration()
        {
            InitializeComponent();
            Gender.Items.Add("Nam");
            Gender.Items.Add("Nữ");
            Gender.DropDownStyle = ComboBoxStyle.DropDownList;
            Gender.SelectedIndex = 0;
            ProfileImage.BorderStyle = BorderStyle.FixedSingle;
            ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
            ChooseProfileIm.Cursor = Cursors.Hand;
            Backbutton.Cursor = Cursors.Hand;
            FinishButton.Cursor = Cursors.Hand;
            FinishButton.MouseEnter += (sender, e) => FinishButton.BackColor = Color.LightCoral;
            FinishButton.MouseLeave += (sender, e) => FinishButton.BackColor = Color.IndianRed;
            Backbutton.MouseEnter += (sender, e) => Backbutton.BackColor = Color.LightCoral;
            Backbutton.MouseLeave += (sender, e) => Backbutton.BackColor = Color.IndianRed;
            ChooseProfileIm.MouseEnter += (sender, e) => ChooseProfileIm.BackColor = Color.LightCoral;
            ChooseProfileIm.MouseLeave += (sender, e) => ChooseProfileIm.BackColor = Color.IndianRed;
            panel1.Visible = false;
        }
        private void Backbutton_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void ChooseProfileIm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                ProfileImage.ImageLocation = imagePath;
            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || Password.Text == "" || CheckPassword.Text == "" || gmail.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (Password.Text != CheckPassword.Text)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string[] lines = File.ReadAllLines("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\UserList.txt");
                    bool checkus = true;
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('*');
                        if (parts[0] == username.Text)
                        {
                            checkus = false;
                            break;
                        }
                    }
                    if (!checkus) MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    else
                    {
                        
                        try
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
                            message.To.Add(gmail.Text);
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
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
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
            message.To.Add(gmail.Text);
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
                string filePath = @"D:\CS511\Doan\[CS511] SocialNetworkApplication\[CS511] SocialNetworkApplication\Data\UserList.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{username.Text}*{hoten.Text}*{BornDate.Text}*{Gender.Text}*{gmail.Text}*{Password.Text}*{ProfileImage.ImageLocation}");
                }
                MessageBox.Show("Đã đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
                ButtonClicked?.Invoke(this, EventArgs.Empty);
            }    
            else
            {
                checkingPw = false;
                MessageBox.Show("Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
            }    

        }
    }
}
