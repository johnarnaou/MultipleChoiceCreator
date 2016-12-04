﻿using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
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
        public LoadFeed(Panel p)
        {
            panel = p;
            load();
        }
        public void load()
        {
            int k = (int)qTableAdapter.getSize();
            if (k == 0)
            {
                Label message = new Label();
                message.Text = "No Questions Available";
                message.Dock = DockStyle.Top;
                panel.BackColor = Color.Red;
                panel.Controls.Add(message);
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
            DataTable data = qTableAdapter.GetData();
            for (var i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;
                q = new Question((int)data.Rows[0][i]);
                panel.Controls.Add(new FeedPanel(c,q));
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
