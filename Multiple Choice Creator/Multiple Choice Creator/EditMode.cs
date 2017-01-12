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
using static Multiple_Choice_Creator.mltChoiceDataSet;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
namespace Multiple_Choice_Creator
{
    public partial class EditMode : UserControl
    {
        Question q;
        AnswDataTable answers;
        FeedPanel panel;
        string diff;
        Manage mang;
        public EditMode(Question q, AnswDataTable answers, FeedPanel panel)
        {
            InitializeComponent();
            this.q = q;
            this.answers = answers;
            this.panel = panel;
            this.Dock = DockStyle.Fill;
            diff = q.getDifficulty();
            loadInfo();
        }
        //Long Live Da Duke
        public void loadInfo()
        {
            questRichTextBox.Text = q.getText();
            answDataGridView.DataSource = answers;
            answDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            if(diff == "Easy")
            {
                diffTrackBar.Value = 0;
                diff="E";
            }
            else if (diff == "Medium")
            {
                diffTrackBar.Value = 1;
                diff = "M";
            }
            else if(diff == "Hard")
            {
                diffTrackBar.Value = 2;
                diff = "H";
            }
            diffLabel.Text = diff;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            panel.showInsert();
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (MessageBox.Show("Are you sure you want to save the following changes","Save",MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            updateQuestionAndAnswers();
            panel.updateContent(questRichTextBox.Text, (AnswDataTable)answDataGridView.DataSource, diff);
            panel.showInsert();
            MessageBox.Show("Your changes were saved");
            this.Dispose();
            Cursor.Current = Cursors.Default;
        }

        private void updateQuestionAndAnswers()
        {
            QuestTableAdapter questAdapt = new QuestTableAdapter();
            questAdapt.updateQuest(questRichTextBox.Text, diff, q.getQuestionID());

            AnswTableAdapter asnwAdapt = new AnswTableAdapter();
            List<int> answIds = panel.getAnswIDs();
            for (int i = 0; i < answDataGridView.Rows.Count - 1; i++)
            {
                asnwAdapt.updateAnsw(answDataGridView.Rows[i].Cells[0].Value.ToString(), answIds[i]);
            }
        }

        private void diffTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (diffTrackBar.Value == 0)
                diffLabel.Text = "Easy";
            else if (diffTrackBar.Value == 1)
                diffLabel.Text = "Medium";
            else if (diffTrackBar.Value == 2)
                diffLabel.Text = "Hard";

            diff = diffLabel.Text;
        }

        private void questRichTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questRichTextBox.Text))
            {
                MessageBox.Show("There is no question.Please enter a question ", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;//den ton afhnoume na fugei apo to text box mexri na grapsei mia erwthsh
            }
            return;
        }

        private void answDataGridView_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(answDataGridView.Rows[0].Cells[0].Value as string)
                && string.IsNullOrWhiteSpace(answDataGridView.Rows[1].Cells[0].Value as string))
            {
                MessageBox.Show("There are no answers.You must type at least two answers", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;//den ton afhnoume na fugei apo to text box mexri na grapsei mia toulaxiston apanthsh
            }
            return;
        }
    }
}
