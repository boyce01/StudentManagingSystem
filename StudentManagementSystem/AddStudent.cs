using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class AddStuForm : Form
    {
        //不带参数的构造函数(用于：新增)
        public AddStuForm()
        {
            InitializeComponent();
        }

        //公共变量，保存被选中学员的id（一定>0）
        int sid = 0;
        //再声明一个构造函数，此构造函数带参数(用于：修改)
        public AddStuForm(int selectedId)
        {
            InitializeComponent();
            sid = selectedId;
        }

        //公共类对象
        BLL.Student stu = new BLL.Student();
        Model.Student model = new Model.Student();

        void ClearAndFocus()
        {
            txtAddName.Clear();
            txtAddPwd.Clear();
            txtAddName.Focus();
        }

        /// <summary>
        /// 加载时，显示年龄下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStuForm_Load(object sender, EventArgs e)
        {
            txtAddName.Focus();

            #region 显示下拉框,新增，修改都会执行
            cmbAge.Items.Add("-请选择-");
            for (int i = 10; i < 61; i++)
            {
                cmbAge.Items.Add(i);
            }
            //设置显示默认值：
            this.cmbAge.SelectedIndex = 0;
            #endregion

            #region 修改时，加载
            if (sid > 0)
            {
                this.Text = "修改信息";
                //获得要修改学员的信息：
                model = stu.GetStudentInfo(sid);

                //取得选中行的学员信息（要修改的学员信息）：
                txtAddName.Text = model.Name;
                txtAddPwd.Text = model.Password;
                this.cmbAge.Text = model.Age.ToString();
                if (model.Gender == "男")
                {
                    this.rdoBtnMale.Checked = true;
                }
                else
                {
                    rdoBtnFemale.Checked = true;
                }
                txtAddress.Text = model.Address;
            }
            #endregion
        }

        /// <summary>
        /// 取消添加学员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 打开选择地区界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            AddressForm af = new AddressForm();
            if (af.ShowDialog() == DialogResult.OK)
            {
                //把所选的地区显示在地址栏，用AddressForm类中的SelectedArea属性给txtAddress赋值
                txtAddress.Text = af.SelectedArea;
            }
        }

        /// <summary>
        /// 新增学员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 相同代码，新增，修改都需要用到
            if (string.IsNullOrEmpty(txtAddName.Text.Trim()) || string.IsNullOrEmpty(txtAddPwd.Text))
            {
                MessageBox.Show("请输入用户名和密码");
                ClearAndFocus();
                return;
            }
            //获得年龄：
            int age;
            try
            {
                age = Convert.ToInt32(cmbAge.SelectedItem);
            }
            catch //若没未选择年龄，则默认为0
            {
                age = 0;
            }

            //获得性别（三元表达式）：若rdoBtnMale.Checked被选中，就输出“男”；否则输出rdoBtnFemale.Text
            string gender = rdoBtnMale.Checked ? "男" : rdoBtnFemale.Text;
            #endregion

            #region 新增
            if (sid == 0)
            {
                model = stu.AddStudent(txtAddName.Text.Trim(), txtAddPwd.Text, age, gender, txtAddress.Text);

                if (model != null) //实体类对象不为null时
                {
                    MessageBox.Show(string.Format("添加成功，您的ID是{0}", model.ID));
                    //在MessageBox.Show()中添加占位符时，必须用string.Format("xxx{0}",par)
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("未添加成功");
                }
            }
            #endregion

            #region 修改
            if (sid > 0)
            {
                int res = stu.Update(sid, txtAddName.Text.Trim(), txtAddPwd.Text, age, gender, txtAddress.Text);
                if (res > 0)
                {
                    MessageBox.Show("修改成功");
                    this.DialogResult = DialogResult.OK;
                }
            }
            #endregion

        }

    }
}
