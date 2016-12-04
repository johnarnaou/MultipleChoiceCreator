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
        private Label ans;
        public FeedPanel(Color c, QuestionAnswer qa)
        {
            InitializeComponent();
            this.BackColor = c;
            this.Dock = DockStyle.Top;
            q = qa.getQuestion();
            setQuestion(q.getText());

        }

        private void fillAnswers(QuestionAnswer answers)
        {
            Answer[] list = answers.getAnswArList();
            for(int i=0; i<answers.getIndex(); i++)
            {
                this.label1.Text = list[i].getText();
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

        private void seeMoreLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            if (clicked)
            {
                this.label1.Visible = true;
                this.label2.Visible = true;
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.label5.Visible = true;
                this.label6.Visible = true;
                this.label7.Visible = true;
                this.label8.Visible = true;

                clicked = false;
                this.seeMoreLabel.Text = "Hide answers";
            }
            else
            {
                this.label1.Visible = false;
                this.label2.Visible = false;
                this.label3.Visible = false;
                this.label4.Visible = false;
                this.label5.Visible = false;
                this.label6.Visible = false;
                this.label7.Visible = false;
                this.label8.Visible = false;

                clicked = true;
                this.seeMoreLabel.Text = "Show answers";
            }
        }
    }
}
