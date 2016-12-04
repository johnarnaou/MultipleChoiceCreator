using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    class LoadFeed
    {
        FeedToolBar toolbar;
        Panel panel;
        QuestTableAdapter qTableAdapter = new QuestTableAdapter();
        QuestAnswTableAdapter qaTableAdapter = new QuestAnswTableAdapter();
        AnswTableAdapter aTableAdapter = new AnswTableAdapter();
        User user;
        public LoadFeed(Panel p, User user)
        {
            this.user = user;
            panel = p;
            load();
        }
        public void load()
        {
            Object a = qTableAdapter.getSize(user.getUserID());
            int k = Convert.ToInt32(a);
            if (k == 0)
            {
                Label message = new Label();
                NoFeed control = new NoFeed();
                control.Dock = DockStyle.Top;
                panel.Controls.Add(control);
            }
            else if(k<50)
            {
                fill(k);
            } else
            {
                fill(50);
            }
        }

        private void fill(int size)
        {
            Color c;
            Question q;
            DataTable data = qTableAdapter.GetDataByUserID(user.getUserID());
            DataTable answersID;
            DataTable answers;
            Answer a;
            QuestionAnswer qa;
            for (var i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;
                q = new Question((int)data.Rows[i][0]);
                q.setUserID(user.getUserID());
                qa = new QuestionAnswer(q);
                answersID = qaTableAdapter.getAnswersID(q.getQuestionID());
                int num = (int)qaTableAdapter.getNumberOfAnswers(q.getQuestionID());
                for(var j=0; j<num; j++)
                {
                    answers = aTableAdapter.getDataByID((int)answersID.Rows[j][0]);
                    a = new Answer((int)answers.Rows[j][0],(string)answers.Rows[j][1]);
                    qa.addAnswArList(a);
                }
                panel.Controls.Add(new FeedPanel(c,qa));
                QuestAnswTableAdapter g = new QuestAnswTableAdapter();
                DataTable d = g.getUserAnswers(3);
            }
            toolbarload();
        }

        private void toolbarload()
        {
            toolbar = new FeedToolBar();
            panel.Controls.Add(toolbar);
        }
    }
}
