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

namespace Multiple_Choice_Creator
{
    public partial class Insert : UserControl
    {
        User user;
        public Insert(User user)
        {
            InitializeComponent();
            this.user = user;
            //this.Dock = Top;
        }

        String question;
        QuestTableAdapter qTableAdapter;
        DataTable qID;
        int qid;
        private void button1_Click(object sender, EventArgs e)
        {
            /* string dif = "E";
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
             String question = richTextBox1.Text;
             QuestTableAdapter qTableAdapter = new QuestTableAdapter();

             qTableAdapter.insertQuest(question, dif, user.getUserID());
             DataTable qID = qTableAdapter.getIdOfInsertedQuest(question);

             int qid = Convert.ToInt32(qID.Rows[0][0].ToString());*/
            insertQuestin();
            string correct="";
            AnswTableAdapter aTableAdapter = new AnswTableAdapter();
            DataTable aid;
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
                correct = "True";
                aTableAdapter.insertAnsw(textAnsw);
                aid = aTableAdapter.getIdOfInsertedAnsw(textAnsw);
                a.insertQuestAnsw(qid, Convert.ToInt32(aid.Rows[0][0].ToString()), Convert.ToBoolean(correct));
            }
            MessageBox.Show("well done");
        }
      
        private void insertQuestin()
        {
            string dif = "E";
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
    }
}
