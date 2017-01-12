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
        private bool shrinkMode, toolTipEnabled = false;
        private LoadFeed feed;
        private AnswTableAdapter answAdapter = new AnswTableAdapter();
        private QuestAnswTableAdapter qaAdapter = new QuestAnswTableAdapter();
        private List<int> answIDs = new List<int>();
        private int height = 180;
        private bool valuesChanged = false;
        private DataGridViewCellCancelEventArgs eve;
        private CreateTestControl cr;
        private QuePreview qPreview;
        private Panel edit;

        public FeedPanel(QuestionAnswer qa, bool shrinkMode, bool style, CreateTestControl cr, Panel edit)
        {
            InitializeComponent();
            this.shrinkMode = shrinkMode;
            this.Dock = DockStyle.Top;
            q = qa.getQuestion();
            setQuestion(q.getText());
            setDifficulty(q.getDifficulty());
            fillAnswers(qa);
            this.qa = qa;
            this.cr = cr;

            this.edit = edit;

            if (style)
            {
                this.Height = 0;
                showWithStyle();
            }
            answersDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            answersDataGridView.ScrollBars = ScrollBars.None;
        }

        public int getNumberOfAnswers()
        {
            return answers.Count;
        }

        public DateTime getTime()
        {
            return q.getCreationTime();
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

        public void updateContent(string question, AnswDataTable updatedTable, string diff)
        {
            setQuestion(question);
            answersDataGridView.DataSource = updatedTable;
            setDifficulty(diff);
        }
        private void setQuestion(string question)
        {
            this.QuestionLabel.Text = question;
        }

        private void setDifficulty(string difficulty)
        {
            this.diffLabel.Text = "Difficulty: " + difficulty;
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
            if (MessageBox.Show("You are about to delete the follwoing question:"+q.getText(),"Delete Action" ,MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            this.deleteTimer.Enabled = true;
        }

        public int getQuestionID()
        {
            return q.getQuestionID();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            if (this.Height >= height) this.showTimer.Enabled = false;
            else this.Height += 10;
        }

        private void deleteTimer_Tick(object sender, EventArgs e)
        {
            if (this.Height <= 30)
            {
                this.deleteTimer.Enabled = false;
                feed.delete(q);
            }
            else this.Height -= 10;
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

        public void setShrinkMode(bool value)
        {
            shrinkMode = value;
            toolTipEnabled = value;
        }
        private void answersDataGridView_Leave(object sender, EventArgs e)
        {
            answersDataGridView.ScrollBars = ScrollBars.None;

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

        private void toolStrip1_MouseHover(object sender, EventArgs e)
        {
            Debug.WriteLine(shrinkMode);
            ToolTip ToolTip1 = new ToolTip();
            if (toolTipEnabled)
            {
                string text = "";
                if (answers.Count > 0)
                {
                    for (int i = 0; i < answers.Count; i++)
                    {
                        text = text + "Answer " + (i + 1) + ": " + answers[i][0] + "\n";
                    }
                } else
                {
                    text = "No Answers";
                }
                ToolTip1.Active = true;
                ToolTip1.SetToolTip(this.toolStrip1, text);
                Debug.WriteLine(text);
            } else
            {
                ToolTip1.Active = false;
            }
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Height <= toolStrip1.Height)
            {
                this.hideTimer.Enabled = false;
            }
            else this.Height -= 10;
        }

        private void QuestionLabel_Click(object sender, EventArgs e)
        {
            if (shrinkMode)
            {
                showTimer.Enabled = true;
                tm_Tick(sender, e);
                shrinkMode = false;
                toolTipEnabled = false;
            }
            else
            {
                hideTimer.Enabled = true;
                shrinkMode = true;
                toolTipEnabled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            answersDataGridView_Leave(sender, eve);
        }

        private void answersDataGridView_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            answersDataGridView.ScrollBars = ScrollBars.Both;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            toolStrip1.BackColor = Color.Green;
            if (!shrinkMode)
            {
                hideTimer.Enabled = true;
                shrinkMode = true;
            }
            addButton.Visible = false;
            removeButton.Visible = true;

            List<Answer> correctAnsw = new List<Answer>();
            List<Answer> incorrectAnsw = new List<Answer>();

            for(int i=0; i<answers.Count; i++)
            {
                if ((bool)answers.Rows[i]["correct"])
                {
                    correctAnsw.Add(new Answer(0,(string)answers.Rows[i]["answer"]));
                }
                else
                {
                    incorrectAnsw.Add(new Answer(0, (string)answers.Rows[i]["answer"]));
                }
            }

            qPreview = new QuePreview(cr.getflowlayoutPanel(), q, correctAnsw, incorrectAnsw,cr.getMyPList(), this,cr);
            cr.CountQuestion(1);
            cr.getMyPList().Add(qPreview.getMyQuePrev());
        }

        public void unMark()
        {
            toolStrip1.BackColor = Color.White;
            showWithStyle();
            removeButton.Visible = false;
            addButton.Visible = true;
            shrinkMode = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            qPreview.getMyQuePrev().deleteThis();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editThis();
        }

        public void editThis()
        {
            EditMode editor = new EditMode(q, answers, this);
            feed.hideInsert();
            edit.Controls.Add(editor);
            this.toolStrip1.BackColor = Color.Yellow;
        }

        private void answersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            eve = e;
            saveButton.Visible = true;
            valuesChanged = true;
        }

        public string getQuestionDifficulty()
        {
            return this.q.getDifficulty();
        }

        public void showInsert()
        {
            this.toolStrip1.BackColor = Color.White;
            feed.showInsert();
            
        }

        public List<int> getAnswIDs()
        {
            return answIDs;
        }

    }
}
