using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem //添加了对BLL类库的引用，以便调用BLL类库中的类
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtLoginName.Focus();
            groupBox1.Visible = true; //打开登录窗口时，注册页面不可见
        }

        /// <summary>
        /// 单击注册时，调用BLL类库中的Register()方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegisterName.Text.Trim()) || string.IsNullOrEmpty(txtPwd1.Text) || string.IsNullOrEmpty(txtPwd2.Text))
            {
                MessageBox.Show("请输入用户名和密码");
                RClearAndFocus();
                return;
            }
            if (txtPwd1.Text == txtPwd2.Text) //调用BLL的Register()方法
            {
                BLL.Register register = new BLL.Register();
                bool b = register.RegisterAccount(txtRegisterName.Text.Trim(), txtPwd1.Text);
                if (b) //注册成功，显示登录窗口
                {
                    MessageBox.Show("注册成功，请登录");
                    groupBox1.Visible = true;
                    this.Text = "登录";
                    txtLoginName.Focus();
                }
                else
                {
                    MessageBox.Show("注册失败");
                    RClearAndFocus();
                }
            }
            else
            {
                MessageBox.Show("2次输入密码必须相同");
                RClearAndFocus();
            }

        }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            this.Text = "登录";
        }

        /// <summary>
        /// 注册连接，打开注册界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            this.Text = "注册";
            txtRegisterName.Focus();
        }

        /// <summary>
        /// 清空注册输入栏，光标聚焦在用户名栏
        /// </summary>
        void RClearAndFocus()
        {
            txtRegisterName.Clear();
            txtPwd1.Clear();
            txtPwd2.Clear();
            txtRegisterName.Focus();
        }

        /// <summary>
        /// 清空登录输入栏，光标聚焦在用户名栏
        /// </summary>
        void LClearAndFocus()
        {
            txtLoginName.Clear();
            txtPwd.Clear();
            txtLoginName.Focus();
        }

        /// <summary>
        /// 登录按钮，调用BLL中的Login()方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginName.Text.Trim()) || string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("请输入用户名和密码");
                LClearAndFocus();
                return;
            }

            BLL.Login login = new BLL.Login();

            switch (login.GetName(txtLoginName.Text.Trim(), txtPwd.Text))
            {
                case BLL.LoginState.OK:
                    this.DialogResult = DialogResult.OK;
                    break;
                case BLL.LoginState.NoName:
                    MessageBox.Show("用户名不存在");
                    LClearAndFocus();
                    break;
                case BLL.LoginState.IncorrectPwd:
                    MessageBox.Show("密码错误");
                    LClearAndFocus();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 取消登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
