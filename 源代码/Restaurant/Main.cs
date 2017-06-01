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
    public partial class Main : Form
    {
        public Main(string userID,string userPower)
        {
            InitializeComponent();
            dataBase = new DataBase();
            sql="";
            sdr=null;
            ds = null;

            this.toolLabelUserID.Text = "用户名：" + userID;
            this.toolLableUserPower.Text = "用户权限：" + userPower;

        }

        private DataBase dataBase;
        private string sql;
        private SqlDataReader sdr;
        private DataSet ds;

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            Start frmStart = new Start();
            frmStart.ShowDialog();
        }

        private void toolStripButtonOrder_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order();
            frmOrder.ShowDialog();
        }

        private void toolStripButtonBill_Click(object sender, EventArgs e)
        {
            Bill frmBill = new Bill();
            frmBill.ShowDialog();
        }

        private void 开台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start frmStart = new Start();
            frmStart.ShowDialog();
        }

        private void 点餐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order();
            frmOrder.ShowDialog();
        }

        private void 结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill frmBill = new Bill();
            frmBill.ShowDialog();
        }

        private void 桌台管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControlForm.SelectedIndex = 1;
        }

        private void 菜单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlForm.SelectedIndex = 2;
        }

        private void 营业额统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlForm.SelectedIndex = 3;
        }

        private void 职工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlForm.SelectedIndex = 4;
        }

        private void 用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlForm.SelectedIndex = 5;
        }
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPwd frmUserPwd = new UserPwd(this.toolLabelUserID.Text.Substring(4, this.toolLabelUserID.Text.Length - 4));
            frmUserPwd.ShowDialog();
        }

        private void 系统备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUp frmBackUp = new BackUp();
            frmBackUp.ShowDialog();
        }

        private void 系统恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recovery frmRecovery = new Recovery();
            frmRecovery.ShowDialog();
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //绑定信息和按钮控件
            BindDataRoom();
            SetButtonRoom();

            BindDataFood();
            SetButtonFood();

            BindDataWaiter();
            SetButtonWaiter();

            BindDataUser();

            //绑定状态栏信息
            toolLabelTime.Text = "当前系统时间：" + System.DateTime.Now.ToString();
        }

        private void CloseLogin()                                //查找开启的登陆窗体
        {
            FormCollection frmArray = Application.OpenForms;
            foreach (Form frmname in frmArray)
            {
                if (frmname.Name == "Login")
                {
                    frmname.Close();
                    break;
                }
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
                this.CloseLogin();
        }


        //----------------------------------------------------桌台信息-----------------------------------------------//
        private void BindDataRoom()     //绑定桌台信息
        {
            sql = "select RoomID,RoomName,RoomPrice,RoomLocation,RoomType,RoomDescription from tb_Room";
            ds = dataBase.SQLQueryDataSet(sql);
            dgvRoom.DataSource = ds.Tables[0];
            dataBase.Close();
        }
        private void SetButtonRoom()   //设置按钮控件
        {
            butRoomAdd.Enabled = true;
            butRoomUpdate.Enabled = false;
            butRoomSave.Enabled = false;
            butRoomCancel.Enabled = false;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = false;
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)    //绑定详细信息
        {
            txtRoomID.Text = dgvRoom.SelectedCells[0].Value.ToString().Trim();
            txtRoomName.Text = dgvRoom.SelectedCells[1].Value.ToString().Trim();
            txtRoomPrice.Text = dgvRoom.SelectedCells[2].Value.ToString().Trim();
            txtRoomLocation.Text = dgvRoom.SelectedCells[3].Value.ToString().Trim();
            txtRoomType.Text = dgvRoom.SelectedCells[4].Value.ToString().Trim();
            txtRoomDescription.Text = dgvRoom.SelectedCells[5].Value.ToString().Trim();

            txtRoomName.Enabled = false;
            txtRoomLocation.Enabled = false;
            txtRoomPrice.Enabled = false;
            txtRoomType.Enabled = false;
            txtRoomDescription.Enabled = false;

            butRoomAdd.Enabled = true;
            butRoomUpdate.Enabled = true;
            butRoomSave.Enabled = true;
            butRoomCancel.Enabled = true;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = true;
        }

        private void butRoomSearch_Click(object sender, EventArgs e)      //查询
        {
            BindDataRoom();
        }

        private void butRoomAdd_Click(object sender, EventArgs e)         //新建
        {
            txtRoomName.Enabled = true;
            txtRoomLocation.Enabled = true;
            txtRoomPrice.Enabled = true;
            txtRoomType.Enabled = true;
            txtRoomDescription.Enabled = true;

            txtRoomID.Text = "";
            txtRoomName.Text = "";
            txtRoomPrice.Text = "";
            txtRoomLocation.Text = "";
            txtRoomType.Text = "";
            txtRoomDescription.Text = "";
            

            butRoomUpdate.Enabled = false;
            butRoomSave.Enabled = true;
            butRoomCancel.Enabled = true;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = false;
        }
         
        private void butRoomSave_Click(object sender, EventArgs e)        //保存
        {
            if (txtRoomID.Text!="")
            {
                sql = "update tb_Room set RoomName='" + txtRoomName.Text.Trim() + "',RoomPrice='" + txtRoomPrice.Text.Trim() + "',RoomLocation='" + txtRoomLocation.Text.Trim() + "',RoomType='" + txtRoomType.Text.Trim() + "',RoomDescription='" + txtRoomDescription.Text.Trim() + "' where RoomID='" + txtRoomID.Text.Trim() + "'";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                BindDataRoom();

                txtRoomName.Enabled = false;
                txtRoomLocation.Enabled = false;
                txtRoomPrice.Enabled = false;
                txtRoomType.Enabled = false;
                txtRoomDescription.Enabled = false;

                butRoomAdd.Enabled = true;
                butRoomUpdate.Enabled = false;
                butRoomSave.Enabled = false;
                butRoomCancel.Enabled = false;
                butRoomSearch.Enabled = true;
                butRoomDelete.Enabled = false;
            }

            else if (txtRoomLocation.Text==""||txtRoomName.Text==""||txtRoomPrice.Text==""||txtRoomType.Text=="")
            {
                MessageBox.Show("请输入添加信息(备注可不填)");
                return;
            }
            else
            {
                sql="insert into tb_Room(RoomName,RoomPrice,RoomLocation,RoomStatus,RoomType,RoomDescription) values('" + txtRoomName.Text.Trim() + "','" + txtRoomPrice.Text.Trim() + "','" + txtRoomLocation.Text.Trim() + "','待用','" + txtRoomType.Text.Trim() + "','" + txtRoomDescription.Text.Trim() + "')";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                MessageBox.Show("添加成功");
                BindDataRoom();

                txtRoomName.Enabled = false;
                txtRoomLocation.Enabled = false;
                txtRoomPrice.Enabled = false;
                txtRoomType.Enabled = false;
                txtRoomDescription.Enabled = false;

                butRoomAdd.Enabled = true;
                butRoomUpdate.Enabled = false;
                butRoomSave.Enabled = false;
                butRoomCancel.Enabled = false;
                butRoomSearch.Enabled = true;
                butRoomDelete.Enabled = false;

                sql = "select RoomID from tb_Room where RoomName='" + txtRoomName.Text + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                if (sdr.Read())
                {
                    txtRoomID.Text = sdr.GetSqlValue(0).ToString();
                }
                dataBase.Close();
                
            }
        }

        private void butRoomCancel_Click(object sender, EventArgs e)               //取消
        {
            txtRoomName.Enabled = false;
            txtRoomLocation.Enabled = false;
            txtRoomPrice.Enabled = false;
            txtRoomType.Enabled = false;
            txtRoomDescription.Enabled = false;

            txtRoomID.Text = "";
            txtRoomName.Text = "";
            txtRoomPrice.Text = "";
            txtRoomLocation.Text = "";
            txtRoomType.Text = "";
            txtRoomDescription.Text = "";

            butRoomAdd.Enabled = true;
            butRoomUpdate.Enabled = false;
            butRoomSave.Enabled = false;
            butRoomCancel.Enabled = false;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = false;
        }

        private void butRoomUpdate_Click(object sender, EventArgs e)                //修改
        {
            txtRoomName.Enabled = true;
            txtRoomLocation.Enabled = true;
            txtRoomPrice.Enabled = true;
            txtRoomType.Enabled = true;
            txtRoomDescription.Enabled = true;

            butRoomAdd.Enabled = true;
            butRoomUpdate.Enabled = true;
            butRoomSave.Enabled = true;
            butRoomCancel.Enabled = true;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = true;
        }

        private void butRoomDelete_Click(object sender, EventArgs e)                //删除
        {
            sql = "delete from tb_Room where RoomID='" + txtRoomID.Text + "'";
            dataBase.SQLUpdate(sql);
            dataBase.Close();
            BindDataRoom();

            txtRoomName.Enabled = false;
            txtRoomLocation.Enabled = false;
            txtRoomPrice.Enabled = false;
            txtRoomType.Enabled = false;
            txtRoomDescription.Enabled = false;

            txtRoomID.Text = "";
            txtRoomName.Text = "";
            txtRoomPrice.Text = "";
            txtRoomLocation.Text = "";
            txtRoomType.Text = "";
            txtRoomDescription.Text = "";

            butRoomAdd.Enabled = true;
            butRoomUpdate.Enabled = false;
            butRoomSave.Enabled = false;
            butRoomCancel.Enabled = false;
            butRoomSearch.Enabled = true;
            butRoomDelete.Enabled = false;
        }

        private void txtRoomPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }




        //-----------------------------------------------员工信息--------------------------------------------------------//
        private void BindDataWaiter()                 //绑定员工信息
        {
            sql = "select * from tb_Waiter";
            ds = dataBase.SQLQueryDataSet(sql);
            dgvWaiter.DataSource = ds.Tables[0];
            dataBase.Close();
        }

        private void SetButtonWaiter()   //设置按钮控件
        {
            butWaiterAdd.Enabled = true;
            butWaiterUpdate.Enabled = false;
            butWaiterSave.Enabled = false;
            butWaiterCancel.Enabled = false;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = false;
        }

        private void dgvWaiter_CellClick(object sender, DataGridViewCellEventArgs e)       //绑定详细信息
        {
            txtWaiterID.Text = dgvWaiter.SelectedCells[0].Value.ToString().Trim();
            txtWaiterUserID.Text = dgvWaiter.SelectedCells[1].Value.ToString().Trim();
            txtWaiterName.Text = dgvWaiter.SelectedCells[2].Value.ToString().Trim();
            comboBoxWaiterSex.Text = dgvWaiter.SelectedCells[3].Value.ToString().Trim();
            txtWaiterAge.Text = dgvWaiter.SelectedCells[4].Value.ToString().Trim();
            txtWaiterTel.Text = dgvWaiter.SelectedCells[5].Value.ToString().Trim();

            txtWaiterID.Enabled = false;
            txtWaiterName.Enabled = false;
            comboBoxWaiterSex.Enabled = false;
            txtWaiterAge.Enabled = false;
            txtWaiterUserID.Enabled = false;
            txtWaiterTel.Enabled = false;

            butWaiterAdd.Enabled = true;
            butWaiterUpdate.Enabled = true;
            butWaiterSave.Enabled = true;
            butWaiterCancel.Enabled = true;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = true;
        }

        private void butWaiterSearch_Click(object sender, EventArgs e)             //查询
        {
            BindDataWaiter();
        }

        private void butWaiterAdd_Click(object sender, EventArgs e)                //新建
        {
            txtWaiterName.Enabled = true;
            comboBoxWaiterSex.Enabled = true;
            txtWaiterAge.Enabled = true;
            txtWaiterUserID.Enabled = true;
            txtWaiterTel.Enabled = true;

            txtWaiterID.Text = "";
            txtWaiterName.Text = "";
            comboBoxWaiterSex.Text = "";
            txtWaiterAge.Text = "";
            txtWaiterUserID.Text = "";
            txtWaiterTel.Text = "";


            butWaiterUpdate.Enabled = false;
            butWaiterSave.Enabled = true;
            butWaiterCancel.Enabled = true;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = false;
        }

        private void butWaiterUpdate_Click(object sender, EventArgs e)             //修改
        {
            txtWaiterName.Enabled = true;
            comboBoxWaiterSex.Enabled = true;
            txtWaiterAge.Enabled = true;
            txtWaiterUserID.Enabled = true;
            txtWaiterTel.Enabled = true;

            butWaiterUpdate.Enabled = true;
            butWaiterSave.Enabled = true;
            butWaiterCancel.Enabled = true;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = true;
        }

        private void butWaiterSave_Click(object sender, EventArgs e)               //保存
        {
            if (txtWaiterID.Text != "")
            {
                sql = "update tb_Waiter set WaiterName='" + txtWaiterName.Text.Trim() + "',WaiterSex='" + comboBoxWaiterSex.Text.Trim() + "',WaiterAge='" + txtWaiterAge.Text.Trim() + "',WaiterUserID='" + txtWaiterUserID.Text.Trim() + "',WaiterTel='" + txtWaiterTel.Text.Trim() + "' where WaiterID='" + txtWaiterID.Text.Trim() + "'";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                BindDataWaiter();

                txtWaiterName.Enabled = true;
                comboBoxWaiterSex.Enabled = true;
                txtWaiterAge.Enabled = true;
                txtWaiterUserID.Enabled = true;
                txtWaiterTel.Enabled = true;

                butWaiterAdd.Enabled = true;
                butWaiterUpdate.Enabled = false;
                butWaiterSave.Enabled = false;
                butWaiterCancel.Enabled = false;
                butWaiterSearch.Enabled = true;
                butWaiterDelete.Enabled = false;
            }

            else if (txtWaiterName.Text == "" || comboBoxWaiterSex.Text == "" || txtWaiterAge.Text == "" || txtWaiterUserID.Text == "" || txtWaiterTel.Text == "")
            {
                MessageBox.Show("请输入添加信息");
                return;
            }
            else
            {
                sql = "insert into tb_Waiter(WaiterName,WaiterSex,WaiterAge,WaiterUserID,WaiterTel) values('" + txtWaiterName.Text.Trim() + "','" + comboBoxWaiterSex.Text.Trim() + "','" + txtWaiterAge.Text.Trim() + "','" + txtWaiterUserID.Text.Trim() + "','" + txtWaiterTel.Text.Trim() + "')";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                MessageBox.Show("添加成功");
                BindDataWaiter();

                txtWaiterName.Enabled = false;
                comboBoxWaiterSex.Enabled = false;
                txtWaiterAge.Enabled = false;
                txtWaiterUserID.Enabled = false;
                txtWaiterTel.Enabled = false;

                butWaiterAdd.Enabled = true;
                butWaiterUpdate.Enabled = false;
                butWaiterSave.Enabled = false;
                butWaiterCancel.Enabled = false;
                butWaiterSearch.Enabled = true;
                butWaiterDelete.Enabled = false;

                sql = "select WaiterID from tb_Waiter where WaiterName='" + txtWaiterName.Text + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                if (sdr.Read())
                {
                    txtWaiterID.Text = sdr.GetSqlValue(0).ToString();
                }
                dataBase.Close();

            }
        }

        private void butWaiterCancel_Click(object sender, EventArgs e)            //取消
        {
            txtWaiterName.Enabled = false;
            comboBoxWaiterSex.Enabled = false;
            txtWaiterAge.Enabled = false;
            txtWaiterUserID.Enabled = false;
            txtWaiterTel.Enabled = false;

            txtWaiterID.Text = "";
            txtWaiterName.Text = "";
            comboBoxWaiterSex.Text = "";
            txtWaiterAge.Text = "";
            txtWaiterUserID.Text = "";
            txtWaiterTel.Text = "";

            butWaiterAdd.Enabled = true;
            butWaiterUpdate.Enabled = false;
            butWaiterSave.Enabled = false;
            butWaiterCancel.Enabled = false;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = false;
        }

        private void butWaiterDelete_Click(object sender, EventArgs e)            //删除
        {
            sql = "delete from tb_Waiter where WaiterID='" + txtWaiterID.Text + "'";
            dataBase.SQLUpdate(sql);
            dataBase.Close();
            BindDataWaiter();

            txtWaiterName.Enabled = false;
            comboBoxWaiterSex.Enabled = false;
            txtWaiterAge.Enabled = false;
            txtWaiterUserID.Enabled = false;
            txtWaiterTel.Enabled = false;

            txtWaiterID.Text = "";
            txtWaiterName.Text = "";
            comboBoxWaiterSex.Text = "";
            txtWaiterAge.Text = "";
            txtWaiterUserID.Text = "";
            txtWaiterTel.Text = "";

            butWaiterAdd.Enabled = true;
            butWaiterUpdate.Enabled = false;
            butWaiterSave.Enabled = false;
            butWaiterCancel.Enabled = false;
            butWaiterSearch.Enabled = true;
            butWaiterDelete.Enabled = false;
        }


        //-------------------------------------------------用户信息------------------------------------------------------//
        private void BindDataUser()                       //绑定用户信息
        {
            sql = "select * from tb_User";
            ds = dataBase.SQLQueryDataSet(sql);
            dgvUser.DataSource = ds.Tables[0];
            dataBase.Close();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserDelete.Text = dgvUser.SelectedCells[0].Value.ToString().Trim();
        }

        private void butUserClear_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtUserPwd.Text = "";
            txtUserPwdCheck.Text = "";
            comboBoxUserPower.Text = "";
        }

        private void butUserOK_Click(object sender, EventArgs e)                       //添加新用户
        {
            if (txtUserID.Text == "" || txtUserPwd.Text == "" || txtUserPwdCheck.Text == "" || comboBoxUserPower.Text == "")
            {
                MessageBox.Show("请输入添加信息");
                return;
            }
            if (txtUserPwd.Text.Trim() != txtUserPwdCheck.Text.Trim())
            {
                MessageBox.Show("密码与确认密码不一致");
                return;
            }
            if (comboBoxUserPower.Text != "一般服务员" || comboBoxUserPower.Text != "前台收银员" || comboBoxUserPower.Text != "后台管理员")
            {
                MessageBox.Show("权限信息有误");
                return;
            }
            else
            {
                int flag = 0;
                sql = "select count(*) from tb_User where UserID='" + txtUserID.Text.Trim() + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    if (sdr.GetInt32(0) == 1)
                    {
                        MessageBox.Show("用户已存在");
                        flag++;
                        return;
                    }
                }

                if (flag == 0)
                {
                    sql = "insert into tb_User values('" + txtUserID.Text.Trim() + "','" + txtUserPwd.Text.Trim() + "','" + comboBoxUserPower.Text.Trim() + "')";
                    dataBase.SQLUpdate(sql);
                    dataBase.Close();
                    MessageBox.Show("添加成功");
                    BindDataUser();
                }

            }
        }

        private void butUserDelete_Click(object sender, EventArgs e)                  //删除
        {
            if ("用户名：" + txtUserDelete.Text == toolLabelUserID.Text)
            {
                MessageBox.Show("后台管理员不能被删除！");
                return;
            }
            else
            {
                sql = "delete from tb_User where UserID='" + txtUserDelete.Text.Trim() + "'";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                MessageBox.Show("删除成功");
                txtUserDelete.Text = "";
                BindDataUser();
            }
        }

        //------------------------------------------菜单信息-------------------------------------------------------//
        private void BindDataFood()　　　　　　　　　　　　　//绑定菜单信息
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

        private void SetButtonFood()   //设置按钮控件
        {
            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = false;
            butFoodSave.Enabled = false;
            butFoodCancel.Enabled = false;
            butFoodDelete.Enabled = false;
        }

        private void tvFood_DoubleClick(object sender, EventArgs e)　　　　　　//绑定详细信息
        {
            string foodname = "";
            int flag = 0;

            foodname = tvFood.SelectedNode.Text;
            sql = "select FoodType from tb_FoodType";
            sdr = dataBase.SQLQueryDataReader(sql);
            while (sdr.Read())
                if (foodname == sdr[0].ToString())
                    flag++;
            dataBase.Close();
            if (flag > 0)                                       //如果选择的是菜品类型，不做任何操作
                return;
            else
            {
                sql = "select * from tb_Food where FoodName='" + foodname + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    txtFoodID.Text = sdr["FoodID"].ToString().Trim();
                    txtFoodName.Text = foodname;
                    txtFoodPrice.Text = sdr["FoodPrice"].ToString().Trim();
                    txtFoodDescription.Text = sdr["FoodDescription"].ToString().Trim();
                }
                dataBase.Close();

                sql = "select * from tb_FoodType,tb_Food where tb_FoodType.FoodTypeID=tb_Food.FoodTypeID and FoodName= '" + foodname + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    txtFoodTypeID.Text = sdr["FoodTypeID"].ToString().Trim();
                    txtFoodType.Text = sdr["FoodType"].ToString().Trim();
                }
                dataBase.Close();
            }

            txtFoodTypeID.Enabled = false;
            txtFoodType.Enabled = false;
            txtFoodID.Enabled = false;
            txtFoodName.Enabled = false;
            txtFoodPrice.Enabled = false;
            txtFoodDescription.Enabled = false;

            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = true;
            butFoodSave.Enabled = false;
            butFoodCancel.Enabled = false;
            butFoodDelete.Enabled = true;
        }

        private void butFoodAdd_Click(object sender, EventArgs e)           //新建
        {
            txtFoodTypeID.Enabled = false;
            txtFoodType.Enabled = true;
            txtFoodID.Enabled = false;
            txtFoodName.Enabled = true;
            txtFoodPrice.Enabled = true;
            txtFoodDescription.Enabled = true;

            txtFoodTypeID.Text = "";
            txtFoodType.Text = "";
            txtFoodID.Text = "";
            txtFoodName.Text = "";
            txtFoodPrice.Text = "";
            txtFoodDescription.Text = "";

            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = false;
            butFoodSave.Enabled = true;
            butFoodCancel.Enabled = true;
            butFoodDelete.Enabled = false;
        }

        private void butFoodUpdate_Click(object sender, EventArgs e)        //修改
        {
            txtFoodTypeID.Enabled = false;
            txtFoodType.Enabled = true;
            txtFoodID.Enabled = false;
            txtFoodName.Enabled = true;
            txtFoodPrice.Enabled = true;
            txtFoodDescription.Enabled = true;

            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = true;
            butFoodSave.Enabled = true;
            butFoodCancel.Enabled = true;
            butFoodDelete.Enabled = true;
        }

        private void butFoodSave_Click(object sender, EventArgs e)      //保存
        {
            int i = 0;                               //记录菜品类别编号                                                      
            int j = 0;                               //记录菜单编号                  
            int flag = 0;


            if (txtFoodTypeID.Text != "")                //保存修改菜单的信息
            {
                sql = "update tb_FoodType set FoodType='" + txtFoodType.Text.Trim() + "' where FoodTypeID='" + txtFoodTypeID.Text.Trim() + "'";
                dataBase.SQLUpdate(sql);
                sql = "update tb_Food set FoodName='" + txtFoodName.Text.Trim() + "',FoodPrice='" + txtFoodPrice.Text + "',FoodDescription='" + txtFoodDescription.Text + "' where FoodID='" + txtFoodID.Text.Trim() + "'";
                dataBase.SQLUpdate(sql);
                dataBase.Close();
                MessageBox.Show("修改成功");
                BindDataRoom();

                txtFoodTypeID.Enabled = false;
                txtFoodType.Enabled = false;
                txtFoodID.Enabled = false;
                txtFoodName.Enabled = false;
                txtFoodPrice.Enabled = false;
                txtFoodDescription.Enabled = false;

                butFoodAdd.Enabled = true;
                butFoodUpdate.Enabled = true;
                butFoodSave.Enabled = false;
                butFoodCancel.Enabled = false;
                butFoodDelete.Enabled = true;
            }

            else if (txtFoodType.Text == "" || txtFoodName.Text == "" || txtFoodPrice.Text == "")
            {
                MessageBox.Show("请输入添加信息(菜品详情可不填)");
                return;
            }
            else                                    //保存新建菜单的信息，分两种情况（只新建某个菜品类别下的菜单，新建菜品类别和新菜单）
            {
                sql = "select FoodTypeID from tb_FoodType where FoodType='" + txtFoodType.Text.Trim() + "'";
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    i=sdr.GetInt32(0);
                    flag++;
                }
                dataBase.Close();

                if (flag == 1)                     //只新建某个菜品类别下的菜单
                {
                    sql = "insert into tb_Food(FoodTypeID,FoodName,FoodPrice,FoodDescription) values(" + i + ",'" + txtFoodName.Text.Trim() + "','" + txtFoodPrice.Text.Trim() + "','" + txtFoodDescription.Text.Trim() + "')";
                    dataBase.SQLUpdate(sql);
                    dataBase.Close();
                    MessageBox.Show("添加成功");
                }
                else
                {
                    sql = "insert into tb_FoodType values('" + txtFoodType.Text.Trim() + "')";        //更新菜品类别表
                    dataBase.SQLUpdate(sql);

                    sql = "select FoodTypeID from tb_FoodType where FoodType='" + txtFoodType.Text.Trim() + "'";     //查询新建菜品类别的编号（主键）
                    sdr = dataBase.SQLQueryDataReader(sql);
                    while (sdr.Read())
                    {
                        i = sdr.GetInt32(0);
                    }
                    dataBase.Close();

                    sql = "insert into tb_Food(FoodTypeID,FoodName,FoodPrice,FoodDescription) values(" + i + ",'" + txtFoodName.Text.Trim() + "','" + txtFoodPrice.Text.Trim() + "','" + txtFoodDescription.Text.Trim() + "')";
                    dataBase.SQLUpdate(sql);                                                           //更新菜单表
                    dataBase.Close();
                    MessageBox.Show("添加成功");

                }
                sql = "select FoodID from tb_Food where FoodName='" + txtFoodName.Text.Trim() + "'";     //查询新建菜单的编号（主键）
                sdr = dataBase.SQLQueryDataReader(sql);
                while (sdr.Read())
                {
                    j = sdr.GetInt32(0);
                }
                dataBase.Close();

                BindDataFood();
                txtFoodTypeID.Text = i.ToString();
                txtFoodID.Text = j.ToString();

                txtFoodTypeID.Enabled = false;
                txtFoodType.Enabled = false;
                txtFoodID.Enabled = false;
                txtFoodName.Enabled = false;
                txtFoodPrice.Enabled = false;
                txtFoodDescription.Enabled = false;

                butFoodAdd.Enabled = true;
                butFoodUpdate.Enabled = true;
                butFoodSave.Enabled = false;
                butFoodCancel.Enabled = false;
                butFoodDelete.Enabled = true;
            }
        }

        private void butFoodCancel_Click(object sender, EventArgs e)                   //取消
        {
            txtFoodTypeID.Enabled = false;
            txtFoodType.Enabled = false;
            txtFoodID.Enabled = false;
            txtFoodName.Enabled = false;
            txtFoodPrice.Enabled = false;
            txtFoodDescription.Enabled = false;

            txtFoodTypeID.Text = "";
            txtFoodType.Text = "";
            txtFoodID.Text = "";
            txtFoodName.Text = "";
            txtFoodPrice.Text = "";
            txtFoodDescription.Text = "";

            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = false;
            butFoodSave.Enabled = false;
            butFoodCancel.Enabled = false;
            butFoodDelete.Enabled = false;
        }

        private void butFoodDelete_Click(object sender, EventArgs e)
        {
            sql = "delete from tb_Food where FoodID='" + txtFoodID.Text.Trim() + "'";
            dataBase.SQLUpdate(sql);
            dataBase.Close();
            MessageBox.Show("删除成功");
            BindDataFood();

            txtFoodTypeID.Enabled = false;
            txtFoodType.Enabled = false;
            txtFoodID.Enabled = false;
            txtFoodName.Enabled = false;
            txtFoodPrice.Enabled = false;
            txtFoodDescription.Enabled = false;

            txtFoodTypeID.Text = "";
            txtFoodType.Text = "";
            txtFoodID.Text = "";
            txtFoodName.Text = "";
            txtFoodPrice.Text = "";
            txtFoodDescription.Text = "";

            butFoodAdd.Enabled = true;
            butFoodUpdate.Enabled = false;
            butFoodSave.Enabled = false;
            butFoodCancel.Enabled = false;
            butFoodDelete.Enabled = false;
        }

        private void txtFoodPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }



        //-----------------------------------------------------营业额统计-------------------------------------------------------//
        private void butTurnoverOK_Click(object sender, EventArgs e)
        {
            if (comboBoxMethod.Text == "")
            {
                MessageBox.Show("请选择统计方式");
                return;
            }
            else
            {
                string startDate = dateTimePickerStart.Value.Date.ToShortDateString().ToString();
                string endDate = dateTimePickerEnd.Value.Date.ToShortDateString().ToString();

                string startHour = this.txtStartHour.Text.Trim();
                string startMin = this.txtStartMinute.Text.Trim();
                string startSec = this.txtStartSecond.Text.Trim();
                string startTime = startHour + ":" + startMin + ":" + startSec;

                string endHour = this.txtEndHour.Text.Trim();
                string endMin = this.txtEndMinute.Text.Trim();
                string endSec = this.txtEndSecond.Text.Trim();
                string endTime = endHour + ":" + endMin + ":" + endSec;

                string startDateTime = startDate + " " + startTime;
                string endDateTime = endDate + " " + endTime;

                int choose = comboBoxMethod.SelectedIndex;  //获取统计方式

                switch (choose)
                {
                    case 0: sql = "select year(DateTime) as 年,month(DateTime) as 月, day(DateTime) as 日,sum(Turnover) as 营业额 from tb_Turnover where DateTime between '" + startDateTime + "' and '" + endDateTime + "' group by year(DateTime),month(DateTime),day(DateTime)";
                        break;
                    case 1: sql = "select year(DateTime) as 年,month(DateTime) as 月,sum(Turnover) as 营业额 from tb_Turnover where DateTime between '" + startDateTime + "' and '" + endDateTime + "' group by year(DateTime),month(DateTime)";
                        break;
                    case 2: sql = "select year(DateTime) as 年,sum(Turnover) as 营业额 from tb_Turnover where DateTime between '" + startDateTime + "' and '" + endDateTime + "' group by year(DateTime)";
                        break;
                }
                ds = dataBase.SQLQueryDataSet(sql);
                dgvTurnover.DataSource = ds.Tables[0];
            }
        }

        private void txtStartHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void txtStartMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void txtStartSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void txtEndHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void txtEndMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void txtEndSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void toolStripButtonFresh_Click(object sender, EventArgs e)
        {
            BindDataRoom();
            BindDataFood();
            BindDataWaiter();
            BindDataUser();
        }

        


    }
}