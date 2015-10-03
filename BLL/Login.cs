using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
