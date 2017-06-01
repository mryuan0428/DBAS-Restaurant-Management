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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();

            dataBase = new DataBase();
            sql = "";
            sdr = null;
            ds = null;
        }

        private DataBase dataBase;
        string sql;
        private SqlDataReader sdr;
        private DataSet ds;

        private string price = "";
        private string roomprice = "";


        private void Bill_Load(object sender, EventArgs e)
        {
            BindDataBill();

            labelMoney.Text = "";
            labelChange.Text = "";
            txtGuestMoney.Text = "";
            txtGuestMoney.Enabled = false;
            butOK.Enabled = false;
        }

        private void BindDataBill()  //绑定已点餐的桌台信息
        {
            comboBoxRoom.Items.Clear();
            comboBoxRoom.Text = "";
            sql = "select distinct(RoomName) from tb_GuestFood,tb_GuestRoom,tb_Room where tb_GuestFood.GuestRoomID=tb_GuestRoom.GuestRoomID and tb_GuestRoom.RoomID=tb_Room.RoomID";

            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                comboBoxRoom.Items.Add(sdr[0].ToString().Trim());
            }
            dataBase.Close();
        }
        private void BindDataGuestFood()  //绑定某个桌台的点菜信息
        {
            string guestroomID = "";
            
            sql = "select guestroomID from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and RoomName='" + comboBoxRoom.Text.ToString().Trim() + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                guestroomID = sdr[0].ToString().Trim();
            }
            dataBase.Close();
            
            sql="select FoodName,FoodSum,FoodAllPrice,GuestFoodDescription,DateTime from tb_GuestFood where GuestRoomID='" + guestroomID + "'";
            ds = dataBase.SQLQueryDataSet(sql);
            dgvGuestFood.DataSource = ds.Tables[0];


            sql = "select sum(FoodAllPrice) from tb_GuestFood where GuestRoomID='" + guestroomID + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                price = Convert.ToString(sdr[0].ToString().Trim());
            }
            dataBase.Close();
            if (price == "")
            {
                labelMoney.Text = "0";
                butOK.Enabled = false;
            }
            else
            {
                sql = "select RoomPrice from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and GuestRoomID='" + guestroomID + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    roomprice = Convert.ToString(sdr[0].ToString().Trim());
                }
                dataBase.Close();

            
                butOK.Enabled = true;
                txtGuestMoney.Enabled = true;
                labelMoney.Text = price + "+" + roomprice + "=" + (Convert.ToDecimal(Convert.ToDouble(price)) + Convert.ToDecimal(roomprice)).ToString("C");
            
            }
        }
        

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataGuestFood();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (labelMoney.Text == "0")
            {
                MessageBox.Show("请选择桌台");
                return;
            }
            if (txtGuestMoney.Text == "0")
            {
                MessageBox.Show("请输入消费收银金额");
                return;
            }
            else
            {
                if (labelChange.Text.Substring(1, 1) == "-")
                {
                    MessageBox.Show("金额不足");
                    return;
                }
                else
                {
                    string guestroomID = "";
                    sql = "select guestroomID from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and RoomName='" + comboBoxRoom.Text.ToString().Trim() + "'";
                    sdr = dataBase.SQLQueryDataReader(sql);
                    while (sdr.Read())
                    {
                        guestroomID = sdr[0].ToString().Trim();
                    }
                    dataBase.Close();
                    
                    sql = "delete from tb_GuestFood where guestroomID='" + guestroomID + "'";
                    dataBase.SQLUpdate(sql);
                    sql = "insert into tb_Turnover(Turnover,DateTime) values('" + (Convert.ToDecimal(price) + Convert.ToDecimal(roomprice)) + "','" + DateTime.Now.ToString() + "')";
                    dataBase.SQLUpdate(sql);
                    sql = "update tb_Room set RoomStatus='待用'where RoomName='" + comboBoxRoom.Text.ToString().Trim() + "'";
                    dataBase.SQLUpdate(sql);
                    dataBase.Close();

                    Bill_Load(sender,e);
                    BindDataGuestFood();
                }
            }
        }

        private void txtGuestMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void txtGuestMoney_TextChanged(object sender, EventArgs e)
        {

            if(txtGuestMoney.Text!="")
                labelChange.Text = (Convert.ToDecimal(txtGuestMoney.Text.ToString().Trim()) - Convert.ToDecimal(price) - Convert.ToDecimal(roomprice)).ToString("C");
              
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}