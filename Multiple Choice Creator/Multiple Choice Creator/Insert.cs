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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Question questIns=new Model.Question(richTextBox1.Text, dif, user.getUserID());
            QuestionAnswer qaInserted = new QuestionAnswer(questIns);
            AnswDataTable inseAnsw = mang.inserQ(questIns,dataGridView1,user);
            qaInserted.setAnswersDataTable(inseAnsw);
            bool ins=saveChanges();
            if (ins==true) {
                currFeed.add(qaInserted);
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value==0)
            {
                diffLabel.Text = "Easy";
                dif = "E";
            }
            else if (trackBar1.Value == 1)
            {
                diffLabel.Text = "Medium";
                dif = "M";
            }
            else 
            {
                diffLabel.Text = "Hard";
                dif = "H";
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
            richTextBox1.Text = "";
        }

    }
}
