using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    class Question
    {
        private int id, themeID, userID, courseID, answID;
        private string question;

        public Question(int id)
        {

        }

        public string getQuestion()
        {
            return question;
        }
    }
}
