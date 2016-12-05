using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
using System.Collections;
using static Multiple_Choice_Creator.mltChoiceDataSet;

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        private bool clicked = true;
        private Question q;
        private AnswDataTable answers;
        public FeedPanel(Color c, QuestionAnswer qa)
        {
            InitializeComponent();
            this.BackColor = c;
            this.Dock = DockStyle.Top;
            q = qa.getQuestion();
            setQuestion(q.getText());
            fillAnswers(qa);
        }

        private void fillAnswers(QuestionAnswer answers)
        {
            this.answers = answers.getAnswersDataTable();
            this.answers.Constraints.Clear();
            this.answers.Columns.Remove("Id");
            this.answers.Columns.Remove("questId");
            this.answers.Columns.Remove("answId");
            this.answers.Columns.Remove("Id1");
            this.answersDataGridView.DataSource = this.answers;
        }
        private void setQuestion(string question)
        {
            this.QuestionLabel.Text = question;
        }

        private void addCheckBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Add to test", this);
        }

        private void seeMoreLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            if (clicked)
            {
                this.answersDataGridView.Visible = true;

                clicked = false;
                this.seeMoreLabel.Text = "Hide answers";
            }
            else
            {
                this.answersDataGridView.Visible = false;

                clicked = true;
                this.seeMoreLabel.Text = "Show answers";
            }
        }
    }
}
