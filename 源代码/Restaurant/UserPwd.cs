using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class UserPwd : Form
    {
        public UserPwd(string userID)
        {
            InitializeComponent();

            dataBase = new DataBase();
            sql = "";
            sdr = null;

            txtUserID.Text = userID;
        }

        private DataBase dataBase;
        string sql;
        private SqlDataReader sdr;

        private void butClear_Click(object sender, EventArgs e)
        {
            txtUserPwdOld.Text = "";
            txtUserPwdNew.Text = "";
            txtUserPwdCheck.Text = "";
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtUserPwdOld.Text == "" || txtUserPwdNew.Text == "" || txtUserPwdCheck.Text == "")
            {
                MessageBox.Show("������������Ϣ");
                return;
            }
            else
            {
                if (txtUserPwdNew.Text != txtUserPwdCheck.Text)
                {
                    MessageBox.Show("�������벻һ��");
                    return;
                }
                else
                {
                    string userpwd = "";
                    sql = "select UserPwd from tb_User where UserID='" + txtUserID.Text + "'";
                    sdr = dataBase.SQLQueryDataReader(sql);
                    while (sdr.Read())
                    {
                        userpwd = sdr[0].ToString().Trim();
                    }
                    dataBase.Close();

                    if (userpwd != txtUserPwdOld.Text)
                    {
                        MessageBox.Show("��������");
                        return;
                    }
                    else
                    {
                        sql = "update tb_User set UserPwd='" + txtUserPwdNew.Text + "' where UserID='" + txtUserID.Text + "'";
                        dataBase.SQLUpdate(sql);
                        MessageBox.Show("�޸ĳɹ�");

                        txtUserPwdOld.Text = "";
                        txtUserPwdNew.Text = "";
                        txtUserPwdCheck.Text = "";

                    }
                }
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}