using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// DAL_Register类
    /// </summary>
    public class Register
    {
        /// <summary>
        /// DAL_RegisterAccount()方法，向数据库insert一条数据，并得到返回结果
        /// </summary>
        /// <param name="name">要注册的用户名</param>
        /// <param name="pwd">要注册的密码</param>
        /// <returns>受影响行数</returns>
        public int RegisterAccount(string name, string pwd)
        {
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@name";
            par1.SqlDbType = SqlDbType.NVarChar;
            par1.Value = name;

            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "@pwd";
            par2.SqlDbType = SqlDbType.NVarChar;
            par2.Value = pwd;

            return SqlHelper.ExecuteNonQuery("insert into Student(Name,Password) values(@name,@pwd)", par1, par2);
        }
    }
}
