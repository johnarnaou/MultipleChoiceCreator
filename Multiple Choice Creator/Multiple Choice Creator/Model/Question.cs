using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Choice_Creator.Model
{
    public class Question
    {
        private string text, difficulty, topic;
        private int userId,id;
        private DateTime creationTime;
        private DateTime LastModifTime;
        private QuestTableAdapter adapter = new QuestTableAdapter();
        private QuestionAnswer qa;
        private TopicQuestTableAdapter ta = new TopicQuestTableAdapter();

        public Question(string text,string difficulty,int userId)
        {
            this.text = text;
            this.userId = userId;
            this.difficulty = difficulty;
            creationTime = DateTime.Now;
        }
        public Question() {  }

        public Question(int id)
        {
            this.id = id;
            setText((string)adapter.getQuestionWithId(id));
            setDifficulty();
            setCreationTime();
            //setTopic();
        }

        /*private void setTopic()
        {
            topic = (string)ta.getTopicNameByQuestId(id);
        }*/
        private void setCreationTime()
        {
            creationTime = (DateTime)adapter.getTime(id);
        }

        private void setText(string text)
        {
            this.text = text;
        }

        private void setDifficulty()
        {
            difficulty = (string)adapter.getDifficultyByQuestId(id);
        }

        private void setLastModifTime(DateTime LastModifTime)
        {
            this.LastModifTime = LastModifTime;
        }

        public string getText()
        {
            return this.text;
        }

        public string getDifficulty()
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
