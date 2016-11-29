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

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        public FeedPanel()
        {
            InitializeComponent();
            this.Show();
        }

        public void fill(int id)
        {
            Question q = new Question(id);
            Question.Text = "Question: " + q.getQuestion();
             
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show();
        }
    }
}
