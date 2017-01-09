﻿using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
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
        Panel panel, edit;
        QuestTableAdapter qTableAdapter = new QuestTableAdapter();
        QuestAnswTableAdapter qaTableAdapter = new QuestAnswTableAdapter();
        AnswTableAdapter aTableAdapter = new AnswTableAdapter();
        User user;
        List<FeedPanel> myLayoutControls = new List<FeedPanel>(), filteredLayoutControls = new List<FeedPanel>();
        NoFeed noFeedControl;
        int controlsCount = 0;
        bool shrinkMode = false;
        CreateTestControl cr;
        Manage manage;

        int index = 0;
        public LoadFeed(Panel p, User user, CreateTestControl cr, Panel edit)
        {
            this.user = user;
            panel = p;
            toolbar = new FeedToolBar(panel, user);
            toolbar.setFeed(this);
            this.cr = cr;
            this.edit = edit;
        }

        public void load()
        {
            Object a = qTableAdapter.getSize(user.getUserID());
            controlsCount = Convert.ToInt32(a);
            if (controlsCount == 0)
            {
                NoFeed("No Questions..., Try inserting some!!");
            }
            else if(controlsCount<50)
            {
                fill(controlsCount);
            } else
            {
                fill(50);
            }
        }

        private void fill(int size)
        {
            DataTable data = qTableAdapter.GetDataByUserID(user.getUserID());
            toolbar.Enabled = true;
            for (var i = 0; i < size; i++)
            {
                displayUser((int)data.Rows[i][0]);
            }

            toolbarload();
        }

        public void toolbarload()
        {
            panel.Controls.Add(toolbar);
        }

        private void displayUser(int id)
        {
            Question q = new Question(id);
            AnswDataTable answers;
          
            QuestionAnswer qa;

            q.setUserID(user.getUserID());

            qa = new QuestionAnswer(q);

            answers = new AnswDataTable();

            aTableAdapter.FillAnswersByQuestionID(answers, q.getQuestionID());

            qa.setAnswersDataTable(answers);

            myLayoutControls.Add(new FeedPanel(qa, shrinkMode, false,cr,edit));

            myLayoutControls[index].setFeed(this);

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
                    myLayoutControls[i].setShrinkMode(shrinkMode);
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    myLayoutControls[i].Height = 180;
                    myLayoutControls[i].setShrinkMode(shrinkMode);
                }
            }
        }

        public void fillSearch(DataTable data, int num)
        {
            controlsDispose();
            for (int i = 0; i < num; i++)
            {
                Debug.WriteLine("ADDED");
                displaySearch((int)data.Rows[i][0]);
            }
            toolbarload();
        }
        private void displaySearch(int id)
        {
            Question q = new Question(id);
            AnswDataTable answers;
            QuestionAnswer qa;

            qa = new QuestionAnswer(q);

            answers = new AnswDataTable();

            aTableAdapter.FillAnswersByQuestionID(answers, q.getQuestionID());

            qa.setAnswersDataTable(answers);

            myLayoutControls.Add(new FeedPanel(qa, shrinkMode,false,cr,edit));

            myLayoutControls[index].setFeed(this);

            panel.Controls.Add(myLayoutControls[index]);

            index++;

        }

        
        public void NoFeed(string text)
        {
            controlsDispose();
            noFeedControl = new NoFeed(text);
            noFeedControl.Dock = DockStyle.Top;
            toolbar.setNoFeedWasLoaded(true);
            toolbar.Enabled = false;
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

        public void add(QuestionAnswer element)
        {
            if (myLayoutControls.Count == 0)
                NoFeedControlDispose();
            myLayoutControls.Add(new FeedPanel(element, shrinkMode, true,cr,edit));

            myLayoutControls[index].setFeed(this);

            panel.Controls.Add(myLayoutControls[index]);

            toolbarload();

            index++;
        }

        public void delete(Question element)
        {
            for (int i = 0; i < index; i++)
            {
                if (myLayoutControls[i].getQuestionID() == element.getQuestionID())
                {
                    myLayoutControls[i].remove();
                    myLayoutControls.RemoveAt(i);
                    index--;
                    qaTableAdapter.deleteQuestAnsw(element.getQuestionID());
                }
            }
            if (myLayoutControls.Count == 0)
                NoFeed("No Questions..., Try inserting some!!");
        }

        public void filterControlsDispose()
        {
            for (int i = 0; i < filteredLayoutControls.Count; i++)
            {
                filteredLayoutControls[i].remove();
            }
            filteredLayoutControls = new List<FeedPanel>();
        }

        public void filterLoad(List<string> filter)
        {
            filteredLayoutControls = new List<FeedPanel>();
            for(int i=0; i<filter.Count; i++)
            {
                for (int j = 0; j < myLayoutControls.Count; j++)
                {
                    if (myLayoutControls[j].getQuestionDifficulty() == filter[i])
                    {
                        filteredLayoutControls.Add(myLayoutControls[j]);
                    } else
                    {
                        myLayoutControls[j].Visible = false;
                    }
                }
            }
            if (filteredLayoutControls.Count > 0)
            {
                reload(filteredLayoutControls);
            }
            else
                NoFeed("No content using this filter");
        }

        private void reload(List<FeedPanel> LayoutControls)
        {
            if (controlsCount == 0)
                NoFeedControlDispose();
            else
                filterControlsDispose();
            for(int i =0; i<LayoutControls.Count; i++)
            {
                LayoutControls[i].Visible = true;
                panel.Controls.Add(LayoutControls[i]);
            }
            toolbarload();
        }

        public void clearFilter()
        {
            reload(myLayoutControls);
        }

        public void setManage(Manage m)
        {
            manage = m;
        }

        public void showInsert()
        {
            manage.show();
        }

        public void hideInsert()
        {
            manage.hide();
        }

    }
}
