using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator
{
    class themeTree
    {

        List<Theme> myList;
        public themeTree(List<Theme> mytmpList) {
            myList = mytmpList;
            

        }


        public void printTree()
        {
            for (int i=0;i<myList.Count;i++)
            {
                if (myList[i].getFatherD() == 0)
                {
                    Console.Write("Father: ",myList[i].getID());
                    printKids(myList[i].getID());
                    
                }
            }

        }


        public void printKids(int fatherID)
        {
            for(int i = 0; i < myList.Count; i++)
            {
                Console.Write("Father: " + fatherID);
                if (myList[i].getFatherD() == fatherID)
                {
                    Console.WriteLine(" Kid: "+myList[i].getID());
                    printKids(myList[i].getID());

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
