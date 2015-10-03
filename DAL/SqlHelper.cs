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
    /// DAL_SqlHelper类，用于调用数据库信息
    /// </summary>
    class SqlHelper
    {
        private static string connStr = @"server=UP-PC\MSSQL2012;database=mydb1;uid=sa;pwd=123";

        /// <summary>
        /// SQL增删改方法，返回受影响行数
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] par)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(par);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// SQL查询方法，返回结果集的首行首列
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>结果集的首行首列</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] par)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(par);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// SQL查询，返回数据集中的第一张表
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>数据集中的第一张表，若没有取到表，就返回null</returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] par)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
            {
                using (DataSet ds = new DataSet())
                {
                    //添加sql语句需要的参数
                    adapter.SelectCommand.Parameters.AddRange(par);
                    try
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                    catch
                    {
                        return null; //如果没有取到表，就返回null
                    }
                }
            }
        }

    }

}
