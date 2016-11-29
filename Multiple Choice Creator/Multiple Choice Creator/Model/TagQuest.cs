using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Multiple_Choice_Creator.Model
{
    public class TagQuest
    {
       
        private Question quest;
        private ArrayList tagArList;

        public TagQuest(Question quest)
        {
            this.quest = quest;
            tagArList = new ArrayList();
        }

        public void setQuestion(Question quest)
        {
            this.quest = quest;
        }

        public void addTag(Tag tag)
        {
            this.tagArList.Add(tag);
        }

        public Question getQuest()
        {
            return this.quest;
        }

        public ArrayList getTagArList()
        {
            return this.tagArList;
        }
    }
}
