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
    /// DAL_Student类
    /// </summary>
    public class Student
    {
        /// <summary>
        /// DAL_GetStudentTable()方法，获得整张Student表
        /// </summary>
        /// <returns>Model实体类</returns>
        public List<Model.Student> GetStudentTable()
        {
            //要取得整张表时，应从DataTable中一行一行的取得数据，然后赋值给model中，最后把model添加到List泛型集合中
            Model.Student model = null;
            List<Model.Student> modelList = null;
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Student");
            if (dt.Rows.Count > 0) //若DataTable不为null时
            {
                modelList = new List<Model.Student>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    //实例化实体类model（每添加一次，都要新new一个）
                    model = GetModel(dr);//调用GetModel(DataRow dr)方法，给实例化对象中的属性赋值
                    //把实体类对象model，添加到集合中
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 分页查询，获得分页的Student表（只查询IsDel字段值为0，false的）
        /// </summary>
        /// <param name="_pageIndex">页码</param>
        /// <param name="_pageSize">页容量</param>
        /// <returns></returns>
        public List<Model.Student> GetStudentTable(int _pageIndex, int _pageSize) //out参数：可从方法内部向外部输出该参数的值(方法内改变out参数值，方法外部也跟着改变)
        {//已经提前在数据库中创建了，名为GetStudent的执行过程，执行过程为分页查询Student表
            #region 输出分页查询表的总页数（作废）
            //手动定义输出参数，可通过这个out参数，取到输出的值（此处，获得Student表的总页数）？？？
            //SqlParam 
            //sp = new SqlParameter("@pageCount", SqlDbType.Int) { Direction = ParameterDirection.Output }; //？？？
            #endregion

            DataTable dt = SqlHelper.ExecuteDataTable("exec GetStudent @pageIndex, @pageSize",
                new SqlParameter("@pageIndex", SqlDbType.Int) { Value = _pageIndex },
                new SqlParameter("@pageSize", SqlDbType.Int) { Value = _pageSize });

            List<Model.Student> stuList = null;
            if (dt.Rows.Count > 0)
            {
                stuList = new List<Model.Student>();
                //遍历数据集的行集合
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //获得每个行元素
                    DataRow dr = dt.Rows[i];
                    //把行数据转成实体对象，再存入集合中
                    stuList.Add(GetModel(dr));
                }
            }
            return stuList;
        }


        /// <summary>
        /// DAL：修改学员信息时，返回的一行数据
        /// </summary>
        /// <param name="id">要修改学员的ID</param>
        /// <returns>已赋值的实例化对象model</returns>
        public Model.Student GetStudentInfo(int id)
        {
            //修改时，根据ID取得那一行数据（DataTable中只有一行数据）
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Student where ID=@id", new SqlParameter("@id", SqlDbType.Int) { Value = id });
            Model.Student model = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0]; //取得DataTable第一行
                model = GetModel(dr); //调用GetModel(DataRow dr)方法，给实例化对象中的属性赋值
            }
            return model;
        }

        #region 转换成model实体类
        /// <summary>
        /// 把DataTable中的数据，存入Model实体类对象中
        /// </summary>
        /// <param name="dr">DataTable中的行集合</param>
        /// <returns>已存好数据的实体类对象</returns>      
        private Model.Student GetModel(DataRow dr)
        {
            //实例化实体类model
            Model.Student model = new Model.Student();
            model.ID = Convert.ToInt32(dr[0]);
            model.Name = dr[1].ToString();
            model.Password = dr[2].ToString();
            if (!(dr[3] is DBNull)) //字段Age可以为null
            {
                model.Age = Convert.ToInt32(dr[3]);
            }
            if (!(dr[4] is DBNull))
            {
                model.Gender = dr[4].ToString();
            }
            if (!(dr[5] is DBNull))
            {
                model.Address = dr[5].ToString();
            }
            return model;
        }
        #endregion

        /// <summary>
        /// DAL_AddStudent()方法，向数据库插入一条信息
        /// </summary>
        /// <param name="name">要新增的姓名</param>
        /// <param name="pwd">要新增的密码</param>
        /// <param name="age">要新增的年龄</param>
        /// <param name="gender">要新增的性别</param>
        /// <param name="address">要新增的地址</param>
        /// <returns>新增的ID</returns>
        public Model.Student AddStudent(string name, string pwd, int age, string gender, string address)
        {
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@name";
            par1.SqlDbType = SqlDbType.NVarChar;
            par1.Value = name;

            SqlParameter par2 = new SqlParameter("@pwd", SqlDbType.NVarChar) { Value = pwd };

            SqlParameter par3 = new SqlParameter();
            par3.ParameterName = "@age";
            par3.SqlDbType = SqlDbType.Int;
            par3.Value = age;

            SqlParameter par4 = new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender };

            SqlParameter par5 = new SqlParameter("@address", SqlDbType.NVarChar) { Value = address };

            try
            {
                object obj = SqlHelper.ExecuteScalar("insert into Student(Name,Password,Age,Gender,Address) output inserted.ID values(@name,@pwd,@age,@gender,@address)", par1, par2, par3, par4, par5);

                Model.Student model = null;
                if (Convert.ToInt32(obj) > 0) //若有返回值，就实例化实体类
                {
                    //实例化实体类
                    model = new Model.Student();
                    //把得到的ID值存到实体类中的ID属性
                    model.ID = Convert.ToInt32(obj);
                    return model;
                }
                return model;
            }
            catch (SqlException)
            {
                throw;
            }

        }

        /// <summary>
        /// DAL_Update()方法，修改一条信息
        /// </summary>
        /// <param name="id">要修改的ID</param>
        /// <param name="name">要修改的姓名</param>
        /// <param name="pwd">要修改的密码</param>
        /// <param name="age">要修改的年龄</param>
        /// <param name="gender">要修改的性别</param>
        /// <param name="address">要修改的地址</param>
        /// <returns>受影响行数</returns>
        public int Update(int id, string name, string pwd, int age, string gender, string address)
        {
            object obj = SqlHelper.ExecuteNonQuery("update Student set Name=@name,Password=@pwd,Age=@age,Gender=@gender,Address=@address where ID=@id",
               new SqlParameter[]{
                   new SqlParameter ("@id",SqlDbType.Int){Value=id},
                   new SqlParameter("@name",SqlDbType.NVarChar){Value=name},
                   new SqlParameter("@pwd",SqlDbType.NVarChar){Value=pwd},
                   new SqlParameter("@age",SqlDbType.Int){Value=age},
                   new SqlParameter("@gender",SqlDbType.NVarChar){Value=gender},
                   new SqlParameter("@address",SqlDbType.NVarChar){Value=address},
               });
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// DAL_GetAddress():读取Area表
        /// </summary>
        /// <returns>存放已赋过值的泛型集合</returns>
        public List<Model.Area> GetAddress()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Area");
            List<Model.Area> areaList = new List<Model.Area>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i]; //遍历DataTable表中的每一行
                    Model.Area modelArea = new Model.Area(); //创建实体类对象
                    modelArea.ID = Convert.ToInt32(dr[0]); //第一列：ID
                    modelArea.Name = dr[1].ToString(); //第二列：Name
                    modelArea.UID = Convert.ToInt32(dr[2]); //第三列：UID
                    //把赋过值的实体类对象modelArea，存到泛型集合areaList中：
                    areaList.Add(modelArea);
                }
            }

            return areaList;
        }

        /// <summary>
        /// 根据ID删除一条学生信息
        /// </summary>
        /// <param name="id">要删除行的ID</param>
        /// <returns>受影响行数</returns>
        public int Delete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from Student where ID=@id",
                new SqlParameter("@id", SqlDbType.Int) { Value = id });
        }

        /// <summary>
        /// 把IsDel字段从0改成1（从false改成true）
        /// </summary>
        /// <param name="id">要修改的ID</param>
        /// <returns>受影响行数</returns>
        public int IsDelete(int id)
        {   //如果参数只是int类型(强类型)，就不会发生注入攻击，可直接拼接
            return SqlHelper.ExecuteNonQuery("update Student set IsDel=1 where ID=" + id);
        }

        /// <summary>
        /// 查询所有IsDel=1，true的信息
        /// </summary>
        /// <returns>IsDel为true</returns>
        public List<Model.Student> GetRecycleStuTable()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Student where IsDel=1");
            List<Model.Student> stuList = null;
            if (dt.Rows.Count > 0)
            {
                stuList = new List<Model.Student>(); //千万记得new List集合！！！
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    stuList.Add(GetModel(dr));
                }
            }
            return stuList;
        }

        /// <summary>
        /// 撤销删除
        /// </summary>
        /// <param name="id">要撤销的ID</param>
        /// <returns>受影响行数</returns>
        public int RemoveStu(int id)
        {
            //把数据库中IsDel字段的值从1改成0（从true改成false）
            return SqlHelper.ExecuteNonQuery("update Student set IsDel=0 where ID=" + id);
        }

    }
}
