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
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        private Question q;
        private QuestionAnswer qa;
        private AnswDataTable answers, backup;
        private bool shrinkMode, tempValue;
        private LoadFeed feed;
        private AnswTableAdapter answAdapter = new AnswTableAdapter();
        private QuestAnswTableAdapter qaAdapter = new QuestAnswTableAdapter();
        private List<int> answIDs = new List<int>();
        private int height = 180;
        private bool valuesChanged = false;
        private DataGridViewCellCancelEventArgs eve;
        private string tempAnsw;
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
            for(int i=0; i<this.answers.Count; i++)
            {
                answIDs.Add((int)this.answers.Rows[i][3]);
            }
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

        private void answersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                answAdapter.updateAnsw((string)answers.Rows[e.RowIndex][e.ColumnIndex], answIDs[e.RowIndex]);
            }
            else if (e.ColumnIndex == 1)
            {
                int value;
                if ((bool)answers.Rows[e.RowIndex][e.ColumnIndex])
                    value = 1;
                else
                    value = 0;
                qaAdapter.updateCorAnswer(value, answIDs[e.RowIndex]);
            }
            saveButton.Visible = false;
        }

        private void answersDataGridView_Leave(object sender, EventArgs e)
        {
            if (valuesChanged) {
                string message = "Keep changes?";
                string caption = "Unsaved content";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    
                }
                saveButton.Visible = false;
            }
        }

        private void answersDataGridView_Enter(object sender, EventArgs e)
        {
            backup = answers;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            answersDataGridView_Leave(sender, eve);
        }

        private void answersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            eve = e;
            saveButton.Visible = true;
            valuesChanged = true;
        }
    }
}
