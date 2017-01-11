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
        List<QuestionPreview> myQPList;
        FeedPanel fdPanel;
        public QuePreview(FlowLayoutPanel myPanel,Question qe,List<Answer> corr,List<Answer> wrong, object myQPList, FeedPanel feedPanel)
        {
            this.correct = corr;
            this.wrongs = wrong;
            this.myQuestion = qe;
            this.panel = myPanel;
            this.fdPanel = feedPanel;
            this.myQPList = (List<QuestionPreview>)myQPList;
            myQuePrev = new QuestionPreview(myQuestion, correct, wrongs,panel, this.myQPList, fdPanel);
            this.panel.Controls.Add(myQuePrev);
            numberOfQuestions++;
        }

        public QuestionPreview getMyQuePrev()
        {
            return myQuePrev;
        }



    }
}
