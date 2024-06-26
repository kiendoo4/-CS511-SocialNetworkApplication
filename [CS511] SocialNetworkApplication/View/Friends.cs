﻿using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Friends : UserControl
    {
        List<EachFriend> lf = new List<EachFriend>();
        List<EachFriend> umkl = new List<EachFriend>();
        List<EachFriend> fil = new List<EachFriend>();
        public event EventHandler changeButton, optionButton;
        List<int> listInvite = new List<int>();
        DataTable userList2 = new DataTable();
        int index = -1;
        public Friends()
        {
            InitializeComponent();
        }
        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public Friends(DataTable userList, int idx)
        {
            InitializeComponent();
            userList2 = userList;
            index = idx;
            friendInviteList.AutoScroll = true;
            friendInviteList.WrapContents = false;
            friendInviteList.FlowDirection = FlowDirection.LeftToRight;
            uMightKnowList.AutoScroll = true;
            uMightKnowList.WrapContents = false;
            uMightKnowList.FlowDirection = FlowDirection.LeftToRight;
            panel1.Controls.Add(friendInviteList);
            yourInvitation.AutoScroll = true;
            yourInvitation.WrapContents = false;
            yourInvitation.FlowDirection = FlowDirection.LeftToRight;

            for (int i = 0; i < userList.Rows.Count; i++)
            {
                if (i == index) continue;
                string[] frList2 = userList.Rows[i]["AddFriend"].ToString().Split('*');
                if (Array.Exists(frList2, e => e == Convert.ToString(idx)))
                {
                    listInvite.Add(i);
                }
            }
            for (int i = 0; i < listInvite.Count; i++)
            {
                fil.Add(new EachFriend(userList, listInvite[i], "Invite"));
                fil[fil.Count - 1].changeButton += Friends_changeButton;
                fil[fil.Count - 1].optionButton += Friends_optionButton2;
                yourInvitation.Controls.Add(fil[fil.Count - 1]);
            }

            string frInviteList = userList.Rows[idx]["AddFriend"].ToString();
            string[] Invites = frInviteList.Split('*');
            string[] frList = userList.Rows[idx]["FriendList"].ToString().Split('*');
            foreach (string invite in Invites) 
            {
                if (invite == "") continue;
                lf.Add(new EachFriend(userList, Convert.ToInt32(invite), "Accept"));
                lf[lf.Count - 1].changeButton += Friends_changeButton;
                lf[lf.Count - 1].optionButton += Friends_optionButton;
                friendInviteList.Controls.Add(lf[lf.Count - 1]);
            }
            for(int i = 0; i < userList.Rows.Count; i++)
            {
                if (!Array.Exists(frList, e => e == Convert.ToString(i)) && !Array.Exists(Invites, e => e == Convert.ToString(i)) && i != idx && !listInvite.Contains(i))
                {
                    umkl.Add(new EachFriend(userList, i, "Other"));
                    umkl[umkl.Count - 1].changeButton += Friends_changeButton;
                    umkl[umkl.Count - 1].optionButton += Friends_optionButton1;
                    uMightKnowList.Controls.Add(umkl[umkl.Count - 1]);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                yourInvitation.Controls.Add(new blank());
                friendInviteList.Controls.Add(new blank());
                uMightKnowList.Controls.Add(new blank());
            }    
        }

        private void Friends_optionButton2(object sender, EventArgs e)
        {
            if (sender is int index2)
            {
                for (int i = 0; i < fil.Count; i++)
                {
                    if (index2 == fil[i].index)
                    {
                        DialogResult result = MessageBox.Show("Hủy lời mời muốn kết bạn đến người này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string[] frList = userList2.Rows[index2]["AddFriend"].ToString().Split('*');
                            List<string> frListAsList = new List<string>(frList);
                            string elementToAdd = Convert.ToString(index);
                            frListAsList.Remove(elementToAdd);
                            frList = frListAsList.ToArray();
                            userList2.Rows[index2]["AddFriend"] = string.Join("*", frList);
                            WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);

                            uMightKnowList.Controls.Clear();
                            umkl.Clear();
                            string frInviteList = userList2.Rows[index]["AddFriend"].ToString();
                            string[] Invites = frInviteList.Split('*');
                            frList = userList2.Rows[index]["FriendList"].ToString().Split('*');

                            yourInvitation.Controls.Clear();
                            fil.Clear();
                            listInvite.Clear();
                            for (int ii = 0; ii < userList2.Rows.Count; ii++)
                            {
                                if (ii == index) continue;
                                string[] frList2 = userList2.Rows[ii]["AddFriend"].ToString().Split('*');
                                if (Array.Exists(frList2, ee => ee == Convert.ToString(index)))
                                {
                                    listInvite.Add(ii);
                                }
                            }
                            for (int ii = 0; ii < listInvite.Count; ii++)
                            {
                                fil.Add(new EachFriend(userList2, listInvite[ii], "Invite"));
                                fil[fil.Count - 1].changeButton += Friends_changeButton;
                                fil[fil.Count - 1].optionButton += Friends_optionButton2;
                                yourInvitation.Controls.Add(fil[fil.Count - 1]);
                            }

                            for (int inn = 0; inn < userList2.Rows.Count; inn++)
                            {
                                if (!Array.Exists(frList, ee => ee == Convert.ToString(inn)) && !Array.Exists(Invites, ee => ee == Convert.ToString(inn)) && inn != index && !listInvite.Contains(inn))
                                {
                                    umkl.Add(new EachFriend(userList2, inn, "Other"));
                                    umkl[umkl.Count - 1].changeButton += Friends_changeButton;
                                    umkl[umkl.Count - 1].optionButton += Friends_optionButton1;
                                    uMightKnowList.Controls.Add(umkl[umkl.Count - 1]);
                                }
                            }

                            for (int inn = 0; inn < 2; inn++)
                            {
                                yourInvitation.Controls.Add(new blank());
                                uMightKnowList.Controls.Add(new blank());
                            }
                            MessageBox.Show("Đã hủy lời mời kết bạn", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
            }
        }

        private void Friends_optionButton1(object sender, EventArgs e)
        {
            if (sender is int index2)
            {
                for (int i = 0; i < umkl.Count; i++)
                {
                    if (index2 == umkl[i].index)
                    {
                        DialogResult result = MessageBox.Show("Gửi lời mời muốn kết bạn đến người này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string[] frList = userList2.Rows[index2]["AddFriend"].ToString().Split('*');
                            List<string> frListAsList = new List<string>(frList);
                            string elementToAdd = Convert.ToString(index);
                            frListAsList.Add(elementToAdd);
                            frList = frListAsList.ToArray();
                            userList2.Rows[index2]["AddFriend"] = string.Join("*", frList);
                            WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);

                            uMightKnowList.Controls.Clear();
                            umkl.Clear();
                            string frInviteList = userList2.Rows[index]["AddFriend"].ToString();
                            string[] Invites = frInviteList.Split('*');
                            frList = userList2.Rows[index]["FriendList"].ToString().Split('*');

                            yourInvitation.Controls.Clear();
                            fil.Clear();
                            listInvite.Clear();
                            for (int ii = 0; ii < userList2.Rows.Count; ii++)
                            {
                                if (ii == index) continue;
                                string[] frList2 = userList2.Rows[ii]["AddFriend"].ToString().Split('*');
                                if (Array.Exists(frList2, ee => ee == Convert.ToString(index)))
                                {
                                    listInvite.Add(ii);
                                }
                            }
                            for (int ii = 0; ii < listInvite.Count; ii++)
                            {
                                fil.Add(new EachFriend(userList2, listInvite[ii], "Invite"));
                                fil[fil.Count - 1].changeButton += Friends_changeButton;
                                fil[fil.Count - 1].optionButton += Friends_optionButton2;
                                yourInvitation.Controls.Add(fil[fil.Count - 1]);
                            }

                            for (int inn = 0; inn < userList2.Rows.Count; inn++)
                            {
                                if (!Array.Exists(frList, ee => ee == Convert.ToString(inn)) && !Array.Exists(Invites, ee => ee == Convert.ToString(inn)) && inn != index && !listInvite.Contains(inn))
                                {
                                    umkl.Add(new EachFriend(userList2, inn, "Other"));
                                    umkl[umkl.Count - 1].changeButton += Friends_changeButton;
                                    umkl[umkl.Count - 1].optionButton += Friends_optionButton1;
                                    uMightKnowList.Controls.Add(umkl[umkl.Count - 1]);
                                }
                            }

                            for (int inn = 0; inn < 2; inn++)
                            {
                                yourInvitation.Controls.Add(new blank());
                                uMightKnowList.Controls.Add(new blank());
                            }
                            MessageBox.Show("Đã gửi lời mời kết bạn", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
            }
        }

        private void Friends_optionButton(object sender, EventArgs e)
        {
            if(sender is int index2)
            {
                for (int i = 0; i < lf.Count; i++)
                {
                    if (index2 == lf[i].index)
                    {
                        DialogResult result = MessageBox.Show("Chấp nhận kết bạn với người này?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string[] frList = userList2.Rows[index]["FriendList"].ToString().Split('*');
                            List<string> frListAsList = new List<string>(frList);
                            string elementToAdd = Convert.ToString(index2);
                            frListAsList.Add(elementToAdd);
                            frList = frListAsList.ToArray();
                            userList2.Rows[index]["FriendList"] = string.Join("*", frList);
                            WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);

                            string[] frList3 = userList2.Rows[index]["AddFriend"].ToString().Split('*');
                            List<string> frListAsList3 = new List<string>(frList3);
                            string elementToDelete3 = Convert.ToString(index2);
                            frListAsList3.Remove(elementToDelete3);
                            frList3 = frListAsList3.ToArray();
                            userList2.Rows[index]["AddFriend"] = string.Join("*", frList3);
                            WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);

                            string[] frList2 = userList2.Rows[index2]["FriendList"].ToString().Split('*');
                            List<string> frListAsList2 = new List<string>(frList2);
                            string elementToRemove2 = Convert.ToString(index);
                            frListAsList2.Add(elementToRemove2);
                            frList2 = frListAsList2.ToArray();
                            userList2.Rows[index2]["FriendList"] = string.Join("*", frList2);
                            WriteDataTableToCsv("D:\\CS511\\Doan\\[CS511] SocialNetworkApplication\\[CS511] SocialNetworkApplication\\Data\\User.csv", userList2);
                            
                            friendInviteList.Controls.Clear();
                            frList = userList2.Rows[index]["AddFriend"].ToString().Split('*');
                            lf.Clear();
                            foreach (string invite in frList)
                            {
                                if (invite == "") continue;
                                lf.Add(new EachFriend(userList2, Convert.ToInt32(invite), "Accept"));
                                lf[lf.Count - 1].changeButton += Friends_changeButton;
                                lf[lf.Count - 1].optionButton += Friends_optionButton;
                                friendInviteList.Controls.Add(lf[lf.Count - 1]);
                            }
                            for (int inn = 0; inn < 2; inn++)
                            {
                                friendInviteList.Controls.Add(new blank());
                            }
                            MessageBox.Show("Đã thêm bạn mới", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }
                    }    
                }    
            }    
        }

        private void Friends_changeButton(object sender, EventArgs e)
        {
            if(sender is int index)
            {
                changeButton?.Invoke(index, e);
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

        private void Friends_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            uMightKnowList.Controls.Clear();
            umkl.Clear();
            string frInviteList = userList2.Rows[index]["AddFriend"].ToString();
            string[] Invites = frInviteList.Split('*');
            string[] frList = userList2.Rows[index]["FriendList"].ToString().Split('*');
            for (int inn = 0; inn < userList2.Rows.Count; inn++)
            {
                if ((!Array.Exists(frList, ee => ee == Convert.ToString(inn)) && !Array.Exists(Invites, ee => ee == Convert.ToString(inn)) && inn != index && !listInvite.Contains(inn))
                    && (userList2.Rows[inn]["Username"].ToString().ToLower().Contains(textBox1.Text.ToLower())||
                    userList2.Rows[inn]["Name"].ToString().ToLower().Contains(textBox1.Text.ToLower())))
                {
                    umkl.Add(new EachFriend(userList2, inn, "Other"));
                    umkl[umkl.Count - 1].changeButton += Friends_changeButton;
                    umkl[umkl.Count - 1].optionButton += Friends_optionButton1;
                    uMightKnowList.Controls.Add(umkl[umkl.Count - 1]);
                }
            }
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
