using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// BLL_enum,判断登录状态
    /// </summary>
    public enum LoginState
    {//此处，应该再新建一个公共的Common层，DAL,BLL,UI层都可以调用
        //一个项目中有很多类，方法，但有些不应该属于3层之内的，但又是项目需要的，
        //故，可以将那些类写到Common层

        /// <summary>
        /// 登录成功
        /// </summary>
        OK,

        /// <summary>
        /// 用户名不存在
        /// </summary>
        NoName,

        /// <summary>
        /// 密码错误
        /// </summary>
        IncorrectPwd
    }
}
