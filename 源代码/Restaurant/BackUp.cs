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
    public partial class BackUp : Form
    {
        public BackUp()
        {
            InitializeComponent();

            dataBase = new DataBase();
            sql = "";
        }

        private DataBase dataBase;
        string sql;

        private void butScan_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();             //打开文件资源管理器

            if (folder.SelectedPath.ToString().Length > 0)
            {
                DirectoryInfo dInfo = new DirectoryInfo(folder.SelectedPath);
                txtBackUp.Text = dInfo.ToString();
            }
            else
                return;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtBackUp.Text == "")
            {
                MessageBox.Show("请选择备份路径");
                return;
            }
            else
            {
                try
                {
                    sql = @"BACKUP DATABASE Restaurant TO Disk='" + txtBackUp.Text + "\\" + "备份" + ".bak" + "'";
                    dataBase.SQLUpdate(sql);
                    dataBase.Close();

                    if (MessageBox.Show("备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        this.Close();
                    }
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