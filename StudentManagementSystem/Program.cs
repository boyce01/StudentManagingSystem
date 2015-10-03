using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建登录窗体对象：
            //LoginForm lf = new LoginForm(); //会先打开登录界面LoginForm
            //if (lf.ShowDialog() == DialogResult.OK)
            //{
            //Application.Run(new LoginForm());
            //Application.Run(new AddStuForm());
            Application.Run(new MainForm()); //登录页面不能作为主界面，因为主界面要保持开着
            //}

            /***************************************************************************
             * 解析：当程序从Main()进来，执行到lf.ShowDialog()时，
             * LoginForm窗体(登录窗口)会弹出，程序停止，等待用户选择login按钮或cancel按钮
             * 之后程序根据用户的选择返回DialogResult.OK或DialogResult.Cancel
             * 以此来觉得主窗体MainForm是否开启
             * 何时用ShowDialog()?
             * 若新打开的窗体，是用来操作的，就用ShowDialog()
             ***************************************************************************/
        }
    }
}
