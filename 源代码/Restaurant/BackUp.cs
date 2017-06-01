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
            folder.ShowDialog();             //���ļ���Դ������

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
                MessageBox.Show("��ѡ�񱸷�·��");
                return;
            }
            else
            {
                try
                {
                    sql = @"BACKUP DATABASE Restaurant TO Disk='" + txtBackUp.Text + "\\" + "����" + ".bak" + "'";
                    dataBase.SQLUpdate(sql);
                    dataBase.Close();

                    if (MessageBox.Show("���ݳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
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