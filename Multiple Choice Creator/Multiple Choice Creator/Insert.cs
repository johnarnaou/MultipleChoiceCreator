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
using static Multiple_Choice_Creator.mltChoiceDataSet;

namespace Multiple_Choice_Creator
{
    public partial class Insert : UserControl
    {
        User user;
        LoadFeed currFeed;
        ///local variables not used in constructor///////
        string dif = "E";
        public Insert(User user,Object feed)
        {
            InitializeComponent();
            this.user = user;
            this.Dock = DockStyle.Fill;
            currFeed = (LoadFeed)feed;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Question questIns=new Model.Question(richTextBox1.Text, Convert.ToChar(dif), user.getUserID());
            QuestionAnswer qaInserted = new QuestionAnswer(questIns);
            AnswDataTable inseAnsw = new Manage().inserQ(questIns,dataGridView1,user);
            qaInserted.setAnswersDataTable(inseAnsw);
            currFeed.add(qaInserted);
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value==0)
            {
                diffLabel.Text = "Easy";
            }else if (trackBar1.Value == 1)
            {
                diffLabel.Text = "Medium";
            }
            else 
            {
                diffLabel.Text = "Hard";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
