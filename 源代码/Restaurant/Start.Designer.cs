namespace Restaurant
{
    partial class Start
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGuestNum = new System.Windows.Forms.TextBox();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.comboBoxWaiter = new System.Windows.Forms.ComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.butOK = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "桌台名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务员：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "账单日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "就餐人数：";
            // 
            // txtGuestNum
            // 
            this.txtGuestNum.Location = new System.Drawing.Point(307, 75);
            this.txtGuestNum.Name = "txtGuestNum";
            this.txtGuestNum.Size = new System.Drawing.Size(128, 21);
            this.txtGuestNum.TabIndex = 8;
            this.txtGuestNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuestNum_KeyPress);
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Location = new System.Drawing.Point(90, 28);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(128, 20);
            this.comboBoxRoom.TabIndex = 10;
            // 
            // comboBoxWaiter
            // 
            this.comboBoxWaiter.FormattingEnabled = true;
            this.comboBoxWaiter.Location = new System.Drawing.Point(307, 28);
            this.comboBoxWaiter.Name = "comboBoxWaiter";
            this.comboBoxWaiter.Size = new System.Drawing.Size(128, 20);
            this.comboBoxWaiter.TabIndex = 11;
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(90, 74);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(128, 21);
            this.dateTime.TabIndex = 12;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(127, 131);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 13;
            this.butOK.Text = "保存";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(266, 131);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 15;
            this.butExit.Text = "退出";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 186);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.comboBoxWaiter);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.txtGuestNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开台";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGuestNum;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.ComboBox comboBoxWaiter;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butExit;
    }
}