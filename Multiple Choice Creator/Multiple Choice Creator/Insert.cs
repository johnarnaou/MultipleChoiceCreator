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
        Manage mang;
        User user;
        LoadFeed currFeed;
        ///local variables not used in constructor///////
        string dif = "E";
        public Insert(User user,Object feed,Object manage)
        {
            InitializeComponent();
            this.mang = (Manage)manage;
            this.user = user;
            this.Dock = DockStyle.Fill;
            currFeed = (LoadFeed)feed;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int numberOfThemes=mang.getThemesCount();
            if (numberOfThemes==0)
            {
                MessageBox.Show("You did not select theme for this question.Please choose at least one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string allThemes = mang.getThemes();
            Question questIns=new Model.Question(richTextBox1.Text, dif, user.getUserID());
            QuestionAnswer qaInserted = new QuestionAnswer(questIns);
            string aboutToInsert = "Question:" + questIns.getText() + "\nWith answers:"+ this.getAnswersForInsertion() + "\n" + allThemes;
            if (MessageBox.Show(aboutToInsert,"You are about to save the follwoing changes",MessageBoxButtons.YesNo,MessageBoxIcon.Information) ==DialogResult.No)
            {
                return;
            }            
            AnswDataTable inseAnsw = mang.inserQ(questIns,dataGridView1,user);
            if (inseAnsw==null)
            {//an epistrepsei null shmainei oti m petakse exception kata th syndesh me th bash..to theloume logw vpn sth periptwsh mas
                MessageBox.Show("A network problem has occured,please try again");
                return;
            }
            qaInserted.setAnswersDataTable(inseAnsw);
            bool ins=saveChanges();
            if (ins==true) {
                currFeed.add(qaInserted);
            }
            Cursor.Current = Cursors.Default;
        }
        public string getAnswersForInsertion()
        {
            string allAnswers = "\n";
            for (int i=0; i<dataGridView1.Rows.Count-1; i++)
            {
                allAnswers += Convert.ToString(i)+")"+dataGridView1.Rows[i].Cells[0].Value.ToString()+"\n";
            }
            return allAnswers;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value==0)
            {
                diffLabel.Text = "Easy";
                dif = "Easy";
            }
            else if (trackBar1.Value == 1)
            {
                diffLabel.Text = "Medium";
                dif = "Medium";
            }
            else 
            {
                diffLabel.Text = "Hard";
                dif = "Hard";
            }
        }

        private bool saveChanges()
        {
            if (validateData())
            {
                if (!dataHasErrors())
                {
                    TableAdapterManager manageDataset = new TableAdapterManager();
                    manageDataset.UpdateAll(mltChoiceDataSet);
                    MessageBox.Show("Your changes were saved", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private bool validateData()
        {
            bool flug = false;
            if (Validate())
            {
                try
                {
                    questBindingSource.EndEdit();
                    flug= true;
                }
                catch (Exception exc)
                {
                    if (MessageBox.Show("Invalid data was entered", "wrong", MessageBoxButtons.YesNo, MessageBoxIcon.Error)==DialogResult.Yes)
                    {
                        questBindingSource.CancelEdit();
                    }
                    return false;
                }
                try
                {
                    answBindingSource.EndEdit();
                    flug= true;
                }
                catch (Exception exc)
                {
                    if (MessageBox.Show("Invalid data was entered", "wrong", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        answBindingSource.CancelEdit();
                    }
                    return false;
                }
            }
            if (flug==true)
            {
                return true;
            }
            return false;
        }

        private bool dataHasErrors()
        {
            bool err = false;
            string errorStringQ = "";
            string errorStringA = "";
            if (mltChoiceDataSet.Quest.HasErrors)
            {
                foreach (DataRow row in mltChoiceDataSet.Quest)
                {
                    if (row.HasErrors)
                    {
                        errorStringQ += row.RowError + Environment.NewLine;
                    }
                }
                MessageBox.Show("the following errors occured in Question"
                + Environment.NewLine + errorStringQ, "Question", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
            }
            if (mltChoiceDataSet.Answ.HasErrors)
            {
                foreach (DataRow row in mltChoiceDataSet.Answ)
                {
                    if (row.HasErrors)
                    {
                        errorStringA += row.RowError + Environment.NewLine;
                    }
                }
                err = true;
                MessageBox.Show("the following errors occured in Answer"
                + Environment.NewLine + errorStringA, "Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (err==true)
            {
                return true;
            }
            return false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
           // richTextBox1.Text = "";
        }

        private void dataGridView1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(dataGridView1.Rows[0].Cells[0].Value as string)
                && string.IsNullOrWhiteSpace(dataGridView1.Rows[1].Cells[0].Value as string))
            {
                MessageBox.Show("There are no answers.You must type at least two answers","Error"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                errorProvider.SetError(this.dataGridView1,"Please type at least one answer");
                e.Cancel = true;//den ton afhnoume na fugei apo to text box mexri na grapsei mia toulaxiston apanthsh
            }
            return;
        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("There is no question.You must type a question ", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(this.richTextBox1, "Please type a question");
                e.Cancel = true;//den ton afhnoume na fugei apo to text box mexri na grapsei mia erwthsh
            }
            return;
        }
    }
}
