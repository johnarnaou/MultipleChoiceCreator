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

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        private bool clicked = true;
        private Question q;
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
            this.answersDataGridView.DataSource = answers.getAnswersDataTable();
           
            
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
