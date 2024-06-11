using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class First : UserControl
    {
        Login login = new Login();
        Registration registration = new Registration();
        GetPassword getPassword = new GetPassword();
        public event EventHandler changeSession;
        public First()
        {
            InitializeComponent();
            panel1.Controls.Add(login);
            panel2.Visible = false;
            login.ButtonClicked += Login_ButtonClicked;
            login.LoginSuccessClicked += Login_LoginSuccessClicked;
            login.ForgotPasswordClicked += Login_ForgotPasswordClicked;
        }

        private void Login_LoginSuccessClicked(object sender, EventArgs e)
        {
            if (sender is string lmeo)
                changeSession?.Invoke(lmeo, EventArgs.Empty);
        }

        private void Login_ForgotPasswordClicked(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            getPassword = new GetPassword();
            getPassword.ButtonClicked += GetPassword_ButtonClicked;
            panel1.Controls.Add(getPassword);
        }

        private void GetPassword_ButtonClicked(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(login);
        }

        private void Login_ButtonClicked(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Controls.Clear();
            registration = new Registration();
            panel2.Controls.Add(registration);
            registration.ButtonClicked += Registration_ButtonClicked;
            panel2.Visible = true;
        }

        private void Registration_ButtonClicked(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel1.Visible = true;
            panel2.Visible = false;
        }
    }
}
