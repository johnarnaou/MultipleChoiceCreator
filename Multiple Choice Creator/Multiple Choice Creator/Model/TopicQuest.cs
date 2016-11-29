using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Multiple_Choice_Creator.Model
{
    public class TopicQuest
    {

        private Question quest;
        private ArrayList topicArList;

        public TopicQuest(Question quest)
        {
            this.quest = quest;
            topicArList = new ArrayList();
        }

        public void setQuest(Question quest)
        {
            this.quest = quest;
        }

        public void addtopicArList(Topic topic)
        {
            this.topicArList.Add(topic);
        }

        public Question getQuestion()
        {
            return this.quest;
        }

        public ArrayList getTopicArList()
        {
            return this.topicArList;
        }
    }
}
