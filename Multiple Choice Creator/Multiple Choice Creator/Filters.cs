using System;
using Multiple_Choice_Creator.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    public partial class Filters : UserControl
    {
        public Filters()
        {

            //myTreeview = treeView1;
            
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            fillTreeView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public List<String> returnThemes()
        {
            List<String> myList = new List<string>();
            foreach (TreeNode child in this.treeView1.Nodes)
            {
                if (child.Checked)
                {
                    myList.Add(child.Text);
                }
                myList.AddRange(returnChildNodethemes(child));
            }
            return myList;
        }

        public List<String> returnChildNodethemes(TreeNode node)
        {
            List<String> tempList = new List<String>();
            foreach(TreeNode child in node.Nodes)
            {
                if (child.Checked)
                {
                    tempList.Add(child.Text);
                }
                tempList.AddRange(returnChildNodethemes(child));
            }
            return tempList;
        }

        private void fillTreeView()
        {
            DaoMysql dMsql = new DaoMysql();
            List<Topic> topicList = dMsql.returnThemeTree();
            themeTree myThemeTree = new themeTree(topicList);
            myThemeTree.printKids(0, treeView1);
            //TreeView item = (TreeView)(treeView1);
            //myThemeTree.printKids(0, item);



        }
        public List<TreeNode> tmNodes = new List<TreeNode>();
        //isws kai na thelei mono gia ena node

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void myNodeExpand(TreeNode nodeExpand)
        {
            while (nodeExpand != null)
            {
                nodeExpand.Expand();
                nodeExpand = nodeExpand.Parent;

            }
        }

        private void removeColor(List<TreeNode> listoOfNodes)
        {
            foreach (TreeNode node in listoOfNodes)
            {
                node.BackColor = Color.White;
            }
        }

        private TreeNode FindNode(TreeNode node, string searchText)
        {
            TreeNode result = null;

            if (node.Text.ToUpper().Contains(searchText.ToUpper()))
            {
                result = node;
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                {
                    result = FindNode(child, searchText);
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            List<String> mys = returnThemes();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            removeColor(tmNodes);
            if (textBox1.Text.Length > 0)
            {
                foreach (TreeNode node in this.treeView1.Nodes)
                {

                    TreeNode tmpNode = FindNode(node, textBox1.Text);
                    if (tmpNode != null)
                    {
                        this.myNodeExpand(tmpNode);
                        tmpNode.BackColor = Color.Orange;

                        tmNodes = new List<TreeNode>();
                        tmNodes.Add(tmpNode);
                        break;
                        //treeView1.Select();
                        //treeView1.SelectedNode = tmpNode;
                    }


                }
            }
        }


    }
}
