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

namespace _CS511__SocialNetworkApplication.View
{
    public partial class ChangeInfo : UserControl
    {
        public event EventHandler InfoChanged;
        DataTable dataTable2 = new DataTable();
        int index = -1;
        public ChangeInfo()
        {
            InitializeComponent();
        }
        public ChangeInfo(DataTable userList, int idx)
        {
            InitializeComponent();
            panel1.Visible = false;
            Gender.Items.Add("Nữ");
            Gender.Items.Add("Nam");
            Gender.DropDownStyle = ComboBoxStyle.DropDownList;
            Gender.BackColor = Color.White;
            dataTable2 = userList;
            index = idx;
            hoten.Enabled = false;
            gmail.Enabled = false;
            username.Enabled = false;
            BornDate.Enabled = false;
            Gender.Enabled = false;
            hoten.Text = userList.Rows[idx]["Name"].ToString();
            gmail.Text = userList.Rows[idx]["Email"].ToString();
            username.Text = userList.Rows[idx]["Username"].ToString();
            BornDate.Text = userList.Rows[idx]["Date_of_birth"].ToString();
            Gender.SelectedIndex = Convert.ToInt32(userList.Rows[idx]["Gender"].ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Đổi thông tin")
            {
                hoten.Enabled = true;
                gmail.Enabled = true;
                BornDate.Enabled = true;
                Gender.Enabled = true;
                changePwButton.Visible = false;
                button1.Text = "Hoàn tất";
            }    
            else
            {
                if (hoten.Text == "" || gmail.Text == "" || username.Text == "")
                    MessageBox.Show("Không được để trống thông tin");
                else
                {
                    dataTable2.Rows[index]["Name"] = hoten.Text;
                    dataTable2.Rows[index]["Email"] = gmail.Text;
                    dataTable2.Rows[index]["Date_of_birth"] = BornDate.Text;
                    dataTable2.Rows[index]["Gender"] = Gender.SelectedIndex;
                    WriteDataTableToCsv("../../Data/User.csv", dataTable2);
                    hoten.Enabled = false;
                    gmail.Enabled = false;
                    Gender.Enabled = false;
                    BornDate.Enabled = false;
                    changePwButton.Visible = true;
                    button1.Text = "Đổi thông tin";
                    InfoChanged?.Invoke(sender, EventArgs.Empty);
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

        private void changePwButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ChangingPassword changingPassword = new ChangingPassword(dataTable2, index);
            changingPassword.backButton += ChangingPassword_backButton;
            panel1.Controls.Add(changingPassword);
            panel1.Visible = true;
        }

        private void ChangingPassword_backButton(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
    }
}
