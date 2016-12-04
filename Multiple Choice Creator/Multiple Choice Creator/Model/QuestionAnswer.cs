using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Multiple_Choice_Creator.Model
{
    public class QuestionAnswer
    {
        
        private Question quest;
        private ArrayList answArList;

        public QuestionAnswer(Question quest)
        {
            this.quest = quest;
            answArList = new ArrayList();
        }

        private void setQuestion(Question quest)
        {
            this.quest = quest;
        }

        public void addAnswArList(Answer answ)
        {
            this.answArList.Add(answ);
        }

        private Question getQuestion()
        {
            return this.quest;
        }

        public ArrayList getAnswArList()
        {
            return this.answArList;
        }

      
    }
}
