using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;


namespace MyContrals
{
    public partial class TvUser : UserControl
    {
        

        #region 增加AfterCheck事件
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AfterCheckEventHandler(object sender, System.Windows.Forms.TreeViewEventArgs e);
        private AfterCheckEventHandler AfterCheckEvent;

        public event AfterCheckEventHandler AfterCheck
        {
            add
            {
                AfterCheckEvent = (AfterCheckEventHandler)System.Delegate.Combine(AfterCheckEvent, value);
            }
            remove
            {
                AfterCheckEvent = (AfterCheckEventHandler)System.Delegate.Remove(AfterCheckEvent, value);
            }
        }
        #endregion


        #region 增加AfterSelect事件
        public delegate void AfterSelectEventHandler(object sender, System.Windows.Forms.TreeViewEventArgs e);
        private AfterSelectEventHandler AfterSelectEvent;

        public event AfterSelectEventHandler AfterSelect
        {
            add
            {
                AfterSelectEvent = (AfterSelectEventHandler)System.Delegate.Combine(AfterSelectEvent, value);
            }
            remove
            {
                AfterSelectEvent = (AfterSelectEventHandler)System.Delegate.Remove(AfterSelectEvent, value);
            }
        }
        #endregion



        private bool Check = true;

        #region 清除所有节点的方法
        public void Clear()
        {
            this.TreeView1.Nodes.Clear();
        }
        #endregion

        #region 返回所有节点的属性
        public System.Windows.Forms.TreeNodeCollection Nodes
        {
            get
            {
                return this.TreeView1.Nodes;
            }

        }
        #endregion



        public TvUser()
        {
            InitializeComponent();
        }

        #region 增加TREE的方法
        public void AddTree(DataTable dt, string Fa_menu_no, string menu_no, string menu_name)
        {
            short i = 0;
            i = (short)0;
            TreeNode TV = new TreeNode();

            this.TreeView1.Nodes.Clear();
            this.TreeView1.ImageList = this.ImageList1;

            TV.Text = (dt.Rows[i]["menu_name"]).ToString();
            TV.Tag = (dt.Rows[i]["menu_no"]).ToString();
            this.TreeView1.Nodes.Add(TV);
            TV.ImageIndex = 0;
            TV.SelectedImageIndex = 0;


            i++;

            while (i != dt.Rows.Count - 1)
            {
                TV = GetNode(TV, dt.Rows[i][Fa_menu_no].ToString());
                TV = TV.Nodes.Add(dt.Rows[i][menu_name].ToString());
                TV.Tag = dt.Rows[i][menu_no].ToString();
                TV.ImageIndex = 0;
                i++;
            }
            this.TreeView1.Nodes[0].Expand();
        }



        /// <summary>
        /// 得到当前节点的父节点
        /// </summary>
        /// <param name="Node">当前节点</param>
        /// <param name="Fa_NodeTag">父节Tag名称</param>
        /// <returns>返回父节点的Node</returns>
        private TreeNode GetNode(TreeNode Node, string Fa_NodeTag)
        {
            TreeNode returnValue = default(TreeNode);
            
            returnValue = Node;
            while (!(Node.Parent == null))
            {
                if ((string)Node.Parent.Tag.ToString() == Fa_NodeTag.ToString())
                {
                    returnValue = Node.Parent;
                    return returnValue;
                }
                else
                {
                    Node = Node.Parent;
                }
            }

            return returnValue;
        }
        #endregion




        public void SelectNode(ref DataTable dt, string menu_no, TreeNode Node, ref int j)
        {

         

            if (j == dt.Rows.Count)
            {
                Check = false;
                Node.Checked = false;
                Node.ImageIndex = 0;
                Node.SelectedImageIndex = 0;
                Check = true;
            }
            else
            {
                if (dt.Rows[j]["menu_no"].ToString() == Node.Tag.ToString())
                {
                    Check = false;
                    Node.Checked = true;
                    Node.ImageIndex = 1;
                    Node.SelectedImageIndex = 1;
                    Check = true;
                    j++;
                }
            }

            if (Node.FirstNode == null)
            {
                if (Node.NextNode == null)
                {
                    Check = false;
                    CheckParentNode(ref Node);
                    Check = true;
                }
            }
            else
            {
                for (int i = 0; i <= Node.GetNodeCount(false) - 1; i++)
                {
                    SelectNode(ref dt, menu_no, Node.Nodes[i], ref j);
                }
            }

        }
        private void TvUser_Resize(object sender, System.EventArgs e)
        {
            this.TreeView1.Left = 0;
            this.TreeView1.Top = 0;
            this.TreeView1.Width = this.Width;
            this.TreeView1.Height = this.Height;
        }

        private void TreeView1_AfterCheck(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (Check == true)
            {
                this.TreeView1.Enabled = false;
                Check = false;
                if (AfterCheckEvent != null)
                    AfterCheckEvent(sender, e);
                Check = true;
                this.TreeView1.Enabled = true;
            }
        }
        public void CheckNode(TreeNode Node)
        {
            CheckChildNode(Node);
            CheckParentNode(ref Node);

        }
        private void CheckChildNode(TreeNode Node)
        {

            if (Node.Checked == true)
            {
                Node.ImageIndex = 1;
                Node.SelectedImageIndex = 1;
            }
            else
            {
                Node.ImageIndex = 0;
                Node.SelectedImageIndex = 0;
            }

            if (Node.FirstNode == null)
            {
                return;
            }
            else
            {
                Node.FirstNode.Checked = Node.Checked;
                Node = Node.FirstNode;
                CheckChildNode(Node);
            }

            while (!(Node.NextNode == null))
            {
                Node.NextNode.Checked = Node.Checked;
                Node = Node.NextNode;
                CheckChildNode(Node);
            }

        }
        private void CheckParentNode(ref TreeNode Node)
        {

            
            short s = 0;


            s = (short)Node.ImageIndex;

            if (Node.Parent == null)
            {
                return;
            }

            Node = Node.Parent;
            for (int i = 0; i <= Node.GetNodeCount(false) - 1; i++)
            {

                if (Node.Nodes[i].ImageIndex != s)
                {
                    s = (short)2;
                    break;
                }
            }
            if (s == 0)
            {
                Node.Checked = false;
            }
            else
            {
                Node.Checked = true;
            }
            Node.ImageIndex = s;
            Node.SelectedImageIndex = s;
            CheckParentNode(ref Node);

        }
        private void TreeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (AfterSelectEvent != null)
                AfterSelectEvent(sender, e);

        }

        private void TvUser_Load(object sender, EventArgs e)
        {

        }


      
    }
}
