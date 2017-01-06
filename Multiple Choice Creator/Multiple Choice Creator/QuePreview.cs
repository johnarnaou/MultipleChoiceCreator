using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;

namespace Multiple_Choice_Creator
{
    class QuePreview
    {
        public int ID { get; set; }
        FlowLayoutPanel panel;
        QuestionPreview myQuePrev;
        Question myQuestion;
        List<Answer> correct;
        List<Answer> wrongs;
        int numberOfQuestions=0;
        public QuePreview(FlowLayoutPanel myPanel,Question qe,List<Answer> corr,List<Answer> wrong)
        {
            this.correct = corr;
            this.wrongs = wrong;
            this.myQuestion = qe;
            this.panel = myPanel;
            myQuePrev = new QuestionPreview(myQuestion, correct, wrongs,panel);
            this.panel.Controls.Add(myQuePrev);
            numberOfQuestions++;
        }

        public QuestionPreview getMyQuePrev()
        {
            return myQuePrev;
        }



    }
}
