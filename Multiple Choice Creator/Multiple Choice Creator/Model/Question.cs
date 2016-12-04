using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class Question
    {
        private string text;
        private char difficulty;
        private int userId;
        private DateTime creationTime;
        private DateTime LastModifTime;
        private QuestTableAdapter adapter = new QuestTableAdapter();
        private QuestionAnswer qa;

        public Question(string text,char difficulty,int userId)
        {
            this.text = text;
            this.difficulty = difficulty;
            this.userId = userId;
            creationTime = DateTime.Now;
        }

        public Question(int id)
        {
            setText(adapter.getQuestionWithId(id));
        }

        private void setText(string text)
        {
            this.text = text;
        }

        private void setDifficulty(char difficulty)
        {
            this.difficulty = difficulty;
        }

        private void setLastModifTime(DateTime LastModifTime)
        {
            this.LastModifTime = LastModifTime;
        }

        public string getText()
        {
            return this.text;
        }

        private char getDifficulty()
        {
            return this.difficulty;
        }

        private DateTime getCreationTime()
        {
            return this.creationTime;
        }
    }
}
