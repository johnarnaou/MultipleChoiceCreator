using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    class User
    {
        private string email, password, Fname, Lname;
        private int id, uId;
        private University university;

        public User(int ID, string EMAIL, string PASSWORD, string FNAME, string LNAME, int UID)
        {
            id = ID;
            email = EMAIL;
            password = PASSWORD;
            Fname = FNAME;
            Lname = LNAME;
            uId = UID;
            university = new University(UID);
        }

        public string getFname()
        {
            return Fname;
        }

        public string getLname()
        {
            return Lname;
        }

        public string getEmail()
        {
            return email;
        }

        public int getID()
        {
            return id;
        }

        public int getUID()
        {
            return uId;
        }

        public string getUniversityName()
        {
            return university.getName();
        }
    }
}
