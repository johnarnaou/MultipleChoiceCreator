using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    class themeTree
    {

        List<Theme> myList;
        public themeTree(List<Theme> mytmpList) {
            myList = mytmpList;
            

        }



        
        //This method is to create the first nodes of the treeView
        public void printKids(int fatherID, TreeView treeView1)
        {
            for(int i = 0; i < myList.Count; i++)
            {
                Console.Write("Father: " + fatherID);

                if (myList[i].getFatherD() == fatherID)
                {

                    TreeNode tnode = new TreeNode(myList[i].getName());
                    treeView1.Nodes.Add(tnode);
                    Console.WriteLine(" Kid: "+myList[i].getID());
                    printKids(myList[i].getID(), tnode);

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
                if (myList[i].getFatherD() == fatherID)
                {
                    TreeNode cnode = new TreeNode(myList[i].getName());
                    tnode.Nodes.Add(cnode);
                    printKids(myList[i].getID(), cnode);
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
