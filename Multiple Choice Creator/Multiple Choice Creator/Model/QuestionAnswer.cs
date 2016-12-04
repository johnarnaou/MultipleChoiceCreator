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
        private Answer[] answArList;
        private int index;

        public QuestionAnswer(Question quest)
        {
            this.quest = quest;
            index = 0;
            answArList = new Answer[8];
        }

        private void setQuestion(Question quest)
        {
            this.quest = quest;
        }

        private void fillAnswers(Question q)
        {
            
        }

        public void addAnswArList(Answer answ)
        {
            if(index < 8)
                this.answArList[index] = answ;
            else
                //error
            index++;
        }
        public int getIndex()
        {
            return index;
        }
        public Question getQuestion()
        {
            return this.quest;
        }

        public Answer[] getAnswArList()
        {
            return this.answArList;
        }

      
    }
}
