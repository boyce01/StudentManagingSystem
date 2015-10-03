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
    /// DAL_Login类
    /// </summary>
    public class Login
    {
        /// <summary>
        /// 根据名字取得用户信息
        /// </summary>
        /// <param name="name">要check的用户名</param>
        /// <returns></returns>
        public Model.Student GetName(string name)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Student where Name=@name", new SqlParameter("@name", name));
            //int i = dt.Rows.Count; //DataTable中的行数，若1行都没有，说明返回的DataTable是一个null
            //即：DataRow中没有数据(但DataTable仍是一张表)

            Model.Student model = null;

            if (dt.Rows.Count > 0) //DataTable不为null时(有用户名时)
            {
                DataRow dr = dt.Rows[0];
                model = new Model.Student();
                model.Name = dr[1].ToString();
                model.Password = dr[2].ToString();
            }
            return model;
        }

    }
}
