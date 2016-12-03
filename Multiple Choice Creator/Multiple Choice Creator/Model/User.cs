using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class User
    {
        private string email, password, fName, lName;

        public User(string email,string password,string fName,string lName)
        {
            this.email = email;
            this.password = password;
            this.fName = fName;
            this.lName = lName;
        }
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public void setFname(string fName)
        {
            this.fName = fName;
        }

        public void setLname(string lName)
        {
            this.lName = lName;
        }
        public string getFname()
        {
            return this.fName;
        }

        public string getLname()
        {
            return this.lName;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getPassword()
        {
            return this.password;
        }


        

    }
}
