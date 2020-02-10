using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获得第一层节点集合
            List<StoreModel> list = GetFirstNodeData();
            foreach (StoreModel item in list)
            {
                //父节点
                TreeNode firstNode = new TreeNode();
                firstNode.Text = item.storeName;
                firstNode.Tag = item.storeCode;
                List<StoreModel> list2 = GetSecondNodeData(item.storeName);
                foreach (StoreModel item2 in list2)
                {
                    //子节点
                    TreeNode secondNode = new TreeNode();
                    secondNode.Text = item2.storeCode;
                    secondNode.Tag = item2.storeName;
                    //关联父子节点
                    firstNode.Nodes.Add(secondNode);
                }
                treeView1.Nodes.Add(firstNode);
            }
            
        }

        private List<StoreModel> GetFirstNodeData()
        {
            List<StoreModel> list = new List<StoreModel>();
            string sql = "select 仓库名称, 仓库代码 from 仓库信息_主表 ";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreModel model = new StoreModel();
                        model.storeName = reader.GetString(0);
                        model.storeCode = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        private List<StoreModel> GetSecondNodeData(string name)
        {
            List<StoreModel> list = new List<StoreModel>();
            string sql = "select 仓位代码,所属仓库 from 仓位信息_主表 where 所属仓库 = @storeName ";
            //赋参数
            SqlParameter p1 = new SqlParameter("@storeName", SqlDbType.NVarChar) { Value = name };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, p1))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreModel model = new StoreModel();
                        model.storeName = reader.GetString(1);
                        model.storeCode = reader.GetString(0);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
