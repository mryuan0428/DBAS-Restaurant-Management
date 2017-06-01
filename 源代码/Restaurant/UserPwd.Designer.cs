namespace Restaurant
{
    partial class UserPwd
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserPwdOld = new System.Windows.Forms.TextBox();
            this.txtUserPwdNew = new System.Windows.Forms.TextBox();
            this.txtUserPwdCheck = new System.Windows.Forms.TextBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "原密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "确认密码：";
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(116, 27);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 4;
            // 
            // txtUserPwdOld
            // 
            this.txtUserPwdOld.Location = new System.Drawing.Point(116, 79);
            this.txtUserPwdOld.Name = "txtUserPwdOld";
            this.txtUserPwdOld.PasswordChar = '*';
            this.txtUserPwdOld.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwdOld.TabIndex = 5;
            // 
            // txtUserPwdNew
            // 
            this.txtUserPwdNew.Location = new System.Drawing.Point(116, 128);
            this.txtUserPwdNew.Name = "txtUserPwdNew";
            this.txtUserPwdNew.PasswordChar = '*';
            this.txtUserPwdNew.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwdNew.TabIndex = 6;
            // 
            // txtUserPwdCheck
            // 
            this.txtUserPwdCheck.Location = new System.Drawing.Point(116, 177);
            this.txtUserPwdCheck.Name = "txtUserPwdCheck";
            this.txtUserPwdCheck.PasswordChar = '*';
            this.txtUserPwdCheck.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwdCheck.TabIndex = 7;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(262, 51);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 8;
            this.butOK.Text = "确认";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(262, 103);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 23);
            this.butClear.TabIndex = 9;
            this.butClear.Text = "重置";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(262, 154);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 10;
            this.butExit.Text = "退出";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // UserPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 240);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.txtUserPwdCheck);
            this.Controls.Add(this.txtUserPwdNew);
            this.Controls.Add(this.txtUserPwdOld);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "UserPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserPwdOld;
        private System.Windows.Forms.TextBox txtUserPwdNew;
        private System.Windows.Forms.TextBox txtUserPwdCheck;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butExit;
    }
}