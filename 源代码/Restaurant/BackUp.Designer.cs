namespace Restaurant
{
    partial class BackUp
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
            this.txtBackUp = new System.Windows.Forms.TextBox();
            this.butScan = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份路径：";
            // 
            // txtBackUp
            // 
            this.txtBackUp.Location = new System.Drawing.Point(83, 41);
            this.txtBackUp.Name = "txtBackUp";
            this.txtBackUp.Size = new System.Drawing.Size(235, 21);
            this.txtBackUp.TabIndex = 1;
            // 
            // butScan
            // 
            this.butScan.Location = new System.Drawing.Point(324, 39);
            this.butScan.Name = "butScan";
            this.butScan.Size = new System.Drawing.Size(75, 23);
            this.butScan.TabIndex = 2;
            this.butScan.Text = "浏览";
            this.butScan.UseVisualStyleBackColor = true;
            this.butScan.Click += new System.EventHandler(this.butScan_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(93, 111);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 3;
            this.butOK.Text = "确定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(236, 111);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 4;
            this.butExit.Text = "退出";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 158);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butScan);
            this.Controls.Add(this.txtBackUp);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "BackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统备份";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackUp;
        private System.Windows.Forms.Button butScan;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butExit;
    }
}