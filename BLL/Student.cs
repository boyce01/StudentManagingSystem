using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// BLL_Student类
    /// </summary>
    public class Student
    {
        //这个类中的多个方法，都有可能调用DAL.Student类中的方法，故声明在外面
        DAL.Student stu = new DAL.Student();

        /// <summary>
        /// BLL_GetStudentTable()方法，获得整张Student表
        /// </summary>
        /// <returns></returns>
        public List<Model.Student> GetStudentTable()
        {
            return stu.GetStudentTable();
        }

        /// <summary>
        /// 分页查询，获得分页的Student表
        /// </summary>
        /// <param name="_pageIndex">页码</param>
        /// <param name="_pageSize">页容量</param>
        /// <returns></returns>
        public List<Model.Student> GetStudentTable(int _pageIndex, int _pageSize)
        {
            return stu.GetStudentTable(_pageIndex, _pageSize);
        }

        /// <summary>
        /// BLL：修改学员信息时，返回的一行数据
        /// </summary>
        /// <param name="id">要修改学员的ID</param>
        /// <returns>已赋值的实例化对象model</returns>
        public Model.Student GetStudentInfo(int id)
        {
            //修改时，根据ID取得那一行数据
            return stu.GetStudentInfo(id);
        }

        /// <summary>
        /// BLL_AddStudent()方法，向数据库插入一条信息
        /// </summary>
        /// <param name="name">要新增的姓名</param>
        /// <param name="pwd">要新增的密码</param>
        /// <param name="age">要新增的年龄</param>
        /// <param name="gender">要新增的性别</param>
        /// <param name="address">要新增的地址</param>
        /// <returns>添加的ID</returns>
        public Model.Student AddStudent(string name, string pwd, int age, string gender, string address)
        {
            return stu.AddStudent(name, pwd, age, gender, address);
        }

        /// <summary>
        /// BLL_Update()方法，修改一条信息
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
            return stu.Update(id, name, pwd, age, gender, address);
        }

        /// <summary>
        /// BLL_GetAddress():读取Area表
        /// </summary>
        /// <returns>存放已赋过值的泛型集合</returns>
        public List<Model.Area> GetAddress()
        {
            return stu.GetAddress();
        }

        /// <summary>
        /// 根据ID删除一条学生信息
        /// </summary>
        /// <param name="id">要删除行的ID</param>
        /// <returns>受影响行数是否大于0</returns>
        public bool Delete(int id)
        {
            return stu.Delete(id) > 0;
        }

        /// <summary>
        /// 把IsDel字段从0改成1（从false改成true）
        /// </summary>
        /// <param name="id">要修改的ID</param>
        /// <returns>受影响行数是否大于0</returns>
        public bool IsDelete(int id)
        {
            return stu.IsDelete(id) > 0;
        }

        /// <summary>
        /// 查询所有IsDel=1，true的信息
        /// </summary>
        /// <returns>IsDel为true</returns>
        public List<Model.Student> GetRecycleStuTable()
        {
            return stu.GetRecycleStuTable();
        }

        /// <summary>
        /// 撤销删除
        /// </summary>
        /// <param name="id">要撤销的ID</param>
        /// <returns>受影响行数是否大于0</returns>
        public bool RemoveStu(int id)
        {
            return stu.RemoveStu(id) > 0;
        }


    }
}
