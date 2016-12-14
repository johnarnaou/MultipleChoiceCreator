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
        private int userId,id;
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
            this.id = id;
            setText((string)adapter.getQuestionWithId(id));
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

        public char getDifficulty()
        {
            return this.difficulty;
        }

        public DateTime getCreationTime()
        {
            return this.creationTime;
        }

        public void setUserID(int id)
        {
            this.userId = id;
        }

        public int getUserID()
        {
            return this.userId;
        }

        public int getQuestionID()
        {
            return this.id;
        }
    }
}
