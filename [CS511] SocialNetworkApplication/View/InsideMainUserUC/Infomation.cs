using CsvHelper;
using CsvHelper.Configuration;
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

namespace _CS511__SocialNetworkApplication.View.InsideMainUserUC
{
    public partial class Infomation : UserControl
    {
        public Infomation()
        {
            InitializeComponent();
        }
        int index = -1;
        DataTable dataTable2 = new DataTable();
        public Infomation(DataTable userList, int idx, string role) 
        {
            InitializeComponent();
            index = idx;
            dataTable2 = userList;
            CenterLabelInButton(label3, 0);
            mota.ReadOnly = true;
            mota.BackColor = Color.White;
            chitiet.ReadOnly = true;
            chitiet.BackColor = Color.White;    
            label3.Click += Label3_Click;
            panel1.Click += Label3_Click;
            label2.Click += ChiTiet_Click;
            panel2.Click += ChiTiet_Click;
            if (role != "User")
            {
                label3.Visible = false;
                panel1.Visible = false;
                label2.Visible = false;
                panel2.Visible = false;
            }    
            mota.Text = userList.Rows[idx]["Mota"].ToString();
            chitiet.Text = userList.Rows[idx]["Chitiet"].ToString();
        }

        private void ChiTiet_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Chỉnh sửa chi tiết")
            {
                chitiet.ReadOnly = false;
                chitiet.BorderStyle = BorderStyle.FixedSingle;
                label2.Text = "Sửa hoặc thêm chi tiết";
                CenterLabelInButton2(label2, 0);
            }
            else
            {
                dataTable2.Rows[index]["Chitiet"] = chitiet.Text;
                WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", dataTable2);
                chitiet.ReadOnly = true;
                chitiet.BorderStyle = BorderStyle.None;
                label2.Text = "Chỉnh sửa chi tiết";
                CenterLabelInButton2(label2, 0);
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            if(label3.Text == "Chỉnh sửa tiểu sử")
            {
                mota.ReadOnly = false;
                mota.BorderStyle = BorderStyle.FixedSingle;
                label3.Text = "Hoàn tất";
                CenterLabelInButton(label3, 0);
                
            }    
            else
            {
                dataTable2.Rows[index]["Mota"] = mota.Text;
                WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", dataTable2);
                mota.ReadOnly = true;
                mota.BorderStyle = BorderStyle.None;
                label3.Text = "Chỉnh sửa tiểu sử";
                CenterLabelInButton(label3, 0);

            }    
        }
        private void CenterLabelInButton(Label label, int add)
        {
            label.AutoSize = true;
            int newLabelX = (panel1.Width - label.Width) / 2;
            int newLabelY = (panel1.Height - label.Height) / 2 + add;
            label.Location = new Point(newLabelX, newLabelY);
        }
        private void CenterLabelInButton2(Label label, int add)
        {
            label.AutoSize = true;
            int newLabelX = (panel2.Width - label.Width) / 2;
            int newLabelY = (panel2.Height - label.Height) / 2 + add;
            label.Location = new Point(newLabelX, newLabelY);
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

        // Writes the list of dictionaries to a CSV file
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
