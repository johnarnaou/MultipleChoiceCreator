﻿using System;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;

namespace Multiple_Choice_Creator
{
    public partial class Filters : UserControl
    {
        LoadFeed myfeed;
        public Filters(object feed)
        {

            //myTreeview = treeView1;

            InitializeComponent();
            myfeed = (LoadFeed)feed;
            fill_checkedListBox();
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

        private void fill_checkedListBox()
        {
            try
            {
                checkedListBox1.Items.Clear();
                foreach(object itemChecked in this.checkedListBox1.Items)
                {
                    checkedListBox1.Items.Remove(itemChecked);
                }
                DiffTableAdapter myDiffAdapter = new DiffTableAdapter();
                mltChoiceDataSet.DiffDataTable diff = myDiffAdapter.getDifficulties();
                for(int i = 0; i < diff.Count(); i++)
                {
                    object mycheckedListBoxItem = (String)diff[i]["name"];
                    checkedListBox1.Items.Add(mycheckedListBoxItem);
                }
                //checkedListBox1.BackColor = Color.LightSteelBlue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void expand_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();

        }

        private void close_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach(TreeNode node in this.treeView1.Nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                checkedListBox1.SetSelected(i, false);
            }

        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        List<string> DifficultiesChecked=new List<string>();
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            List<string> checkedItems = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
                checkedItems.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(checkedListBox1.Items[e.Index].ToString());
            else
            {
                checkedItems.Remove(checkedListBox1.Items[e.Index].ToString());
            }

            foreach (string item in checkedItems)
            {
                Console.WriteLine("ITEM: "+item);
            }
            myfeed.filterLoad(checkedItems);


            /*foreach (object itemChecked in checkedListBox1.CheckedItems)
            {

                // Use the IndexOf method to get the index of an item.
                MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
                                "\", is checked. Checked state is: " +
                                checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");
                DifficultiesChecked.Add(itemChecked.ToString());
            }
            CheckedListBox justChecked = (CheckedListBox)sender;
            CheckedListBox.CheckedItemCollection coll = justChecked.CheckedItems;
            MessageBox.Show("Sender is: "+ justChecked.Text);
            if (DifficultiesChecked.Contains(justChecked.Text))
            {
                DifficultiesChecked.Remove(justChecked.Text);
            }
            else
            {
                DifficultiesChecked.Add(justChecked.Text);
            }
            MessageBox.Show("justChecked.Text is: " + justChecked.Text);
            myfeed.filterLoad(DifficultiesChecked);

            //foreach(object itemChecked in checkedListBox1.CheckedItems)
            //{
            for(int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                DifficultiesChecked.Add(checkedListBox1.CheckedItems.ToString());
            }



            if (DifficultiesChecked.Contains(sender.ToString()))
            {
                DifficultiesChecked.Remove(sender.ToString());
            }
            else
            {
                DifficultiesChecked.Add(sender.ToString());
            }

            for(int i=0;i<DifficultiesChecked.Count;i++)
            {
                mydiffsArr.Add(dta.getAbbreviationOfDiff(DifficultiesChecked[i]));
            }
            //}*/
            //myfeed.filterLoad(mydiffsArr);
        }
    }
}
