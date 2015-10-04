namespace StudentManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsDeleteS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecycle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack2List = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPage = new System.Windows.Forms.ComboBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.lkDown = new System.Windows.Forms.LinkLabel();
            this.lkUp = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.btnsDeleteS,
            this.btnExport,
            this.btnRecycle,
            this.btnBack2List,
            this.btnRemove});
            this.menuStrip1.Location = new System.Drawing.Point(0, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 24);
            this.btnAdd.Text = "新增学员";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
            this.toolStripMenuItem1.Text = "修改学员";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(81, 24);
            this.toolStripMenuItem2.Text = "删除学员";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btnsDeleteS
            // 
            this.btnsDeleteS.Name = "btnsDeleteS";
            this.btnsDeleteS.Size = new System.Drawing.Size(81, 24);
            this.btnsDeleteS.Text = "批量删除";
            this.btnsDeleteS.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 24);
            this.btnExport.Text = "导出当前列表";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(66, 24);
            this.btnRecycle.Text = "回收站";
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // btnBack2List
            // 
            this.btnBack2List.Name = "btnBack2List";
            this.btnBack2List.Size = new System.Drawing.Size(81, 24);
            this.btnBack2List.Text = "查看列表";
            this.btnBack2List.Click += new System.EventHandler(this.btnBack2List_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(81, 24);
            this.btnRemove.Text = "撤销删除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name1,
            this.Age,
            this.Gender,
            this.Address});
            this.dgvMain.Location = new System.Drawing.Point(0, 67);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 27;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(848, 499);
            this.dgvMain.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "编号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "name";
            this.Name1.HeaderText = "姓名";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "age";
            this.Age.HeaderText = "年龄";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "gender";
            this.Gender.HeaderText = "性别";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "address";
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(848, 62);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(848, 62);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbPage);
            this.panel1.Controls.Add(this.lblPage);
            this.panel1.Controls.Add(this.lkDown);
            this.panel1.Controls.Add(this.lkUp);
            this.panel1.Location = new System.Drawing.Point(505, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 34);
            this.panel1.TabIndex = 5;
            // 
            // cmbPage
            // 
            this.cmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPage.FormattingEnabled = true;
            this.cmbPage.Location = new System.Drawing.Point(4, 8);
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.Size = new System.Drawing.Size(121, 23);
            this.cmbPage.TabIndex = 4;
            this.cmbPage.SelectedIndexChanged += new System.EventHandler(this.cmbPage_SelectedIndexChanged);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(213, 11);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(55, 15);
            this.lblPage.TabIndex = 2;
            this.lblPage.Text = "label1";
            // 
            // lkDown
            // 
            this.lkDown.AutoSize = true;
            this.lkDown.Location = new System.Drawing.Point(286, 11);
            this.lkDown.Name = "lkDown";
            this.lkDown.Size = new System.Drawing.Size(52, 15);
            this.lkDown.TabIndex = 3;
            this.lkDown.TabStop = true;
            this.lkDown.Text = "下一页";
            this.lkDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkDown_LinkClicked);
            // 
            // lkUp
            // 
            this.lkUp.AutoSize = true;
            this.lkUp.Location = new System.Drawing.Point(143, 11);
            this.lkUp.Name = "lkUp";
            this.lkUp.Size = new System.Drawing.Size(52, 15);
            this.lkUp.TabIndex = 1;
            this.lkUp.TabStop = true;
            this.lkUp.Text = "上一页";
            this.lkUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkUp_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 537);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.dgvMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ComboBox cmbPage;
        private System.Windows.Forms.LinkLabel lkDown;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lkUp;
        private System.Windows.Forms.ToolStripMenuItem btnsDeleteS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.ToolStripMenuItem btnRecycle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnBack2List;
        private System.Windows.Forms.ToolStripMenuItem btnRemove;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
    }
}