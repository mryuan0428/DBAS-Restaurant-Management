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
    public partial class Order : Form
    {
        public Order()
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

        private void BindDataFood()　　　　　　　　　　　　 //绑定菜单信息
        {
            //读取菜品类型
            tvFood.Nodes.Clear();
            TreeNode[] treenode = new TreeNode[30];
            int i = 0;                                      //记录菜品类型的个数

            sql = "select FoodType from tb_FoodType";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                treenode[i] = tvFood.Nodes.Add(sdr[0].ToString().Trim());
                i++;
            }
            dataBase.Close();

            //读取菜品详细信息
            for (int j = 0; j < i; j++)
            {
                sql = "select FoodName from tb_Food,tb_FoodType where tb_Food.FoodTypeID=tb_FoodType.FoodTypeID and  Foodtype='" + treenode[j].Text + "'";
                sdr = dataBase.SQLQueryDataReader(sql);

                while (sdr.Read())
                {
                    treenode[j].Nodes.Add(sdr[0].ToString().Trim());
                }
                dataBase.Close();
            }
            tvFood.ExpandAll();
        }
        private void BindDataRoom()      //绑定桌台信息
        {
            sql="select RoomName from tb_Room where RoomStatus='使用'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                comboBoxRoom.Items.Add(sdr[0].ToString().Trim());
            }
            dataBase.Close();
        }
        private void BindDataWaiter()     //绑定服务员信息
        {
            string roomID = "";
            sql = "select RoomID from tb_Room where RoomName='" + comboBoxRoom.SelectedItem.ToString() + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                roomID = sdr[0].ToString().Trim();
            }
            dataBase.Close();

            sql = "select WaiterName from tb_GuestRoom,tb_Waiter where tb_GuestRoom.WaiterID=tb_Waiter.WaiterID and RoomID='" + roomID + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                txtWaiter.Text = sdr[0].ToString().Trim();
            }
            dataBase.Close();
        }
        private void BindDataGuestFood()   //绑定点菜信息
        {
            string guestroomID = "";
            sql = "select GuestRoomID from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and RoomName='" + comboBoxRoom.SelectedItem.ToString() + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                guestroomID = sdr[0].ToString().Trim();
            }
            dataBase.Close();

            sql = "select FoodName,FoodSum,FoodAllPrice,GuestFoodDescription from tb_GuestFood where GuestRoomID='" + guestroomID + "'";
            ds = dataBase.SQLQueryDataSet(sql);
            dgvGuestFood.DataSource = ds.Tables[0];
        }

        private void Order_Load(object sender, EventArgs e)
        {
            BindDataFood();
            BindDataRoom();
        }

        private void tvFood_DoubleClick(object sender, EventArgs e)
        {
            string foodname = tvFood.SelectedNode.Text;
            int flag = 0;

            sql = "select FoodType from tb_Foodtype";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
                if (foodname == sdr[0].ToString())
                    flag++;
            dataBase.Close();

            if (flag > 0)                             //选择的是菜品类别的节点，不做任何操作
                return;
            else
            {
                sql = "select FoodID,FoodPrice from tb_Food where FoodName='" + foodname + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    txtFoodID.Text = sdr["FoodID"].ToString().Trim();
                    txtFoodName.Text = foodname;
                    txtFoodPrice.Text = sdr["FoodPrice"].ToString().Trim();
                    txtFoodSum.Text = "1";
                    txtFoodAllPrice.Text = Convert.ToString(Convert.ToInt32(txtFoodPrice.Text) * Convert.ToInt32(txtFoodSum.Text));
                }
                dataBase.Close();
                
                txtFoodSum.Enabled = true;
                txtGuestFoodDescription.Enabled = true;
                txtFoodDelete.Enabled = false;
                butDelete.Enabled = false;
            }
        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataWaiter();
            BindDataGuestFood();
        }

        private void txtFoodSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void dgvGuestFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFoodName.Text = dgvGuestFood.SelectedCells[0].Value.ToString();
            txtGuestFoodDescription.Text = dgvGuestFood.SelectedCells[3].Value.ToString();

            sql = "select FoodID,FoodPrice from tb_Food where FoodName='" + txtFoodName.Text.ToString().Trim() + "'";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
            {
                txtFoodID.Text = sdr["FoodID"].ToString().Trim();
                txtFoodPrice.Text = sdr["FoodPrice"].ToString().Trim();
            }
            txtFoodSum.Enabled = true;
            txtGuestFoodDescription.Enabled = true;
            txtFoodDelete.Enabled = true;
            butDelete.Enabled = true;
        }

        private void txtFoodDelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void butOK_Click(object sender, EventArgs e)                //保存点菜信息
        {
            if (txtFoodSum.Text == "" || comboBoxRoom.Text == "")
            {
                MessageBox.Show("请输入完整信息(备注可不填)");
                return;
            }
            else
            {
                if (txtFoodSum.Text == "")
                {
                    MessageBox.Show("数量不能为空！");
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtFoodSum.Text) <= 0)
                    {
                        MessageBox.Show("请输入消费数量！");
                        return;
                    }
                    else
                    {
                        string guestroomID = "";
                        int i = 0;

                        sql = "select GuestRoomID from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and RoomName='" + comboBoxRoom.SelectedItem.ToString() + "'";
                        sdr = dataBase.SQLQueryDataReader(sql);
                        while (sdr.Read())
                        {
                            guestroomID = sdr[0].ToString().Trim();
                        }
                        dataBase.Close();


                        sql = "select FoodSum from tb_GuestFood where FoodID='" + txtFoodID.Text.ToString().Trim() + "' and GuestRoomID='" + guestroomID + "'";
                        
                        sdr = dataBase.SQLQueryDataReader(sql);
                        while (sdr.Read())
                        {
                            i = sdr.GetInt32(0);
                        }
                        dataBase.Close();
                        
                        if (i > 0)
                        {
                            i = i + Convert.ToInt32(txtFoodSum.Text);
                            decimal j = Convert.ToDecimal(i * (Convert.ToInt32(txtFoodPrice.Text)));              //计算已点菜信息的总价
                            sql = "update tb_GuestFood set FoodSum='" + i + "', GuestFoodDescription='" + txtGuestFoodDescription.Text.ToString().Trim() + "' where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";
                            dataBase.SQLUpdate(sql);
                            sql = "update tb_GuestFood set FoodAllPrice='" + j + "' where FoodName='" + txtFoodID.Text + "'";
                            dataBase.SQLUpdate(sql);
                            dataBase.Close();
                        }
                        else
                        {
                            string datetime = "";
                            sql = "select DateTime from tb_GuestRoom,tb_Room where tb_GuestRoom.RoomID=tb_Room.RoomID and RoomName='" + comboBoxRoom.SelectedItem.ToString() + "'";
                            sdr = dataBase.SQLQueryDataReader(sql);
                            while (sdr.Read())
                            {
                                datetime = sdr[0].ToString().Trim();
                            }
                            dataBase.Close();
                            sql = "insert into tb_GuestFood(GuestRoomID,FoodID,FoodName,FoodSum,FoodAllPrice,GuestFoodDescription,DateTime) values('" + guestroomID + "','" + txtFoodID.Text.ToString().Trim() + "','" + txtFoodName.Text.ToString().Trim() + "','" + Convert.ToDecimal(txtFoodSum.Text.ToString().Trim()) + "','" + txtFoodAllPrice.Text.ToString().Trim() + "','" + txtGuestFoodDescription.Text.ToString().Trim() + "','" + datetime + "')";
                            dataBase.SQLUpdate(sql);
                            dataBase.Close();
                        }
                        BindDataGuestFood();
                    }
                }
            }
        }

        private void butDelete_Click(object sender, EventArgs e)            //删除点菜信息
        {
            if (dgvGuestFood.SelectedRows.Count > 0)
            {
                if (txtFoodDelete.Text == "")
                {
                    MessageBox.Show("请输入删除数量！");
                    return;
                }
                else
                {
                    //String tnames = dataGridView1.SelectedCells[5].Value.ToString();  //获取桌台
                    int i = 0;              //数量
                    decimal j = 0;              //单价

                    sql = "select FoodSum from tb_GuestFood where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";    //获取菜单总数量
                    sdr = dataBase.SQLQueryDataReader(sql);
                    while (sdr.Read())
                    {
                        i = sdr.GetInt32(0);
                    }
                    dataBase.Close();

                    sql = "select FoodPrice from tb_Food where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";    //获取菜单单价
                    sdr = dataBase.SQLQueryDataReader(sql);
                    while (sdr.Read())
                    {
                        j = sdr.GetDecimal(0);
                    }
                    dataBase.Close();

                    if (i > Convert.ToInt32(txtFoodDelete.Text.ToString().Trim()))
                    {
                        i = i - Convert.ToInt32(txtFoodDelete.Text.ToString().Trim());
                        decimal k = Convert.ToDecimal(i * j);  //计算删除某菜单后的总价

                        sql = "update tb_GuestFood set FoodSum='" + i + "' where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";
                        dataBase.SQLUpdate(sql);
                        sql = "update tb_GuestFood set FoodAllPrice='" + k + "' where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";
                        dataBase.SQLUpdate(sql);
                        dataBase.Close();
                    }
                    else if (i == Convert.ToInt32(txtFoodDelete.Text.ToString().Trim()))
                    {
                        sql = "delete from tb_GuestFood where FoodID='" + txtFoodID.Text.ToString().Trim() + "'";
                        dataBase.SQLUpdate(sql);
                        dataBase.Close();
                    }
                    else
                    {
                        MessageBox.Show("删除数量需小于点菜数量！");
                    }
                    BindDataGuestFood();
                }
            }
            else
                return;
        }

        private void txtFoodSum_TextChanged(object sender, EventArgs e)
        {
            txtFoodAllPrice.Text = Convert.ToString(Convert.ToInt32(txtFoodPrice.Text) * Convert.ToInt32(txtFoodSum.Text));
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}