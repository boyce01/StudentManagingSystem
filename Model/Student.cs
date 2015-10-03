using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Model_Student实体类：储存从数据库中取得的数据
    /// </summary>
    public class Student
    {
        //实体类：只有字段、属性，没有方法的类
        //按照数据库中的字段(列)，声明字段和属性：

        private int _id;
        public int ID
        { get; set; }

        private string _name;
        public string Name
        { get; set; }

        private string _pwd;
        public string Password
        { get; set; }

        private int _age;
        public int Age
        { get; set; }

        private string _gender;
        public string Gender
        { get; set; }

        private string _address;
        public string Address
        { get; set; }

    }
}
