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
        ///local variables not used in constructor///////////////////////////////////////
        String question;
        QuestTableAdapter qTableAdapter;
        DataTable qID;
        int qid;
        string dif = "E";
        public Insert(User user,Object feed)
        {
            InitializeComponent();
            this.user = user;
            currFeed = (LoadFeed)feed;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dif = "E";
            if (trackBar1.Value == 0)
            {
                dif = "E";
            }
            else if (trackBar1.Value == 5)
            {
                dif = "M";
            }
            else
            {
                dif = "H";
            }
            insertQuestion();
            string correct="";
            AnswTableAdapter aTableAdapter = new AnswTableAdapter();
            AnswDataTable aid=null;//arxika einai null
            QuestAnswTableAdapter a = new QuestAnswTableAdapter();
            for (int rows = 0; rows < dataGridView1.Rows.Count-1; rows++)
            {
                string textAnsw = dataGridView1.Rows[rows].Cells[0].Value.ToString();
                try
                {
                    correct = dataGridView1.Rows[rows].Cells[1].Value.ToString();
                }
                catch (NullReferenceException exc)
                {
                    Console.WriteLine(exc.ToString());
                    correct = "False";
                }
                aTableAdapter.insertAnsw(textAnsw);
                aid = aTableAdapter.getIdOfInsertedAnsw(textAnsw);
                a.insertQuestAnsw(qid, Convert.ToInt32(aid.Rows[0][0].ToString()), Convert.ToBoolean(correct));
            }
            Question quest = new Question(richTextBox1.Text, Convert.ToChar(dif), user.getUserID());
            AnswDataTable insAnsw = aTableAdapter.GetAnswersByQuestionID(qid);
            QuestionAnswer qaInserted = new QuestionAnswer(quest);
            qaInserted.setAnswersDataTable(insAnsw);
            currFeed.add(qaInserted);
            MessageBox.Show("the insert of question-answers has been completed");
        }
      
        private void insertQuestion()
        {
            dif = "E";
            if (trackBar1.Value == 0)
            {
                dif = "E";
            }
            else if (trackBar1.Value == 5)
            {
                dif = "M";
            }
            else
            {
                dif = "H";
            }
            question = richTextBox1.Text;
            qTableAdapter = new QuestTableAdapter();

            qTableAdapter.insertQuest(question, dif, user.getUserID());
            qID = qTableAdapter.getIdOfInsertedQuest(question);
            qid = Convert.ToInt32(qID.Rows[0][0].ToString());
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value==0)
            {
                diffLabel.Text = "Easy";
            }else if (trackBar1.Value == 5)
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
