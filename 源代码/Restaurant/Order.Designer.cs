namespace Restaurant
{
    partial class Order
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
            this.tvFood = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGuestFoodDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butDelete = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.txtFoodDelete = new System.Windows.Forms.TextBox();
            this.txtFoodAllPrice = new System.Windows.Forms.TextBox();
            this.txtFoodSum = new System.Windows.Forms.TextBox();
            this.txtFoodPrice = new System.Windows.Forms.TextBox();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.txtFoodID = new System.Windows.Forms.TextBox();
            this.txtWaiter = new System.Windows.Forms.TextBox();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGuestFood = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestFood)).BeginInit();
            this.SuspendLayout();
            // 
            // tvFood
            // 
            this.tvFood.Location = new System.Drawing.Point(21, 12);
            this.tvFood.Name = "tvFood";
            this.tvFood.Size = new System.Drawing.Size(158, 419);
            this.tvFood.TabIndex = 14;
            this.tvFood.DoubleClick += new System.EventHandler(this.tvFood_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "选择桌台：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "菜单编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "单    价：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "服务员：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "删除数量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGuestFoodDescription);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.butDelete);
            this.groupBox1.Controls.Add(this.butExit);
            this.groupBox1.Controls.Add(this.butOK);
            this.groupBox1.Controls.Add(this.txtFoodDelete);
            this.groupBox1.Controls.Add(this.txtFoodAllPrice);
            this.groupBox1.Controls.Add(this.txtFoodSum);
            this.groupBox1.Controls.Add(this.txtFoodPrice);
            this.groupBox1.Controls.Add(this.txtFoodName);
            this.groupBox1.Controls.Add(this.txtFoodID);
            this.groupBox1.Controls.Add(this.txtWaiter);
            this.groupBox1.Controls.Add(this.comboBoxRoom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(201, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 210);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单信息";
            // 
            // txtGuestFoodDescription
            // 
            this.txtGuestFoodDescription.Enabled = false;
            this.txtGuestFoodDescription.Location = new System.Drawing.Point(91, 131);
            this.txtGuestFoodDescription.Name = "txtGuestFoodDescription";
            this.txtGuestFoodDescription.Size = new System.Drawing.Size(316, 21);
            this.txtGuestFoodDescription.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "备 　  注：";
            // 
            // butDelete
            // 
            this.butDelete.Enabled = false;
            this.butDelete.Location = new System.Drawing.Point(170, 163);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 21;
            this.butDelete.Text = "删除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(332, 163);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 32;
            this.butExit.Text = "退出";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(251, 163);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 31;
            this.butOK.Text = "保存";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtFoodDelete
            // 
            this.txtFoodDelete.Enabled = false;
            this.txtFoodDelete.Location = new System.Drawing.Point(91, 165);
            this.txtFoodDelete.Name = "txtFoodDelete";
            this.txtFoodDelete.Size = new System.Drawing.Size(63, 21);
            this.txtFoodDelete.TabIndex = 30;
            this.txtFoodDelete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFoodDelete_KeyPress);
            // 
            // txtFoodAllPrice
            // 
            this.txtFoodAllPrice.Enabled = false;
            this.txtFoodAllPrice.Location = new System.Drawing.Point(332, 94);
            this.txtFoodAllPrice.Name = "txtFoodAllPrice";
            this.txtFoodAllPrice.Size = new System.Drawing.Size(75, 21);
            this.txtFoodAllPrice.TabIndex = 29;
            // 
            // txtFoodSum
            // 
            this.txtFoodSum.Enabled = false;
            this.txtFoodSum.Location = new System.Drawing.Point(204, 94);
            this.txtFoodSum.Name = "txtFoodSum";
            this.txtFoodSum.Size = new System.Drawing.Size(41, 21);
            this.txtFoodSum.TabIndex = 28;
            this.txtFoodSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFoodSum_KeyPress);
            this.txtFoodSum.TextChanged += new System.EventHandler(this.txtFoodSum_TextChanged);
            // 
            // txtFoodPrice
            // 
            this.txtFoodPrice.Enabled = false;
            this.txtFoodPrice.Location = new System.Drawing.Point(91, 94);
            this.txtFoodPrice.Name = "txtFoodPrice";
            this.txtFoodPrice.Size = new System.Drawing.Size(52, 21);
            this.txtFoodPrice.TabIndex = 27;
            // 
            // txtFoodName
            // 
            this.txtFoodName.Enabled = false;
            this.txtFoodName.Location = new System.Drawing.Point(303, 62);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(104, 21);
            this.txtFoodName.TabIndex = 26;
            // 
            // txtFoodID
            // 
            this.txtFoodID.Enabled = false;
            this.txtFoodID.Location = new System.Drawing.Point(91, 62);
            this.txtFoodID.Name = "txtFoodID";
            this.txtFoodID.Size = new System.Drawing.Size(100, 21);
            this.txtFoodID.TabIndex = 25;
            // 
            // txtWaiter
            // 
            this.txtWaiter.Enabled = false;
            this.txtWaiter.Location = new System.Drawing.Point(303, 27);
            this.txtWaiter.Name = "txtWaiter";
            this.txtWaiter.Size = new System.Drawing.Size(104, 21);
            this.txtWaiter.TabIndex = 24;
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Location = new System.Drawing.Point(91, 27);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(100, 20);
            this.comboBoxRoom.TabIndex = 23;
            this.comboBoxRoom.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoom_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "＝总价：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "×数量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "菜单名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGuestFood);
            this.groupBox2.Location = new System.Drawing.Point(201, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 203);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "点菜信息";
            // 
            // dgvGuestFood
            // 
            this.dgvGuestFood.AllowUserToAddRows = false;
            this.dgvGuestFood.AllowUserToDeleteRows = false;
            this.dgvGuestFood.BackgroundColor = System.Drawing.Color.White;
            this.dgvGuestFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuestFood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5});
            this.dgvGuestFood.Location = new System.Drawing.Point(8, 20);
            this.dgvGuestFood.Name = "dgvGuestFood";
            this.dgvGuestFood.ReadOnly = true;
            this.dgvGuestFood.RowHeadersVisible = false;
            this.dgvGuestFood.RowTemplate.Height = 23;
            this.dgvGuestFood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuestFood.Size = new System.Drawing.Size(403, 177);
            this.dgvGuestFood.TabIndex = 0;
            this.dgvGuestFood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuestFood_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FoodName";
            this.Column1.HeaderText = "菜单名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FoodSum";
            this.Column2.HeaderText = "数量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FoodAllPrice";
            this.Column3.HeaderText = "总价";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GuestFoodDescription";
            this.Column5.HeaderText = "备注";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvFood);
            this.MaximizeBox = false;
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点餐";
            this.Load += new System.EventHandler(this.Order_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWaiter;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TextBox txtFoodDelete;
        private System.Windows.Forms.TextBox txtFoodAllPrice;
        private System.Windows.Forms.TextBox txtFoodSum;
        private System.Windows.Forms.TextBox txtFoodPrice;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.TextBox txtFoodID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGuestFood;
        private System.Windows.Forms.TextBox txtGuestFoodDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}