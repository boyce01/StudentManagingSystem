using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Security; //用于MD5

namespace BLL //添加了对DAL类库的引用，以便调用DAL类库中的类
{
    /// <summary>
    /// BLL_Register类
    /// </summary>
    public class Register
    {
        /// <summary>
        /// BLL_RegisterAccount()方法，向数据库insert一条数据
        /// </summary>
        /// <param name="name">要注册的用户名</param>
        /// <param name="pwd">要注册的密码</param>
        /// <returns></returns>
        public bool RegisterAccount(string name, string pwd)
        {
            DAL.Register register = new DAL.Register();
            //把用户输入的密码，进行MD5加密，再存入数据库
            pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5").ToLower();
            //微软提供的FormsAuthentication类的，HashPasswordForStoringInConfigFile()方法，会把加密后的MD5字符串自动
            //转成大写，故：要ToLower()

            int res = register.RegisterAccount(name, pwd);
            if (res==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
