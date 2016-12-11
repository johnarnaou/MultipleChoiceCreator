using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Multiple_Choice_Creator.mltChoiceDataSet;

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
        List<FeedPanel> myLayoutControls = new List<FeedPanel>();
        NoFeed noFeedControl;
        Color c;
        bool shrinkMode = false;

        int index = 0;
        public LoadFeed(Panel p, User user)
        {
            this.user = user;
            panel = p;
            toolbar = new FeedToolBar(panel, user);
            toolbar.setFeed(this);
        }

        public void load()
        {
            Object a = qTableAdapter.getSize(user.getUserID());
            int k = Convert.ToInt32(a);
            if (k == 0)
            {
                NoFeed("No Questions...");
                toolbar.setNoFeedWasLoaded(true);
                toolbar.Enabled = false;
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
            DataTable data = qTableAdapter.GetDataByUserID(user.getUserID());
            toolbar.Enabled = true;
            for (var i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;

                displayUser((int)data.Rows[i][0],c);
            }

            toolbarload();
        }

        public void toolbarload()
        {
            panel.Controls.Add(toolbar);
        }

        private void displayUser(int id, Color c)
        {
            Question q = new Question(id);
            AnswDataTable answers;
          
            QuestionAnswer qa;

            q.setUserID(user.getUserID());

            qa = new QuestionAnswer(q);

            answers = new AnswDataTable();

            aTableAdapter.FillAnswersByQuestionID(answers, q.getQuestionID());

            qa.setAnswersDataTable(answers);

            myLayoutControls.Add(new FeedPanel(c, qa, shrinkMode));

            panel.Controls.Add(myLayoutControls[index]);

            index++;
        }

        public void shrinkExpand(bool shrinkMode)
        {
            if (shrinkMode)
            {
                for (int i = 0; i < index; i++)
                {
                    myLayoutControls[i].Height = toolbar.Height;
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    myLayoutControls[i].Height = 188;
                }
            }
        }

        public void fillSearch(DataTable data, int num)
        {
            controlsDispose();
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;

                Debug.WriteLine("ADDED");
                displaySearch((int)data.Rows[i][0], c);
            }
            toolbarload();
        }
        private void displaySearch(int id, Color c)
        {
            Question q = new Question(id);
            AnswDataTable answers;
            QuestionAnswer qa;

            qa = new QuestionAnswer(q);

            answers = new AnswDataTable();

            aTableAdapter.FillAnswersByQuestionID(answers, q.getQuestionID());

            qa.setAnswersDataTable(answers);

            myLayoutControls.Add(new FeedPanel(c, qa, shrinkMode));
            
            panel.Controls.Add(myLayoutControls[index]);

            index++;

        }

        
        public void NoFeed(string text)
        {
            controlsDispose();
            noFeedControl = new NoFeed(text);
            noFeedControl.Dock = DockStyle.Top;
            panel.Controls.Add(noFeedControl);
            toolbarload();
        }

        public void NoFeedControlDispose()
        {
            noFeedControl.Dispose();
        }

        public void controlsDispose()
        {
            for(int i=0; i<index; i++)
            {
                myLayoutControls[i].remove();
            }
            index = 0;
            myLayoutControls = new List<FeedPanel>();
        }

    }
}
