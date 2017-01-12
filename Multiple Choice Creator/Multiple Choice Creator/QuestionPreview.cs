using System;
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
        FeedPanel fdPanel;
        CreateTestControl ctcPanel;
        public QuestionPreview(Question myQuestion,List<Answer> correct, List<Answer> wrong,FlowLayoutPanel theFather, object myQPList,FeedPanel feedPanel, CreateTestControl ctcPnl)
        {
            InitializeComponent();
            questLabel.MaximumSize = new Size(150, 0);
            father = theFather;
            fdPanel = feedPanel;
            this.Width = father.Width;
            this.myQPList=(List<QuestionPreview>)myQPList;
            myQ = myQuestion;
            myLCorr = correct;
            myLWro = wrong;
            ctcPanel = ctcPnl;
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
            try { 
            category.Text = category.Text + " " + tqta.getTopicNameByQuestId(myQ.getQuestionID()).ToString();
            }catch(Exception e)
            {
                MessageBox.Show("The question added does not have category!");
            }
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
            deleteThis();

        }

        public void deleteThis()
        {
            fdPanel.unMark();
            father.Controls.Remove(this);
            ctcPanel.CountQuestion(-1);
            myQPList.Remove(this);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            fdPanel.editThis();
        }
    }
}
