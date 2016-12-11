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
        private Question q;
        private AnswDataTable answers;
        private bool shrinkMode;
        public FeedPanel(Color c, QuestionAnswer qa, bool shrinkMode)
        {
            InitializeComponent();
            this.shrinkMode = shrinkMode;
            this.BackColor = c;
            this.Dock = DockStyle.Top;
            this.Height = 188;
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

    }
}
