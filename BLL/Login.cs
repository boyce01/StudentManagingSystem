using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Security; //用于MD5转换

namespace BLL
{
    /// <summary>
    /// BLL_Login类
    /// </summary>
    public class Login
    {
        /// <summary>
        /// BLL_GetName()方法，登录判断
        /// </summary>
        /// <param name="name">登录用户名</param>
        /// <param name="pwd">登录密码</param>
        /// <returns>是否登录成功</returns>
        public LoginState GetName(string name, string pwd)
        {
            DAL.Login login = new DAL.Login();
            Model.Student model = login.GetName(name);

            //把用户输入的pwd进行MD5转换，再与数据库得到的pwd(MD5加密后的)对比
            //1）添加引用；2）添加namespace:using System.Web.Security;
            pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5").ToLower();
            //微软提供的FormsAuthentication类的，HashPasswordForStoringInConfigFile()方法，会把加密后的MD5字符串自动
            //转成大写，故：要ToLower()

            if (model == null)
            {
                return LoginState.NoName;
            }
            else
            {
                if (model.Password == pwd)
                {
                    return LoginState.OK;
                }
                else
                {
                    return LoginState.IncorrectPwd;
                }
            }

        }
    }
}
