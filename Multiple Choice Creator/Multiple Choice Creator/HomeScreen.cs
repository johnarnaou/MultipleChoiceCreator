using Multiple_Choice_Creator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    public partial class HomeScreen : Form
    {
        LoadFeed feed;
        Manage manage;
        Filter myFilter;
        public HomeScreen(User user)
        {
            InitializeComponent();
            //fillTreeView();
            feed = new LoadFeed(splitContainer3.Panel2, user);
            splitContainer3.Panel2.AutoScroll = true;
            feed.load();
            myFilter = new Filter(splitContainer1.Panel1);
            manage = new Manage(user, splitContainer3.Panel1, feed,myFilter.getFilters());
           

        }

        /*
        private void fillTreeView()
        {
            DaoMysql dMsql = new DaoMysql();
            List<Topic> topicList = dMsql.returnThemeTree();
            themeTree myThemeTree = new themeTree(topicList);
            myThemeTree.printKids(0, treeView1);



        }

    */

        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //public List<TreeNode> tmNodes = new List<TreeNode>();
        //isws kai na thelei mono gia ena node
        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            removeColor(tmNodes);
            if (textBox1.Text.Length > 0) { 
                foreach (TreeNode node in this.treeView1.Nodes)
                {

                    TreeNode tmpNode = FindNode(node, textBox1.Text);
                    if (tmpNode != null)
                    {
                        this.myNodeExpand(tmpNode);
                        tmpNode.BackColor = Color.Orange;
                        
                        tmNodes =new List<TreeNode>();
                        tmNodes.Add(tmpNode);
                        break;
                        //treeView1.Select();
                        //treeView1.SelectedNode = tmpNode;
                    }


                }
            }
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
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
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
        }*/
    }
}
