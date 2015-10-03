namespace StudentManagementSystem
{
    partial class AddStuForm
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
            this.txtAddName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.rdoBtnMale = new System.Windows.Forms.RadioButton();
            this.rdoBtnFemale = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddName
            // 
            this.txtAddName.Location = new System.Drawing.Point(162, 48);
            this.txtAddName.Name = "txtAddName";
            this.txtAddName.Size = new System.Drawing.Size(272, 25);
            this.txtAddName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // txtAddPwd
            // 
            this.txtAddPwd.Location = new System.Drawing.Point(162, 133);
            this.txtAddPwd.Name = "txtAddPwd";
            this.txtAddPwd.PasswordChar = '*';
            this.txtAddPwd.Size = new System.Drawing.Size(272, 25);
            this.txtAddPwd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "性别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "年龄：";
            // 
            // cmbAge
            // 
            this.cmbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAge.FormattingEnabled = true;
            this.cmbAge.Location = new System.Drawing.Point(162, 313);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(272, 23);
            this.cmbAge.TabIndex = 7;
            // 
            // rdoBtnMale
            // 
            this.rdoBtnMale.AutoSize = true;
            this.rdoBtnMale.Checked = true;
            this.rdoBtnMale.Location = new System.Drawing.Point(220, 219);
            this.rdoBtnMale.Name = "rdoBtnMale";
            this.rdoBtnMale.Size = new System.Drawing.Size(43, 19);
            this.rdoBtnMale.TabIndex = 8;
            this.rdoBtnMale.TabStop = true;
            this.rdoBtnMale.Text = "男";
            this.rdoBtnMale.UseVisualStyleBackColor = true;
            // 
            // rdoBtnFemale
            // 
            this.rdoBtnFemale.AutoSize = true;
            this.rdoBtnFemale.Location = new System.Drawing.Point(340, 217);
            this.rdoBtnFemale.Name = "rdoBtnFemale";
            this.rdoBtnFemale.Size = new System.Drawing.Size(43, 19);
            this.rdoBtnFemale.TabIndex = 9;
            this.rdoBtnFemale.Text = "女";
            this.rdoBtnFemale.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(89, 470);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "确定";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.Location = new System.Drawing.Point(318, 470);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(116, 36);
            this.btnCancelAdd.TabIndex = 11;
            this.btnCancelAdd.Text = "取消";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "地址：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(162, 396);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(202, 25);
            this.txtAddress.TabIndex = 12;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(370, 394);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(64, 24);
            this.btnSelect.TabIndex = 14;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // AddStuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 552);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnCancelAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rdoBtnFemale);
            this.Controls.Add(this.rdoBtnMale);
            this.Controls.Add(this.cmbAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStuForm";
            this.Text = "新增学员";
            this.Load += new System.EventHandler(this.AddStuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.RadioButton rdoBtnMale;
        private System.Windows.Forms.RadioButton rdoBtnFemale;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSelect;
    }
}