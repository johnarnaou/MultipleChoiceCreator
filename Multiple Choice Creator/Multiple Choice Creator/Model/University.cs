using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    class University
    {
        private int id;
        private string name;

        public University(int ID, string NAME)
        {
            id = ID;
            name = NAME;
        }

        public University(int ID)
        {
            id = ID;
            name = ""; //get the name from base.
        }

        public string getName()
        {
            return name;
        }

        public int getID()
        {
            return id;
        }
    }
}
