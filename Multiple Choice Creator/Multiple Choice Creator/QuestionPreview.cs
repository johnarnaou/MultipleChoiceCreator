﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;

namespace Multiple_Choice_Creator
{
    public partial class QuestionPreview : UserControl
    {

        Question myQ { get; }
        List<Answer> myLCorr { get; }
        List<Answer> myLWro { get; }
        FlowLayoutPanel father;
        List<QuestionPreview> myQPList;
        TopicQuestTableAdapter tqta = new TopicQuestTableAdapter();
        public QuestionPreview(Question myQuestion,List<Answer> correct, List<Answer> wrong,FlowLayoutPanel theFather, Object myQPList)
        {
            InitializeComponent();
            questLabel.MaximumSize = new Size(150, 0);
            father = theFather;
            this.Width = father.Width;
            this.myQPList=(List<QuestionPreview>)myQPList;
            myQ = myQuestion;
            myLCorr = correct;
            myLWro = wrong;
            questLabel.Text = myQ.getText();
            foreach (Answer apant in myLCorr)
            {
                ListViewItem tmpItem = new ListViewItem(apant.getText());
                tmpItem.BackColor = Color.LightGreen;
                listView1.Items.Add(tmpItem); 
            }
            foreach (Answer apant in myLWro)
            {
                ListViewItem tmpItem = new ListViewItem(apant.getText());
                tmpItem.BackColor = Color.IndianRed;
                listView1.Items.Add(tmpItem);
            }
            
            category.Text = category.Text + " " + tqta.getTopicNameByQuestId(myQ.getQuestionID()).ToString();
            Difficulty.Text = Difficulty.Text + " "+myQ.getDifficulty();
            //xMore.Text = wrong.Count().ToString() + " wrong answ";
            Update();



        }

        public List<Answer> getCorrAnswers()
        {
            return myLCorr;
        }

        public List<Answer> getWrongAnswers()
        {
            return myLWro;
        }

        public Question getQuestion()
        {
            return myQ;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            father.Controls.Remove(this);
            myQPList.Remove(this);

        }
    }
}
