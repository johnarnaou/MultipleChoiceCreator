using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using System.Data;
using static Multiple_Choice_Creator.mltChoiceDataSet;
namespace Multiple_Choice_Creator
{
    class Manage
    {
        Panel panel;
        User user;
        Insert management;
        Filters filters;
        public Manage(User user, Panel panel,LoadFeed curfeed,Filters filters)
        {
            this.user = user;
            this.filters = filters;
            this.management = new Insert(user,curfeed,this);
            this.panel = panel;
            panel.Controls.Add(management);
        }
        
        public AnswDataTable inserQ(Question q,DataGridView manageGrid,User user)
        {
            QuestTableAdapter qTableAdapter;
            DataTable questionId;
            int qid;
            List<string> themes = filters.returnThemes();
            themes = filters.returnThemes();
            if (themes.Count == 0)//prin kanw otidipote mesa sto eisagwgh prepei na eleksw an o xrhsths exei epileksei thematikes enothtes
            {
              MessageBox.Show("You did not select theme for this question.Please choose at least one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return null;
            }
            qTableAdapter = new QuestTableAdapter();
            qTableAdapter.insertQuest(q.getText(),Convert.ToString(q.getDifficulty()),user.getUserID());
            questionId = qTableAdapter.getIdOfInsertedQuest(q.getText());
            qid = Convert.ToInt32(questionId.Rows[0][0].ToString());
            insertThemes(themes,qid);
            AnswDataTable answData = insertAnsw(qid, manageGrid);
            return answData;
        }

        private void insertThemes(List<string> themeList,int qId)
        {
            TopicTableAdapter topic = new TopicTableAdapter();
            TopicQuestTableAdapter tq = new TopicQuestTableAdapter();
            for (int i=0; i<themeList.Count; i++)
            {   
                DataTable topicId = topic.getIdOfTopic(themeList[i]);
                Topic currentTopic = new Topic(themeList[i], Convert.ToInt32(topicId.Rows[0][0].ToString()));
                //MessageBox.Show(topicId.Rows[0][0].ToString());
                tq.insertTopicQuest(qId, currentTopic.getId());
            }
        }

        public void hide()
        {
            management.Visible = false;
        }

        public void show()
        {
            management.Visible = true;
        }

        private AnswDataTable insertAnsw(int questionId,DataGridView manageGrid)
        {
            string correct = "";
            AnswTableAdapter aTableAdapter = new AnswTableAdapter();
            AnswDataTable aid = null;//arxika einai null
            QuestAnswTableAdapter a = new QuestAnswTableAdapter();
            for (int rows = 0; rows < manageGrid.Rows.Count - 1; rows++)
            {
                string textAnsw = manageGrid.Rows[rows].Cells[0].Value.ToString();
                try
                {
                    correct = manageGrid.Rows[rows].Cells[1].Value.ToString();
                }
                catch (NullReferenceException exc)
                {
                    Console.WriteLine(exc.ToString());
                    correct = "False";
                }
                aTableAdapter.insertAnsw(textAnsw);
                aid = aTableAdapter.getIdOfInsertedAnsw(textAnsw);
                a.insertQuestAnsw(questionId, Convert.ToInt32(aid.Rows[0][0].ToString()), Convert.ToBoolean(correct));
            }
            AnswDataTable insAnsw = aTableAdapter.GetAnswersByQuestionID(questionId);
            return insAnsw;
        }






    }
}