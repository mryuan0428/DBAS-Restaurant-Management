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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

            dataBase = new DataBase();
            sql = "";
            sdr = null;
        }

        private DataBase dataBase;
        private string sql;
        private SqlDataReader sdr;
        
        private void Start_Load(object sender, EventArgs e)
        {
            BindDataStart();
        }

        private void BindDataStart()                       //绑定桌台和服务员信息
        {
            comboBoxRoom.Items.Clear();
            comboBoxWaiter.Items.Clear();

            sql = "select RoomName from tb_Room where RoomStatus='待用'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                comboBoxRoom.Items.Add(sdr.GetString(0).Trim());
            }
            comboBoxRoom.SelectedIndex = 0;
            dataBase.Close();

            sql = "select WaiterName from tb_Waiter";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                comboBoxWaiter.Items.Add(sdr.GetString(0).Trim());
            }
            comboBoxWaiter.SelectedIndex = 0;
            dataBase.Close();
        }

        private void txtGuestNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string waiterID = "";
            string roomID = "";

            if (txtGuestNum.Text == "" || Convert.ToInt32(txtGuestNum.Text) <= 0)
            {
                MessageBox.Show("请输入用餐人数");
                return;
            }
            else
            {
                sql = "select WaiterID from tb_Waiter where WaiterName='" + comboBoxWaiter.SelectedItem.ToString().Trim() + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    waiterID = sdr.GetSqlValue(0).ToString().Trim();
                }
                dataBase.Close();
                sql = "select RoomID from tb_Room where RoomName='" + comboBoxRoom.SelectedItem.ToString().Trim() + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    roomID = sdr.GetSqlValue(0).ToString().Trim();
                }

                sql = "insert into tb_GuestRoom(WaiterID,RoomId,DateTime,GuestNum) values('" + Convert.ToInt32(waiterID) + "','" + Convert.ToInt32(roomID) + "','" + dateTime.Value.ToString() + "','" + Convert.ToInt32(txtGuestNum.Text) + "')";
                dataBase.SQLUpdate(sql);
                sql = "update tb_Room set RoomStatus='使用' where RoomID='" + Convert.ToInt32(roomID) + "'";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                MessageBox.Show("开台成功");

                BindDataStart();
                txtGuestNum.Text = "";
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}