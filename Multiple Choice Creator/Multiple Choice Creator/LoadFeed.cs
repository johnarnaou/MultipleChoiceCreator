﻿using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;
using System;
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
            DataTable data = qTableAdapter.GetDataByUserID(user.getUserID());

            for (var i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;

                display((int)data.Rows[i][0],c);
            }

            toolbarload();
        }

        private void toolbarload()
        {
            toolbar = new FeedToolBar();
            panel.Controls.Add(toolbar);
        }

        private void display(int id, Color c)
        {
            Question q = new Question(id);
            AnswDataTable answers;
            QuestionAnswer qa;

            q.setUserID(user.getUserID());

            qa = new QuestionAnswer(q);

            answers = new AnswDataTable();

            aTableAdapter.FillAnswersByQuestionID(answers, q.getQuestionID());

            qa.setAnswersDataTable(answers);

            panel.Controls.Add(new FeedPanel(c, qa));
        }
    }
}
