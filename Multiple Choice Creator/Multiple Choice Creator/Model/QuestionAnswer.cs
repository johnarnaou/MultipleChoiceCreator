using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using static Multiple_Choice_Creator.mltChoiceDataSet;

namespace Multiple_Choice_Creator.Model
{
    public class QuestionAnswer
    {
        
        private Question quest;
        private AnswDataTable answers;

        public QuestionAnswer(Question quest)
        {
            this.quest = quest;
            
        }

        private void setQuestion(Question quest)
        {
            this.quest = quest;
        }

        private void fillAnswers(Question q)
        {
            
        }

        public void setAnswersDataTable(AnswDataTable answers)
        {
            this.answers = answers;
        }
      
        public Question getQuestion()
        {
            return this.quest;
        }

        public AnswDataTable getAnswersDataTable()
        {
            return this.answers;
        }

      
    }
}
