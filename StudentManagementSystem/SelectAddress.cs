using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
        }

        //声明一个Model.Area实体类
        Model.Area[] areaModel = null;

        private void AddressForm_Load(object sender, EventArgs e)
        {
            BLL.Student stu = new BLL.Student();
            List<Model.Area> areaList = stu.GetAddress();
            //把泛型集合转成数组
            areaModel = areaList.ToArray();
            LoadArea(0, null);
        }
       
        #region eg. 取得List<>泛型集合中的某个值
        /************************************************** 
         * 假设只要输出uid=0的项（省）：
         *   for (int i = 0; i < areaModel.Length; i++)
         *   {
         *      if (areaModel[i].UID==0)
         *     {
         *        TreeNode tNode = new TreeNode();
         *        tNode.Text = areaModel[i].Name;
         *        tvArea.Nodes.Add(tNode);
         *     }
         *   }
         ***************************************************/
        
        #endregion

        /// <summary>
        /// 添加地区
        /// </summary>
        /// <param name="pid">地区的父级id</param>
        /// <param name="pnode">父级节点</param>
        void LoadArea(int pid, TreeNode pnode)//pid为地区的父级id;pnode为父级节点
        {
            //遍历数组中的每一项（每一项就是一行数据，数据为Model.Area类型的，存放在Model.Area类的属性中）
            for (int i = 0; i < areaModel.Length; i++)
            {//areaModel[0]表示：Area表中的第一行数据，第一行的每个列(字段)的值，存放在实体类的对应属性中！
                if (areaModel[i].UID == pid)//父级id为0，全国的省
                {
                    TreeNode tnode = new TreeNode();
                    tnode.Text = areaModel[i].Name;//节点标签要显示的文本
                    if (pnode == null)
                    {
                        //若父节点为null,把节点添加到面板上：
                        tvArea.Nodes.Add(tnode);
                    }
                    else
                    {
                        //若已有父节点，则在父节点下添加子节点：
                        pnode.Nodes.Add(tnode);//把创建的节点，添加到面板上
                    }
                    //自己调用自己，来添加子节点
                    LoadArea(areaModel[i].ID, tnode);
                }
            }
        }


        //创建一个public属性，来接收所选地区的值
        public string SelectedArea { get; set; }

        /// <summary>
        /// 确定选择地区，显示在地址栏上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //获得所选地区,赋值给SelectedArea属性
            this.SelectedArea = tvArea.SelectedNode.FullPath.ToString();
            //关闭ShowDialog窗口
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消地区选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
