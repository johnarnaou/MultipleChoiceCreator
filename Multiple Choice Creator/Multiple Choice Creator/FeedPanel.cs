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
using System.Diagnostics;

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        private Question q;
        private QuestionAnswer qa;
        private AnswDataTable answers;
        private bool shrinkMode;
        private LoadFeed feed;
        private int height = 180;
        public FeedPanel(QuestionAnswer qa, bool shrinkMode, bool style)
        {
            InitializeComponent();
            this.shrinkMode = shrinkMode;
            this.Dock = DockStyle.Top;
            q = qa.getQuestion();
            setQuestion(q.getText());
            fillAnswers(qa);
            this.qa = qa;
            if (style)
            {
                this.Height = 0;
                showWithStyle();
            }
        }

        private void showWithStyle()
        {
            this.showTimer.Enabled = true;
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
            if (shrinkMode)
            {
                answersDataGridView.Visible = false;
                this.Height = toolStrip1.Height;
            }
        }
        private void setQuestion(string question)
        {
            this.QuestionLabel.Text = question;
        }

        private void addCheckBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Add to test", this);
        }

        public void remove()
        {
            this.Parent.Controls.Remove(this);
        }

        public void setFeed(Object feed)
        {
            this.feed = (LoadFeed)feed;
        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            this.deleteTimer.Enabled = true;
        }

        public int getQuestionID()
        {
            return q.getQuestionID();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            if (this.Height >= height) this.showTimer.Enabled = false;
            else this.Height += 20;
        }

        private void deleteTimer_Tick(object sender, EventArgs e)
        {
            if (this.Height <= 30)
            {
                this.deleteTimer.Enabled = false;
                feed.delete(q);
            }
            else this.Height -= 20;
        }

    }
}
