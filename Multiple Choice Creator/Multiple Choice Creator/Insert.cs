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
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            String question = richTextBox1.Text;
            QuestTableAdapter qTableAdapter = new QuestTableAdapter();
            string dif = "m";// if-else gia to difficulty
            qTableAdapter.insertQuest(question, dif, user.getUserID());

            AnswTableAdapter aTableAdapter = new AnswTableAdapter();
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                string value = dataGridView1.Rows[rows].Cells[0].Value.ToString();
                string correct = dataGridView1.Rows[rows].Cells[1].Value.ToString();
                //QuestAnswTableAdapter a = new QuestAnswTableAdapter();
                
               
                aTableAdapter.insertAnsw(value);

            }
        }
    }
}
