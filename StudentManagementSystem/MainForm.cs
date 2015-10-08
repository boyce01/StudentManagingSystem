using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region 单例模式
        ////私有化构造函数，使外部不能new此MainForm窗体类
        //private MainForm()
        //{
        //    InitializeComponent();
        //}
        ////创建窗体类，静态，私有变量
        //private static MainForm instance;
        ////创建静态的，公共的，返回窗体对象的方法，即：设置全局访问点
        //public static MainForm GetInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //    {
        //        instance = new MainForm();
        //    }
        //    return instance;
        //} 
        ////需要调用MainForm类对象时：
        ////MainForm mf = MainForm.GetInstance();
        #endregion

        //这个类中的多个方法，都有可能调用BLL.Student类中的方法，故声明在外面
        BLL.Student stu = new BLL.Student();

        //公共类变量
        int pageIndex = 1; //默认页码
        int pageSize = 10; //默认页容量
        bool isDel = false; //第一次点击删除，把选中信息添加到回收站，在回收站中点删除，真的删除

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false; //dataGridView控件，不自动生成列

            GetLastStudentTable();

            #region 加载时，显示页容量下拉框
            cmbPage.Items.Add(10);
            cmbPage.Items.Add(20);
            cmbPage.Items.Add(50);
            cmbPage.SelectedIndex = 0;
            #endregion

            #region 加载时，显示性别查询下拉框
            cmbGender.Items.Add("不限");
            cmbGender.Items.Add("男");
            cmbGender.Items.Add("女");
            cmbGender.SelectedIndex = 0;
            #endregion
        }

        /// <summary>
        /// 获得最新的Student表
        /// </summary>
        void GetLastStudentTable()
        {
            if (isDel) //isDel=true:在回收站中加载
            {
                btnRemove.Visible = true; //显示"撤销删除"按钮
                btnBack2List.Visible = true; //显示"查看列表"按钮
                panel1.Visible = false; //分页不可见
                List<Model.Student> modelList = stu.GetRecycleStuTable();
                dgvMain.DataSource = modelList;
            }
            else //isDel=false：普通加载
            {
                btnRemove.Visible = false; //"撤销删除"按钮不可见
                btnBack2List.Visible = false; //"查看列表"按钮不可见
                panel1.Visible = true; //显示分页
                lblPage.Text = "第" + pageIndex.ToString() + "页"; //显示页数
                List<Model.Student> modelList = stu.GetStudentTable(pageIndex, pageSize); //分页查询
                //对象名.DataSource:可以添加DataTable,List<>泛型集合
                dgvMain.DataSource = modelList;
            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //打开增加学员页面
            AddStuForm addStu = new AddStuForm();
            //在添加完学员信息之前(关闭添加页面之前)，不能操作原来的窗体：addStu.ShowDialog(); 
            if (addStu.ShowDialog() == DialogResult.OK)
            {
                GetLastStudentTable();
            }
        }

        /// <summary>
        /// 修改学员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selectedId = GetIdFromDGV();
            if (selectedId == -1)
            {
                return;
            }
            //从此处调用，打开修改页面：
            AddStuForm addStu = new AddStuForm(selectedId);
            //若新打开的窗体，是用来操作的，就用ShowDialog()
            if (addStu.ShowDialog() == DialogResult.OK)
            {
                GetLastStudentTable();
            }
        }

        /// <summary>
        /// 从DataGridView控件中得到，选中行的ID列的值
        /// </summary>
        /// <returns>选中行ID列中的值</returns>
        private int GetIdFromDGV()
        {
            if (dgvMain.SelectedRows.Count > 0) //若选中行的集合大于0
            {
                //获得用户选中行的集合的第一行：
                DataGridViewRow dgvr = dgvMain.SelectedRows[0];
                //获得选中行的第一列（ID列）：
                DataGridViewCell dgvc = dgvr.Cells[0];
                //获得ID列中的值：
                int selectedId = Convert.ToInt32(dgvc.Value); //可封装成一个方法
                return selectedId;
            }
            return -1; //若未选中任何一行，则返回-1
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pageIndex++;
            GetLastStudentTable();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pageIndex--;
            if (pageIndex < 1)
            {
                pageIndex = 1; //当pageIndex小于默认页码时，赋值为1
                return; //且退出循环，不执行GetLastStudentTable()方法
            }
            GetLastStudentTable();
        }

        /// <summary>
        /// 改变页容量下拉框的值时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //每当改变页容量的值时，就要重新开始翻页(不然有bug)：
            pageIndex = 1;

            pageSize = Convert.ToInt32(cmbPage.Text);
            GetLastStudentTable();
        }

        /// <summary>
        /// 删除学员(根据ID)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int selectedId = GetIdFromDGV();

            if (isDel) //isDel为true：在回收站中点删除，真的删除
            {
                if (stu.Delete(selectedId)) //受影响行数大于0
                {
                    MessageBox.Show("删除成功");
                    GetLastStudentTable();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else //isDel为false：添加到回收站中
            {
                if (stu.IsDelete(selectedId))
                {
                    MessageBox.Show("把用户移入回收站");
                    GetLastStudentTable();
                }
                else
                {
                    MessageBox.Show("移入回收站失败");
                }
            }

        }

        /// <summary>
        /// 批量删除学员(根据ID)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMain.SelectedRows.Count; i++)
            {
                //获得用户选中行的集合的第i行：
                DataGridViewRow dgvr = dgvMain.SelectedRows[i];
                //获得选中行的第一列（ID列）：
                DataGridViewCell dgvc = dgvr.Cells[0];
                //获得ID列中的值：
                int selectedId = Convert.ToInt32(dgvc.Value);
                //删除当前遍历到的行
                stu.Delete(selectedId);
            }
            MessageBox.Show("批量删除成功");
            GetLastStudentTable();
        }

        /// <summary>
        /// 回收站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecycle_Click(object sender, EventArgs e)
        {
            isDel = true; //回收站中：只要进到回收站中，isDel就为true,无论进行哪些操作，isDel的值都是true，直到离开回收站
            GetLastStudentTable();
        }

        /// <summary>
        /// 在回收站中，可以查看列表，回到之前界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack2List_Click(object sender, EventArgs e)
        {
            isDel = false; //离开回收站：当离开时，isDel才再此被赋值为false
            GetLastStudentTable();
        }

        /// <summary>
        /// 撤销删除，把回收站里的行，返回普通列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //把数据库中IsDel字段的值从1改成0(从true改成false):
            int selectedId = GetIdFromDGV();
            if (selectedId == -1)
            {
                return;
            }

            if (stu.RemoveStu(selectedId)) //受影响行数大于0
            {
                MessageBox.Show("移除除功");
                GetLastStudentTable();
            }
            else
            {
                MessageBox.Show("移除失败");
            }
        }

        /// <summary>
        /// 导出Excel列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            #region create and export excel
            ////创建一个工作本对象
            //HSSFWorkbook workbook = new HSSFWorkbook();
            ////通过工作本对象，创建一个页
            //HSSFSheet sheet = workbook.CreateSheet("第一页");
            ////通过页，创建一个行对象
            //HSSFRow row = sheet.CreateRow(0);
            ////通过行对象，创建一个指定位置的列的对象
            //HSSFCell cell = row.CreateCell(0);
            ////给创建的列对象赋值
            //cell.SetCellValue("张三asd");
            ////创建第二列，并给第二列赋值
            //HSSFCell cell2 = row.CreateCell(1);
            //cell2.SetCellValue(111); 
            #endregion

            //创建一个工作本对象
            HSSFWorkbook workbook = new HSSFWorkbook();
            //通过工作本对象，创建一个页
            HSSFSheet sheet = workbook.CreateSheet("第一页");
            //创建第一行
            HSSFRow rowHead = sheet.CreateRow(0);
            //在已创建的第一行中，创建5个列，并赋值
            rowHead.CreateCell(0).SetCellValue("No.");
            rowHead.CreateCell(1).SetCellValue("NAME");
            rowHead.CreateCell(2).SetCellValue("AGE");
            rowHead.CreateCell(3).SetCellValue("GENDER");
            rowHead.CreateCell(4).SetCellValue("ADDRESS");
            //可写成：HSSFCell cell0 = rowHead.CreateCell(0);
            //cell0.SetCellValue("No.");

            //循环建立行
            for (int i = 0; i < dgvMain.RowCount; i++) //不能让i=1,因为从面板上开始遍历
            {
                HSSFRow row = sheet.CreateRow(i + 1); //从第2行开始建立行，第一行为列名
                //循环建立列，并给创建的列对象直接赋值
                for (int j = 0; j < 5; j++)
                {
                    row.CreateCell(j).SetCellValue(dgvMain.Rows[i].Cells[j].Value.ToString());
                    //上面代码也可写成：HSSFCell cell = row.CreateCell(j);//创建第j列
                    //cell..SetCellValue(dgvMain.Rows[i].Cells[j].Value.ToString());
                }
            }
            //建立保存文本对话框：
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Table|*.xls";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    //通过FileStream导出内存中的exeel表
                    using (FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fs);
                    }
                }
            }

        }//btnExport_Click

        /// <summary>
        /// select student infor by name or gender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //声明2个list泛型集合，1个存sql语句中where后面的查询条件，另1个存sqlparameter
            //因为不确定用户是否选择姓名or性别，故用List泛型集合（集合中可以随意添加元素）
            List<string> listWhere = new List<string>();
            List<SqlParameter> listSqlpara = new List<SqlParameter>();
            //若有name，就存入2个集合中
            if (!(string.IsNullOrEmpty(txtName.Text.Trim())))
            {
                listWhere.Add("Name=@name");
                listSqlpara.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = txtName.Text.Trim() });
            }
            if (cmbGender.SelectedIndex != 0)
            {
                listWhere.Add("Gender=@gender");
                listSqlpara.Add(new SqlParameter("@gender", SqlDbType.NVarChar) { Value = cmbGender.Text });
                //当下来框是DropDownList格式时，必须用“对象名.Text”取值 
            }

            string sql = "select * from Student ";
            if (listWhere.Count > 0) //若用户选择了查询条件
            {
                sql += " where " + string.Join(" and ", listWhere.ToArray());
                //string.Join():会在每个字符串直接插入指定字符
            }
            //search stu by name or gender
            List<Model.Student> stuList = stu.GetStuTableByNameOrGender(sql, listSqlpara.ToArray());
            dgvMain.DataSource = stuList;
        }

    }
}
