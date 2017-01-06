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
    public partial class QuestionPreview : UserControl
    {

        Question myQ;
        List<Answer> myLCorr;
        List<Answer> myLWro;
        FlowLayoutPanel father;
        public QuestionPreview(Question myQuestion,List<Answer> correct, List<Answer> wrong,FlowLayoutPanel theFather)
        {
            InitializeComponent();
            father = theFather;
            this.Width = father.Width;
            myQ = myQuestion;
            myLCorr = correct;
            myLWro = wrong;
            questLabel.Text = myQ.getText();
            Correct.Text = correct.Count().ToString()+": ";
            foreach (Answer apant in correct)
            {
                
                Correct.Text = Correct.Text + " , " + apant.ToString();
            }
            xMore.Text = wrong.Count().ToString() + " wrong answ";
            Update();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            father.Controls.Remove(this);

        }
    }
}
