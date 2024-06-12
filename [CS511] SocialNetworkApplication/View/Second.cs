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
using CsvHelper;
using CsvHelper.Configuration;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Second : UserControl
    {
        UserUC userUC2 = new UserUC();
        static DataTable postList = new DataTable();

        public Second()
        {
            InitializeComponent();
        }
        public Second(string username) 
        {
            InitializeComponent();
            userUC2 = new UserUC(username);
            userUC.Controls.Add(userUC2);
            showPost(username);
            flowPost.FlowDirection = FlowDirection.TopDown;
            flowPost.WrapContents = false;
            flowPost.AutoScroll = true;
            socialUC.Controls.Add(flowPost);
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
    }
}
