using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
namespace Multiple_Choice_Creator
{
    public class themeTree
    {

        List<Topic> myList;
        public themeTree(List<Topic> mytmpList) {
            myList = mytmpList;
            

        }
        //This method is to create the first nodes of the treeView
        public void printKids(int fatherID, TreeView treeView1)
        {
            for(int i = 0; i < myList.Count; i++)
            {
                Console.Write("Father: " + fatherID);

                if (myList[i].getParent() == fatherID)
                {

                    TreeNode tnode = new TreeNode(myList[i].getName());
                    treeView1.Nodes.Add(tnode);
                    //printKids(myList[i].getID(), tnode); <-- edw υπάρχει θέμα

                }
            }
            treeView1.ExpandAll();
            
        }
        //This method is to create everey node for every other node that is not a start node and it calls itself to 
        //add the children of the nodes that are created.
        public void printKids(int fatherID, TreeNode tnode)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].getParent() == fatherID)
                {
                    TreeNode cnode = new TreeNode(myList[i].getName());
                    tnode.Nodes.Add(cnode);
                    printKids(myList[i].getParent(), cnode);
                }
            }
        }
       // public List<themeTree> createThemeTree() {
       //List < themeTree > myList = new List<themeTree>;


        //mySqlCommand to get every theme kai na to valei se mia lista
        //for (int i=0;i<) { }

        // return myList;


        //}





    }
}
