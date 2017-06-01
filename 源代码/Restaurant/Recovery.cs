using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Restaurant
{
    public partial class Recovery : Form
    {
        public Recovery()
        {
            InitializeComponent();

            dataBase = new DataBase();
            sql = "";
        }

        private DataBase dataBase;
        string sql;

        private void butScan_Click(object sender, EventArgs e)
        {
            OpenFileDialog folder = new OpenFileDialog();
            folder.ShowDialog();
            if (folder.FileName.ToString().Length > 0)
            {
                DirectoryInfo dInfo = new DirectoryInfo(folder.FileName);

                txtRecovery.Text = dInfo.ToString();
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtRecovery.Text == "")
            {
                MessageBox.Show("请选择还原路径");
                return;
            }
            else
            {
                try
                {
                    sql = "use master restore database Restaurant from Disk='" + txtRecovery.Text.Trim() + "'";
                    dataBase.SQLUpdate(sql);
                    
                    if (MessageBox.Show("恢复成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        this.Close();
                    }
                    dataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}