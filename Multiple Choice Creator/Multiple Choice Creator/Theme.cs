using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator
{
    class Theme
    {

        int id, userID, courseID,father;
        string destription, name;
        public Theme(int idd,string named, string descriptiond, int userIDd,int courseIdd,int fatherd) {
            this.id = idd;
            this.name = named;
            this.destription = descriptiond;
            this.userID = userIDd;
            this.courseID = courseIdd;
            this.father = fatherd;

        }
        public int getID()
        {
            return this.id;
        }
        public String getName()
        {
            return this.name;
        }

        public int getFatherD()
        {
            return this.father;
        }

        public string toString()
        {
            return "ID= "+this.id+" name= " +this.name+" Father= "+father; 
        }

    }
}
