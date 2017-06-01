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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            dataBase = new DataBase();
        }

        private DataBase dataBase;
        private string sql;
        SqlDataReader sdr;

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtLoginUserID.Text == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (txtLoginUserPwd.Text == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            else
            {
                sql = "select count(*) from tb_User where UserID='" + txtLoginUserID.Text.Trim() + "' and UserPwd='" + txtLoginUserPwd.Text.Trim() + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                int flag = 0;
                while (sdr.Read())
                {
                    if (sdr.GetInt32(0) == 0)
                    {
                        MessageBox.Show("用户名或密码有误");
                        flag++;
                        dataBase.Close();
                        return;
                    }
                }
                if (flag == 0)
                {
                    sql = "select UserPower from tb_User where UserID='" + txtLoginUserID.Text.Trim() + "'";
                    sdr=dataBase.SQLQueryDataReader(sql);
                    string userPower="";
                    while (sdr.Read())
                    {
                        userPower = sdr["UserPower"].ToString();
                    }
                    dataBase.Close();

                    Main main = new Main(txtLoginUserID.Text.Trim().ToString(),userPower);
                    main.Show();
                    this.Hide();
                }
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}