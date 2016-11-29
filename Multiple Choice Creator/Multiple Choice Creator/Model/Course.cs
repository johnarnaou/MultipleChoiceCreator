using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    class Course
    {
        private int id, userId;
        private string name, description;

        public Course(int ID, string NAME, string DESCRIPTION, int USERID)
        {
            id = ID;
            name = NAME;
            description = DESCRIPTION;
            userId = USERID;
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }

        public int getID()
        {
            return id;
        }

        public int getUserID()
        {
            return userId;
        }
    }
}
